namespace Test.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public  string Phone { get; set; }
        
        //1-1 relation for this example 1 product for 1 customer
        public Product Product { get; set; }
    }
}