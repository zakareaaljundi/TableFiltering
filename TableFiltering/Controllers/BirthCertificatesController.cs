using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TableFiltering.Data;
using TableFiltering.Models;

namespace TableFiltering.Controllers
{
    public class BirthCertificatesController : Controller
    {
        private readonly FinalDbContext _context;

        public BirthCertificatesController(FinalDbContext context)
        {
            _context = context;
        }

        // GET: BirthCertificates
        public async Task<IActionResult> Index()
        {
              return _context.BirthCertificates != null ? 
                          View(await _context.BirthCertificates.ToListAsync()) :
                          Problem("Entity set 'FinalDbContext.BirthCertificates'  is null.");
        }

        // GET: BirthCertificates/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.BirthCertificates == null)
            {
                return NotFound();
            }

            var birthCertificate = await _context.BirthCertificates
                .FirstOrDefaultAsync(m => m.BirthCertificateId == id);
            if (birthCertificate == null)
            {
                return NotFound();
            }

            return View(birthCertificate);
        }

        // GET: BirthCertificates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BirthCertificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BirthCertificateId,Name,Health,DateOfBirth,PlaceOfBirth,FatherName,MotherName,Status,Approved,CreationDate")] BirthCertificate birthCertificate)
        {
            if (ModelState.IsValid)
            {
                birthCertificate.BirthCertificateId = Guid.NewGuid();
                _context.Add(birthCertificate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(birthCertificate);
        }

        // GET: BirthCertificates/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.BirthCertificates == null)
            {
                return NotFound();
            }

            var birthCertificate = await _context.BirthCertificates.FindAsync(id);
            if (birthCertificate == null)
            {
                return NotFound();
            }
            return View(birthCertificate);
        }

        // POST: BirthCertificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BirthCertificateId,Name,Health,DateOfBirth,PlaceOfBirth,FatherName,MotherName,Status,Approved,CreationDate")] BirthCertificate birthCertificate)
        {
            if (id != birthCertificate.BirthCertificateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(birthCertificate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirthCertificateExists(birthCertificate.BirthCertificateId))
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
            return View(birthCertificate);
        }

        // GET: BirthCertificates/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.BirthCertificates == null)
            {
                return NotFound();
            }

            var birthCertificate = await _context.BirthCertificates
                .FirstOrDefaultAsync(m => m.BirthCertificateId == id);
            if (birthCertificate == null)
            {
                return NotFound();
            }

            return View(birthCertificate);
        }

        // POST: BirthCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.BirthCertificates == null)
            {
                return Problem("Entity set 'FinalDbContext.BirthCertificates'  is null.");
            }
            var birthCertificate = await _context.BirthCertificates.FindAsync(id);
            if (birthCertificate != null)
            {
                _context.BirthCertificates.Remove(birthCertificate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BirthCertificateExists(Guid id)
        {
          return (_context.BirthCertificates?.Any(e => e.BirthCertificateId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Print(Guid id)
        {
            if (id == null || _context.BirthCertificates == null)
            {
                return NotFound();
            }

            var birthCertificate = await _context.BirthCertificates
                .FirstOrDefaultAsync(m => m.BirthCertificateId == id);
            if (birthCertificate == null)
            {
                return NotFound();
            }

            return View(birthCertificate);
        }

    }
}
