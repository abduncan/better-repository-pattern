using MediatR;

namespace Company.Domain.Queries.GetOrderTotal
{
    public class OrderTotalQuery : IAsyncRequest<OrderTotalModel>
    {
    }
}
