using AirSystem.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSystem.Repositories
{
    public class AcessoRepository
    {
        AirSystemContext ctx = new AirSystemContext();

        public bool Cadastrar(Acesso acesso)
        {
            try
            {
                ctx.Acesso.Add(acesso);
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

        public List<Acesso> BuscarTodos()
        {
            return ctx.Acesso.ToList();
        }
    }
}
