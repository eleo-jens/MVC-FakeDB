using System.Collections.Generic;

namespace Exercice4.Models.ViewModel
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; }

        public ProductIndexViewModel(IEnumerable<Product> products)
        {
            Products = new List<Product>();
            foreach (Product product in products)
            {
                Products.Add(product);
            }
        }
    }
}
