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
    public class ClientUpdateOrderEvent : IConsumer<UpdatedOrderEvent>
    {
        readonly private IBus _rabbit;
        public ClientUpdateOrderEvent(IBus rabbit)
        {
            _rabbit = rabbit;
        }
        public Task Consume(ConsumeContext<UpdatedOrderEvent> context)
        {
            //get order
            var order = context.Message;

            //convert event to command
            var client = new ClientUpdateOrder
            {
                Id = order.Id,
                IdCliente = order.IdCliente,
                TotalPrice = order.TotalPrice
            };

            //publish
            _rabbit.Publish(client);

            return Task.CompletedTask;
        }
    }
}
