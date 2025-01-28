using Microsoft.Win32; // Para los cuadros de diálogo
using System;
using System.IO;
using System.Windows;

namespace Tarea
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Evento para Abrir un archivo
        private void BotonAbrir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                Title = "Abrir Archivo"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string contenido = File.ReadAllText(openFileDialog.FileName);
                    Tindi.Text = contenido; // Mostrar contenido en el TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Evento para Guardar el archivo
        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                Title = "Guardar Archivo"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, Tindi.Text); // Guardar el contenido del TextBox
                    MessageBox.Show("Archivo guardado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Evento para Borrar el contenido del TextBox
        private void BotonBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas borrar el contenido?", "Confirmar Borrado",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Tindi.Clear(); // Limpia el contenido del TextBox
            }
        }
    }
}
