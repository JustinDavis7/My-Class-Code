using System;

namespace ProductInventory.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString() => $"{Id};{Name};{Price}";
        public override bool Equals(object obj)
        {
            if (obj is not Product product) return false;

            return Id == product.Id;
        }

        public override int GetHashCode() => Id;
    }
}
