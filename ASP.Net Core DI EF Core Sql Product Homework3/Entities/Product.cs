using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ("Name is Required"))]

        [MinLength(3,ErrorMessage = "Minimum name should be 3")]
        public string Name { get; set; }

        [Required(ErrorMessage =("Description Is Required"))]

        [MinLength(5, ErrorMessage = "Minimum description should be 5")]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Value must be at least 1.")]
        public int Discount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Value must be at least 1.")]
        public int Price { get; set; }
        public string ImageLink { get; set; }

        public Product() 
        {
        
        }
        public Product(int ıd, string name, string description, int discount, int price, string ımageLink)
        {
            Id = ıd;
            Name = name;
            Description = description;
            Discount = discount;
            Price = price;
            ImageLink = ımageLink;
        }
    }
}
