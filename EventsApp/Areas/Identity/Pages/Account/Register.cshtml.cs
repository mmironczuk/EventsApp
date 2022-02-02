using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using EventsApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using EmailService;
using EventsApp.Data;

namespace EventsApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly EmailService.IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            EmailService.IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Podanie loginu jest wymagane")]
            [Display(Name="Login*")]
            public string Login { get; set; }
            [Required(ErrorMessage = "Podanie emailu jest wymagane")]
            [EmailAddress]
            [Display(Name = "Email*")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło*")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Powtórz hasło*")]
            [Compare("Password", ErrorMessage = "Hasła muszą być takie same")]
            public string ConfirmPassword { get; set; }
            [Display(Name = "Imię")]
            public string Name { get; set; }
            [Display(Name = "Nazwisko")]
            public string Surname { get; set; }
            [Display(Name = "Data urodzenia")]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }
            //[Display(Name = "Role")]
            //public string Role { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ViewData["roles"] = _roleManager.Roles.ToList();
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            //var role = _roleManager.FindByIdAsync(Input.Role).Result;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new User { UserName = Input.Login, Email = Input.Email, name=Input.Name,surname=Input.Surname, birthDate=Input.BirthDate };
                User usr = _context.User.FirstOrDefault(x => x.Email == Input.Email);
                if(usr==null)
                {
                    var usr2 = _context.User.FirstOrDefault(x => x.UserName == Input.Login);
                    if(usr2==null)
                    {
                        var result = await _userManager.CreateAsync(user, Input.Password);
                        if (result.Succeeded)
                        {
                            _logger.LogInformation("User created a new account with password.");

                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                            var callbackUrl = Url.Page(
                                "/Account/ConfirmEmail",
                                pageHandler: null,
                                values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                                protocol: Request.Scheme);

                            Message message = new Message(new string[] { Input.Email },
                                "Confirm your email",
                                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                            //_emailSender.SendEmail(message);

                            if (_userManager.Options.SignIn.RequireConfirmedAccount)
                            {
                                //return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                                return RedirectToPage("ConfirmEmail");
                            }
                            else
                            {
                                await _signInManager.SignInAsync(user, isPersistent: false);
                                return LocalRedirect(returnUrl);
                            }
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    else
                    {
                        ViewData["err"] = "Użytkownik z podanym loginem już istnieje!";
                    }
                }
                else
                {
                    ViewData["err"] = "Użytkownik z podanym emailem już istnieje!";
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
