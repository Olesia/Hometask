using Azure.Messaging.ServiceBus;
using Hometask.BLL.Dto;
using Hometask.Common.Interfaces;
using Newtonsoft.Json;

namespace Hometask.WebApi
{
    /// <summary>
    /// Listener of Azure Service Bus Message Publisher
    /// </summary>
    public class MessageListener
    {
        private const string TopicName = "carttopic";
        private const string SubscriptionName = "S1";
        private const string ConnectionName = "AzureConnection";

        private readonly ICartService _cartService;
        private readonly ServiceBusClient _client;
        private readonly ServiceBusProcessor _processor;

        /// <summary>
        /// Constructor of the listener class
        /// </summary>
        /// <param name="cartService"> The cart service </param>
        /// <param name="configuration"> The configuration </param>
        public MessageListener(ICartService cartService, IConfiguration configuration)
        {
            _cartService = cartService;
            _client = new ServiceBusClient(configuration.GetConnectionString(ConnectionName));

            _processor = _client.CreateProcessor(TopicName, SubscriptionName, new ServiceBusProcessorOptions());
        }

        /// <summary>
        /// Start listening process
        /// </summary>
        /// <returns> Task </returns>
        public async Task StartListening()
        {
            _processor.ProcessMessageAsync += MessageHandler;
            _processor.ProcessErrorAsync += ErrorHandler;

            await _processor.StartProcessingAsync();
        }

        /// <summary>
        /// Handle received messages
        /// </summary>
        /// <param name="args"></param>
        /// <returns> Completed task </returns>
        public async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();

            if (string.IsNullOrEmpty(body))
            {
                await args.DeadLetterMessageAsync(args.Message);
            };

            var item = JsonConvert.DeserializeObject<ItemDto>(body);
            if (item == null) return;

            var result = _cartService.UpdateCartItems(item);
            if (result)
            {
                await args.CompleteMessageAsync(args.Message);
            }
            else
            {
                await args.DeferMessageAsync(args.Message);
            }
        }

        /// <summary>
        /// Handle any errors when receiving messages
        /// </summary>
        /// <param name="args"></param>
        /// <returns> Completed task </returns>
        public Task ErrorHandler(ProcessErrorEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
