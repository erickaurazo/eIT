using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Globalization;


namespace RecursosHumanos.Negocios
{
    public class Mes
    {
        List<MesesObj> Meses = new List<MesesObj>();
        MesesObj obj = new MesesObj();

        public List<MesesObj> ListarMeses()
        {

            obj = new MesesObj();
            obj.Valor = "00";
            obj.Descripcion = "TODOS";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "01";
            obj.Descripcion = "ENERO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "02";
            obj.Descripcion = "FEBRERO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "03";
            obj.Descripcion = "MARZO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "04";
            obj.Descripcion = "ABRIL";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "05";
            obj.Descripcion = "MAYO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "06";
            obj.Descripcion = "JUNIO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "07";
            obj.Descripcion = "JULIO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "08";
            obj.Descripcion = "AGOSTO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "09";
            obj.Descripcion = "SETIEMBRE";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "10";
            obj.Descripcion = "OCTUBRE";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "11";
            obj.Descripcion = "NOVIEMBRE";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "12";
            obj.Descripcion = "DICIEMBRE";
            Meses.Add(obj);


            obj = new MesesObj();
            obj.Valor = "13";
            obj.Descripcion = "PERSONALIZADO";
            Meses.Add(obj);

            return Meses.ToList();
        }

        public List<MesesObj> ListarDoceMeses()
        {

          

            obj = new MesesObj();
            obj.Valor = "01";
            obj.Descripcion = "ENERO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "02";
            obj.Descripcion = "FEBRERO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "03";
            obj.Descripcion = "MARZO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "04";
            obj.Descripcion = "ABRIL";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "05";
            obj.Descripcion = "MAYO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "06";
            obj.Descripcion = "JUNIO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "07";
            obj.Descripcion = "JULIO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "08";
            obj.Descripcion = "AGOSTO";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "09";
            obj.Descripcion = "SETIEMBRE";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "10";
            obj.Descripcion = "OCTUBRE";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "11";
            obj.Descripcion = "NOVIEMBRE";
            Meses.Add(obj);

            obj = new MesesObj();
            obj.Valor = "12";
            obj.Descripcion = "DICIEMBRE";
            Meses.Add(obj);



            return Meses.ToList();
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

    }
}
