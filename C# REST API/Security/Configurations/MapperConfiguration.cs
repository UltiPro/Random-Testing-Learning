using AutoMapper;
using CountryNamespace;
using entityf.Data;
using entityf.Data.Users;
using entityf.Models.Country;
using entityf.Models.Hotels;
using HotelNamespace;

namespace entityf.Configurations
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Country, CreateCountry>().ReverseMap();
            CreateMap<Country, GetCountry>().ReverseMap();
            CreateMap<Country, GetCountryDetails>().ReverseMap();
            CreateMap<Country, UpdateCountry>().ReverseMap();
            CreateMap<Hotel, GetHotel>().ReverseMap();

            CreateMap<ApiUserReg, APIUser>().ReverseMap();
        }
    }
}
