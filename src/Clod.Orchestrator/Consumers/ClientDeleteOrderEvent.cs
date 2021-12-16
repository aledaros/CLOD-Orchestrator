using Gruppo3.ClientiDTO.Domain.Commands;
using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clod.Orchestrator.Consumers
{
    public class ClientDeleteOrderEvent : IConsumer<DeletedOrderEvent>
    {
        readonly private IBus _rabbit;
        public ClientDeleteOrderEvent(IBus rabbit)
        {
            _rabbit = rabbit;
        }
        public Task Consume(ConsumeContext<DeletedOrderEvent> context)
        {
            //get order
            var order = context.Message;

            //convert event to command
            var client = new ClientDeleteOrder
            {
                Id = order.Id
            };

            //publish
            _rabbit.Publish(client);

            return Task.CompletedTask;
        }
    }
}
