using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLITEEsame.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemListView : ContentPage
    {
        public static ObservableCollection<Scheda> schede = new ObservableCollection<Scheda>();
        public ItemListView()
        {
            InitializeComponent();
            var schedeIEnum = App.Dbcontroller.GetSchede();
            schede = new ObservableCollection<Scheda>(schedeIEnum);


            this.Title = "Seleziona Un Allenamento";

            this.BindingContext = schede;
            

        }

        private void Delete(object sender, System.EventArgs e)
        {
            var viewCellSelected = sender as MenuItem;
            var schedaToDelete = viewCellSelected?.BindingContext as Scheda;
            var schedaToDeleteint = (int)schedaToDelete.Id;
            App.Dbcontroller.DeleteScheda(schedaToDeleteint);
            DisplayAlert("", viewCellSelected.ToString() + schedaToDelete.ToString() + schedaToDeleteint.ToString(), "ok");
        }
        public void OnDelete(object sender, EventArgs e)
        {
            var viewCellSelected = sender as MenuItem;
            var schedaToDelete = viewCellSelected?.BindingContext as Scheda;
            var schedaToDeleteint = (int)schedaToDelete.Id;
            App.Dbcontroller.DeleteScheda(schedaToDeleteint);
            DisplayAlert("", "Scheda eliminata ", "ok");
            OnPropertyChanged("DeleteScheda");
        }


        private async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var mytimer = e.Item as Scheda;
            await Navigation.PushAsync(new TimerPage(mytimer.Id, mytimer.SchedaName, mytimer.Ripetizioni, mytimer.Recupero));
        }

        private async void AddAllenamento(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddAllenamentoPage());
        }
    }
    

}