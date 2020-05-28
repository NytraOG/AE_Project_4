using System;
using Projekt_4.Library.Enum;

namespace Projekt_4.Library.Models
{
    /// <summary>
    /// Class IpAdressModel
    /// </summary>
    public class IpAddressModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IpAddressModel()
        {
            Id = GenerateRandomId();
        }

        public int Id { get; }
        public int Byte_1 { get; set; }
        public int Byte_2 { get; set; }
        public int Byte_3 { get; set; }
        public int Byte_4 { get; set; }
        public int Subnet { get; set; }
        public IpAddress Classification { get; set; }

        /// <summary>
        /// Converts the Bytes of the IpAdress to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Byte_1}.{Byte_2}.{Byte_3}.{Byte_4}/{Subnet}";
        }

        /// <summary>
        /// Generates a random ID
        /// </summary>
        /// <returns></returns>
        private int GenerateRandomId()
        {
            var retVal = string.Empty;
            var rng = new Random();

            for (var i = 0; i < 9; i++)
            {
                var nummer = rng.Next(0, 10);

                retVal += nummer;
            }

            return Convert.ToInt32(retVal);
        }
    }
}