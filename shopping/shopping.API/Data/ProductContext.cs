using MongoDB.Driver;
using shopping.API.Models;


namespace shopping.API.Data
{
    public  class ProductContext
    {

        public IMongoCollection<product> Products { get; }
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<product>(configuration["DatabaseSettings:CollectionName"]);

            SeedData(Products);
        }

        private static void SeedData(IMongoCollection<product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<product> GetPreconfiguredProducts()
        {
            return new List<product>()
            {
                new product()
            {
                Name = "IPhone X",
                Description  = "This phone is the company's biggest change",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = "Smart phone"

            },
             new product()
            {
                Name = "Samsung 10",
                Description  = "This phone is the company's biggest change",
                ImageFile = "product-2.png",
                Price = 840.00M,
                Category = "Smart phone"

            }
            };
        }

    }
}