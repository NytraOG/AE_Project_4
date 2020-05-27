using System;
using System.Collections.Generic;
using System.Windows;
using Projekt_4.Library;
using Projekt_4.Library.Models;

namespace Projekt_4
{
    public partial class MainWindow : Window
    {
        private readonly List<IpAddressModel> addresses;
        private readonly DataAccessHelper dataLayer;
        private readonly AddressManager manager;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            dataLayer = new DataAccessHelper();
            addresses = new List<IpAddressModel>();
            manager = new AddressManager();

            Refresh();
        }

        private void OnClick_AddAddress(object sender, RoutedEventArgs e)
        {
            try
            {
                var model = CreateAddressModel();
                manager.CalculateCidrNotation(subnet1.Text, subnet2.Text, subnet3.Text, subnet4.Text, model);

                dataLayer.AddIpAddress(model);
                ClearTextboxes();
                Refresh();
            }
            catch (Exception exception)
            {
                GenerateErrorPopup(exception);
            }
        }

        private void OnClick_DeleteAddressEntry(object sender, RoutedEventArgs e)
        {
            try
            {
                var address = AddressListBox.SelectedItems;

                if (address == null || address.Count < 1)
                    throw new Exception("Select an entry before trying to delete it. lol");

                dataLayer.DeleteEntry((IpAddressModel) address[0]);

                OnClick_RefreshList(sender, e);
            }
            catch (Exception exception)
            {
                GenerateErrorPopup(exception);
            }
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(byte1.Text) && !string.IsNullOrWhiteSpace(byte2.Text) &&
                    !string.IsNullOrWhiteSpace(byte3.Text) && !string.IsNullOrWhiteSpace(byte4.Text))
                {
                    var model = ModelProvider.Create(byte1.Text, byte2.Text, byte3.Text, byte4.Text);

                    var defaultSubnet = manager.GenerateDefaultSubnetMask(model);

                    RenderSubnetMask(defaultSubnet);
                }
            }
            catch (Exception exception)
            {
                GenerateErrorPopup(exception);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextboxes();
        }

        private void OnClick_RefreshList(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        #region HelperMethods

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
            subnet1.Clear();
            subnet2.Clear();
            subnet3.Clear();
            subnet4.Clear();
        }

        private IpAddressModel CreateAddressModel()
        {
            return ModelProvider.Create(byte1.Text, byte2.Text, byte3.Text, byte4.Text);
        }

        private void GenerateErrorPopup(Exception ex)
        {
            var popup = new ErrorPopup();
            popup.ErrorWindow.Text = ex.Message;
            popup.ShowDialog();
        }

        private void Refresh()
        {
            addresses.Clear();
            addresses.AddRange(dataLayer.GetIpAddresses());

            AddToListBoxDatasource();
        }

        private void RenderSubnetMask(string[] defaultSubnet)
        {
            subnet1.Text = string.IsNullOrWhiteSpace(defaultSubnet[0]) ? "NA" : defaultSubnet[0];
            subnet2.Text = defaultSubnet[1];
            subnet3.Text = defaultSubnet[2];
            subnet4.Text = defaultSubnet[3];
        }

        #endregion
    }
}