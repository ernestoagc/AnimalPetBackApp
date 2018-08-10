using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace DataAccess
{
    public class UsuarioDA
    {

        private static UsuarioDA instanciaUsuarioDA = null;
        public static UsuarioDA getUsuarioDA
        {
            get
            {
                if (instanciaUsuarioDA == null)
                    instanciaUsuarioDA = new UsuarioDA();
                return instanciaUsuarioDA;
            }
        }

        public List<UsuarioBE> get(UsuarioBE.Criterio pCriterio)
        {
            try
            {
                List<UsuarioBE> listado = new List<UsuarioBE>();
                using (dbVeterinariaEntities db = new dbVeterinariaEntities())
                {
                    var lstQuery = (from elem in db.USUARIO
                                    select new UsuarioBE()
                                    {
                                        id = elem.ID,
                                        usuario = elem.USUARIO1,
                                        apellidoMaterno = elem.APELLIDO_MATERNO,
                                        apellidoPaterno = elem.APELLIDO_PATERNO,
                                        perfilNombre = elem.PERFIL1.NOMBRE
                                    }).ToList();

                    if (lstQuery != null)
                    {
                        listado.AddRange(lstQuery.ToList());
                    }

                }


                if (pCriterio != null)
                {
                    if (!string.IsNullOrEmpty(pCriterio.USUARIO))
                    {
                        listado = listado.FindAll(t => t.usuario.Equals(pCriterio.USUARIO));
                    }

                    if (pCriterio.ID!=0)
                    {
                        listado = listado.FindAll(t => t.id.Equals(pCriterio.ID));
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
