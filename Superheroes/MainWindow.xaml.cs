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
        Superheroe heroe = null;     
        
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
            pestaña1DockPanel.DataContext = heroes[indice];
            heroe = new Superheroe();
            pestaña2Grid.DataContext = heroe;
            heroe.Heroe = true;
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
            pestaña2Grid.DataContext = heroe;
            MessageBox.Show("Superhéroe insertado con éxito", "Superhéroes",MessageBoxButton.OK,MessageBoxImage.Information);
            heroes.Add(heroe);
            ActualizaIndice(ObtenerIndiceActual());
            LimpiarFormulario();
        }

        private void LimpiarButton(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();

        }
        private void LimpiarFormulario()
        {
            heroe = new Superheroe();
            pestaña2Grid.DataContext = heroe;
            heroe.Heroe = true;
        }
    }
}
