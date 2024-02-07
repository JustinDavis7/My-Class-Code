using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using ProductInventory.Model;

namespace ProductInventory.DataAccess
{
    public class ProductRepositoryMock : IProductRepository
    {
        private readonly Mock<IProductRepository> _repository = new();
        private readonly IList<Product> _products = new List<Product>();

        public ProductRepositoryMock()
        {
            _products.Add(new Product() {Id = 1, Name = "Dawn Dish Soap", Price = 3.49m});
            _products.Add(new Product() { Id = 2, Name = "Totino's Pizza Rolls", Price = 4.39m });
            _products.Add(new Product() { Id = 3, Name = "Purina Dog Chow", Price = 19.99m });
            _products.Add(new Product() { Id = 4, Name = "Meow Mix Cat Food", Price = 9.99m });
            _products.Add(new Product() { Id = 5, Name = "Jiffy Peanut Butter", Price = 3.29m });

            _repository.Setup(repo => repo.FindAll()).Returns((IList<Product>) _products);
            _repository.Setup(repo => repo.FindByName(It.IsAny<string>())).Returns((string name) =>
            {
                return _products.SingleOrDefault(product => product.Name.Equals(name));
            });
            _repository.Setup(repo => repo.FindById(It.IsAny<int>())).Returns((int id) =>
            {
                return _products.SingleOrDefault(product => product.Id.Equals(id));
            });
            _repository.Setup(repo => repo.Save(It.IsAny<Product>())).Callback((Product product) =>
            {
                var productToUpdate = _products.SingleOrDefault(pro => pro.Id.Equals(product.Id));
                if (productToUpdate == null) return;

                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
            });
        }

        public IList<Product> FindAll()
        {
            return _repository.Object.FindAll();
        }

        public Product FindByName(string productName)
        {
            return _repository.Object.FindByName(productName);
        }

        public Product FindById(int productId)
        {
            return _repository.Object.FindById(productId);
        }

        public bool Save(Product target)
        {
            return _repository.Object.Save(target);
        }
    }
}
