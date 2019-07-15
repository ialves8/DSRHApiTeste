using DSRHApiTeste.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSRHApiTeste.Contexts
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Produto> Produtos { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }

        public DbSet<DSRHApiTeste.Entities.UserInfo> UserInfo { get; set; }

        public DbSet<DSRHApiTeste.Entities.UserToken> UserToken { get; set; }
    }
}
