using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppGen.Generator.Controls
{
    public class RootLayout : UIElement
    {

        public RootLayout()
        {
            Content = new StackLayout();
        }

        public new void AddChild(UIElement element)
        {
            ((StackLayout)Content).Children.Add(element);
        }
    }
}
