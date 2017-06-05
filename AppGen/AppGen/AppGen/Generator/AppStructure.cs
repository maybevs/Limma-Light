using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGen.Generator.Controls;
using Xamarin.Forms;

namespace AppGen.Generator
{
    public class AppStructure
    {
        public string Title { get; set; }

        public UIElement Root { get; set; }

        public AppStructure()
        {
            Debug.WriteLine("AppStructure::ctor starts");
            Root = new RootLayout();
        }


        public static AppStructure GetFromWeb(Uri source)
        {
            Debug.WriteLine("AppStructure::GetFromWeb starts");
            AppStructure app = new AppStructure();
            SingleValue sv1 = new SingleValue("TestString", new UISettings{ BackgroundColor = Color.Green});
            app.Root.AddChild(sv1);
            //((StackLayout)((RootLayout)app.Root).Content).Children.Add(sv1);

            Debug.WriteLine("AppStructure::GetFromWeb returns");
            return app;
        }
    }

    public class UIElement : ContentView
    {
        public string Name { get; set; }

        public UISettings UiSettings { get; set; }

        public List<UIElement> Children { get; set; }

        public UIType UIType { get; set; }

        public string DataSource { get; set; }

        public string DefaultValue { get; set; }

        public void AddChild(UIElement child)
        {
            this.Content = child;
        }
        
    }

    public class UISettings
    {
        public Color BackgroundColor { get; set; }
    }

    public enum UIType
    {
        StackLayout,
        Grid,
        Label
    }


}
