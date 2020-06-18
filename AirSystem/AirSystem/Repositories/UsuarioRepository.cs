using AirSystem.Database;
using AirSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem.Repositories
{
    public class UsuarioRepository
    {
        AirSystemContext ctx = new AirSystemContext();

        public bool Cadastrar(Usuarios user)
        {
            try
            {
                ctx.Usuarios.Add(user);
                ctx.SaveChanges();
                return true;

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
                return false;

            }
        }

        public List<Usuarios> BuscarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuarios BuscarTodosUsername(string username)
        {
            try
            {
                return ctx.Usuarios.ToList().Find(u => u.Tx_Usuario == username);
            }
            catch (DbEntityValidationException)
            {   
                return null;
            }

        }
        public Usuarios BuscarId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
        }

        public void Deletar(int id)
        {
            Usuarios user = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            ctx.Usuarios.Remove(user);
            ctx.SaveChanges();
        }

        public void Atualizar(Usuarios userGrid)
        {
            try
            {
                Usuarios u = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == userGrid.IdUsuario);

                u.Tx_Nome = userGrid.Tx_Nome;
                u.Tx_Sobrenome = userGrid.Tx_Sobrenome;
                u.Tx_Logradouro = userGrid.Tx_Logradouro;
                u.Nr_Casa = userGrid.Nr_Casa;
                u.Dt_Nascimento = userGrid.Dt_Nascimento;
                u.Tx_Usuario = userGrid.Tx_Usuario;
                u.Tx_Senha = userGrid.Tx_Senha;
                u.Tx_CaminhoFoto = userGrid.Tx_CaminhoFoto;
                u.IsAdmin = userGrid.IsAdmin;

                ctx.Usuarios.AddOrUpdate(u);
                ctx.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }

        public Usuarios BuscarUsuario(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Tx_Usuario == email && u.Tx_Senha == senha);
        }
    }
}
