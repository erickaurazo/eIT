using Asistencia.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asistencia.Helper
{
    public class GlobalesHelper
    {
        public Grupo GetConfigInitialByLogin()
        {
            string cnx = string.Empty;
            var config = new Grupo();
            string path = Path.Combine(@"C:\Dev\ASJ\AsistenciaConfig.txt");
            path = Path.GetFullPath(path);
            string[] lines = System.IO.File.ReadAllLines(path);
            int count = 0;
            foreach (string line in lines)
            {
                count += 1;
                switch (count)
                {
                    case 2:
                        // usuario que se conecta a la base de datos
                        var db01 = line.Split(':');
                        config.userBydb = db01[1].Trim();
                        break;

                    case 3:
                        // clave del usuario que se conecta a la base de datos
                        var db02 = line.Split(':');
                        config.passwordBydb = db02[1].Trim();
                        break;

                    case 4:
                        //Instancia local
                        var db03 = line.Split(':');
                        config.isntanceLocal = db03[1].Trim();
                        break;

                    case 5:
                        //Instancia publica
                        var db04 = line.Split(':');
                        config.isntancePublic = db04[1].Trim();
                        break;


                    default:
                        break;
                }
                // Use a tab to indent each line of the file.               
            }

            return config;
        }

    }
}
