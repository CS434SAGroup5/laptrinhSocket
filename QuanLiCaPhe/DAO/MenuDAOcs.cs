using QuanLiCaPhe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCaPhe.DAO
{
    public class MenuDAOcs
    {
        private static MenuDAOcs instance;
        public static MenuDAOcs Instance
        {
            get { if (instance == null) instance = new MenuDAOcs(); return MenuDAOcs.instance; }
            private set { MenuDAOcs.instance = value; }
        }
        private MenuDAOcs() { }

        public List<Menucs> GetListMenucsByTable(int id) 
        {
            List<Menucs> listMenu = new List<Menucs>();

            string query = "SELECT f.name, bi.count, f.price, f.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idTable = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menucs menu = new Menucs(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
