using AutoMapper;
using ReviewsAPI.Dto;
using ReviewsAPI.Models;

namespace ReviewsAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Drink, DrinkDto>();
            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Review, Review>();
        }

    }
}
