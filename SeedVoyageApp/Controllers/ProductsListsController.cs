using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeedVoyageApp.Models;

namespace SeedVoyageApp.Controllers
{
    public class ProductsListsController : Controller
    {
        private readonly SeedVoyageContext _context;

        public ProductsListsController(SeedVoyageContext context)
        {
            _context = context;
        }

        // GET: ProductsLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductsList.ToListAsync());
        }

        // GET: ProductsLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsList = await _context.ProductsList
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productsList == null)
            {
                return NotFound();
            }

            return View(productsList);
        }

        // GET: ProductsLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductsLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductLocation,UploadedDate,ProductOwnerId")] ProductsList productsList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productsList);
        }

        // GET: ProductsLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsList = await _context.ProductsList.FindAsync(id);
            if (productsList == null)
            {
                return NotFound();
            }
            return View(productsList);
        }

        // POST: ProductsLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductLocation,UploadedDate,ProductOwnerId")] ProductsList productsList)
        {
            if (id != productsList.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsListExists(productsList.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productsList);
        }

        // GET: ProductsLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsList = await _context.ProductsList
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productsList == null)
            {
                return NotFound();
            }

            return View(productsList);
        }

        // POST: ProductsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsList = await _context.ProductsList.FindAsync(id);
            _context.ProductsList.Remove(productsList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsListExists(int id)
        {
            return _context.ProductsList.Any(e => e.ProductId == id);
        }
    }
}
