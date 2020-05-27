using System;
using Projekt_4.Library.Enum;
using Projekt_4.Library.Models;

namespace Projekt_4.Library
{
    public class AddressManager
    {
        public void ClassifyIpAddress(IpAddressModel model)
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
    }
}