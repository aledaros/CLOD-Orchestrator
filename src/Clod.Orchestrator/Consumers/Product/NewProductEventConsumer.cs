using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Clod.Orchestrator.Consumers.Product
{
    public class NewProductEventConsumer : IConsumer<NewProductEvent>
    {
        public Task Consume(ConsumeContext<NewProductEvent> context)
        {
            var product = context.Message;
            throw new NotImplementedException();
        }
    }
}
