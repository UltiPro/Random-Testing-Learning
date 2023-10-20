using System.ComponentModel.DataAnnotations;

namespace entityf.Models.Country
{
    public class CreateCountry
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
