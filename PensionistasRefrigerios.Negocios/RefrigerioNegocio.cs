using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using TransportistaMto.Datos;

namespace Transportista.Negocios
{
    public class RefrigerioNegocio
    {
        private Refrigerio Obj;
        public List<Refrigerio> ListaRefrigerios()
        {

            List<Refrigerio> Lista = new List<Refrigerio>();

            Obj = new Refrigerio();
            Obj.TipoRefrigerio = "D";
            Obj.Descripcion = "Desayuno";
            Lista.Add(Obj);

            Obj = new Refrigerio();
            Obj.TipoRefrigerio = "A";
            Obj.Descripcion = "Almuerzo";
            Lista.Add(Obj);

            Obj = new Refrigerio();
            Obj.TipoRefrigerio = "C";
            Obj.Descripcion = "Cena";
            Lista.Add(Obj);

            Obj = new Refrigerio();
            Obj.TipoRefrigerio = "O";
            Obj.Descripcion = "Otro";
            Lista.Add(Obj);

            return Lista;
        }

    }
}
