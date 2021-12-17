using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;
using Microservices.Ecommerce.DTO.Commands;

namespace Clod.Orchestrator.Consumers
{
    public class G2DeleteOrderConsumer : IConsumer<DeletedOrderEvent>
{
        public async Task Consume(ConsumeContext<DeletedOrderEvent> context)
        {
            await context.Publish(new DeleteOrderCommand
            {

                Id = context.Message.Id

        });
        }
    }
}
