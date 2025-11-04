using BancoPreguntasIntento25.Data;
using BancoPreguntasIntento25.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BancoPreguntasIntento25.Pages.CuentaUsuarios
{
    public class RegistroModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;
        public RegistroModel(BancoPreguntasIntento25Context context) => _context = context;

        [BindProperty] public string Email { get; set; } = "";
        [BindProperty] public string Clave { get; set; } = "";

        public string Mensaje { get; set; } = "";
        public string MensajeExito { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Clave))
            {
                Mensaje = "Debe ingresar correo y contraseña.";
                return Page();
            }

            if (_context.Usuario.Any(u => u.email == Email))
            {
                Mensaje = "Ya existe un usuario con ese correo.";
                return Page();
            }

            // Hash de la contraseña
            var hash = BCrypt.Net.BCrypt.HashPassword(Clave); // por defecto usa salt y work factor seguro

            var nuevo = new Usuarios
            {
                email = Email,
                clave = hash
            };

            _context.Usuario.Add(nuevo);
            await _context.SaveChangesAsync();

            MensajeExito = "Usuario registrado con éxito. Ahora puede iniciar sesión.";
            return RedirectToPage("/Index");
        }
    }
}
