using Google.Api.Gax.ResourceNames;
using Google.Cloud.PubSub.V1;
using Grpc.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventBus
{

    public class PubsubSubscriber<T> : ISubscriber<T> where T : Message
    {
        private CancellationTokenSource _cancellationTokenSource;
        private readonly PubsubOptions _options;
        private PublisherServiceApiClient _serviceApiClient;
        private SubscriberServiceApiClient _subscriberService;
        private SubscriberClient _subscriber;
        private readonly string _topic;
        private readonly string _subscriptionId;
        private bool _running;


        public PubsubSubscriber(PubsubOptions options, string topic)
        {
            _running = false;

            _topic = topic;
            _subscriptionId = _topic;
            _options = options;

            _subscriberService = SubscriberServiceApiClient.Create();
            _serviceApiClient = PublisherServiceApiClient.Create();

            var subscriptionName = new SubscriptionName(options.ProjectId, _subscriptionId);

            _subscriber = SubscriberClient.Create(subscriptionName, new[] { _subscriberService },
                new SubscriberClient.Settings()
                {
                    FlowControlSettings = new Google.Api.Gax
                        .FlowControlSettings(
                        maxOutstandingElementCount: _options.MaxOutstandingElementCount,
                        maxOutstandingByteCount: _options.MaxOutstandingByteCount)
                });
        }

        public bool IsRunning()
        {
            try
            {
                _serviceApiClient.ListTopics(new ProjectName(_options.ProjectId));
            }
            catch (Exception)
            {
                return false;
            }

            return _running;
        }

        private void CheckSubscription()
        {
            TopicName topicName = new TopicName(_options.ProjectId, _topic);
            SubscriptionName subscriptionName = new SubscriptionName(_options.ProjectId, _subscriptionId);

            try
            {
                Subscription subscription = _subscriberService.CreateSubscription(
                    subscriptionName, topicName, pushConfig: null,
                    ackDeadlineSeconds: _options.ProcessTimeout);

                Console.WriteLine("a");
            }
            catch (RpcException e)
            when (e.Status.StatusCode == StatusCode.AlreadyExists)
            {
                // Subscription já existe.
            }
        }

        private void CheckTopic(string topicId)
        {
            TopicName topicName = new TopicName(_options.ProjectId, topicId);
            try
            {
                _serviceApiClient.CreateTopic(topicName);
            }
            catch (RpcException e)
            when (e.Status.StatusCode == StatusCode.AlreadyExists)
            {
                //topico já existe
            }
        }

        private async Task ConsumeStream(Func<T, bool> factory)
        {
            await _subscriber.StartAsync((msg, cancellationToken) =>
            {
                var msgString = Encoding.UTF8.GetString(msg.Data.ToArray());

                var msgObj = default(T);
                msgObj = JsonConvert.DeserializeObject<T>(msgString);

                var ok = factory(msgObj);

                return Task.FromResult(ok ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);
            });
        }

        public void StartConsume(Func<T, bool> factory)
        {
            CheckSubscription();

            _cancellationTokenSource = new CancellationTokenSource();
            new Task(() => ConsumeStream(factory).Wait(), _cancellationTokenSource.Token, TaskCreationOptions.LongRunning).Start();

            _running = true;
        }

        public void StopConsume()
        {
            if (IsRunning())
            {
                Dispose();
            }
        }

        private void Dispose()
        {
            _subscriber.StopAsync(CancellationToken.None).Wait();
            _cancellationTokenSource.Cancel();
            _running = false;
        }
    }
}

