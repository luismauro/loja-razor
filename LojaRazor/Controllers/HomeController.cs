using LojaRazor.DAO;
using LojaRazor.Models;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace LojaRazor.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
           
            ProdutosDAO produtosDAO = new ProdutosDAO();
            ViewBag.Produtos = produtosDAO.Ofertas();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contato(Contato objModelMail)
        {
            if (ModelState.IsValid)
            {
                string from = "xxxxxx@gmail.com"; //email gmail
                using (MailMessage mail = new MailMessage(from, objModelMail.Email))
                {
                    mail.Subject = objModelMail.Nome;
                    mail.Subject = objModelMail.Assunto;
                    mail.Body = objModelMail.Mensagem;
                    
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "xxxxxx");//password gmail
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                   
                    return View("Contato", objModelMail);
                }
            }
            else
            {
                return View();
            }
        }

    }
}

