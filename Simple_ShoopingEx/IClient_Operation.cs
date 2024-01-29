using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_ShoopingEx
{
    internal interface IClient_Operation
    {
        void SetConnection();
        void Add_Client(string firstName, string lastName, string address, int phone, string email);
        void Delete_ClientById(int id);
        void Update_Client(int id, string firstName, string lastName);
        Client GetClients();
    }
}
