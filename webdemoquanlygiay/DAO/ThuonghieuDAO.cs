using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webdemoquanlygiay.Models;
namespace MyClass.DAO

{
    public class ThuonghieuDAO
    {
        mydbcontext db = new mydbcontext();
        public List<Brand> getList(int BrandID)
        {
            List<Brand> list = db.Brands

                .ToList();
            return list;

        }
    }
}