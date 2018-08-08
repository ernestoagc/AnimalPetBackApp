using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
namespace DataAccess
{
    class ListaDA
    {
        public List<LISTA> Get()
        {
            try
            {
                List<LISTA> Listado = new List<LISTA>();
                using (dbVeterinariaEntities db = new dbVeterinariaEntities())
                {
                    var lstALMACENs = (from elem in db.LISTA
                                       select new LISTA());

                    //Listado.AddRange(lstALMACENs.ToList());
                }

                return Listado;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
