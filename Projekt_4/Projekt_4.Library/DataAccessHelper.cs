using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Projekt_4.Library.Models;

namespace Projekt_4.Library
{
    /// <summary>
    /// DataAccessHelper Class<
    /// </summary>
    public class DataAccessHelper
    {
        /// <summary>
        /// Returns the list of IP-Addresses
        /// </summary>
        /// <returns></returns>
        public List<IpAddressModel> GetIpAddresses()
        {
            var list = new List<IpAddressModel>();

            var connString = LoadConnectionstring();

            using (IDbConnection connection = new SQLiteConnection(connString))
            {
                var query = "select * from IpAddress";
                var result = connection.Query<IpAddressModel>(query, new DynamicParameters()).ToList();

                list.AddRange(result);
            }

            return list;
        }

        /// <summary>
        /// Adds the new IP-Address
        /// </summary>
        /// <param name="newAddress">The new IP-Address entered by the user</param>
        /// <param name="oldAddress">Checks if the same IP-Address ist already existing</param>
        public void AddIpAddress(IpAddressModel newAddress, IpAddressModel oldAddress)
        {
            var connString = LoadConnectionstring();

            if(oldAddress != null)
                DeleteEntry(oldAddress);

            using (IDbConnection connection = new SQLiteConnection(connString))
            {
                var query = $"Insert into IpAddress Values({newAddress.Id}, {newAddress.Byte_1}, {newAddress.Byte_2}, {newAddress.Byte_3}, {newAddress.Byte_4}, {newAddress.Subnet})";
                connection.Execute(query);
            }
        }

        /// <summary>
        /// Deletes the given Address
        /// </summary>
        /// <param name="address">The given address</param>
        public void DeleteEntry(IpAddressModel address)
        {
            var connString = LoadConnectionstring();

            using (IDbConnection connection = new SQLiteConnection(connString))
            {
                var query = $"DELETE FROM IpAddress WHere Byte_1 = '{address.Byte_1}' AND Byte_2 = '{address.Byte_2}' AND Byte_3 = '{address.Byte_3}' AND Byte_4 = '{address.Byte_4}' AND Subnet = '{address.Subnet}'";

                connection.Execute(query);
            }
        }
        /// <summary>
        /// Loads the SQL Connection string
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string LoadConnectionstring(string id = "Default")
        {
            var connString = ConfigurationManager.ConnectionStrings[id].ConnectionString;

            return connString;
        }
    }
}