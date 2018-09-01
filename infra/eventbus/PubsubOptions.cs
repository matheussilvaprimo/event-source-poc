
using Google.Cloud.PubSub.V1;

namespace EventBus
{
    /// <summary>
    /// Configuração do Pubsub para publicação de mensagens.
    /// </summary>
    public class PubsubOptions
    {
        /// <summary>
        /// Id do projeto no google cloud.
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// Configuração de timeout de request do pubsub em segundos.
        /// </summary>
        public int ProcessTimeout { get; set; }

        /// <summary>
        /// Configuração de controle de threads.
        /// </summary>
        public int MaxOutstandingElementCount { get; set; }

        /// <summary>
        /// Configuração de controle de byte de threads.
        /// </summary>
        public int MaxOutstandingByteCount { get; set; }

        /// <summary>
        /// Client do pubsub do Google.
        /// </summary>
        public PublisherServiceApiClient ServiceApiClient { get; set; }

    }
}
