using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas;

namespace PupuseriaJenny.Utils
{
    public class CrearPDFDesdeDataTable
    {
        /// <summary>
        /// Genera un archivo PDF a partir de un DataTable y lo guarda en la ruta especificada.
        /// </summary>
        /// <param name="dataTable">El DataTable que contiene los datos a exportar.</param>
        /// <param name="archivoDestino">La ruta de destino donde se guardará el archivo PDF.</param>
        public static void GenerarPDFDesdeDataTable(DataTable dataTable, string archivoDestino)
        {
            try
            {
                // Verificar si el DataTable tiene filas y columnas
                if (dataTable == null || dataTable.Rows.Count == 0 || dataTable.Columns.Count == 0)
                {
                    throw new ArgumentException("El DataTable está vacío o no contiene columnas.");
                }

                // Crear el archivo PDF de salida
                using (FileStream fs = new FileStream(archivoDestino, FileMode.Create))
                {
                    // Inicializar el escritor de PDF
                    PdfWriter writer = new PdfWriter(fs);
                    PdfDocument pdf = new PdfDocument(writer);

                    // Inicializar el documento para agregar contenido
                    Document document = new Document(pdf);

                    // Crear una tabla en el PDF basada en las columnas del DataTable
                    Table tabla = new Table(dataTable.Columns.Count);

                    // Crear la fuente (usando Helvetica estándar)
                   // PdfFont font = PdfFontFactory.CreateFont(iText);


                    // Agregar los encabezados de las columnas
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        tabla.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Agregar las filas de datos
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            // Si el valor es null, mostrar un texto vacío
                            string cellText = item?.ToString() ?? string.Empty;
                            tabla.AddCell(new Cell().Add(new Paragraph(cellText)));
                        }
                    }

                    // Agregar la tabla al documento PDF
                    document.Add(tabla);

                    // Cerrar el documento
                    document.Close();
                }

                MessageBox.Show("PDF generado exitosamente en: " + archivoDestino, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Capturar y mostrar el error completo, incluyendo el stack trace
                MessageBox.Show("Error al generar el PDF: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra un cuadro de diálogo para que el usuario elija la ubicación de guardado del archivo PDF.
        /// </summary>
        /// <returns>La ruta seleccionada por el usuario para guardar el archivo.</returns>
        public static string ObtenerRutaGuardado()
        {
            // Crear un nuevo cuadro de diálogo para elegir la ubicación del archivo
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"; // Solo archivos PDF
                saveFileDialog.DefaultExt = "pdf"; // Extensión predeterminada
                saveFileDialog.AddExtension = true; // Agregar la extensión de forma automática

                // Mostrar el cuadro de diálogo y verificar si el usuario seleccionó una ruta
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName; // Retorna la ruta seleccionada por el usuario
                }
            }

            return string.Empty; // Si el usuario cancela, retornar una cadena vacía
        }
    }
}
