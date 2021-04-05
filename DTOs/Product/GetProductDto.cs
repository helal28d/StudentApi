using Test.DTOs.Customer;
using Test.DTOs.Gategory;

namespace Test.DTOs.Product
{
    public class GetProductDto
    {
        public int Id { get; set; }
       public string Name { get; set; }
        public int Price { get; set; }
        public int Qantity { get; set; }

        public GetCustomerDto customer { get; set; }
        public GetGategoryDto Gategory  { get; set; }

    }
}