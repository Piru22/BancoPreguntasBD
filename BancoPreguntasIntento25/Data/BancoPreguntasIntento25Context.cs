using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BancoPreguntasIntento25.Models;

namespace BancoPreguntasIntento25.Data
{
    public class BancoPreguntasIntento25Context : DbContext
    {
        public BancoPreguntasIntento25Context (DbContextOptions<BancoPreguntasIntento25Context> options)
            : base(options)
        {
        }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<ListaPreguntas> ListasPreguntas { get; set; }
    }
}
