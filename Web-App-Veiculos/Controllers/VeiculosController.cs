using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_App_Veiculos.Models;

namespace Web_App_Veiculos.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToArrayAsync();
            
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if(ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(veiculo);
        }

        public async Task<ActionResult> Edit(int? id)
        {
           if(id == null) 
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if(dados == null)
                return NotFound();
            
            return View(dados);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Veiculo veiculo)
        {
            if(id != veiculo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
               _context.Veiculos.Update(veiculo);            
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details (int? id)
        {
           if(id ==null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if(dados == null)
                return NotFound();

            return View(dados);
        }
    }
}
