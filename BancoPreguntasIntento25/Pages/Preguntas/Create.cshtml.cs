using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BancoPreguntasIntento25.Data;
using BancoPreguntasIntento25.Models;

namespace BancoPreguntasIntento25.Pages.Preguntas
{
    public class CreateModel : PageModel
    {
        private readonly BancoPreguntasIntento25.Data.BancoPreguntasIntento25Context _context;

        public CreateModel(BancoPreguntasIntento25.Data.BancoPreguntasIntento25Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ListaPreguntas ListaPreguntas { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ListaPreguntas.Add(ListaPreguntas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
