using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Drawing;
//using iTextSharp;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.Windows.Forms;


namespace RecursosHumanos
{
    public static class UtilControles
    {
        #region Colores Basicos para Grillas

        public static Color colorAmarrilloClaro = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(192)))));

        public static Color colorAmarilloMedio = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(128)))));

        public static Color colorVerdeClaro = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(192)))),
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(192)))));


        public static Color colorBlancoHumo = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(239)))),
                                            ((int)(((byte)(213)))));
        /* rojo bajito */
        public static Color colorMistyRose = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(228)))),
                                            ((int)(((byte)(225)))));

        /* amarillo bajito  255,255,205*/
        public static Color colorBlanchedAlmond = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(205)))));


        public static Color colorVerdeMedio = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(128)))),
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(128)))));

        public static Color colorRojoClaro = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(192)))),
                                            ((int)(((byte)(192)))));

        public static Color colorRojoMedio = System.Drawing.Color.FromArgb(
                                            ((int)(((byte)(255)))),
                                            ((int)(((byte)(128)))),
                                            ((int)(((byte)(128)))));

        public static Color colorCelesteMedio = System.Drawing.SystemColors.GradientInactiveCaption;

        public static Color colorVioletaClaro = System.Drawing.Color.FromArgb(
                                    ((int)(((byte)(192)))),
                                    ((int)(((byte)(192)))),
                                    ((int)(((byte)(255)))));


        #endregion

        #region Exportacion Excel

        public static int FilaInicial = 4;
        public static int ColumnaInicial = 2;
        //public string data;

        public static void ExportarDataTableExcel(System.Data.DataTable tablaDatos, string tituloReporte)
        {
            string vFileName = Path.GetTempFileName();
            string rutaArch = Path.GetTempFileName().Replace("tmp", "xls");
            File.Delete(rutaArch);

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range rangoFormato;
            Excel.Range rangoCuerpo;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int x = FilaInicial;
            int y = ColumnaInicial;
            int x2 = 2;
            int y2 = 4;

            xlWorkSheet.Cells[2, 10] = tituloReporte;
            rangoFormato = xlWorkSheet.get_Range("D2", "P2");
            rangoFormato.Font.Bold = true;
            rangoFormato.Merge();

            foreach (DataColumn columna in tablaDatos.Columns)
            {
                xlWorkSheet.Cells[x, y] = columna.ColumnName;
                rangoFormato = xlWorkSheet.get_Range(ObtenerNombreColumna(y) + x, ObtenerNombreColumna(y) + x);
                rangoFormato.Font.Bold = true;
                rangoFormato.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                rangoFormato.EntireColumn.AutoFit();
                rangoFormato.Orientation = 0;

                y2 += 1;
                x2 = 4;
                y++;
            }
            x++;

            string xCabecera, yCabecera;
            xCabecera = ObtenerNombreColumna(y2) + x2;
            yCabecera = ObtenerNombreColumna(2) + x2;
            //tope = ObtenerNombreColumna(j2) + i2;
            //topeinicio = ObtenerNombreColumna(1) + i2;

            foreach (DataRow row in tablaDatos.Rows)
            {
                y = 2;
                foreach (object item in row.ItemArray)
                {
                    xlWorkSheet.Cells[x, y] = item.ToString();
                    y2 = 2;
                    x2++;
                    y++;
                }
                x++;
            }

            string xCola, yCola;
            xCola = ObtenerNombreColumna(y) + x;
            yCola = ObtenerNombreColumna(y2) + x;

            rangoCuerpo = xlWorkSheet.get_Range(yCabecera, xCola);
            //rangoCuerpo.Font.Bold = true;
            rangoCuerpo.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            rangoCuerpo.EntireColumn.AutoFit();
            rangoCuerpo.Borders.LineStyle = 1;

            xlWorkBook.SaveAs(rutaArch, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            Process.Start(rutaArch, "Excel.exe");
        }

        public static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        public static string ObtenerNombreColumna(int indice)
        {
            string letra = "";
            switch (indice)
            {
                case 1:
                    letra = "A";
                    break;

                case 2:
                    letra = "B";
                    break;

                case 3:
                    letra = "C";
                    break;

                case 4:
                    letra = "D";
                    break;

                case 5:
                    letra = "E";
                    break;

                case 6:
                    letra = "F";
                    break;

                case 7:
                    letra = "G";
                    break;

                case 8:
                    letra = "H";
                    break;

                case 9:
                    letra = "I";
                    break;

                case 10:
                    letra = "J";
                    break;

                case 11:
                    letra = "K";
                    break;

                case 12:
                    letra = "L";
                    break;

                case 13:
                    letra = "M";
                    break;

                case 14:
                    letra = "N";
                    break;

                case 15:
                    letra = "O";
                    break;

                case 16:
                    letra = "P";
                    break;

                case 17:
                    letra = "Q";
                    break;

                case 18:
                    letra = "R";
                    break;

                case 19:
                    letra = "S";
                    break;

                case 20:
                    letra = "T";
                    break;

                case 21:
                    letra = "U";
                    break;

                case 22:
                    letra = "V";
                    break;

                case 23:
                    letra = "W";
                    break;

                case 24:
                    letra = "X";
                    break;

                case 25:
                    letra = "Y";
                    break;

                case 26:
                    letra = "Z";
                    break;

                case 27:
                    letra = "AA";
                    break;

                case 28:
                    letra = "AB";
                    break;

                //----------------------

                case 29:
                    letra = "AC";
                    break;

                case 30:
                    letra = "AD";
                    break;

                case 31:
                    letra = "AE";
                    break;

                case 32:
                    letra = "AF";
                    break;

                case 33:
                    letra = "AG";
                    break;

                case 34:
                    letra = "AH";
                    break;

                case 35:
                    letra = "AI";
                    break;

                case 36:
                    letra = "AJ";
                    break;

                case 37:
                    letra = "AK";
                    break;

                case 38:
                    letra = "AL";
                    break;

                case 39:
                    letra = "AM";
                    break;

                case 40:
                    letra = "AN";
                    break;

                case 41:
                    letra = "AO";
                    break;

                case 42:
                    letra = "AP";
                    break;

                case 43:
                    letra = "AQ";
                    break;

                case 44:
                    letra = "AR";
                    break;

                case 45:
                    letra = "AS";
                    break;

                case 46:
                    letra = "AT";
                    break;

                case 47:
                    letra = "AU";
                    break;

                case 48:
                    letra = "AV";
                    break;

                case 49:
                    letra = "AW";
                    break;

                case 50:
                    letra = "AX";
                    break;

                case 51:
                    letra = "AY";
                    break;

                case 52:
                    letra = "AZ";
                    break;

                case 53:
                    letra = "BA";
                    break;

                case 54:
                    letra = "BB";
                    break;

                case 55:
                    letra = "BC";
                    break;

                case 56:
                    letra = "BD";
                    break;

                case 57:
                    letra = "BE";
                    break;

                case 58:
                    letra = "BF";
                    break;

                case 59:
                    letra = "BG";
                    break;

                case 60:
                    letra = "BH";
                    break;

                case 61:
                    letra = "BI";
                    break;

                case 62:
                    letra = "BJ";
                    break;

                case 63:
                    letra = "BK";
                    break;

                case 64:
                    letra = "BL";
                    break;

                case 65:
                    letra = "BM";
                    break;

                case 66:
                    letra = "BN";
                    break;

                case 67:
                    letra = "BO";
                    break;

                case 68:
                    letra = "BP";
                    break;

                case 69:
                    letra = "BQ";
                    break;

                case 70:
                    letra = "BR";
                    break;

                case 71:
                    letra = "BS";
                    break;

                case 72:
                    letra = "BT";
                    break;

                case 73:
                    letra = "BU";
                    break;

                case 74:
                    letra = "BV";
                    break;

                case 75:
                    letra = "BW";
                    break;

                case 76:
                    letra = "BX";
                    break;

                case 77:
                    letra = "BY";
                    break;

                case 78:
                    letra = "BZ";
                    break;

                case 79:
                    letra = "CA";
                    break;

                case 80:
                    letra = "CB";
                    break;

                case 81:
                    letra = "CC";
                    break;

                case 82:
                    letra = "CD";
                    break;

                case 83:
                    letra = "CE";
                    break;

                case 84:
                    letra = "CF";
                    break;

                case 85:
                    letra = "CG";
                    break;

                case 86:
                    letra = "CH";
                    break;

                case 87:
                    letra = "CI";
                    break;

                case 88:
                    letra = "CJ";
                    break;

                case 89:
                    letra = "CK";
                    break;

                case 90:
                    letra = "CL";
                    break;

                case 91:
                    letra = "CM";
                    break;

                case 92:
                    letra = "CN";
                    break;

                case 93:
                    letra = "CO";
                    break;

                case 94:
                    letra = "CP";
                    break;

                case 95:
                    letra = "CQ";
                    break;

                case 96:
                    letra = "CR";
                    break;

                case 97:
                    letra = "CS";
                    break;

                case 98:
                    letra = "CT";
                    break;

                case 99:
                    letra = "CU";
                    break;

                case 100:
                    letra = "CV";
                    break;

                case 101:
                    letra = "CW";
                    break;

                case 102:
                    letra = "CX";
                    break;

                case 103:
                    letra = "CY";
                    break;

                case 104:
                    letra = "CZ";
                    break;

                case 105:
                    letra = "DA";
                    break;

                case 106:
                    letra = "DB";
                    break;

                case 107:
                    letra = "DC";
                    break;

                case 108:
                    letra = "DD";
                    break;

                case 109:
                    letra = "DE";
                    break;

                case 110:
                    letra = "DF";
                    break;

                case 111:
                    letra = "DG";
                    break;

                case 112:
                    letra = "DH";
                    break;

                case 113:
                    letra = "DI";
                    break;

                case 114:
                    letra = "DJ";
                    break;

                case 115:
                    letra = "DK";
                    break;

                case 116:
                    letra = "DL";
                    break;

                case 117:
                    letra = "DM";
                    break;

                case 118:
                    letra = "DN";
                    break;

                case 119:
                    letra = "DO";
                    break;

                case 120:
                    letra = "DP";
                    break;

            }
            return letra;
        }
        #endregion

        #region  iReport
        /*
     public static Paragraph GenerarParrafo()
        {

            //Creamos un nuevo parrafo, por ejemplo el titulo de nuestro reporte
            //Y le damos algunas propiedades.
            //Console.WriteLine("Generando un parrafo...");

            Paragraph parrafo = new Paragraph();

            parrafo.Alignment = Element.ALIGN_CENTER;
            parrafo.Font = FontFactory.GetFont("Arial", 10);
            parrafo.Font.SetStyle(iTextSharp.text.Font.BOLD);
            parrafo.Font.SetStyle(iTextSharp.text.Font.UNDERLINE);

            parrafo.Add("Reporte Cosecha" + " al " + DateTime.Now);

            return parrafo;
     
        }
     */

        /* public static Image GenerarImagen()
         {
             //Generamos imágen
             Console.WriteLine("Generando una imágen...");

             byte[] bytesImagen = new System.Drawing.ImageConverter().ConvertTo(Recursos.cat, typeof(byte[])) as byte[];
             Image imagen = Image.GetInstance(bytesImagen);
             imagen.Alignment = Element.ALIGN_CENTER;

             return imagen;
         }*/

        //public static PdfPTable GenerarTabla(System.Data.DataTable tablaDatos, string tituloReporte)
        //{
        //    //Console.WriteLine("Generando una tabla...");

        //    PdfPTable unaTabla = new PdfPTable(31);
        //    unaTabla.SetWidthPercentage(new float[] { 20, 40, 30, 20, 20, 20, 30, 30, 30, 30,
        //                                              30, 30, 30, 20, 20, 30, 30, 30, 30, 30,
        //                                              30, 30, 30, 20, 20, 30, 30, 30, 30, 30, 30}, PageSize.A4.Rotate());

        //    string vFileName = Path.GetTempFileName();
        //    string rutaArch = Path.GetTempFileName().Replace("tmp", "xls");
        //    File.Delete(rutaArch);

        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    object misValue = System.Reflection.Missing.Value;
        //    Excel.Range rangoFormato;
        //    Excel.Range rangoCuerpo;

        //    xlApp = new Excel.ApplicationClass();
        //    xlWorkBook = xlApp.Workbooks.Add(misValue);
        //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //    int x = FilaInicial;
        //    int y = ColumnaInicial;
        //    int x2 = 2;
        //    int y2 = 4;

        //    xlWorkSheet.Cells[2, 10] = tituloReporte;
        //    //rangoFormato = xlWorkSheet.get_Range("D2", "J2");
        //    //rangoFormato.Font.Bold = true;
        //    //rangoFormato.Merge();

        //    foreach (DataColumn columna in tablaDatos.Columns)
        //    {
        //        xlWorkSheet.Cells[x, y] = columna.ColumnName;
        //        rangoFormato = xlWorkSheet.get_Range(ObtenerNombreColumna(y) + x, ObtenerNombreColumna(y) + x);
        //        //rangoFormato.Font.Bold = true;
        //        //rangoFormato.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
        //        //rangoFormato.EntireColumn.AutoFit();

        //       // rangoFormato.Orientation = 90;

        //        y2 += 1;
        //        x2 = 4;
        //        y++;
        //        string obNombre = Convert.ToString(columna);
        //        //PdfPCell celda1 = new PdfPCell(new Paragraph(Convert.ToString(columna), FontFactory.GetFont("Arial", 5)));
        //        PdfPCell celda1 = new PdfPCell(new Paragraph(Convert.ToString(columna), FontFactory.GetFont("Arial", 8)));
        //        //unaTabla.AddCell(new Paragraph("Columna 1"));
        //        //unaTabla.AddCell(new Paragraph(obNombre));
        //        unaTabla.AddCell((celda1));
        //    }
        //    x++;

        //    string xCabecera, yCabecera;
        //    xCabecera = ObtenerNombreColumna(y2) + x2;
        //    yCabecera = ObtenerNombreColumna(2) + x2;

        //    //tope = ObtenerNombreColumna(j2) + i2;
        //    //topeinicio = ObtenerNombreColumna(1) + i2;

        //    foreach (DataRow row in tablaDatos.Rows)
        //    {
        //        y = 2;
        //        foreach (object item in row.ItemArray)
        //        {
        //            xlWorkSheet.Cells[x, y] = item.ToString();
        //            y2 = 2;
        //            x2++;
        //            y++;

        //            PdfPCell celda1 = new PdfPCell(new Paragraph(Convert.ToString(item), FontFactory.GetFont("Arial", 8)));
        //            unaTabla.AddCell(celda1);
        //        }
        //        x++;
        //    }

        //    string xCola, yCola;
        //    xCola = ObtenerNombreColumna(y) + x;
        //    yCola = ObtenerNombreColumna(y2) + x;

        //    rangoCuerpo = xlWorkSheet.get_Range(yCabecera, xCola);
        //    //rangoCuerpo.Font.Bold = true;
        //    //rangoCuerpo.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
        //    //rangoCuerpo.EntireColumn.AutoFit();
        //    //rangoCuerpo.Borders.LineStyle = 1;


        //   // xlWorkBook.SaveAs(rutaArch, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //    //xlWorkBook.Close(true, misValue, misValue);
        //    //xlApp.Quit();

        //    //releaseObject(xlWorkSheet);
        //    //releaseObject(xlWorkBook);
        //    //releaseObject(xlApp);

        //    //Headers
        //    //unaTabla.AddCell(new Paragraph("Columna 1"));
        //    //unaTabla.AddCell(new Paragraph("Columna 2"));


        //    //¿Le damos un poco de formato?
        //    foreach (PdfPCell celda1 in unaTabla.Rows[0].GetCells())
        //    {
        //        celda1.BackgroundColor = BaseColor.YELLOW;
        //        //celda1.HorizontalAlignment = 1;
        //        celda1.Padding = 5;
        //        celda1.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
        //        //colocarlo vertical
        //        celda1.Rotation = 90;
        //        //celda1.UseDescender = true;
        //        //celda1.UseAscender = true;
        //        //celda1.PaddingTop = 1;
        //        //celda1.PaddingRight = 1;
        //        //celda1.PaddingLeft = 1;
        //        //celda1.PaddingBottom = 1;
        //        //celda1.NoWrap = true;
        //        //celda1.Colspan = 1;
        //        //celda1.Width = 10;
        //    }
        //    return unaTabla;
        //}

        public static float[] GetColumnasSize(DataGridView tablaDatos)
        {
            float[] values = new float[tablaDatos.ColumnCount - 1];
            for
            (int i = 0; i < tablaDatos.ColumnCount; i++)
            {
                values[i] = Convert.ToSingle(tablaDatos.Columns[i].Width);
            }
            return values;
        }



        #endregion

    }
}