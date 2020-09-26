using QuanLiCaPhe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCaPhe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Table> getListTable()
        {
            List<Table> list = new List<Table>();

            string query = "SELECT * FROM TableFood ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table (item);
                list.Add(table);
            }
            return list;
        }

        public bool insertTable(string name)
        {
            string query = string.Format(" INSERT INTO dbo.TableFood ( name ) VALUES ( N' Bàn {0}' ) " , name);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateTable( string name,int id)
        {
            string query = string.Format(" UPDATE dbo.TableFood SET name = N'{0}' WHERE id = {1} ", name , id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool deleteTable(int id)
        {
            BillInfoDAO.Instance.deleteBillInfo(id);

            string query = string.Format("DELETE dbo.TableFood WHERE id = {0} ", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
