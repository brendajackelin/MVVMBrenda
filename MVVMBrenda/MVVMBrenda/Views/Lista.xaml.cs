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
    public partial class Lista : ContentPage
    {
        public Lista()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TraerData();

        }
        public async void TraerData()
        {
            var emplist = await App.SQLiteBD.GetEmpleadosAsync();
            if (emplist != null)
            {
                ListViewEmpleados.ItemsSource = emplist;
            }
        }

        private async void ListViewEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Empleado)e.SelectedItem;
            var page = new Views.Update();
            Empleado emp = new Empleado
            {
                IdEmpleado = Convert.ToInt32(obj.IdEmpleado.ToString())
            };
            page.BindingContext = emp;
            await Navigation.PushAsync(page);
        }
    }
}