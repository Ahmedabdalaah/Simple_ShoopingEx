using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_ShoopingEx
{
    internal interface IProductOperations
    {
        void SetConnection();
        void Add_Product(string productName, float price, int amount, int type_id);
        void Delete_ProductById(int id);
        void Update_Product(int id, string ProductName, int amount);
        Product GetProducts();
    }
}
