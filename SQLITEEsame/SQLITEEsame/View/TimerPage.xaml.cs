using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLITEEsame.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimerPage : ContentPage
	{
        bool start = false;
        public DateTime data;
        public int rip,riptot;
        public int recupero,timeview;
        int _SecondsElapsed;
        int SecondsElapsed
        {
            get { return _SecondsElapsed; }
            set { _SecondsElapsed = value; }
        }
        
        public TimerPage(int id, String Name, int Ripetizioni, int Rec)
        {
            InitializeComponent();
            this.Title = "Allenamento";
            rip = Ripetizioni;
            riptot = Ripetizioni;
            recupero = Rec;
            timeview = Rec;
            MyScheda.Text = Name;
            MyRipetizioni.Text =  rip.ToString()+"/" +riptot.ToString();
            updateCountDownText();
        }
        public void StartTimer(int time)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (start == true && SecondsElapsed <= time)
                {
                    progressRing.Progress = ((float)SecondsElapsed / time);
                    SecondsElapsed++;
                    updateCountDownText();
                    timeview--;
                    return true;
                }
                if (SecondsElapsed >= time)
                {
                    if (Controlla(rip) == false)
                    {
                        DisplayAlert("Allenamento Terminato ", "Congratulazioni hai terminato il tuo allenamento ", "Nuovo Allenamento");
                        Navigation.PopAsync();
                        return false;
                    }
                    MyRipetizioni.Text =  rip.ToString()+ "/" +riptot.ToString();
                    SecondsElapsed = 0;
                    timeview = recupero;
                    updateCountDownText();
                    progressRing.Progress = 0;
                    start = !start;
                    bottone.Text = "Tap to play";
                    return false;
                }
                return false;
            });
        }

        public bool Controlla(int var)
        {
            if (var > 1)
            {
                rip--;
                return true;
            }
            else return false;
        }
        public void Startandstop(object sender, EventArgs e)
        {
            start = !start;
            if (start == true)
            {
                bottone.Text = "tap to pause";
                StartTimer(recupero);

            }
            else
            {
                bottone.Text = "tap to resume";
                
            }

        }

        private void updateCountDownText()
        {
            int minutes = (int)timeview / 60;
            int seconds = (int)timeview % 60;
            data= new DateTime(2018,1,1,1,minutes,seconds);
            MyTime.Text=data.ToString("mm:ss");

        }
    }
}