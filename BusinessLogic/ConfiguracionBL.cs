using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessEntities;
namespace BusinessLogic
{
   public class ConfiguracionBL
    {
        ValorDA oValorDA = ValorDA.getValorDA;
        ServicioDA servicioDA = ServicioDA.getServicioDA;

        private static ConfiguracionBL instanciaConfiguracionBL = null;
        public static ConfiguracionBL getConfiguracionBL
        {
            get
            {
                if (instanciaConfiguracionBL == null)
                    instanciaConfiguracionBL = new ConfiguracionBL();
                return instanciaConfiguracionBL;
            }
        }


        public List<ValorBE> getValor(ValorBE.Criterio pCriterio) {

            return  oValorDA.Get(pCriterio);
        }

        public List<ServicioBE> getServicio(ServicioBE.Criterio pCriterio)
        {
            return servicioDA.get(pCriterio);
        }
    }
}
