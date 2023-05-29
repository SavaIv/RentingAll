namespace RentingAll.Areas.Cars.Data
{
    public class CarsDataConstants
    {
        public class Car
        {
            public const int CarBrandMinLength = 2;
            public const int CarBrandMaxLength = 20;

            public const int CarModelMinLength = 2;
            public const int CarModelMaxLength = 20;

            public const int CarDescriptionMinlenght = 3;
            public const int CarDescriptionMaxlenght = 160;

            public const int CarYearMinValue = 2000;
            public const int CarYearMaxValue = 2100;
        }

        public class Category
        {
            public const int CategoryNameMaxlength = 25;
        }

        public class Dealer
        {
            public const int DealerNameMaxlength = 25;
            public const int DealerPhoneNumberMaxLength = 30;
        }


    }
}
