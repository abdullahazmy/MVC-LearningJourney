namespace Demo1.Models.Products
{
    public class ProductSample
    {
        List<Product> products;
        public ProductSample()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 999.99m, Category = "Electronics", ImageUrl = "laptop.jpg" },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, Category = "Electronics", ImageUrl = "smartphone.jpg" },
                new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199.99m, Category = "Accessories", ImageUrl = "headphone.jpg" },
                new Product { Id = 4, Name = "Smartwatch", Description = "Feature-rich smartwatch", Price = 249.99m, Category = "Wearables", ImageUrl = "smartwatch.jpg" },
                new Product { Id = 5, Name = "Tablet", Description = "Portable tablet with stylus", Price = 499.99m, Category = "Electronics", ImageUrl = "tablet.jpg" },
            };
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

    }
}
