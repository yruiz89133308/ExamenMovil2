using Xamarin.Forms;

namespace PMO2EXAMEN3.ModelView
{
    internal class ListaViewModel
    {
        private INavigation navigation;

        public ListaViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}