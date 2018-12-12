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
    public class CraditcarrdsController : Controller
    {
        private readonly Context _context;

        public CraditcarrdsController(Context context)
        {
            _context = context;
        }

        // GET: Craditcarrds
        public IActionResult Index()
        {
            return View(_context.Craditcarrds.ToList());
        }

        // GET: Craditcarrds/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var craditcarrd =  _context.Craditcarrds
                .FirstOrDefault(m => m.ID == id);
            if (craditcarrd == null)
            {
                return NotFound();
            }

            return View(craditcarrd);
        }

        // GET: Craditcarrds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Craditcarrds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Craditcarrd craditcarrd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(craditcarrd);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(craditcarrd);
        }

        // GET: Craditcarrds/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var craditcarrd =  _context.Craditcarrds.Find(id);
            if (craditcarrd == null)
            {
                return NotFound();
            }
            return View(craditcarrd);
        }

        // POST: Craditcarrds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Craditcarrd craditcarrd)
        {
            if (id != craditcarrd.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(craditcarrd);
                     _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CraditcarrdExists(craditcarrd.ID))
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
            return View(craditcarrd);
        }

        // GET: Craditcarrds/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var craditcarrd =  _context.Craditcarrds
                .FirstOrDefault(m => m.ID == id);
            if (craditcarrd == null)
            {
                return NotFound();
            }

            return View(craditcarrd);
        }

        // POST: Craditcarrds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var craditcarrd =  _context.Craditcarrds.Find(id);
            _context.Craditcarrds.Remove(craditcarrd);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CraditcarrdExists(int id)
        {
            return _context.Craditcarrds.Any(e => e.ID == id);
        }
    }
}
