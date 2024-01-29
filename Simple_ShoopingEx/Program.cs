using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Simple_ShoopingEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////// Client ///////////////////////
            /* Calling client operations
             * 
            Client c = new Client();
            ClientOperations clientop = new ClientOperations();
            clientop.Add_Client("khaled", "Abdo", "Mansura", 0120200, "kakayahoo ");
            clientop.Delete_ClientById(5);
            c=clientop.GetClients();
            Console.WriteLine("firstname:"+c.firstName + "lastName:"+c.lastName);
            clientop.Update_Client(6,"Mona","Ahmed");
            */
            ///////////////// Type //////////////////////////
            /* 
             *  calling Type operaations
            TypeOperations typeOper = new TypeOperations();
            //typeOper.Delete_TypeById(1);
            // typeOper.Add_Type("Food");
            //Type type = new Type();
            //type = typeOper.GetTypes();
            //Console.WriteLine(type.type_name);
            typeOper.Update_Type(2, "Drink");
            */
            /////////////// Product //////////////////////
            /*
             * calling product operations
             *
            Product product = new Product();
            ProductOperations proo = new ProductOperations();
            // proo.Add_Product("Tea", 20, 50, 2);
            // proo.Delete_ProductById(2);
            //product= proo.GetProducts();
            //Console.WriteLine(product.product_name);
            proo.Update_Product(3, "Coffee", 400);
            */

            /////////////////////// sales ///////////////////
            ///
            /*
             * Calling sales operations
            Sales sale = new Sales();
            SalesOperations salesOp = new SalesOperations();
            // salesOp.Add_Sale(DateTime.Now, 3, 6);
            //salesOp.Delete_SaletById(1);
            //sale = salesOp.GetSales();
            //Console.WriteLine(sale.sale_date);
            // salesOp.Update_Sale(2, DateTime.Now);
            */  
            Console.ReadKey();

        }
    }
}
