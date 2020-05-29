using System;
using System.Collections.Generic;
using Projekt_4.Library.Enum;
using Projekt_4.Library.Models;

namespace Projekt_4.Library
{
    public class AddressManager
    {
        private void ClassifyIpAddress(IpAddressModel model)
        {
            if (model.Byte_1 >= 0 && model.Byte_1 < 128)
                model.Classification = IpAddress.ClassA;

            else if (model.Byte_1 >= 128 && model.Byte_1 < 192)
                model.Classification = IpAddress.ClassB;

            else if (model.Byte_1 >= 192 && model.Byte_1 < 224)
                model.Classification = IpAddress.ClassC;

            else
                model.Classification = IpAddress.ClassD;
        }

        public string[] GenerateDefaultSubnetMask(IpAddressModel model)
        {
            ClassifyIpAddress(model);

            var retVal = new[] { "0", "0", "0", "0" };

            switch (model.Classification)
            {
                case IpAddress.ClassA:
                    retVal[0] = "255";
                    break;
                case IpAddress.ClassB:
                    retVal[0] = "255";
                    retVal[1] = "255";
                    break;
                case IpAddress.ClassC:
                    retVal[0] = "255";
                    retVal[1] = "255";
                    retVal[2] = "255";
                    break;
                case IpAddress.ClassD:
                    retVal[0] = "255";
                    retVal[1] = "255";
                    retVal[2] = "255";
                    break;
                default:
                    throw new Exception("Ip-Address is not classified yet, please try again.");
            }

            return retVal;
        }

        public int[] CalculateNetworkAddress(string subnet1, string subnet2, string subnet3, string subnet4, IpAddressModel model)
        {
            var ipAddress           = AddressToBits(model.Byte_1.ToString(), model.Byte_2.ToString(), model.Byte_3.ToString(), model.Byte_4.ToString());
            var subnetMask          = AddressToBits(subnet1, subnet2, subnet3, subnet4);
            var networkAddressInBit = new List<bool[]>();

            for (var i = 0; i < ipAddress.Count; i++)
            {
                var networkAddressByte = new bool[8];

                for (var j = 0; j < 8; j++)
                    networkAddressByte[j] = ipAddress[i][j] & subnetMask[i][j];

                networkAddressInBit.Add(networkAddressByte);
            }

            var retVal = BitArrayToInt(networkAddressInBit);

            return retVal;
        }

        public int[] CalculateBroadcastAddress(string subnet1, string subnet2, string subnet3, string subnet4, IpAddressModel model)
        {
            var ipAddress             = AddressToBits(model.Byte_1.ToString(), model.Byte_2.ToString(), model.Byte_3.ToString(), model.Byte_4.ToString());
            var subnetMask            = AddressToBits(subnet1, subnet2, subnet3, subnet4);
            var hostBitMask           = CalculateHostBitMask(subnetMask);
            var broadcastAddressInBit = new List<bool[]>();

            for (var i = 0; i < ipAddress.Count; i++)
            {
                var broadcastAddressByte = new bool[8];

                for (var j = 0; j < 8; j++)
                    broadcastAddressByte[j] = ipAddress[i][j] | hostBitMask[i][j];

                broadcastAddressInBit.Add(broadcastAddressByte);
            }

            var retVal = BitArrayToInt(broadcastAddressInBit);

            return retVal;
        }

        private List<bool[]> CalculateHostBitMask(List<bool[]> subnetMask)
        {
            var retVal = new List<bool[]>();

            foreach (var segment in subnetMask)
            {
                var hostMaskByte = new bool[8];

                for (var i = 0; i < segment.Length; i++)
                    hostMaskByte[i] = !segment[i];

                retVal.Add(hostMaskByte);
            }

            return retVal;
        }

        public void CalculateCidrNotation(string subnet1, string subnet2, string subnet3, string subnet4, IpAddressModel model)
        {
            ClassifyIpAddress(model);

            var subnetMask = AddressToBits(subnet1, subnet2, subnet3, subnet4);

            var retVal = CountTrueBits(subnetMask);

            model.Subnet = retVal;
        }

        private int[] BitArrayToInt(List<bool[]> input)
        {
            var retVal = new int[4];

            for (var i = 0; i < input.Count; i++)
            {
                var memory   = 0;
                var bitValue = 1;

                for (var j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j])
                        memory += bitValue;

                    bitValue *= 2;
                }

                retVal[i] = memory;
            }

            return retVal;
        }

        private int CountTrueBits(List<bool[]> subnetMask)
        {
            var counter = 0;

            foreach (var segment in subnetMask)
            {
                foreach (var bit in segment)
                {
                    if (bit)
                        counter++;
                }
            }

            return counter;
        }

        private List<bool[]> AddressToBits(string subnet1, string subnet2, string subnet3, string subnet4)
        {
            var retVal = new List<bool[]> { IntToBit(subnet1), IntToBit(subnet2), IntToBit(subnet3), IntToBit(subnet4) };

            return retVal;
        }

        private bool[] IntToBit(string integer)
        {
            var retVal = new bool[8];

            var memory = Convert.ToInt32(integer);

            for (var i = 0; i < retVal.Length; i++)
            {
                retVal[i] =  memory % 2 == 1;
                memory    /= 2;
            }

            return retVal;
        }
    }
}