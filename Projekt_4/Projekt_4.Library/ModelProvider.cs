using System;
using Projekt_4.Library.Models;

namespace Projekt_4.Library
{
    public static class ModelProvider
    {
        public static IpAddressModel Create(string byte1Text, string byte2Text, string byte3Text, string byte4Text)
        {
            var byte1Valid = int.TryParse(byte1Text, out var byte1Result);

            if (!byte1Valid)
                throw new Exception($"'{byte1Text}' is not a valid entry. Use a 1-Byte Integer!");

            var byte2Valid = int.TryParse(byte2Text, out var byte2Result);

            if (!byte2Valid)
                throw new Exception($"'{byte2Text}' is not a valid entry. Use a 1-Byte Integer!");

            var byte3Valid = int.TryParse(byte3Text, out var byte3Result);

            if (!byte3Valid)
                throw new Exception($"'{byte3Text}' is not a valid entry. Use a 1-Byte Integer!");

            var byte4Valid = int.TryParse(byte4Text, out var byte4Result);

            if (!byte4Valid)
                throw new Exception($"'{byte4Text}' is not a valid entry. Use a 1-Byte Integer!");

            if (byte1Result > 255 || byte1Result < 0 || byte2Result > 255 || byte2Result < 0 || byte3Result > 255 ||
                byte3Result < 0 || byte4Result > 255 || byte4Result < 0)
            {
                throw new Exception(
                                    $"'{byte1Text}.{byte2Text}.{byte3Text}.{byte4Text}' is not a valid IPv4 Address. Byte entry values must be between 0 and 255.");
            }

            var model = new IpAddressModel
            {
                Byte_1 = byte1Result,
                Byte_2 = byte2Result,
                Byte_3 = byte3Result,
                Byte_4 = byte4Result
            };

            return model;
        }
    }
}