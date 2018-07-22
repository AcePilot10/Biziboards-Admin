using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biziboards_Admin.Models;

namespace Biziboards_Admin.Controllers
{
    public class MerchantsController : Controller
    {
        private readonly BiziboardsContext _context;

        public MerchantsController(BiziboardsContext context)
        {
            _context = context;
        }

        // GET: Merchants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merchants.ToListAsync());
        }

        // GET: Merchants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchants = await _context.Merchants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchants == null)
            {
                return NotFound();
            }

            return View(merchants);
        }

        // GET: Merchants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merchants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Information,PhoneNumber,Location,LogoUrl,IsPaying,OffersList")] Merchants merchants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchants);
        }

        // GET: Merchants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchants = await _context.Merchants.FindAsync(id);
            if (merchants == null)
            {
                return NotFound();
            }
            return View(merchants);
        }

        // POST: Merchants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Information,PhoneNumber,Location,LogoUrl,IsPaying,OffersList")] Merchants merchants)
        {
            if (id != merchants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantsExists(merchants.Id))
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
            return View(merchants);
        }

        // GET: Merchants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchants = await _context.Merchants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchants == null)
            {
                return NotFound();
            }

            return View(merchants);
        }

        // POST: Merchants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merchants = await _context.Merchants.FindAsync(id);
            _context.Merchants.Remove(merchants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantsExists(int id)
        {
            return _context.Merchants.Any(e => e.Id == id);
        }
    }
}
