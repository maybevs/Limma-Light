using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LimmaLight.Helpers
{
    public class AppStructure
    {
        public AppElement Root { get; set; }

        /// <summary>
        /// Just to Show. Could also use a Webendpoint and Serialization.
        /// </summary>
        /// <returns></returns>
        public static AppStructure GetAppStructure()
        {
            AppStructure structure = new AppStructure();

            AppElement root = new AppElement();
            root.AppElementType = AppElementType.StackLayout;
            
            AppElement label1 = new AppElement();
            label1.DefaultText = "Hello";
            label1.AppElementType = AppElementType.Label;
            label1.UpdatePath = new Uri(@"http://test.test");

            AppElement label2 = new AppElement();
            label2.DefaultText = "World";
            label2.AppElementType = AppElementType.Label;

            root.Children = new List<AppElement>();
            root.Children.Add(label1);
            root.Children.Add(label2);

            structure.Root = root;

            return structure;
        }
    }

    public class AppElement
    {
        public List<AppElement> Children { get; set; }

        public AppElementType AppElementType { get; set; }

        public Uri UpdatePath { get; set; }

        public string DefaultText { get; set; }

        public Guid UniqueName { get; set; }
    }

    public enum AppElementType
    {
        StackLayout,
        Label,
        Grid
    }
}
