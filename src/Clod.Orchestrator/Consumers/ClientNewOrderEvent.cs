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
    public class ClientNewOrderEvent : IConsumer<NewOrderEvent>
    {
        public Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            //get order
            var order = context.Message;

            //convert event to command
            var client = new ClientNewOrder
            {
                Id = order.Id,
                IdCliente = order.IdCliente,
                TotalPrice = order.TotalPrice
            };

            //publish
            context.Publish(client);
            return Task.CompletedTask;
        }
    }
}
