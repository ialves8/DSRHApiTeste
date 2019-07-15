using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DSRHWebTeste.Helpers
{
    public class ProdutosStoreCliente
    {
        static HttpClient client;

        string url = "https://localhost:44339/api/v1/contas/criar";
        public ProdutosStoreCliente()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient Client { get { return client; } }
    }
}
