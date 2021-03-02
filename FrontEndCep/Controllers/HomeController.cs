using Newtonsoft.Json;
using FrontEndCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FrontEndCep.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BuscarCEP(string cep)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/api/buscarcep/" + cep);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var retorno = JsonConvert.DeserializeObject<Endereco>(streamReader.ReadToEnd());
                return View(retorno);

            }
        }

    }
}