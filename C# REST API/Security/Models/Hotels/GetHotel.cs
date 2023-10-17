using System.ComponentModel.DataAnnotations.Schema;

namespace entityf.Models.Hotels
{
    public class GetHotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
    }
}
