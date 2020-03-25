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
    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Pin> pinNames;

        public MainPage()
        {
            InitializeComponent();
            Map map = new Map(); // Create a new Map instance


            // Upon initialization, set the map location into a variable
            var initialMapLocation = MapSpan.FromCenterAndRadius
                                   (new Position(48.067687, 12.862049), Distance.FromMiles(1));
            //and move the map to the location from the variable.
            MainMap.MoveToRegion(initialMapLocation);

            //Upon initialiation, place all of the pins from PlaceSelection into the picker using function. 
            PlaceSelection();
        }

        //There are three buttons to change the map style.
        private void SatelliteClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Satellite; //Set to Satellite View 
        }

        private void HybridClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Hybrid; //Set to Hybrid View
        } 

        private void StreetClicked(object sender, EventArgs args)
        {
            this.MainMap.MapType = MapType.Street; //Set to Street View
        }

        //This function creates a new list of Pins and then adds those to the picker.
        private void PlaceSelection()
        {

            pinNames = new ObservableCollection<Pin> //Using the collection, as in the example code from lecture.
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


            //For all the pins that are in the pinNames collection, 
            foreach (Pin item in pinNames)
            {
                //load each pin into the map and the picker
                PlacePicker.Items.Add(item.Label);
                MainMap.Pins.Add(item);
            }

        } //End of the PlaceSelection

        //This function handles the Picker Selected Index Changed event.
        private void OnPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {

            //it creates a variable with the item from the picker.
            var inputSlot = (Picker)sender;
            string pname = inputSlot.SelectedItem.ToString(); //and creates a string with the name of the place

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
