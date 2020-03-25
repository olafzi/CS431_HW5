using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Pin> pinNames;

        public MainPage()
        {
            InitializeComponent();
            Map map = new Map();
            var initialMapLocation = MapSpan.FromCenterAndRadius
                                                (new Position(48.067687, 12.862049)
                                                 , Distance.FromMiles(1));

            MainMap.MoveToRegion(initialMapLocation);

            PlaceSelection();
        }

        private void SatelliteClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Satellite;
        }

        private void HybridClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Hybrid;
        }

        private void StreetClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Street;
        }

        private void PlaceSelection()
        {

            pinNames = new ObservableCollection<Pin>
            {
                new Pin
                {
                    Type =PinType.SavedPin, Label="Hell", Address="Norway",
                    Position = new Position(63.444606, 10.904142)
                },
                new Pin
                {
                    Type =PinType.SavedPin, Label="Llanfairpwllgwyngyll", Address="UK",
                    Position = new Position(53.223552, -4.198321)
                },
                new Pin
                {
                    Type=PinType.SavedPin, Label="Middelfart", Address="Denmark",
                    Position = new Position(55.498766, 9.781120)
                },
                new Pin
                {
                    Type = PinType.SavedPin, Label="Titty Hill", Address="Midhurst, UK",
                    Position = new Position(51.024551, -0.782628)
                },
                new Pin
                {
                    Type = PinType.SavedPin, Label="Anus", Address="France",
                    Position = new Position(47.598841, 3.534277)
                }
            };

            foreach (Pin item in pinNames)
            {
                //Load each pin into the map and picker
                PlacePicker.Items.Add(item.Label);
                MainMap.Pins.Add(item);
            }

            //PlacePicker.SelectedIndex = 0;


        }

        private void OnPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            var inputSlot = (Picker)sender;
            string pname = inputSlot.SelectedItem.ToString();

            //When user selects a pin name, find the pin
            foreach (Pin item in pinNames)
            {
                if (item.Label == pname)
                {
                    //Move the map to center on the pin
                    MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(item.Position, Distance.FromMiles(2)).WithZoom(10));
                }
            }

        }


    }
}
