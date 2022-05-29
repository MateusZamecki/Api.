using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Comum.Repositorios
{
    public static class Conexao
    {        public static string Url() 
            => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Api.Net;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
