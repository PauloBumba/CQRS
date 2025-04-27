using System.ComponentModel.DataAnnotations;
using CQRS.Models;
using MediatR;

namespace CQRS.Query
{
    public class GetProdutoByIdQuery : IRequest<Product>
    {
        [Required(ErrorMessage ="Id obrigatorio ")]
        public int Id { get; set; }
    }
}
