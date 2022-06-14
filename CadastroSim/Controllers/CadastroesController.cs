using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroSim.Models;

namespace CadastroSim.Controllers
{
    public class CadastroesController : Controller
    {
        private readonly Context _context;

        public CadastroesController(Context context)
        {
            _context = context;
        }

        // GET: Cadastroes
        public async Task<IActionResult> Index()
        {
              return _context.cadastro != null ? 
                          View(await _context.cadastro.ToListAsync()) :
                          Problem("Entity set 'Context.cadastro'  is null.");
        }

        // GET: Cadastroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cadastro == null)
            {
                return NotFound();
            }

            var dbCadastro = await _context.cadastro
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbCadastro == null)
            {
                return NotFound();
            }

            return View(dbCadastro);
        }

        // GET: Cadastroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,email,datanascimento,sexo,rua,numero,cep,cidade,estado,mensagem")] DbCadastro dbCadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbCadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbCadastro);
        }

        // GET: Cadastroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cadastro == null)
            {
                return NotFound();
            }

            var dbCadastro = await _context.cadastro.FindAsync(id);
            if (dbCadastro == null)
            {
                return NotFound();
            }
            return View(dbCadastro);
        }

        // POST: Cadastroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,email,datanascimento,sexo,rua,numero,cep,cidade,estado,mensagem")] DbCadastro dbCadastro)
        {
            if (id != dbCadastro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbCadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbCadastroExists(dbCadastro.id))
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
            return View(dbCadastro);
        }

        // GET: Cadastroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cadastro == null)
            {
                return NotFound();
            }

            var dbCadastro = await _context.cadastro
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbCadastro == null)
            {
                return NotFound();
            }

            return View(dbCadastro);
        }

        // POST: Cadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cadastro == null)
            {
                return Problem("Entity set 'Context.cadastro'  is null.");
            }
            var dbCadastro = await _context.cadastro.FindAsync(id);
            if (dbCadastro != null)
            {
                _context.cadastro.Remove(dbCadastro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbCadastroExists(int id)
        {
          return (_context.cadastro?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
