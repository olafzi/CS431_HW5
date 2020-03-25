using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Maps;

namespace CS431_HW5
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Map map = new Map();
        }

        void SatelliteClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Satellite;
        }

        void HybridClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Hybrid;
        }

        void StreetClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Street;
        }



    }
}
