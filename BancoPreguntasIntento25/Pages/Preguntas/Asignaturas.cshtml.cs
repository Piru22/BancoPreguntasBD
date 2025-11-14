using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;              
using Microsoft.AspNetCore.Mvc.RazorPages;     
using BancoPreguntasIntento25.Data;           
using BancoPreguntasIntento25.Models;         


namespace BancoPreguntasIntento25.Pages.Preguntas
{
    public class AsignaturasModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;
        public AsignaturasModel(BancoPreguntasIntento25Context context) => _context = context;

        public List<string> Asignaturas { get; set; } = new();

        public void OnGet()
        {
            Asignaturas = _context.ListaPreguntas
                .Select(p => p.Asignatura)
                .Distinct()
                .ToList();
        }
    }
}
