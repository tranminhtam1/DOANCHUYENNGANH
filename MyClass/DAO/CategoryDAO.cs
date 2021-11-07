using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;
namespace MyClass.DAO
{
    class CategoryDAO
    {
        MyDBContext db = new MyDBContext();
       
        public List<Category> getList(int CategoryID)
        {
            List<Category> list = db.Categories

                .ToList();
            return list;

        }


    }
}
