using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Projekt_4.Library;
using Projekt_4.Library.Models;

namespace Projekt_4
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AddressManager manager;
        private List<IpAddressModel> addresses;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            manager = new AddressManager();
            addresses = new List<IpAddressModel>();
        }

        private void OnClick_AddAddress(object sender, RoutedEventArgs e)
        {
            try
            {
                manager.AddIpAddress(CreateAddressModel());

                ClearTextboxes();

                OnClick_RefreshList(sender, e);
            }
            catch (Exception exception)
            {
                var popup = new ErrorPopup();
                popup.ErrorWindow.Text = exception.Message;
                popup.ShowDialog();
            }
        }

        private void OnClick_RefreshList(object sender, RoutedEventArgs e)
        {
            addresses.Clear();
            addresses.AddRange(manager.GetIpAddresses());

            AddToListBoxDatasource();
        }

        private void OnClick_DeleteAddressEntry(object sender, RoutedEventArgs e)
        {
            try
            {
                var address = AddressListBox.SelectedItems;

                if (address == null || address.Count < 1)
                    throw new Exception("Select an entry before trying to delete it. lol");

                manager.DeleteEntry((IpAddressModel)address[0]);

                OnClick_RefreshList(sender, e);
            }
            catch (Exception exception)
            {
                var popup = new ErrorPopup();
                popup.ErrorWindow.Text = exception.Message;
                popup.ShowDialog();
            }
        }

        private void AddToListBoxDatasource()
        {
            AddressListBox.ItemsSource = null;
            AddressListBox.ItemsSource = addresses;
        }

        private void ClearTextboxes()
        {
            byte1.Clear();
            byte2.Clear();
            byte3.Clear();
            byte4.Clear();
            port.Clear();
        }

        private IpAddressModel CreateAddressModel()
        {
            return ModelProvider.Create(byte1.Text, byte2.Text, byte3.Text, byte4.Text, port.Text);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Ipv4RadioButton.IsChecked != null)
            {
                byte1.IsEnabled = (bool)Ipv4RadioButton.IsChecked;
                byte2.IsEnabled = (bool)Ipv4RadioButton.IsChecked;
                byte3.IsEnabled = (bool)Ipv4RadioButton.IsChecked;
                byte4.IsEnabled = (bool)Ipv4RadioButton.IsChecked;

                ClearTextboxes();
            }
        }
    }
}