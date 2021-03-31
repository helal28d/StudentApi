namespace Test.Models
{
    public class Product
    {
        //منتج خاص لكل زبون حسب طلب الزبون
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Qantity { get; set; }

        //1 to m     1 gategry m products
        public  int GategoryId { get; set; }
        public Gategory Gategory { get; set; }

        //1 to 1 with Customer the product doesnt exist without the customer(منتج  حسب طلب الزبون مثلا)
        // the foreign key for the 1-1 relation = classNmae+Id
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
    }
}