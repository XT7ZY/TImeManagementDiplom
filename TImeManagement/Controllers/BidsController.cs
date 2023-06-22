using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TImeManagement.Data;
using TImeManagement.Models;
using TImeManagement.ViewModels.Bids;

namespace TImeManagement.Controllers
{
    public class BidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BidsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize(Policy = "EmployOnly")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("1") || User.IsInRole("2"))
            {
                return _context.bids != null ?
            View(await _context.bids.Include(e => e.EmployerSender).Include(bt => bt.BidType).ToListAsync()) :
            Problem("Entity set 'ApplicationDbContext.bids'  is null.");
            }
            var employer = _context.employers.FirstOrDefault(x => x.UserLogin == User.Identity.Name);

            IEnumerable<Bid> bids = await _context.bids.Include(bt => bt.BidType).Where(x => x.SenderID == employer.Id).ToListAsync();

            return View(bids);
        }

        [Authorize(Policy = "EmployOnly")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bids == null)
            {
                return NotFound();
            }

            var bid = await _context.bids
                .Include(bt => bt.BidType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        [Authorize(Policy = "EmployOnly")]
        public IActionResult Create()
        {
            ViewData["BidsType"] = new SelectList(_context.bidsType, "Id", "Name");
            return View();
        }

        [Authorize(Policy = "EmployOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BidsAddViewModel bid)
        {
            if (ModelState.IsValid)
            {
                var employer = _context.employers.FirstOrDefault(x => x.UserLogin == bid.SenderLogin);
                var bidType = _context.bidsType.FirstOrDefault(x => x.Id == bid.TypeId);

                Bid newBid = new Bid()
                {
                    TypeID = bid.TypeId,
                    Message = bid.Messange,
                    SenderID = employer.Id,
                    BidType = bidType,
                    RecieverId = employer.Id,
                    EmployerSender = employer,
                };
                _context.bids.Add(newBid);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Заявка успешно создана";
                return RedirectToAction("Index", "Bids");
            }
            ViewData["BidsType"] = new SelectList(_context.bidsType, "Id", "Name");
            return View(bid);
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bids == null)
            {
                return NotFound();
            }

            var bid = await _context.bids
                .Include(bt => bt.BidType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bids == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bids'  is null.");
            }
            var bid = await _context.bids.FindAsync(id);
            if (bid != null)
            {
                _context.bids.Remove(bid);
            }
            
            await _context.SaveChangesAsync();
            TempData["Success"] = "Заявка успешно удалена";
            return RedirectToAction(nameof(Index));
        }

        private bool BidExists(int id)
        {
          return (_context.bids?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Close(int? id)
        {
            if (id == null || _context.bids == null)
            {
                return NotFound();
            }

            var bid = await _context.bids
                .Include(bt => bt.BidType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost, ActionName("Close")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CloseConfrimed(int id)
        {
            if (_context.bids == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bids'  is null.");
            }
            var bid = await _context.bids.FindAsync(id);
            if (bid != null)
            {
                bid.IsClosed = true;
                _context.Update(bid);
            }
            TempData["Success"] = "Заявка успешно закрыта";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
