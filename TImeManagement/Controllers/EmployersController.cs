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

namespace TImeManagement.Controllers
{
    public class EmployersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employers

        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.employers.Include(e => e.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.employers == null)
            {
                return NotFound();
            }

            var employer = await _context.employers
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employer == null)
            {
                return NotFound();
            }

            return View(employer);
        }

        // GET: Employers/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.roles, "Id", "Id");
            return View();
        }

        // POST: Employers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,SurName,RoleId,UserLogin,HashPassword")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.roles, "Id", "Id", employer.RoleId);
            return View(employer);
        }

        // GET: Employers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.employers == null)
            {
                return NotFound();
            }

            var employer = await _context.employers.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.roles, "Id", "Id", employer.RoleId);
            return View(employer);
        }

        // POST: Employers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,SurName,RoleId,UserLogin,HashPassword")] Employer employer)
        {
            if (id != employer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployerExists(employer.Id))
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
            ViewData["RoleId"] = new SelectList(_context.roles, "Id", "Id", employer.RoleId);
            return View(employer);
        }

        // GET: Employers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.employers == null)
            {
                return NotFound();
            }

            var employer = await _context.employers
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employer == null)
            {
                return NotFound();
            }

            return View(employer);
        }

        // POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.employers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.employers'  is null.");
            }
            var employer = await _context.employers.FindAsync(id);
            if (employer != null)
            {
                _context.employers.Remove(employer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployerExists(int id)
        {
          return (_context.employers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
