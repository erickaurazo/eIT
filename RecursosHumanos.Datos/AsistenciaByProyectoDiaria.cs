using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursosHumanos.Datos
{
    public class AsistenciaByProyectoDiaria
    {
        public DateTime fecha { get; set; }

        public int Semana { get; set; }
        public int NumeroMes { get; set; }
        public int NumeroAño { get; set; }
        public string idMedida { get; set; }
        public string NombreMes { get; set; }
        public string nombreDia { get; set; }

        public decimal uva { get; set; } /* 0001	UVA */
        public decimal caña { get; set; }  /* 0002	caña */
        public decimal fundo { get; set; }  /* 0003	fundo */
        public decimal gAdmin { get; set; }  /* 0004	g.admin */
        public decimal export { get; set; }  /* 0005	export */
        public decimal taller { get; set; }  /* 0006	taller*/
        public decimal arandano { get; set; }  /* 0007	arandano */
        public decimal palta { get; set; } /* 0008	palta */
        public decimal planillas { get; set; }  /*0009	planillas */
        public decimal impuestos { get; set; }  /* 0010	impuestos */
        public decimal planta { get; set; } /* 0011	planta */
        public decimal ventas { get; set; }  /* 0010	impuestos */
        public decimal sanidad { get; set; } /* 1001	sanidad */
        public decimal fertiRiego { get; set; } /* 1002	fertirriego */
        public decimal evaluaciones { get; set; } /* 1003	evaluaciones */
        public decimal areasVerdes { get; set; } /* 1004	areas verdes */
        public decimal vigilancia { get; set; } /* 1005	vigilancia */
        public decimal laboratorio { get; set; } /* 1006	laboratorio */
        public decimal canaSanJuan { get; set; } /* 1007	caña san juan */
        public decimal canaTablazosHuacaBlanca { get; set; } /* 1008	caña tablazos - huacablanca */
        //public decimal taller { get; set; } /* 1009	taller */
        public decimal serviciosGenerales { get; set; } /* 1011	servicios generales */
        public decimal ucupe { get; set; } /* 1012	ucupe */

        public decimal ConstanciasFallecimiento { get; set; }
        public decimal sinProyecto { get; set; }
        public decimal otros { get; set; }
        public decimal total { get; set; }


    }
}
