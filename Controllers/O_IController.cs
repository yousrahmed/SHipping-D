using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Models;

namespace Shipping.Controllers
{
    public class O_IController : Controller
    {
        private readonly Context _context;

        public O_IController(Context context)
        {
            _context = context;
        }

        // GET: O_I
        public IActionResult Index()
        {
            var context = _context.O_I.Include(o => o.Items_Items).Include(o => o.Order_Order);
            return View(context.ToList());
        }

        // GET: O_I/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var o_I =  _context.O_I
                .Include(o => o.Items_Items)
                .Include(o => o.Order_Order)
                .FirstOrDefault(m => m.O_ID == id);
            if (o_I == null)
            {
                return NotFound();
            }

            return View(o_I);
        }

        // GET: O_I/Create
        public IActionResult Create()
        {
            ViewData["I_ID"] = new SelectList(_context.Items, "ID", "ID");
            ViewData["O_ID"] = new SelectList(_context.Order, "ID", "ID");
            return View();
        }

        // POST: O_I/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( O_I o_I)
        {
            if (ModelState.IsValid)
            {
                 _context.Add(o_I);
                 _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["I_ID"] = new SelectList(_context.Items, "ID", "ID", o_I.I_ID);
            ViewData["O_ID"] = new SelectList(_context.Order, "ID", "ID", o_I.O_ID);
            return View(o_I);
        }

        // GET: O_I/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var o_I =  _context.O_I.Find(id);
            if (o_I == null)
            {
                return NotFound();
            }
            ViewData["I_ID"] = new SelectList(_context.Items, "ID", "ID", o_I.I_ID);
            ViewData["O_ID"] = new SelectList(_context.Order, "ID", "ID", o_I.O_ID);
            return View(o_I);
        }

        // POST: O_I/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, O_I o_I)
        {
            if (id != o_I.O_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(o_I);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!O_IExists(o_I.O_ID))
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
            ViewData["I_ID"] = new SelectList(_context.Items, "ID", "ID", o_I.I_ID);
            ViewData["O_ID"] = new SelectList(_context.Order, "ID", "ID", o_I.O_ID);
            return View(o_I);
        }

        // GET: O_I/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var o_I =  _context.O_I
                .Include(o => o.Items_Items)
                .Include(o => o.Order_Order)
                .FirstOrDefaultAsync(m => m.O_ID == id);
            if (o_I == null)
            {
                return NotFound();
            }

            return View(o_I);
        }

        // POST: O_I/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var o_I =  _context.O_I.Find(id);
            _context.O_I.Remove(o_I);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool O_IExists(int id)
        {
            return _context.O_I.Any(e => e.O_ID == id);
        }
    }
}
