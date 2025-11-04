using BancoPreguntasIntento25.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BancoPreguntasIntento25.Pages.CuentaUsuarios
{
    public class LoginModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;
        public LoginModel(BancoPreguntasIntento25Context context) => _context = context;

        [BindProperty] public string Email { get; set; } = "";
        [BindProperty] public string Clave { get; set; } = "";
        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Clave))
            {
                Mensaje = "Debe ingresar correo y contraseña.";
                return Page();
            }

            var user = _context.Usuario.FirstOrDefault(u => u.email == Email);
            if (user == null)
            {
                Mensaje = "Correo o contraseña incorrectos.";
                return Page();
            }

            bool ok = false;

            // Si ya es un hash BCrypt (empieza con $2…), verificar con BCrypt.
            if (!string.IsNullOrEmpty(user.clave) && user.clave.StartsWith("$2"))
            {
                ok = BCrypt.Net.BCrypt.Verify(Clave, user.clave);
            }
            else
            {
                // Compatibilidad: si estaba en texto plano y coincide, lo actualizamos a hash.
                if (user.clave == Clave)
                {
                    ok = true;
                    user.clave = BCrypt.Net.BCrypt.HashPassword(Clave);
                    await _context.SaveChangesAsync(); // upgrade transparente
                }
            }

            if (!ok)
            {
                Mensaje = "Correo o contraseña incorrectos.";
                return Page();
            }
            return RedirectToPage("/Preguntas/Index");
        }
    }
}
