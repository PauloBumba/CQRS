using CQRS.Command;
using FluentValidation;

namespace CQRS.Validations
{
    public class CreateProductValidation :AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidation() 
        {
         
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome do produto obrigatorio");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Preço do produto obrigatorio");
            
        }
    
    }
}
