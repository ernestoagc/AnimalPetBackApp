using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
namespace DataAccess
{
    public class ServicioDA
    {
        private static ServicioDA instanciaServicioDA = null;
        public static ServicioDA getServicioDA
        {
            get
            {
                if (instanciaServicioDA == null)
                    instanciaServicioDA = new ServicioDA();
                return instanciaServicioDA;
            }
        }

        public List<ServicioBE> get(ServicioBE.Criterio pCriterio)
        {
            try
            {
                List<ServicioBE> listado = new List<ServicioBE>();
                using (dbVeterinariaEntities db = new dbVeterinariaEntities())
                {
                    var lstQuery = (from elem in db.SERVICIO
                                    select new ServicioBE()
                                    {
                                        id = elem.ID,
                                        codigo = elem.CODIGO,
                                        costo = elem.COSTO,
                                        nombre = elem.NOMBRE
                                    }).ToList();

                    if (lstQuery != null)
                    {
                        listado.AddRange(lstQuery.ToList());
                    }

                }


                if (pCriterio != null)
                {
                    if (!string.IsNullOrEmpty(pCriterio.CODIGO))
                    {
                        listado = listado.FindAll(t => t.codigo.Equals(pCriterio.CODIGO));
                    }
                }


                return listado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
