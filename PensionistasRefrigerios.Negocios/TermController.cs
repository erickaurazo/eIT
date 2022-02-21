using Asistencia.Datos;
using Asistencia.Negocios;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Asistencia.Negocios
{
    public class TermController
    {

        public List<Grupo> FindTerms(string conection) // Obtener comboBox tipo de dispositivos
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["SAS"];
            var typeTerms = new List<Grupo>();
            //seat.Add(new Grupo { Codigo = "000", Descripcion = "Selecionar item" });
            if (conection != string.Empty)
            {
                using (SATURNODataContext contexto = new SATURNODataContext(cnx))
                {

                    typeTerms = (
                        from item in contexto.ESTADO_PRODUCTOS
                        where item.IDESTADOPRODUCTO.ToString().Trim() != string.Empty
                        group item by new { item.IDESTADOPRODUCTO } into j
                        select new Grupo
                        {
                            Codigo = j.Key.IDESTADOPRODUCTO.ToString().Trim(),
                            Descripcion = j.FirstOrDefault().DESCRIPCION != null ? j.FirstOrDefault().DESCRIPCION.Trim() : string.Empty,
                        }
                        ).ToList();
                }
            }
            return typeTerms.OrderBy(x => x.Codigo).ToList();
        }

    }
}
