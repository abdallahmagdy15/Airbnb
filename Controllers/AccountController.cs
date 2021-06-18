using Airbnb.Data;
using Airbnb.Models;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Airbnb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        IWebHostEnvironment webHostEnvironment;
        private ApplicationDbContext DbContext;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment hostEnvironment,ApplicationDbContext applicationDb)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            webHostEnvironment = hostEnvironment;
            DbContext = applicationDb;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return PartialView("~/Views/Shared/LoginPartialView.cshtml",user);

        }
        public IActionResult Register()
        {
            return PartialView("~/Views/Shared/RegisterPartialView.cshtml",new RegisterViewModel());

        }
        public IActionResult Login()
        {
            return PartialView("~/Views/Shared/LoginPartialView.cshtml",new LoginViewModel());

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    FirstName = model.Fname,
                    LastName = model.Lname,
                    DateOfBirth = model.DOB,
                    Gender = model.Gender,
                    PhotoUrl = uniqueFileName,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");

                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                        return RedirectToAction("ListRoles", "Administration");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var Error in result.Errors)
                {
                    ModelState.AddModelError("Error", Error.Description);
                }
            }

            return PartialView("~/Views/Shared/RegisterPartialView.cshtml",model);
        }

      
        [HttpGet]
        public async Task<IActionResult> SocialRegister(string returnUrl)
        {
            RegisterViewModel model = new RegisterViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogin = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult ExternalLogin(string provider,string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                new { ReturnUrl = returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult>ExternalLoginCallback(string returnUrl=null,string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            RegisterViewModel registerViewModel = new RegisterViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogin = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if(remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("SocialRegister", registerViewModel);
            }
            var info = await signInManager.GetExternalLoginInfoAsync();
            if(info == null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("SocialRegister", registerViewModel);
            }
            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if(email != null)
                {
                    var user = await userManager.FindByEmailAsync(email);
                    if(user == null)
                    {
                        user = new AppUser
                        {
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                            FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                            LastName = info.Principal.FindFirstValue(ClaimTypes.Surname),
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            PhoneNumber = info.Principal.FindFirstValue(ClaimTypes.MobilePhone),

                        };
                        if (info.Principal.FindFirstValue(ClaimTypes.Gender) == "Male" || info.Principal.FindFirstValue(ClaimTypes.Gender) == "male")
                        {
                            user.Gender = Gender.Male;
                        }
                        else
                        {
                            user.Gender = Gender.Female;
                        }
                        await userManager.CreateAsync(user);
                    }
                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorTitle = "please contact support on engahmedsalah311@gmail.com";
                return View("Error");
            }
        }
        private string UploadedFile(RegisterViewModel model)
        {
            string uniqueFileName = null;

            if (model.PhotoUrl != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PhotoUrl.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<IActionResult> IsEmailAvailable(string email)
        {
            bool result;
            var user  = await userManager.FindByNameAsync(email);
            if(user == null)
                result = true;
            
            else
                result = false;
            return Json(data:result);
        }
        [HttpGet]
        public IActionResult editprofile()
        {
          
            var userid = userManager.GetUserId(HttpContext.User);
            if (userid==null)
            {
                return View("Login");
            }
            else
            {
                var user = DbContext.Users.FirstOrDefault(d=>d.Id==userid);
                return View(user);
            }
            
        }
        [HttpPost]
        public IActionResult editprofile(AppUser user)
        {
            var olduser = DbContext.Users.FirstOrDefault(d => d.Id == user.Id);
            if (olduser.Id != null)
            {
                olduser.FirstName = user.FirstName;
                olduser.LastName = user.LastName;
                olduser.PhoneNumber = user.PhoneNumber;
                olduser.Email = user.Email;
                olduser.DateOfBirth = user.DateOfBirth;
                olduser.Street = user.Street;
                olduser.BuildingNo = user.BuildingNo;
                DbContext.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(user);
            }

        }
    }
}
