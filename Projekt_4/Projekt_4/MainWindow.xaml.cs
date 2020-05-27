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
        private readonly DataAccessHelper data;
        private readonly List<IpAddressModel> addresses;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            data = new DataAccessHelper();
            addresses = new List<IpAddressModel>();
        }

        private void OnClick_AddAddress(object sender, RoutedEventArgs e)
        {
            try
            {
                data.AddIpAddress(CreateAddressModel());

                ClearTextboxes();

                OnClick_RefreshList(sender, e);
            }
            catch (Exception exception)
            {
                GenerateErrorPopup(exception);
            }
        }

        private void OnClick_RefreshList(object sender, RoutedEventArgs e)
        {
            addresses.Clear();
            addresses.AddRange(data.GetIpAddresses());

            AddToListBoxDatasource();
        }

        private void OnClick_DeleteAddressEntry(object sender, RoutedEventArgs e)
        {
            try
            {
                var address = AddressListBox.SelectedItems;

                if (address == null || address.Count < 1)
                    throw new Exception("Select an entry before trying to delete it. lol");

                data.DeleteEntry((IpAddressModel)address[0]);

                OnClick_RefreshList(sender, e);
            }
            catch (Exception exception)
            {
                GenerateErrorPopup(exception);
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
        }

        private IpAddressModel CreateAddressModel()
        {
            return ModelProvider.Create(byte1.Text, byte2.Text, byte3.Text, byte4.Text);
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(byte1.Text) && !string.IsNullOrWhiteSpace(byte2.Text) && !string.IsNullOrWhiteSpace(byte3.Text) && !string.IsNullOrWhiteSpace(byte4.Text))
                    throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                GenerateErrorPopup(exception);
            }
        }

        private void GenerateErrorPopup(Exception ex)
        {
            var popup = new ErrorPopup();
            popup.ErrorWindow.Text = ex.Message;
            popup.ShowDialog();
        }
    }
}