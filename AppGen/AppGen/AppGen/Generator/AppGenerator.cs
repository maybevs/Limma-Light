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

        public MainPage MainPage { get; set; }
        public AppGenerator()
        {
            Debug.WriteLine("AppGenerator::ctor starts");

            //Get Json config

            Debug.WriteLine("AppGenerator::ctor Generation Finished");

        }

        public void GenerateFromConfig()
        {
            Debug.WriteLine("AppGenerator::GenerateFromConfig Starts");

            AppStructure appStructure = AppStructure.GetFromWeb(null);

            MainPage page = new MainPage();

            StackLayout root = new StackLayout();

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
