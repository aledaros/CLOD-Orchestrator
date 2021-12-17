using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Clod.Orchestrator.Consumers.Product
{
    public class UpdateProductEventConsumer : IConsumer<UpdateProductEvent>
    {
        public Task Consume(ConsumeContext<UpdateProductEvent> context)
        {
            var product = context.Message;
            throw new NotImplementedException();
        }
    }
}
