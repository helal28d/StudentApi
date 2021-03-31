using System.Collections.Generic;

namespace Test.Models
{
    public class Gategory
    {
       public int Id { get; set; }
       public string Name { get; set; }
       //1-m    many products
       public  List<Product> Products { get; set; }
    }
}