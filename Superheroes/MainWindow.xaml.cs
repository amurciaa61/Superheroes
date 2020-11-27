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

        private void flechaAdelanteImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string valorActual = numeroImagenTextBlock.Text;
            string[] valores = valorActual.Split('/');
            int indiceActual = Int32.Parse(valores[0]);
            int indice;
            if (indiceActual == heroes.Count)
                indice = 1;
            else
                indice = indiceActual + 1;
            BindingDelObjeto(indice);
            ActualizaIndice(indice);
        }
        private void flechaAtrasImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string valorActual = numeroImagenTextBlock.Text;
            string[] valores = valorActual.Split('/');
            int indiceActual = Int32.Parse(valores[0]);
            int indice;
            if (indiceActual == 1)
                indice = heroes.Count;
            else
                indice = indiceActual - 1;
            BindingDelObjeto(indice);
            ActualizaIndice(indice);
        }
        public void BindingDelObjeto(int indice)
        {
            indice--;
            nombreHeroeTextBlock.DataContext = heroes[indice];
            imagenHeroeVillanoImage.DataContext = heroes[indice];
            pestaña1DockPanel.DataContext = heroes[indice];
            vengadorImage.DataContext = heroes[indice];
            xmenImage.DataContext = heroes[indice];
        }
        public void ActualizaIndice(int indice)
        {
            numeroImagenTextBlock.Text = indice.ToString()+"/"+heroes.Count.ToString();
        }
    }
}
