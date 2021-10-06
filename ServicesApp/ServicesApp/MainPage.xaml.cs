using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServicesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Unsubscribe<string>(this, "Keytocounter");
            MessagingCenter.Subscribe<string>(this, "Keytocounter", (value) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    counter.Text = value;
                });
            });
        }

        private void Start(object sender, EventArgs e)
        {
            MessagingCenter.Send<string>("1", "Key");
        }
        private void Stop(object sender, EventArgs e)
        {
            MessagingCenter.Send<string>("0", "Key");
        }
    }
}
