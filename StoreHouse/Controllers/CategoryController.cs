using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreHouse.Data_Layer.Repositories;
using StoreHouse.Models;

namespace StoreHouse.Controllers
{
    [Authorize]

    public class CategoryController : Controller
    {
        private CategoryRepository _categoryRepository;
        // GET: Category
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
        public ActionResult Index(string searchQuery)
        {
            var categories = _categoryRepository.GetCategories(searchQuery);


            return View(categories);
        }

        public ActionResult GetCategories(string searchQuery)
        {
            var categories = _categoryRepository.GetCategories(searchQuery);


            return PartialView("_CategoryTable", categories);

        }


        [HttpGet]

        public ActionResult SaveCategory(int id = 0)
        {

            if (id == 0)
            {
                return View("CategoryForm", new Category());
            }


            var category = _categoryRepository.GetCategoryByID(id);

            if (category == null)
            {
                return HttpNotFound();

            }

            return View("CategoryForm", category);

        }

        [HttpPost]
        public ActionResult SaveCategory(Category category)
        {
            if (!ModelState.IsValid)
            {

                return Json(new { isValid = false, message = "fail to save" }, JsonRequestBehavior.AllowGet);


            }

            if (category.CategoryID == 0)
            {
                _categoryRepository.AddCategory(category);



                return Json(new { isValid = true, message = "Saved Succesfully" }, JsonRequestBehavior.AllowGet);

            }


            if (_categoryRepository.UpdateCategory(category))
            {
                return Json(new { isValid = true, message = "Update Succesfully" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isValid = false, message = "Update failed" }, JsonRequestBehavior.AllowGet);

            }


        }


        public ActionResult CategoryDetails(int id)
        {

            var category = _categoryRepository.GetCategoryByID(id);

            if (category == null)
                return HttpNotFound();

            return View(category);
        }


        public ActionResult DeleteCategory(int id)
        {
            var isCategoryDeleted = _categoryRepository.DeleteCategory(id);

            if (!isCategoryDeleted)
            {
                return Json(new { isValid = false, message = "Failed to delete, Category not exist" }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { isValid = true, message = "Delete Succesfully" }, JsonRequestBehavior.AllowGet);


        }


    }
}

