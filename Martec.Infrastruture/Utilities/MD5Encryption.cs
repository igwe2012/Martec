﻿using Martec.Domain.Interfaces.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.Utilities
{
    public class MD5Encryption : IEncryption
    {
        public string Encrypt(string plainText)
        {
            return
                System.Security
                    .Cryptography.MD5.Create()
                    .ComputeHash(Encoding.ASCII.GetBytes(plainText))
                    .Select(x => x.ToString("x2")).Aggregate((ag, s) => ag + s);
        }
    }
}
