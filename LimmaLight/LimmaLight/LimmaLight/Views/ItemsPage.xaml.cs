using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using LimmaLight.Helpers;
using LimmaLight.Models;
using LimmaLight.ViewModels;

using Xamarin.Forms;

namespace LimmaLight.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        private AppStructure _structure;

        public ItemsPage(AppStructure structure)
        {
            InitializeComponent();
            _structure = structure;
            
            foreach (var appElement in structure.Root.Children)
            {
                Root.Children.Add(BuildChildren(appElement));
            }

            BindingContext = viewModel = new ItemsViewModel();
            Device.StartTimer(TimeSpan.FromSeconds(5), UpdateValues);

        }

        private bool UpdateValues()
        {

            UpdateChildrenValues(_structure.Root);

            return true;
        }

        public bool UpdateChildrenValues(AppElement element)
        {
            foreach (var appElement in _structure.Root.Children)
            {
                switch (appElement.AppElementType)
                {
                    case AppElementType.StackLayout:
                        UpdateChildrenValues(appElement);
                        break;
                    case AppElementType.Label:
                        if (appElement.UpdatePath != null)
                        {
                            var locelement = FindElement(appElement.UniqueName, Root);
                            if (locelement != null) { 
                                Label uiElement = locelement as Label;
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    uiElement.Text = "Updated";
                                });

                            }
                        }
                        

                        break;
                    case AppElementType.Grid:
                        UpdateChildrenValues(appElement);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return true;
        }

        private View FindElement(Guid appElementUniqueName, StackLayout root)
        {
            foreach (var child in root.Children)
            {

                if (child.StyleId == appElementUniqueName.ToString())
                {
                    return child;
                }
            }
            return null;
        }

        private View BuildChildren(AppElement appElement)
        {
            List<View> children = new List<View>();
            if (appElement.Children != null && appElement.Children.Count != 0)
            {
                foreach (var appElementChild in appElement.Children)
                {
                    View child = BuildChildren(appElementChild);
                    if (child != null)
                    {
                        children.Add(child);
                    }
                    
                }
            }

            View view;

            switch (appElement.AppElementType)
            {
                case AppElementType.StackLayout:
                    view = new StackLayout();
                    view.StyleId = appElement.UpdatePath.ToString();
                    foreach (var child in children)
                    {
                        ((StackLayout)view).Children.Add(child);
                    }

                    return view;
                    break;
                case AppElementType.Label:
                    Label label = new Label();
                    label.Text = appElement.DefaultText;
                    label.StyleId = appElement.UniqueName.ToString();
                    return label;
                    break;
                case AppElementType.Grid:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            //ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
