using PMO2EXAMEN3;
using Examen3PMO2.controller;
using Examen3PMO2.Models;
using Examen3PMO2.ViewModel;
using SQLite;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Examen3PMO2.ViewModel
{
    public class ViewModelPersonas : BaseViewModel
    {
        conexion conn = new conexion();
        Crud crud = new Crud();
        private int id;
        private int pago;
        private string descripcion;
        private double monto;
        private string fecha;


        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }
        public int Pago
        {
            get { return pago; }
            set { pago = value; OnPropertyChanged(); }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; OnPropertyChanged(); }
        }
        public double Monto
        {
            get { return monto; }
            set { monto = value; OnPropertyChanged(); }
        }
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; OnPropertyChanged(); }
        }

        public async void Guardar()
        {
            if (string.IsNullOrEmpty(Id.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de ID vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Pago.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de PAGO vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Descripcion))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de Descripcion vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Monto.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de Monto vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Fecha))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de fecha vacio", "Ok");
                return;
            }

            var personas = new Personas()
            {
                id = Id,
                pago = Pago,
                descripcion = Descripcion,
                monto = Monto,
                fecha = Fecha


            };

            try
            {


                conn.Conn().CreateTable<Personas>();
                conn.Conn().Insert(personas);
                conn.Conn().Close();

                await App.Current.MainPage.DisplayAlert("Success", "Datos Guardados", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new Home());


            }
            catch (SQLiteException)
            {
                await App.Current.MainPage.DisplayAlert("Warning", "Correo Ya existe", "Ok");
            }
        }

        public ICommand ClearCommand { private set; get; }
        public ICommand SendEmailCommand { private set; get; }

        public ViewModelPersonas()
        {
            ClearCommand = new Command(() => Clear());

        }

        public ICommand GuardarCommand
        {
            get { return new Command(() => Guardar()); }
        }
        public ICommand DeleteCommand { get { return new Command(() => eliminar()); } }
        public ICommand UpdateCommand { get { return new Command(() => actualizar()); } }
        void Clear()
        {

            pago = Convert.ToInt32(Pago.ToString());
            Descripcion = string.Empty;
            monto = Convert.ToDouble(Monto.ToString());
            Fecha = string.Empty;



        }
        async void eliminar()
        {
            var persona = await crud.getPersonasId(Convert.ToInt32(Id));
            bool conf = await App.Current.MainPage.DisplayAlert("Delete", "Eliminar Persona", "Accept", "Cancel");
            if (conf)
            {
                if (persona != null)
                {
                    await crud.Delete(persona);
                    await App.Current.MainPage.DisplayAlert("Delete", "Datos Eliminados", "ok");
                    Clear();
                    await App.Current.MainPage.Navigation.PopModalAsync();

                }
            }

        }
        async void actualizar()
        {

            bool conf = await App.Current.MainPage.DisplayAlert("Update", "Actualizar datos de Empleado", "Accept", "Cancel");
            if (conf)
            {
                if (!string.IsNullOrEmpty(Id.ToString()))
                {
                    Personas update = new Personas
                    {
                        id = Convert.ToInt32(Id.ToString()),
                        pago = Pago,
                        descripcion = Descripcion,
                        monto = Convert.ToDouble(Monto.ToString()),
                        fecha = Fecha

                    };
                    await crud.getPersonasUpdateId(update);
                    await App.Current.MainPage.DisplayAlert("Update", "Datos Actualizados", "ok");
                    await App.Current.MainPage.Navigation.PopModalAsync();

                }
            }

        }

    }
}
