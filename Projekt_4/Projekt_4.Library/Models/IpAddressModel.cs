using System;
using System.Configuration;

namespace Projekt_4.Library.Models
{
    public class IpAddressModel
    {
        public IpAddressModel()
        {
            Id = GenerateRandomId();
        }

        public int Id { get; }
        public int Byte_1 { get; set; }
        public int Byte_2 { get; set; }
        public int Byte_3 { get; set; }
        public int Byte_4 { get; set; }
        public int Port { get; set; }

        public override string ToString()
        {
            return $"{Byte_1}.{Byte_2}.{Byte_3}.{Byte_4}:{Port}";
        }

        private int GenerateRandomId()
        {
            var retVal = string.Empty;
            var rng = new Random();

            for (int i = 0; i < 9; i++)
            {
                var nummer = rng.Next(0, 10);

                retVal += nummer;
            }

            return Convert.ToInt32(retVal);
        }
    }
}