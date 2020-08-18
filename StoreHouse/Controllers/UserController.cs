using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StoreHouse.Data_Layer.Repositories;
using StoreHouse.Models;
using StoreHouse.ViewModels;

namespace StoreHouse.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();

        }

        [HttpGet]
        public ActionResult SignInOrEditUser()
        {
            return View("UserForm", new User());

        }

        [HttpPost]

        
        public ActionResult SignInOrEditUser(User user)
        {
            if (!ModelState.IsValid)
            {

                return Json(new { isValid = false, message = "fallo al guardar, datos invalidos" }, JsonRequestBehavior.AllowGet);

            }


            if (user.UserID == 0)
            {
                var hasUserOneRepitedUserNameOrEmail = _userRepository.GetUserByEmailOrUsername(user.UserName) != null || _userRepository.GetUserByEmailOrUsername(user.Email) != null;

                if (hasUserOneRepitedUserNameOrEmail)
                {
                    return Json(new { isValid = false, message = "Ya existe una cuenta asociada a este Correo o nombre de usuario" }, JsonRequestBehavior.AllowGet);

                }

                _userRepository.AddUser(user);

                FormsAuthentication.SetAuthCookie(user.UserName, true);

                return Json(new { isValid = true, message = "Usuario Guardado con Exito" }, JsonRequestBehavior.AllowGet);


            }


            if (_userRepository.UpdateUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);

                return Json(new { isValid = true, message = "Actualizacion exitosa" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isValid = false, message = "Fallo en la actualizacion" }, JsonRequestBehavior.AllowGet);

            }

        }


        public ActionResult updateUserProfile(string userNameOrEmail)
        {
            var userProfile = _userRepository.GetUserByEmailOrUsername(userNameOrEmail);

            return View("UserForm", userProfile);
        }

        [HttpGet]
        public ActionResult LoginUser()
        {

            return View(); 

        }


        [HttpPost]

        public ActionResult LoginUser(LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid)
            {
                return Json(new {isValid = false, message = "Debe introducir el nombre de usuario y contraseña"}, JsonRequestBehavior.AllowGet);
            }
            
            var user = _userRepository.GetUserByEmailAndPassword(loginViewModel.Email, loginViewModel.Password);

            if (user == null)
            {
                return Json(new { isValid = false, message = "Credenciales incorrectas" }, JsonRequestBehavior.AllowGet);

            }

            FormsAuthentication.SetAuthCookie(user.UserName, true);


            return Json(new { isValid = true, message = "Inicio de session exitoso" }, JsonRequestBehavior.AllowGet);

        }

        [Authorize]
        public ActionResult LogOutUser()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser");
        }

    }




}

