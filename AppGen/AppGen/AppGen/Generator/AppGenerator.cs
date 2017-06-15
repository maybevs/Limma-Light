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
    public class AppGenerator
    {

        public ContentView MainPage { get; set; }
        public AppGenerator()
        {
        }

        public ContentView GenerateFromConfig()
        {
            Debug.WriteLine("AppGenerator::GenerateFromConfig Starts");

            AppStructure appStructure = AppStructure.GetFromWeb(null);

            ContentView page = new ContentView();
            Label label = new Label();
            label.Text = "lalala";

            StackLayout root = new StackLayout();
            root.Children.Add(label);
            page.Content = root;
            this.MainPage = page;

            return page;
            Debug.WriteLine("AppGenerator::GenerateFromConfig Generating Children");

            foreach (var rootChild in appStructure.Root.Children)
            {
                switch (rootChild.GetType().ToString())
                {
                    case "SingleValue":
                        root.Children.Add(rootChild);
                        break;
                }
            }

            

            page.Content = root;
            Debug.WriteLine("AppGenerator::GenerateFromConfig Generating MainPage");
            this.MainPage = page;

            Debug.WriteLine("AppGenerator::GenerateFromConfig finished");

        }
    }
}
