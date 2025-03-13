using HoQuocCuong_2280605191.Models;

namespace HoQuocCuong_2280605191.Repositories

{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public MockProductRepository()
        {
            // Tạo một số dữ liệu mẫu 
            _products = new List<Product>
            {
                new Product { 
                    Id = 1, 
                    Name = "Laptop Gaming Acer Nitro 5", 
                    Price = 22990, 
                    Description = "CPU Intel Core i5-12500H, RAM 8GB, SSD 512GB, RTX 3050 4GB",
                    CategoryId = 1,
                    ImageUrl = "/image/products/Acer Nitro 5.jpg"
                },
                new Product {
                    Id = 2,
                    Name = "PC Gaming MSI",
                    Price = 25490,
                    Description = "CPU i5-13400F, RAM 16GB, SSD 500GB, RTX 4060 8GB",
                    CategoryId = 2,
                    ImageUrl = "/image/products/PC Gaming MSI.jpg"
                },
                new Product {
                    Id = 3,
                    Name = "Laptop Dell Inspiron 15",
                    Price = 15990,
                    Description = "CPU Intel Core i5-1135G7, RAM 8GB, SSD 512GB, Intel Iris Xe Graphics",
                    CategoryId = 1,
                    ImageUrl = "/image/products/Dell Inspiron 15.jpg"
                },
                new Product {
                    Id = 4,
                    Name = "PC Văn Phòng HP",
                    Price = 12490,
                    Description = "CPU i3-12100, RAM 8GB, SSD 256GB, Intel UHD Graphics 730",
                    CategoryId = 2,
                    ImageUrl = "/image/products/PC Văn Phòng HP.jpg"
                },
                new Product {
                    Id = 5,
                    Name = "Laptop MacBook Air M1",
                    Price = 18990,
                    Description = "CPU Apple M1, RAM 8GB, SSD 256GB, 7-Core GPU",
                    CategoryId = 1,
                    ImageUrl = "/image/products/MacBook Air M1.jpg"
                },
                new Product {
                    Id = 6,
                    Name = "PC Gaming ASUS ROG",
                    Price = 35990,
                    Description = "CPU i7-13700K, RAM 32GB, SSD 1TB, RTX 4070 12GB",
                    CategoryId = 2,
                    ImageUrl = "/image/products/PC Gaming ASUS ROG.jpg"
                },
                new Product {
                    Id = 7,
                    Name = "Laptop ThinkPad X1 Carbon",
                    Price = 32990,
                    Description = "CPU Intel Core i7-1260P, RAM 16GB, SSD 1TB, Intel Iris Xe Graphics",
                    CategoryId = 1,
                    ImageUrl = "/image/products/ThinkPad X1 Carbon.jpg"
                },
                new Product {
                    Id = 8,
                    Name = "PC Workstation Dell",
                    Price = 45990,
                    Description = "CPU i9-13900K, RAM 64GB, SSD 2TB, RTX 4080 16GB",
                    CategoryId = 2,
                    ImageUrl = "/image/products/Workstation Dell.jpg"
                },
                new Product {
                    Id = 9,
                    Name = "Laptop Gaming ROG Strix G15",
                    Price = 28990,
                    Description = "CPU AMD Ryzen 7 6800H, RAM 16GB, SSD 1TB, RTX 3060 6GB",
                    CategoryId = 1,
                    ImageUrl = "/image/products/ROG Strix G15.jpg"
                },
                new Product {
                    Id = 10,
                    Name = "PC Mini Mac Studio",
                    Price = 52990,
                    Description = "CPU Apple M1 Max, RAM 32GB, SSD 1TB",
                    CategoryId = 2,
                    ImageUrl = "/image/products/Mini Mac Studio.jpg"
                }
            };
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }
        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
