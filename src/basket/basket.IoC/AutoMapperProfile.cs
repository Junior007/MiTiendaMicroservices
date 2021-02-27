using AutoMapper;

namespace basket.IoC
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            // OUT
            /*CreateMap<User, UserForDetailed>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculatedAge()));

            CreateMap<User, UserForList>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculatedAge()));

            CreateMap<Photo, PhotoForDetailed>();
            CreateMap<Photo, PhotoForReturn>();*/

            //OUT
            CreateMap<basket.domain.models.BasketCart,     basket.application.models.BasketCart>();
            CreateMap<basket.domain.models.BasketCartItem, basket.application.models.BasketCartItem>();
            CreateMap<basket.domain.models.BasketCheckout, basket.application.models.BasketCartCheckout>();

            // IN
            CreateMap<basket.application.models.BasketCart, basket.domain.models.BasketCart>();
            CreateMap<basket.application.models.BasketCartItem, basket.domain.models.BasketCartItem>();
            CreateMap<basket.application.models.BasketCartCheckout, application.models.BasketCartCheckout>();


            //Event Bus
            CreateMap<infra.eventbus.events.BasketCartCheckoutEvent, basket.application.models.BasketCartCheckout>().ReverseMap(); ;


        }
    }
}
