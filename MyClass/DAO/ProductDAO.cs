using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;
namespace MyClass.DAO


{
    public class ProductDAO
    {
        MyDBContext db = new MyDBContext();
        public List<Product> getList(int catid,int pagesize)
        {
            List<Product> list = db.Products
                .Where(m => m.productID == catid )
                .Take(pagesize)
                .ToList();
            return list;

        }
        public Product getRow(String ProductDetail)
        {
            Product row = db.Products

                .FirstOrDefault();
                return row;
        }
    }
}