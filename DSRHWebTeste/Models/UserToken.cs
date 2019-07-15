using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSRHWebTeste.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
