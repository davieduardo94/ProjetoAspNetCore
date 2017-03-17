using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaApp.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }
    }
}
