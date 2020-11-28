using System;
using System.Collections.Generic;
using System.Windows;


namespace Superheroes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Superheroe> heroes;
        
        public MainWindow()
        {
            InitializeComponent();
            heroes = Superheroe.GetSamples();
            BindingDelObjeto(1);
            ActualizaIndice(1);
        }

        private void FlechaAdelanteImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int indiceActual = ObtenerIndiceActual();
            int indice = (indiceActual == heroes.Count) ? 1 : indiceActual + 1;
            BindingDelObjeto(indice);
            ActualizaIndice(indice);
        }
        private void FlechaAtrasImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int indiceActual = ObtenerIndiceActual();
            int indice = (indiceActual == 1) ? heroes.Count : indiceActual - 1;
            BindingDelObjeto(indice);
            ActualizaIndice(indice);
        }
        public void BindingDelObjeto(int indice)
        {
            indice--;
            Superheroe superheroe = heroes[indice];
            principalGrid.DataContext = superheroe;
        }
        public void ActualizaIndice(int indice)
        {
            numeroImagenTextBlock.Text = indice.ToString()+"/"+heroes.Count.ToString();
        }
        public int ObtenerIndiceActual()
        {
            string[] valores = numeroImagenTextBlock.Text.Split('/');
            return Int32.Parse(valores[0]);
        }
        private void AceptarButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Superhéroe insertado con éxito", "Superhéroes",MessageBoxButton.OK,MessageBoxImage.Information);
            bool vengadores = (vengadoresCheckBox.IsChecked == true);
            bool heroe = (heroeRadioButton.IsChecked == true);
            bool villano = (villanoRadioButton.IsChecked == true);
            bool xmen = (xmeCheckBox.IsChecked == true);
            heroes.Add(new Superheroe(nombreSuperheroeTexBox.Text, imagenSuperheroeTexBox.Text, vengadores, xmen, heroe, villano));
            ActualizaIndice(ObtenerIndiceActual());
            LimpiarFormulario();
        }

        private void LimpiarButton(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();

        }
        private void LimpiarFormulario()
        {
            nombreSuperheroeTexBox.Text = "";
            imagenSuperheroeTexBox.Text = "";
            heroeRadioButton.IsChecked = true;
        }
    }
}
