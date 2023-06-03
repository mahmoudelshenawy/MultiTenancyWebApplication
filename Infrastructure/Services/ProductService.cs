using Application.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _context;
        public ProductService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(string name, string description, decimal price)
        {
            var product = new Product();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
