using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_ShoopingEx
{
    internal interface ITypeOperations
    {
        void SetConnection();
        void Add_Type(string typeName);
        void Delete_TypeById(int id);
        void Update_Type(int id, string typeName);
        Type GetTypes();
    }
}
