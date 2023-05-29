using System.ComponentModel.DataAnnotations;
using static RentingAll.Areas.Cars.Data.CarsDataConstants.Category;

namespace RentingAll.Areas.Cars.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxlength)]
        public string Name { get; set; }

        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}
