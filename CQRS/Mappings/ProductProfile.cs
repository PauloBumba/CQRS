using AutoMapper;
using CQRS.Command;
using CQRS.Models;

namespace CQRS.Mappings
{
    public class ProductProfile :Profile
    {
        public ProductProfile() 
        { 
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProoductCommand, Product>();
            CreateMap<DeleteProductCommand, Product>();
        }
    }
}
