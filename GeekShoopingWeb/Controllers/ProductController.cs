﻿using GeekShoopingWeb.Models;
using GeekShoopingWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShoopingWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();

            return View(products);
        }
        
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(product);
                if (response != null) return RedirectToAction(nameof(ProductIndex));            
            }
            
            return View(product);
        }
        
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var response = await _productService.FindProductById(id);
            if (response != null) return View(response);

            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(product);
                if (response != null) return RedirectToAction(nameof(ProductIndex));            
            }
            
            return View(product);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var response = await _productService.FindProductById(id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var response = await _productService.DeleteProductById(model.id);
            if (response != null) return RedirectToAction(nameof(ProductIndex));            
            
            return View(model);
        }
    }
}
