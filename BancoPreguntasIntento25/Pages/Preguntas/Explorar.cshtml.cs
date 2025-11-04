using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;              
using Microsoft.AspNetCore.Mvc.RazorPages;     
using BancoPreguntasIntento25.Data;           
using BancoPreguntasIntento25.Models;         


namespace BancoPreguntasIntento25.Pages.Preguntas
{
    public class ExplorarModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;
        public ExplorarModel(BancoPreguntasIntento25Context context) => _context = context;

        // Parámetros de navegación (querystring)
        [BindProperty(SupportsGet = true)] public string? asig { get; set; }
        [BindProperty(SupportsGet = true)] public int? unidad { get; set; }
        [BindProperty(SupportsGet = true)] public string? sub { get; set; }

        // Datos para cada paso
        public List<string> Asignaturas { get; set; } = new();
        public List<int> Unidades { get; set; } = new();
        public List<string> SubUnidades { get; set; } = new();
        public List<ListaPreguntas> Preguntas { get; set; } = new();

        public void OnGet()
        {
            // Paso 1: Asignaturas disponibles
            Asignaturas = _context.ListaPreguntas
                .Select(p => p.Asignatura)
                .Where(s => s != null && s != "")
                .Distinct()
                .OrderBy(s => s)
                .ToList();

            if (string.IsNullOrWhiteSpace(asig))
                return; // aún no se eligió asignatura → mostramos solo paso 1

            // Paso 2: Unidades de la asignatura elegida
            Unidades = _context.ListaPreguntas
                .Where(p => p.Asignatura == asig)
                .Select(p => p.Unidad)
                .Distinct()
                .OrderBy(u => u)
                .ToList();

            if (!unidad.HasValue)
                return; // aún no se eligió unidad → mostramos paso 2

            // Paso 3: Subunidades de la asignatura + unidad elegidas
            SubUnidades = _context.ListaPreguntas
                .Where(p => p.Asignatura == asig && p.Unidad == unidad.Value)
                .Select(p => p.SubUnidad)
                .Where(s => s != null && s != "")
                .Distinct()
                .OrderBy(s => s)
                .ToList();

            if (string.IsNullOrWhiteSpace(sub))
                return; // aún no se eligió subunidad → mostramos paso 3

            // Paso 4: Preguntas de la combinación elegida
            Preguntas = _context.ListaPreguntas
                .Where(p => p.Asignatura == asig && p.Unidad == unidad.Value && p.SubUnidad == sub)
                .OrderBy(p => p.PreguntaId)
                .ToList();
        }
    }
}
