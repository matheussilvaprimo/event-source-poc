using Google.Api.Gax.ResourceNames;
using Google.Cloud.PubSub.V1;
using Grpc.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{

    public class PubsubPublisher : IPublisher
    {
        private PubsubOptions _options;
        private PublisherServiceApiClient _serviceApiClient;
        private SubscriberServiceApiClient _subscriberService;
        private Dictionary<string, PublisherClient> _publishers;
        private bool _disposed = false;
        private object _lock = new object();
        private TopicName _topic;
        private string _topicName;


        public PubsubPublisher(PubsubOptions options)
        {
            _options = options;
            _serviceApiClient = options.ServiceApiClient;
            _publishers = new Dictionary<string, PublisherClient>();

            LoadTopics();
        }

        private void LoadTopics()
        {
            var topics = _serviceApiClient.ListTopics(new ProjectName(_options.ProjectId));

            foreach (var t in topics)
            {
                _publishers.Add(t.TopicName.TopicId, null);
            }
        }

        public bool IsActive()
        {
            try
            {
                _serviceApiClient.ListTopics(new ProjectName(_options.ProjectId));
            }
            catch (Exception)
            {
                return false;
            }

            return !_disposed;
        }

        public async Task PublishAsync<T>(T message, string topic = null) where T : Message
        {
            if (message == null)
            {
                throw new ArgumentNullException("message", "Cannot publish null message.");
            }

            _topicName = message.GetType().Name;


            CheckTopic();

            var json = JsonConvert.SerializeObject(message);

            await _publishers[_topicName].PublishAsync(json);

        }

        private void CheckTopic()
        {
            if (_publishers.ContainsKey(_topicName))
            {
                _publishers.TryGetValue(_topicName, out PublisherClient client);

                if (client == null)
                {
                    client = PublisherClient.Create(new TopicName(_options.ProjectId, _topicName), new[] { _serviceApiClient });

                    _publishers.Remove(_topicName);
                    _publishers.Add(_topicName, client);
                }
            }
            else
            {
                _topic = new TopicName(_options.ProjectId, _topicName);

                try
                {
                    _serviceApiClient.CreateTopic(_topic);
                    CheckSubscription();
                }
                catch (RpcException e)
                when (e.Status.StatusCode == StatusCode.AlreadyExists)
                {
                    //topico já existe
                }

                var client = PublisherClient.Create(new TopicName(_options.ProjectId, _topicName), new[] { _serviceApiClient });

                _publishers.Add(_topicName, client);
            }
        }

        private void CheckSubscription()
        {
            SubscriptionName subscriptionName = new SubscriptionName(_options.ProjectId, _topicName);

            _subscriberService = SubscriberServiceApiClient.Create();

            try
            {
                Subscription subscription = _subscriberService.CreateSubscription(subscriptionName, _topic, null, _options.ProcessTimeout);
            }
            catch (RpcException e)
            when (e.Status.StatusCode == StatusCode.AlreadyExists)
            {
                // Subscription já existe.
            }
        }
    }

}
