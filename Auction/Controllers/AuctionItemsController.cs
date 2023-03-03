using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auction.Data;
using Auction.Models;

namespace Auction.Controllers
{
    public class AuctionItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuctionItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuctionItems
        public async Task<IActionResult> Index()
        {
              return View(await _context.AuctionItem.ToListAsync());
        }

        // GET: AuctionItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuctionItem == null)
            {
                return NotFound();
            }

            var auctionItem = await _context.AuctionItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auctionItem == null)
            {
                return NotFound();
            }

            return View(auctionItem);
        }

        // GET: AuctionItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuctionItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Tags")] AuctionItem auctionItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auctionItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auctionItem);
        }

        // GET: AuctionItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuctionItem == null)
            {
                return NotFound();
            }

            var auctionItem = await _context.AuctionItem.FindAsync(id);
            if (auctionItem == null)
            {
                return NotFound();
            }
            return View(auctionItem);
        }

        // POST: AuctionItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Tags")] AuctionItem auctionItem)
        {
            if (id != auctionItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auctionItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionItemExists(auctionItem.Id))
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
            return View(auctionItem);
        }

        // GET: AuctionItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuctionItem == null)
            {
                return NotFound();
            }

            var auctionItem = await _context.AuctionItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auctionItem == null)
            {
                return NotFound();
            }

            return View(auctionItem);
        }

        // POST: AuctionItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuctionItem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AuctionItem'  is null.");
            }
            var auctionItem = await _context.AuctionItem.FindAsync(id);
            if (auctionItem != null)
            {
                _context.AuctionItem.Remove(auctionItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuctionItemExists(int id)
        {
          return _context.AuctionItem.Any(e => e.Id == id);
        }
    }
}
