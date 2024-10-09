using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand cCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingId = cCommand.OrderingId,
                ProductAmount = cCommand.ProductAmount,
                ProductId = cCommand.ProductId,
                ProductName = cCommand.ProductName,
                ProductPrice = cCommand.ProductPrice,
                ProductTotalPrice = cCommand.ProductTotalPrice
            });




        }
    }
}
