using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Queries.GetOrderTotal
{
    public class OrderTotalHandler : IAsyncRequestHandler<OrderTotalQuery, OrderTotalModel>
    {
        private readonly IMediator _mediator;

        public OrderTotalHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        Task<OrderTotalModel> IAsyncRequestHandler<OrderTotalQuery, OrderTotalModel>.Handle(OrderTotalQuery message)
        {
            throw new NotImplementedException();
        }
    }
}
