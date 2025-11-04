using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoPreguntasIntento25.Models
{
    [Table("Usuario")]
    public class Usuarios
    {
        [Key]
        public int id_Usuario { get; set; }

        [Required, EmailAddress]
        public string email { get; set; }

        [Required, DataType(DataType.Password)]
        public string clave { get; set; }
    }
}
