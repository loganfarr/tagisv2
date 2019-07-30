using AutoMapper;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderResource>();
//            CreateMap<Product, ProductResource>();
        }
    }
}