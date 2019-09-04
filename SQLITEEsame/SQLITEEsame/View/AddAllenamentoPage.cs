using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLITEEsame.View
{

    public class AddAllenamentoPage : ContentPage
    {
        private Entry _nomeschedaEn;
        private Entry _recuperoEn;
        private Entry _ripetizioniEn;
        private Button _saveButton;
        public AddAllenamentoPage()
        {
            this.Title = "Aggiungi Allenamento"; StackLayout stackLayout = new StackLayout();

            _nomeschedaEn = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nome Scheda"
            };
            stackLayout.Children.Add(_nomeschedaEn);

            _recuperoEn = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "Inserisci i secondi di recupero"
            };
            stackLayout.Children.Add(_recuperoEn);

            _ripetizioniEn = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "Inserisci il numero di ripetizioni"
            };
            stackLayout.Children.Add(_ripetizioniEn);

            _saveButton = new Button
            {
                Text = "Salva Scheda"
            };
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }
        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            if (_nomeschedaEn.Text == "" || _recuperoEn.Text == "" || _ripetizioniEn.Text == "")
            {
                await DisplayAlert("Errore ", "Compila tutti i campi", "Ok");
            }

            else if (_ripetizioniEn.Text == null || _nomeschedaEn.Text == null || _recuperoEn.Text == null)
            {
                await DisplayAlert("Errore ", "Compila tutti i campi", "Ok");
            }

            else if (_ripetizioniEn.Text.Contains(".") || _recuperoEn.Text.Contains("."))
            {
                await DisplayAlert("Errore", "Il punto è un carattere vietato","Ok");
            }

            else
            {
                var scheda = new Scheda { SchedaName = _nomeschedaEn.Text, Recupero = int.Parse(_recuperoEn.Text), Ripetizioni = int.Parse(_ripetizioniEn.Text) };
                ItemListView.schede.Add(scheda);
                App.Dbcontroller.SaveScheda(scheda);
                await DisplayAlert(null, "La Scheda: " + _nomeschedaEn.Text + " è Stato Salvata", "Ok");
                await Navigation.PopAsync();
            }
        }
    }
}