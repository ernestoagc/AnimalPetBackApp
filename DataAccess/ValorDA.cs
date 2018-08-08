using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
namespace DataAccess
{
    public class ValorDA
    {

        private static ValorDA instanciaValorDA = null;
        public static ValorDA getValorDA
        {
            get
            {
                if (instanciaValorDA == null)
                    instanciaValorDA = new ValorDA();
                return instanciaValorDA;
            }
        }

        public List<ValorBE> Get(ValorBE.Criterio pCriterio)
        {
            try
            {
                List<ValorBE> listado = new List<ValorBE>();
                using (dbVeterinariaEntities db = new dbVeterinariaEntities())
                {
                    var lstQuery = (from elem in db.VALOR
                                    select new ValorBE()
                                    {
                                        id = elem.ID,
                                        codigo = elem.CODIGO,
                                        listaCodigo = elem.LISTA1.CODIGO,
                                        listaNombre = elem.LISTA1.NOMBRE,
                                        valor=elem.VALOR1
                                       
                                        

                                    }).ToList();

                    if (lstQuery != null)
                    {
                        listado.AddRange(lstQuery.ToList());
                    }

                }


                if (pCriterio != null)
                {
                    if (!string.IsNullOrEmpty(pCriterio.LISTA_CODIGO))
                    {
                        listado = listado.FindAll(t => t.listaCodigo.Equals(pCriterio.LISTA_CODIGO));
                    }

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
