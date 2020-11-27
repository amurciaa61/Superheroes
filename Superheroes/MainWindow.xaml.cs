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
            int indiceMaximo = heroes.Count;
            int indice;
            if (indiceActual == indiceMaximo)
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
            int indiceMaximo = heroes.Count;
            int indice;
            if (indiceActual == 1)
                indice = indiceMaximo;
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
        }
        public void ActualizaIndice(int indice)
        {
            numeroImagenTextBlock.Text = indice.ToString()+"/"+heroes.Count.ToString();
           // MessageBox.Show(indice.ToString() + "/" + heroes.Count.ToString());
        }
    }
}
