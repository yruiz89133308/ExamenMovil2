using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen3PMO2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        public Home()
        {
            InitializeComponent();

            OnAppearing();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ViewModel.ListaViewModel(Navigation);
        }
        private void menuToolbar_Clicked(object sender, EventArgs e)
        {

        }
    }
}