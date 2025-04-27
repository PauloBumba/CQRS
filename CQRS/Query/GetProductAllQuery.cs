using CQRS.Models;
using MediatR;

namespace CQRS.Query
{
    public class GetProductAllQuery : IRequest<List<Product>>
    {
    }
}
