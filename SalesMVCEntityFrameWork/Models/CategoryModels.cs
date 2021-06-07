using SalesLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SalesMVCEntityFrameWork.Models
{
    public class CategoryModels
    {
        private SalesModels salesModels = null;

        public CategoryModels()
        {
            salesModels = new SalesModels();
        }

        public List<Category> GetListCategory()
        {
            var list = salesModels.Database.SqlQuery<Category>("Sp_Category_ListAll").ToList();

            return list;
        }
    }
}