
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiCaPhe.DAO;
using QuanLiCaPhe.DTO;

namespace QuanLiCaPhe
{
    public partial class frm_TableManager : Form
    {

        private Account login;
        public Account Login
        {
            get { return login; }
            set { login = value;changeAccount(login.Type); }
        }
        public frm_TableManager(Account acc)
        {
            
            InitializeComponent();
            this.Login = acc;
            LoadTable();
            LoadCategory();
 
        }

      
        #region Method

        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " " + Login.DisplayName;
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cb_Category.DataSource = listCategory;
            cb_Category.DisplayMember = "name";
        }

        void LoadFoodListCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cb_Food.DataSource = listFood;
            cb_Food.DisplayMember = "name";
        }

        void LoadTable()
        {
            pfl_Table.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;


                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Beige;
                        break;
                    default:
                        btn.BackColor = Color.Gray;
                        break;
                }

                pfl_Table.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lv_Bill.Items.Clear();
            List<Menucs> listBillInfo = MenuDAOcs.Instance.GetListMenucsByTable(id)  ;
            float totalPrice = 0;

            foreach(Menucs item in listBillInfo)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;  
                lv_Bill.Items.Add(listViewItem);
            }
          
            CultureInfo culture = new CultureInfo("vi-VN");
            
            txtToTalPrice.Text = totalPrice.ToString("c",culture);
        }

        #endregion

        #region Events

        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lv_Bill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_AccountProfile f = new frm_AccountProfile(login);
            f.ShowDialog(); 
        }
        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Admin a = new frm_Admin();
            a.loginAccount = Login;
            a.ShowDialog();
        }

        private void cb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;

            id = selected.ID;

            LoadFoodListCategoryID(id);
        }
     

        private void btn_AddFood_Click(object sender, EventArgs e)
        {
            Table table = lv_Bill.Tag as Table ;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cb_Food.SelectedItem as Food).ID;
            int count = (int)nb_AddFood.Value;

            if(idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(),foodID,count);
            }

            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);

            LoadTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lv_Bill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nbDiscout.Value;
            double totalPrice = Convert.ToDouble(txtToTalPrice.Text.Split(',')[0].Replace(".", ""));
            double finalTotal = (totalPrice - (totalPrice / 100) * discount);


            if (idBill != -1)
            {
                if (discount == 0)
                {
                    if (MessageBox.Show("Bạn có chắc thanh toán " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        BillDAO.Instance.checkOut(idBill, discount, (float)totalPrice);
                        ShowBill(table.ID);

                        LoadTable();
                    }
                }
                else
                {
                    if (MessageBox.Show(string.Format("Bạn có chắc thanh toán bàn {0} và số tiền thanh toán sau khi giảm giá là {1} đồng", table.Name, finalTotal), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        BillDAO.Instance.checkOut(idBill, discount,(float)totalPrice);
                        ShowBill(table.ID);
                        LoadTable();
                    }
                }
            }
        }

        #endregion

        
    }

}

