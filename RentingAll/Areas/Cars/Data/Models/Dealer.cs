using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static RentingAll.Areas.Cars.Data.CarsDataConstants.Dealer;

namespace RentingAll.Areas.Cars.Data.Models
{
    public class Dealer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DealerNameMaxlength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DealerPhoneNumberMaxLength)]
        public string PhomeNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        //public IdentityUser User { get; set; }     // <-- entityFramework works fine withot this property. Espesiaolly
        // Especially when we try to make add-mnigration –
        // we will reseive a little coffusing info that this relationhip is allredary  exist.
        // That’s why –better not use this property
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}


