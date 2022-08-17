using MVVMBrenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMBrenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Update : ContentPage
    {
        public Update()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Traerdata();

        }
        public async void Traerdata()
        {
            int ID = Convert.ToInt32(txtidempleado.Text);
            if (!string.IsNullOrEmpty(ID.ToString()))
            {
                var emp = await App.SQLiteBD.GetEmpleadoByIdAsync(ID);
                if (emp != null)
                {
                    txtNombre.Text = emp.Nombre;
                    txtApellidos.Text = emp.Apellidos;
                    txtEdad.Text = emp.Edad.ToString();
                    txtDireccion.Text = emp.Direccion;
                    txtPuesto.Text = emp.Puesto;
                }
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
        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
            if (validardata())
            {
                Empleado emp = new Empleado
                {
                    IdEmpleado = Convert.ToInt32(txtidempleado.Text),
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellidos.Text,
                    Edad = Convert.ToInt32(txtEdad.Text),
                    Direccion = txtDireccion.Text,
                    Puesto = txtPuesto.Text
                };
                await App.SQLiteBD.SavedEmpleadoAsync(emp);
                await DisplayAlert("Registro", "Se actualizo exitosamente", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txtidempleado.Text);
            var emp = await App.SQLiteBD.GetEmpleadoByIdAsync(ID);
            if (emp != null)
            {
                await App.SQLiteBD.DeleteEmpleadoAsync(emp);
                await DisplayAlert("Registro", "Se Elimino exitosamente", "Ok");
                await Navigation.PopAsync();
            }
        }
    }
}