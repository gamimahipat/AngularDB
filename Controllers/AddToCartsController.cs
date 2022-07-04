using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularFD.Models;
using AngularDB.ViewModels;

namespace AngularDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddToCartsController : ControllerBase
    {
        private readonly StoreContext _context;

        public AddToCartsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/AddToCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddToCartViewModel>>> GetAddToCarts()
        {
            if (_context.AddToCarts == null)
            {
                return NotFound();
            }
           
           var addToCart = from a in _context.AddToCarts
                        join b in _context.Products on a.ProductID equals b.ProductID
                        join c in _context.Users on a.UserID equals c.UserID

                        select new AddToCartViewModel
                        {
                            AddToCartID = a.AddToCartID,
                            UserID = a.UserID,
                            User = c.FirstName + ' ' + c.LastName,
                            ProductID = a.ProductID,
                            Quantity = a.Quantity,
                            Image = b.ProductImage,
                            Product = b.ProductName,
                            Price = b.ProductPrice

                        };
            return await addToCart.ToListAsync();

        }

        // GET: api/AddToCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddToCart>> GetAddToCart(int id)
        {
            if (_context.AddToCarts == null)
            {
                return NotFound();
            }
            var addToCart = await _context.AddToCarts.FindAsync(id);

            if (addToCart == null)
            {
                return NotFound();
            }

            return addToCart;
        }

        // PUT: api/AddToCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddToCart(int id, AddToCart addToCart)
        {
            if (id != addToCart.AddToCartID)
            {
                return BadRequest();
            }

            _context.Entry(addToCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddToCartExists(id))
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

        // POST: api/AddToCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddToCart>> PostAddToCart(AddToCart addToCart)
        {
            if (_context.AddToCarts == null)
            {
                return Problem("Entity set 'StoreContext.AddToCarts'  is null.");
            }
            _context.AddToCarts.Add(addToCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddToCart", new { id = addToCart.AddToCartID }, addToCart);
        }

        // DELETE: api/AddToCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddToCart(int id)
        {
            if (_context.AddToCarts == null)
            {
                return NotFound();
            }
            var addToCart = await _context.AddToCarts.FindAsync(id);
            if (addToCart == null)
            {
                return NotFound();
            }

            _context.AddToCarts.Remove(addToCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddToCartExists(int id)
        {
            return (_context.AddToCarts?.Any(e => e.AddToCartID == id)).GetValueOrDefault();
        }
    }
}
