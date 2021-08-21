using Examen3PMO2.controller;
using Examen3PMO2.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SQLite;
using Examen3PMO2.ViewModel;

namespace Examen3PMO2.ViewModel
{
    public class ListaViewModel : BaseViewModel
{

    Crud crud = new Crud();
    private ObservableCollection<Personas> _persons;

    public ObservableCollection<Personas> Persons
    {
        get { return _persons; }
        set { _persons = value; OnPropertyChanged(); }
    }

    private Personas _selectedPersona;

    public Personas SelectedPersona
    {
        get { return _selectedPersona; }
        set { _selectedPersona = value; OnPropertyChanged(); }
    }

    public ICommand IrInformacionCommand { private set; get; }

    public INavigation Navigation { get; set; }

    public ListaViewModel(INavigation navigation)
    {
        Navigation = navigation;
        IrInformacionCommand = new Command<Type>(async (pageType) => await IrInformacion(pageType));

        Persons = new ObservableCollection<Personas>();

        mostrar();

    }


    public async void mostrar()
    {
        try
        {
            var personasList = await crud.getReadPersonas();
            foreach (var persons in personasList)
            {
                Persons.Add(new Personas
                {
                    id = persons.id,
                    pago = persons.pago,
                    descripcion = persons.descripcion,
                    monto = persons.monto,
                    fecha = persons.fecha,


                });
            }



        }
        catch (SQLiteException e)
        {


        }
    }

    async Task IrInformacion(Type pageType)
    {
        if (SelectedPersona != null)
        {
            var page = (Page)Activator.CreateInstance(pageType);

            page.BindingContext = new ViewModelPersonas()
            {
                Id = SelectedPersona.id,
                Pago = SelectedPersona.pago,
                Descripcion = SelectedPersona.descripcion,
                Monto = SelectedPersona.monto,
                Fecha = SelectedPersona.fecha,


            };

            await Navigation.PushModalAsync(page);
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Mensaje", "Seleccione una Persona", "ok");
        }
    }

}
}
