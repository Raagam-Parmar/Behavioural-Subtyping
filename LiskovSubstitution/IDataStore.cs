using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    public interface IDataStore
    {
        void Save(string key, string value);
        string? Read(string key);
    }
}
