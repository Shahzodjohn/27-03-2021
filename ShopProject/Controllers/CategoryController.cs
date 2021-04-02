using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopProject.Context;
using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly AppDbContext _context;
        public CategoryController(ILogger<CategoryController> logger, AppDbContext context) 
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index(string category)
        {
            //var lst = await _context.Products.Where(p => p.Category.Name == category).ToListAsync();
            var res = await _context.Categories.ToListAsync();
            return View(res);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id != null)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
