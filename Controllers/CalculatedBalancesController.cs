using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fixed_Deposit_Interest_MVC.Data;
using Fixed_Deposit_Interest_MVC.Models;

namespace Fixed_Deposit_Interest_MVC.Controllers
{
    public class CalculatedBalancesController : Controller
    {
        private readonly Fixed_Deposit_Interest_DBContext _context;

        public CalculatedBalancesController(Fixed_Deposit_Interest_DBContext context)
        {
            _context = context;
        }

        // GET: CalculatedBalances
        public async Task<IActionResult> Index()
        {
            var fixed_Deposit_Interest_DBContext = _context.CalculatedBalance.Include(c => c.Account);
            return View(await fixed_Deposit_Interest_DBContext.ToListAsync());
        }

        // GET: CalculatedBalances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatedBalance = await _context.CalculatedBalance
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calculatedBalance == null)
            {
                return NotFound();
            }

            return View(calculatedBalance);
        }

        // GET: CalculatedBalances/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id");
            return View();
        }

        // POST: CalculatedBalances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,NumberOfYears")] CalculatedBalance calculatedBalance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculatedBalance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", calculatedBalance.AccountId);
            return View(calculatedBalance);
        }

        // GET: CalculatedBalances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatedBalance = await _context.CalculatedBalance.FindAsync(id);
            if (calculatedBalance == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", calculatedBalance.AccountId);
            return View(calculatedBalance);
        }

        // POST: CalculatedBalances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountId,NumberOfYears")] CalculatedBalance calculatedBalance)
        {
            if (id != calculatedBalance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculatedBalance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculatedBalanceExists(calculatedBalance.Id))
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
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", calculatedBalance.AccountId);
            return View(calculatedBalance);
        }

        // GET: CalculatedBalances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatedBalance = await _context.CalculatedBalance
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calculatedBalance == null)
            {
                return NotFound();
            }

            return View(calculatedBalance);
        }

        // POST: CalculatedBalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calculatedBalance = await _context.CalculatedBalance.FindAsync(id);
            _context.CalculatedBalance.Remove(calculatedBalance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculatedBalanceExists(int id)
        {
            return _context.CalculatedBalance.Any(e => e.Id == id);
        }
    }
}
