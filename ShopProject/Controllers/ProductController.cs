using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ProductController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly AppDbContext _context;
        public ProductController(ILogger<CategoryController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index(string product)
        {

            if (product != null)
            {
                var lst = await _context.Products.Where(p => p.ProductName == product).ToListAsync();
                return View(lst);
            }
            else
            {
                var lst = await _context.Products.ToListAsync();
                return View(lst);
            }

        }
        public async Task <IActionResult> Create()
        {
            ViewData["CategoryId"] = await _context.Categories.Select(p => new SelectListItem()
            {
               Text = p.Name,
               Value = p.Id.ToString()
           }).ToListAsync();
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["CategoryId"] = await _context.Categories.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        



        


    }
}

