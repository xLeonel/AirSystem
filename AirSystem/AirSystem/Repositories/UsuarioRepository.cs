using AirSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSystem.Repositories
{
    public class UsuarioRepository
    {
        private static List<Usuario> usuarios;
        private static int id = 1;

        public UsuarioRepository()
        {
            if (usuarios == null)
            {
                usuarios = new List<Usuario>();
            }
        }

        public bool Cadastrar(Usuario usuario)
        {
            usuario.Id = id;
            usuarios.Add(usuario);
            id++;
            return true;
        }

        public List<Usuario> BuscarTodos()
        {
            return usuarios;
        }
    }
}
