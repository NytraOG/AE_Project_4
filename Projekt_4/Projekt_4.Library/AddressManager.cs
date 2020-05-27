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

            var retVal = new [] {"0","0","0","0"};

            switch (model.Classification)
            {
                case IpAddress.ClassA :
                    retVal[0] = "255";
                    break;
                case IpAddress.ClassB :
                    retVal[0] = "255";
                    retVal[1] = "255";
                    break;
                case IpAddress.ClassC :
                    retVal[0] = "255";
                    retVal[1] = "255";
                    retVal[2] = "255";
                    break;
                case IpAddress.ClassD :
                    retVal[0] = "255";
                    retVal[1] = "255";
                    retVal[2] = "255";
                    break;
                default:
                    throw new Exception("Ip-Address is not classified yet, please try again.");
            }

            return retVal;
        }

        public void CalculateSubnetPrefix(string subnet1, string subnet2, string subnet3, string subnet4, IpAddressModel model)
        {
            ClassifyIpAddress(model);

            var subnetMask = SubnetToBits(subnet1, subnet2, subnet3, subnet4);

            var retVal = CountTrueBits(subnetMask);

            model.Subnet = retVal;
        }

        private int CountTrueBits(List<int[]> subnetMask)
        {
            var counter = 0;

            foreach (var segment in subnetMask)
            {
                foreach (var bit in segment)
                {
                    if (bit == 1)
                        counter++;
                }
            }

            return counter;
        }
        private List<int[]> SubnetToBits(string subnet1, string subnet2, string subnet3, string subnet4)
        {
            var retVal = new List<int[]> {IntToBit(subnet1), IntToBit(subnet2), IntToBit(subnet3), IntToBit(subnet4)};

            return retVal;
        }

        private int[] IntToBit(string integer)
        {
            var retVal = new int[8];

            var memory = Convert.ToInt32(integer);

            for (int i = 0; i < retVal.Length; i++)
            {
                retVal[i] = memory % 2 == 0 ? 0 : 1;
                memory /= 2;
            }

            return retVal;
        }


    }
}