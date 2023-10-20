using HotelNamespace;
using entityf.Models.Hotels;

namespace entityf.Models.Country
{
    public class GetCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }

    public class GetCountryDetails : GetCountry
    {
        public List<GetHotel> Hotels { get; set; }
    }
}
