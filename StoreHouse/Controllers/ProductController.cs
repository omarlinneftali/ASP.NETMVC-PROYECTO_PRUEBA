using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreHouse.Data_Layer.Repositories;
using StoreHouse.Models;
using StoreHouse.ViewModel;
using StoreHouse.ViewModels;

namespace StoreHouse.Controllers
{

    public class ProductController : Controller
    {
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
        }
        public ActionResult Index(string searchQuery)
        {

            var products = _productRepository.GetProducts(searchQuery);
            var categories = _categoryRepository.GetCategories("");

            var productIndexViewModel = new ProductIndexViewModel()
            {
                Categories = categories,
                Products = products

            };


            return View(productIndexViewModel);
        }

        public ActionResult GetProducts(string searchQuery)
        {
            var products = _productRepository.GetProducts(searchQuery);


            return PartialView("_ProductTable", products);

        }


        [HttpGet]

        public ActionResult SaveProduct(int id = 0)
        {

            var categories = _categoryRepository.GetCategories("");

            var productFormViewModel = new FormProductsViewModel()
            {
                Categories = categories,
                Product = new Product()

            };


            if (id == 0)
            {
                return View("ProductForm", productFormViewModel);
            }

            var product = _productRepository.GetProductByID(id);


            if (product == null)
            {
                return HttpNotFound();

            }

            productFormViewModel.Product = product;

            return View("ProductForm", productFormViewModel);


        }

        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { isValid = false, message = "fail to save" }, JsonRequestBehavior.AllowGet);

            }

            if (product.ProductID == 0)
            {
                _productRepository.AddProduct(product);


                return Json(new { isValid = true, message = "Saved Succesfully" }, JsonRequestBehavior.AllowGet);

            }


            if (_productRepository.UpdateProduct(product))
            {
                return Json(new { isValid = true, message = "Update Succesfully" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isValid = false, message = "Update failed" }, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult ProductDetails(int id)
        {

            var product = _productRepository.GetProductByID(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }


        public ActionResult DeleteProduct(int id)
        {
            var isProductDeleted = _productRepository.DeleteProduct(id);

            if (!isProductDeleted)
            {
                return Json(new { isValid = false, message = "Failed to delete, Product not exist" }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { isValid = true, message = "Delete Succesfully" }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetProductsByCategoryID(int categoryID)
        {
            var products = _productRepository.GetProductsByCategoryID(categoryID);

            return PartialView("_ProductTable", products);
        }


    }
}
