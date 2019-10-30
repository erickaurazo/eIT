using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transportista.Datos;

namespace Transportista.Negocios
{
    public class TipoMovilidadNeg
    {
        private TipoMovilidad tipo;

        public List<TipoMovilidad> ListarTiposdeMovilidad()
        {
            #region 
            List<TipoMovilidad> ListarTiposdeMovilidad = new List<TipoMovilidad>();
            tipo = new TipoMovilidad();
            tipo.IdTipoMovilidad = "000";
            tipo.TipoMovil = "SELECIONAR VALOR";
            ListarTiposdeMovilidad.Add(tipo);

            tipo = new TipoMovilidad();
            tipo.IdTipoMovilidad = "001";
            tipo.TipoMovil = "COASTER";
            ListarTiposdeMovilidad.Add(tipo);

            tipo = new TipoMovilidad();
            tipo.IdTipoMovilidad = "002";
            tipo.TipoMovil = "BUS";
            ListarTiposdeMovilidad.Add(tipo);

            tipo = new TipoMovilidad();
            tipo.IdTipoMovilidad = "003";
            tipo.TipoMovil = "COMBI";
            ListarTiposdeMovilidad.Add(tipo);

            #endregion
            return ListarTiposdeMovilidad;
        }

    }
}
