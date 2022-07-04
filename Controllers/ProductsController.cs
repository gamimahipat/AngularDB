﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularFD.Models;

namespace AngularDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts( int? categoryId )
        {
            if (categoryId == 0 || categoryId ==null)
            {

                var products = (from a in _context.Products
                                join b in _context.Categories on a.CategoryID equals b.CategoryID
                                select new Product
                                {
                                    ProductID = a.ProductID,
                                    ProductName = a.ProductName,
                                    ProductPrice = a.ProductPrice,
                                    ProductDetails = a.ProductDetails,
                                    ProductImage = a.ProductImage,
                                    CategoryID = b.CategoryID,
                                    Category = b.CategoryName

                                }).ToListAsync();

                return await products;
            }
            else
            {
                var products = (from a in _context.Products
                                join b in _context.Categories on a.CategoryID equals b.CategoryID
                                where a.CategoryID == categoryId
                                select new Product
                                {
                                    ProductID = a.ProductID,
                                    ProductName = a.ProductName,
                                    ProductPrice = a.ProductPrice,
                                    ProductDetails = a.ProductDetails,
                                    ProductImage = a.ProductImage,
                                    CategoryID = b.CategoryID,
                                    Category = b.CategoryName

                                }).ToListAsync();

                return await products;
            }


        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            //var product = await _context.Products.FindAsync(id);

            var product = (from a in _context.Products
                            join b in _context.Categories on a.CategoryID equals b.CategoryID
                            where a.ProductID == id
                           select new Product
                            {
                                ProductID = a.ProductID,
                                ProductName = a.ProductName,
                                ProductPrice = a.ProductPrice,
                                ProductDetails = a.ProductDetails,
                                ProductImage = a.ProductImage,
                                CategoryID = b.CategoryID,
                                Category = b.CategoryName

                            }).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return await product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'StoreContext.Products'  is null.");
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
