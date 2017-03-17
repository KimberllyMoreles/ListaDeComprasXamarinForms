using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaDeCompras.ViewModel;
using Xamarin.Forms;

namespace ListaDeComprasXamarin.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ProdutosVM();
        }
    }
}
