using QuanLiCaPhe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCaPhe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        public Account GetAccount(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Account  where UserName = '" + userName + "' ");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool UpdateAccount(string userName,string displayName,string pass,string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @passWord , @newPassWord ", new object[] { userName,displayName,pass,newPass});
            return result > 0;
        }

        public DataTable GetAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName , DisplayName , Type FROM dbo.Account ");
        }

          public bool insertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("INSERT INTO dbo.Account ( UserName , DisplayName , Type ) VALUES (N'{0}',N'{1}',{2})", userName, displayName, type);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateAccount(string userName, string displayName, int type )
        {
            string query = string.Format("UPDATE dbo.Account SET  DisplayName = N'{1}', Type = {2} WHERE UserName = N'{0}' ", userName, displayName, type );

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool deleteAccount(string userName)
        {
            string query = string.Format("DELETE Account WHERE UserName = N'{0}' ", userName);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool resetPassWord(string userName)
        {
            string query = string.Format("Update Account set PassWord = N'0' where UserName = N'{0}'", userName);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }  
}
