﻿using QuanLiCaPhe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCaPhe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO();return instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "SELECT * FROM FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }
        
        public Category GetCategoryID(int id)
        {
            Category category = null;

            string query = "SELECT * FROM FoodCategory WHERE id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                 category = new Category(item);
                 return category;
            }
       
            return category;
        }
        public bool insertCategory(string name)
        {
            string query = string.Format("INSERT INTO dbo.FoodCategory (name) VALUES (N'{0}') ", name);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateCategory(string name , int id)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{0}' WHERE id = {1} ", name ,id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool deleteCategory(int id)
        {
            BillInfoDAO.Instance.deleteBillInfo(id);

            string query = string.Format("DELETE FoodCategory WHERE id = {0} ", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
