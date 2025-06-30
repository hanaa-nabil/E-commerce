using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; } = true;

        protected Product() { } 
        public Product(string name, string description, decimal price, int stock)
        {
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetStock(stock);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty");

            Name = name;
            SetUpdatedAt();
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be negative");

            Price = price;
            SetUpdatedAt();
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentException("Stock cannot be negative");

            Stock = stock;
            SetUpdatedAt();
        }

        public void SetDescription(string description)
        {
            Description = description ?? string.Empty;
            SetUpdatedAt();
        }

        public void Deactivate()
        {
            IsActive = false;
            SetUpdatedAt();
        }

        public void Activate()
        {
            IsActive = true;
            SetUpdatedAt();
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive");

            if (Stock < quantity)
                throw new InvalidOperationException("Insufficient stock");

            Stock -= quantity;
            SetUpdatedAt();
        }
    }
}
