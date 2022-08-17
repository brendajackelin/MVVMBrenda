using MVVMBrenda.Models;
using MVVMBrenda.ViewModel;
using MVVMBrenda.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMBrenda
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ListaViewModel();
        }

            private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (validardata())
            {
                Empleado emp = new Empleado
                {
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellidos.Text,
                    Edad = Convert.ToInt32(txtEdad.Text),
                    Direccion = txtDireccion.Text,
                    Puesto = txtPuesto.Text
                };
                await App.SQLiteBD.SavedEmpleadoAsync(emp);
                await DisplayAlert("Registro", "Se guardo exitosamente", "Ok");
                await Navigation.PushAsync(new Lista());
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }
        }
        public bool validardata()
        {
            bool resp;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(txtPuesto.Text))
            {
                resp = false;
            }
            else
            {
                resp = true;
            }
            return resp;
        }

    }
}
