using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Clod.Orchestrator.Consumers.Product
{
    public class DeleteProductEventConsumer : IConsumer<DeleteProductEvent>
    {
        public Task Consume(ConsumeContext<DeleteProductEvent> context)
        {
            var product = context.Message;
            throw new NotImplementedException();
        }
    }
}
