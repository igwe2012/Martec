using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Interfaces.Utility
{
    public interface IEncryption
    {
        string Encrypt(string password);
    }
}
