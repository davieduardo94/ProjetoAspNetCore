using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Home
{
    public class ContatoViewModel
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="{0} é obrigatório")]
        [EmailAddress(ErrorMessage ="Digite um {0} válido")]
        public string Email { get; set; }

        [Required (ErrorMessage ="{0} é obrigatório")]
        public string Mensagem { get; set; }
        
    }
}
