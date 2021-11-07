using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MyClass.Model;
using webdemoquanlygiay.Models;
namespace MyClass.DAO
{
    class CategoryDAO
    {
        mydbcontext db = new mydbcontext();
        public List<Category> getList(int CategoryID)
        {
            List<Category> list = db.Categories
               
                .ToList();
            return list;
                
        }
        
    }
}
