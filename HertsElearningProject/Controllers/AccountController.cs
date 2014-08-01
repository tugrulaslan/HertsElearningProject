using HertsElearningProject.Models;
using HertsElearningProject.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HertsElearningProject.Controllers
{
    public class AccountController : Controller
    {

            //
            // GET: /Account/
            HertsOnlineEntities db = new HertsOnlineEntities();
            String lastLoginStamp = DateTime.Now.ToString("dd/MM/yyyy H:mm");
            PageHitsService pageHits = new PageHitsService();


            public ActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Login(Users users)
            {
                var userCount = db.UserEntity.Where(x => x.Username == users.Username && x.Password == users.Password).Count();
                if (userCount == 0)
                {
                    ViewBag.errorMsg = "Error: Invalid Users or Credentials";
                    return View();
                }
                else
                {
                    pageHits.updatePageHit("Account/Login", users.Username);
                    Users updateLastLogin = db.UserEntity.Where(x => x.Username == users.Username).FirstOrDefault();
                    updateLastLogin.LastLogin = lastLoginStamp;
                    db.Entry(updateLastLogin).State = EntityState.Modified;
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(users.Username, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            public ActionResult Edit()
            {
                Users userInfo = db.UserEntity.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                EditInfoModel editData = new EditInfoModel();

                editData.Email = userInfo.Email;
                editData.Name = userInfo.Name;
                editData.Lastname = userInfo.Lastname;
                pageHits.updatePageHit("Account/Edit", User.Identity.Name);
                return View(editData);
            }
            [HttpPost]
            public ActionResult Edit(EditInfoModel editInfo)
            {
                if (ModelState.IsValid)
                {
                    Users user = db.UserEntity.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                    user.Name = editInfo.Name;
                    user.Lastname = editInfo.Lastname;
                    user.Email = editInfo.Email;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return View();
                }
            }
            public ActionResult ChangePassword()
            {
                return View();
            }

            [HttpPost]
            public ActionResult ChangePassword(PasswordChangeModel passModel)
            {
                if (ModelState.IsValid)
                {
                    Users users = db.UserEntity.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                    //check password validatiy
                    if (users.Password.Equals(passModel.OldPassword))
                    {
                        Users userOldPass = db.UserEntity.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                        userOldPass.Password = passModel.NewPassword;
                        db.Entry(userOldPass).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        //passwords do not match
                        ModelState.AddModelError("OldPassword", "The entered password doesn't match with the registered password!");
                        return View();
                    }
                }
                return View();
            }

            public ActionResult Signup()
            {
                SignUpModel signup = new SignUpModel();
                return View(signup);
            }
            [HttpPost]
            public ActionResult Signup([Bind(Include = "Id,Username,Password,Email,Name,Lastname,UserRole")] SignUpModel model)
            {
                if (ModelState.IsValid)
                {

                    Users users = new Users();
                    users.Username = model.Username;
                    users.Password = model.Password;
                    users.Email = model.Email;
                    users.Name = model.Name;
                    users.Lastname = model.Lastname;
                    users.UserRole = model.UserRole;

                    db.UserEntity.Add(users);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return View();
                }

            }


            public JsonResult IsUsernameAvailable(SignUpModel model)
            {
                return checkUsernameAvailability(model)
                    ? Json(true, JsonRequestBehavior.AllowGet)
                    : Json(false, JsonRequestBehavior.AllowGet);
            }

            public bool checkUsernameAvailability(SignUpModel model)
            {
                return (!db.UserEntity.Any(x => x.Username == model.Username));
            }


            public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }

        }
	}