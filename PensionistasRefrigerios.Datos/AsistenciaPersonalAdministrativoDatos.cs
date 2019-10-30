using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace TransportistaMto.Datos
{
    public class AsistenciaPersonalAdministrativoDatos
    {

        private string StrConexion;
        private OleDbConnection Conexion;
        private OleDbDataAdapter Adapter;
        private DataSet miDataSet = new DataSet();
        private string sql;


        public void IniciarConexion(string DataBase)
        {
            //Creo la cadena de conexion para Office 2007
            //StrConexion = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + DataBase; //Objeto conexion
            StrConexion = @"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=Z:\\att.mdb ;Persist Security Info=False";
            Conexion = new OleDbConnection(StrConexion);
        }

        public int EjecutarConsultaSQL(string sql)
        {
            int i = 0;
            try
            {
                #region Ejecutar consulta

                //inserto en la BD
                //IniciarConexion("");                

                StrConexion = @"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=Z:\\att.mdb ;Persist Security Info=False";
                Conexion = new OleDbConnection(StrConexion);
                try
                {
                    Conexion.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, Conexion);
                    i = cmd.ExecuteNonQuery();
                }
                catch
                {
                    i = -1;
                }


                #endregion
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }

            return i;
        }

        public DataTable Consultar(string sql, string tabla)
        {
            try
            {
                Adapter = new OleDbDataAdapter(sql, Conexion);
                //Creo el DataTable
                DataTable dt = new DataTable();
                miDataSet = new DataSet();
                //Relleno el adaptador con los datos en memoria
                Adapter.Fill(miDataSet);

                return
                miDataSet.Tables["CHECKINOUT"];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }


        public int Anular(PersonalAdministrativo personalAdministrativo)
        {
            #region Registrar()
            sql = "UPDATE CHECKINOUT";
            sql += " SET Memoinfo = '" + "AN" + "'";
            sql += " WHERE USERID  = " + Convert.ToInt32(personalAdministrativo.codigoPersonal.Trim());
            sql += " AND CHECKTIME = #" + String.Format("{0:MM/dd/yyyy HH:mm:ss}", personalAdministrativo.fecha.Value) + "#";

            int filasAfectadas = EjecutarConsultaSQL(sql);
            if (filasAfectadas == 1) //Si se logro la insercion limpio el formulario             
            {

            }
            else
            {
                filasAfectadas = 0;
            }

            return filasAfectadas;
            #endregion
        }


    }
}
