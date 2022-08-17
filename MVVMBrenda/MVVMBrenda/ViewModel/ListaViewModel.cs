using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MVVMBrenda.Models;
using MVVMBrenda.Views;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MVVMBrenda.ViewModel
{

    public class ListaViewModel : BaseViewModel
    {
        #region Atributos
        private string Nombre;
        private string Apellidos;
        private int Edad;
        private string Direccion;
        private string Puesto;
        #endregion

        #region Propiedades
        public string Nombretxt
        {
            get { return this.Nombre; }
            set { SetValue(ref this.Nombre, value); }
        }
        public string Apellidostxt
        {
            get { return this.Apellidos; }
            set { SetValue(ref this.Apellidos, value); }
        }
        public int Edadtxt
        {
            get { return this.Edad; }
            set { SetValue(ref this.Edad, value); }
        }
        public string Direcciontxt
        {
            get { return this.Direccion; }
            set { SetValue(ref this.Direccion, value); }
        }
        public string Puestotxt
        {
            get { return this.Puesto; }
            set { SetValue(ref this.Puesto, value); }
        }
        #endregion
        #region Comandos
        public ICommand CreateCommand
        {
            get
            {
                return new RelayCommand(Create);
            }
            set
            {

            }
        }
        #endregion
        #region Metodos
        private async void Create()
        {
            bool resp;
            if (string.IsNullOrEmpty(Nombretxt.ToString()))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(Apellidostxt.ToString()))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(Edadtxt.ToString()))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(Direcciontxt.ToString()))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(Puestotxt.ToString()))
            {
                resp = false;
            }
            else
            {
                resp = true;
            }
            if (resp)
            {
                Empleado emp = new Empleado
                {
                    Nombre = Nombretxt.ToString(),
                    Apellidos = Apellidostxt.ToString(),
                    Edad = Convert.ToInt32(Edadtxt.ToString()),
                    Direccion = Direcciontxt.ToString(),
                    Puesto = Puestotxt.ToString()
                };
                await App.SQLiteBD.SavedEmpleadoAsync(emp);
                await Application.Current.MainPage.DisplayAlert("Registro", "Se guardo exitosamente", "Ok");
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }
        }
        #endregion
        #region Constructores

        #endregion
    }
}
