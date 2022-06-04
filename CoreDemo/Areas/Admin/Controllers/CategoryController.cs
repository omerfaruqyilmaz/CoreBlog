using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
        
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context C = new Context();
        public IActionResult Index(int page=1)
        {
            var values = categoryManager.GetList().ToPagedList(page,3);
            return View(values);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category) 
        {

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.AddT(category);              
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var values = categoryManager.TGetById(id);
            categoryManager.DeleteT(values);
            return RedirectToAction("Index");
        }
    }
}
