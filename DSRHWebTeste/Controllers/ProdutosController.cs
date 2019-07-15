using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSRHWebTeste.Models;
using System.Net.Http;
using Newtonsoft.Json;
using DSRHWebTeste.Helpers;
using System.Text;
using System.Net;

namespace DSRHWebTeste.Controllers
{
    public class ProdutosController : Controller
    {
        HttpClient client;

        public ProdutosController()
        {
            client = new ProdutosStoreCliente().Client;
        }

        // GET: ListarProdutos
        public async Task<IActionResult> ListarProdutos()
        {

            HttpResponseMessage response = await client.GetAsync("produtos");

            if (!response.IsSuccessStatusCode)
            {
                return Content("Ocorreu um erro ao conectar-se à API da web");
            }

            string contentresult = await response.Content.ReadAsStringAsync();
            IEnumerable<Produto> produtos = JsonConvert.DeserializeObject<IEnumerable<Produto>>(contentresult);

            return View(produtos);
        }

        //POST: GerarToken
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GerarToken(UserInfo userInfo)
        {
            userInfo.Email = "teste@dsrh.com.br";
            userInfo.Password = "Aa123456!";

            HttpResponseMessage response = await client.PostAsync("contas", new StringContent(
                                          JsonConvert.SerializeObject(userInfo),
                                          Encoding.Unicode,
                                          "application/json"));
            if (response.StatusCode != HttpStatusCode.Created)
            {
                return Content("Ocorreu um erro ao publicar dados na API da web");
            }

            return RedirectToAction("Index");
        }
    }
}
