using Azure.Core;
using CQRS.Models;
using MediatR;
using Microsoft.Identity.Client;

namespace CQRS.Command
{
    public class UpdateProoductCommand: IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string .Empty;

        public string Price { get; set; }= string.Empty;
    }
}
