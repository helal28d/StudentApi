namespace Test.DTOs.Product
{
    public class AddProductDto
    {
           public string Name { get; set; }
        public int Price { get; set; }
        public int Qantity { get; set; }

         public  int GategoryId { get; set; }

         public int CustomerId { get; set; }
    }
}