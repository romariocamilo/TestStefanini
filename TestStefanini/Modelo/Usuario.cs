using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStefanini.Modelo
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SobreNomeUsuario { get; set; }

        public Usuario(int idUsuario, string nomeUsuario, string sobreNome, string emailsuario)
        {
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            SobreNomeUsuario = sobreNome;
            EmailUsuario = emailsuario;
        }
    }
}
