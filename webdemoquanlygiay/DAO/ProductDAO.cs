using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webdemoquanlygiay.Models;

namespace webdemoquanlygiay.DAO
{
    public class ProductDAO
    {
        mydbcontext db = new mydbcontext();
        public List<Product> getList(int catid, int pagesize)
        {
            List<Product> list = db.Products
                .Where(m => m.productID == catid)
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