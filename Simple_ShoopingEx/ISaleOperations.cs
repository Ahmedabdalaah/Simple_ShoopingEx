using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_ShoopingEx
{
    internal interface ISaleOperations
    {
        void SetConnection();
        void Add_Sale(DateTime saleDate, int product_id, int client_id);
        void Delete_SaletById(int id);
        void Update_Sale(int id, DateTime saleDate);
        Sales GetSales();
    }
}
