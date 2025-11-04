using System.ComponentModel.DataAnnotations;

namespace BancoPreguntasIntento25.Models
{
    public class ListaPreguntas
    {
        [Key]
        public int PreguntaId { get; set; }
        public string Texto { get; set; }
        public string RespuestaCorrecta { get; set; }
        public string? RespuestaIncorrecta1 { get; set; }
        public string? RespuestaIncorrecta2 { get; set; }
        public string? RespuestaIncorrecta3 { get; set; }
        public string Asignatura { get; set; }
        public int Unidad { get; set; }
        public string SubUnidad { get; set; }
    }
}
