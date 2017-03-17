using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels.Home;
using WebApplication1.Services;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IMailService mail;
        private IConfigurationRoot config;

        public HomeController(IMailService mail, IConfigurationRoot config) //construtor para passar IMailService como parametro
        {
            this.config = config; //servico que armazena as configuracoes no appsettings
            this.mail = mail; //mail recebe o mail para o serviço
        }
        public IActionResult index()
        {
            Pessoa p = new Pessoa();
            p.Id = 1;
            p.Nome = "Eduardo Barbosa";
            p.Cpf = "01837759294";
            p.Telefone = "32220565";
            return View(p);
        }
        public IActionResult sobre()
        {
            return View();
        }

        //validação do lado do servidor
        [HttpGet] //aqui é feita a  leitura dos dados no formulario

        public IActionResult contato()
        {
            return View();
        }

        [HttpPost] //a partir daqui voce envia os dados passando o modelo
        public IActionResult contato(ContatoViewModel model) //action que vai receber o modelo
        {
          if (model.Email.Contains("bol.com"))
            {
                ModelState.AddModelError("Email", "Não damos suporte ao servidor BOL"); //VERIFICAR A VALIDAÇÃO NO LADO DO SERVER
            }
          if (ModelState.IsValid)
            {
                mail.SendMail(config["MailSettings: ToAddress"], model.Email, "Contato realizado", model.Mensagem); //utiliza o config com as informaçoes do appsettings.json, ToAddress substitui o email
                ModelState.Clear(); //para limpar o modelo apos ser enviado
                ViewBag.Mensagem = "Mensagem enviada com sucesso"; // se o modelo for valido a mensagem sera enviada, para o prorpio view
            }
            return View();
        }
        public IActionResult Error(string mensagem) //pagina de erro
        {
            return View();
        }
    }
}
