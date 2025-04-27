using System.ComponentModel.DataAnnotations;
using CQRS.Models;
using MediatR;

namespace CQRS.Command
{
    public class DeleteProductCommand : IRequest<Product>
    {
        [Required(ErrorMessage ="Id Obrigatorio")]
        public int ID { get; set; }
    }
}
