using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppGen.Generator.Controls
{
    public class SingleValue : UIElement
    {
        public Label TextDisplay { get; set; }

        public SingleValue(string name, UISettings Settings)
        {
            TextDisplay = new Label();
            TextDisplay.Text = "Default";
            this.Content = TextDisplay;

        }
    }
}
