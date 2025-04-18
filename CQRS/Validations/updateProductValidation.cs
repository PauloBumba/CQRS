using CQRS.Command;
using FluentValidation;

namespace CQRS.Validations
{
    public class updateProductValidation : AbstractValidator <UpdateProoductCommand>
    {
        public updateProductValidation() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price é obrigatório");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");
        }
    }
}
