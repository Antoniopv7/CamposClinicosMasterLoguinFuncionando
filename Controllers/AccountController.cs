using Microsoft.AspNetCore.Mvc;
using Gestion_Del_Presupuesto.Models;
using System.Threading.Tasks;

public class AccountController : Controller
{
    // Lista de usuarios de prueba
    private readonly List<LoginViewModel> _testUsers = new List<LoginViewModel>
    {
        new LoginViewModel { Email = "user@example.com", Password = "Password123!" }
    };

    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/Home/Index");

        if (ModelState.IsValid)
        {
            // Simulación de autenticación
            var user = _testUsers.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                // Autenticación simulada exitosa
                // Aquí podrías establecer una cookie o una sesión
                // Simularemos solo la redirección
                return LocalRedirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Intento de inicio de sesión inválido.");
                return View(model);
            }
        }

        return View(model);
    }
}


