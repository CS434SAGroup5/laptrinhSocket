using QuanLiCaPhe.DAO;
using QuanLiCaPhe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCaPhe
{
    public partial class frm_Admin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource tableList = new BindingSource();  
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        public frm_Admin()
        {
            InitializeComponent();
            load();
        }
        public Account loginAccount;

        void load()
        { 
            dtgv_Food.DataSource = foodList;
            dtgr_Table.DataSource = tableList;
            dtgv_Account.DataSource = accountList;
            dtgv_Category.DataSource = categoryList;
            LoadAccountList();
            loadListBill(dt_FromDate.Value, dt_ToDate.Value);
            LoadDateTime();
            loadListFood();
            loadComboboxCategory(cb_Category);
            addFoodBinding();
            addTableBinding();
            addBindingAccount();
            addCategoryBinding();
            loadTable();
            loadCategory();
        }
        #region account
        void LoadAccountList()
        {
            accountList.DataSource = AccountDAO.Instance.GetAccount();
        }

        void addBindingAccount()
        {
            txt_AccountName.DataBindings.Add(new Binding("Text", dtgv_Account.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txt_DisplayAccountName.DataBindings.Add(new Binding("Text", dtgv_Account.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nb_Type.DataBindings.Add(new Binding("Value", dtgv_Account.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        private void btn_ViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        private void btn_AddAccount_Click(object sender, EventArgs e)
        {
            string userName = txt_AccountName.Text;
            string displayName = txt_DisplayAccountName.Text;
            int type = (int)nb_Type.Value;

            addAccount(userName, displayName, type);
        }

        private void btn_DeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txt_AccountName.Text;

            deleteAccount(userName);
        }

        private void btn_EditAccount_Click(object sender, EventArgs e)
        {
            string userName = txt_AccountName.Text;
            string displayName = txt_DisplayAccountName.Text;
            int type = (int)nb_Type.Value;

            updateAccount(userName, displayName, type);
        }

        private void btn_ResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txt_AccountName.Text;

            resetPassword(userName);
        }

        void addAccount(string userName , string displayName, int type)
        {
            if (AccountDAO.Instance.insertAccount(userName, displayName, type))
            {
                MessageBox.Show("Bạn đã tạo tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Bạn đã tạo tài khoản thất bại");
            }
            LoadAccountList();
        }

        void resetPassword(string userName)
        {
            if (AccountDAO.Instance.resetPassWord(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }

        void updateAccount(string userName,string displayName,int type)
        {
            if (AccountDAO.Instance.updateAccount(userName, displayName, type))
            {
                MessageBox.Show("Bạn đã cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Bạn đã cập nhật tài khoản thất bại");
            }
            LoadAccountList();
        }


        void deleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng không xóa tài khoản");
                return;
            }
            if (AccountDAO.Instance.deleteAccount(userName))
            {
                MessageBox.Show("Bạn đã xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Bạn đã xóa tài khoản thất bại");
            }
            LoadAccountList();
        }

        #endregion

        #region bill
        void loadListBill(DateTime checkIn , DateTime checkOut)
        {
            dtgv_Bill.DataSource = BillDAO.Instance.GetListBillDate(checkIn, checkOut);
        }

        void LoadDateTime()
        {
            DateTime today = DateTime.Now;
            dt_FromDate.Value = new DateTime(today.Year, today.Month, 1);
            dt_ToDate.Value = dt_FromDate.Value.AddMonths(1).AddDays(-1);
        }

        private void btn_THONGKE_Click(object sender, EventArgs e)
        {
            loadListBill(dt_FromDate.Value, dt_ToDate.Value);
        }

        #endregion

        #region food

        void addFoodBinding()
        {
            txt_FoodName.DataBindings.Add(new Binding("Text", dtgv_Food.DataSource, "Name" ,true,DataSourceUpdateMode.Never));
            txt_FoodID.DataBindings.Add(new Binding("Text", dtgv_Food.DataSource, "ID" , true, DataSourceUpdateMode.Never));
            nb_Price.DataBindings.Add(new Binding("Value", dtgv_Food.DataSource, "Price" , true, DataSourceUpdateMode.Never));
        }

        void loadComboboxCategory(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        void loadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.getListFood();
        }

        private void btn_ViewFood_Click(object sender, EventArgs e)
        {
            loadListFood();
        }

        private void txt_FoodID_TextChanged(object sender, EventArgs e)
        {
            int id = (int)dtgv_Food.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

            Category category = CategoryDAO.Instance.GetCategoryID(id);

            cb_Category.SelectedItem = category;

            int index = -1;

            int i = 0;

            foreach(Category item in cb_Category.Items)
            {
                if(item.ID == category.ID)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cb_Category.SelectedIndex = index;
        }

        private void btn_AddFood_Click(object sender, EventArgs e)
        {
            string name = txt_FoodName.Text;
            int categoryID = (cb_Category.SelectedItem as Category).ID;
            float price = (float)nb_Price.Value;

            if (FoodDAO.Instance.insertFood(name,categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                loadListFood(); 
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món ");
            }
        }

        private void btn_EditFood_Click(object sender, EventArgs e)
        {
            string name = txt_FoodName.Text;
            int categoryID = (cb_Category.SelectedItem as Category).ID;
            float price = (float)nb_Price.Value;
            int id = Convert.ToInt32(txt_FoodID.Text);


            if (FoodDAO.Instance.updateFood(id,name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                loadListFood();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa món ăn");
            }
        }

        private void btn_DeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_FoodID.Text);

            if (FoodDAO.Instance.deleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                loadListFood();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa món ");
            }
        }

        #endregion

        #region table
        void loadTable()
        {
            tableList.DataSource = TableDAO.Instance.getListTable();
        }

        void addTableBinding()
        {
            txtIDTable.DataBindings.Add(new Binding("Text", dtgr_Table.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dtgr_Table.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        private void btn_AddTable_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;
 
            if (TableDAO.Instance.insertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công và bạn cần đăng nhập lại để xem thay đổi");
                loadTable();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn ");
            }
        }

        private void btn_EditTable_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;
            int id = Convert.ToInt32(txtIDTable.Text);
            if (TableDAO.Instance.updateTable(name,id))
            {
                MessageBox.Show("Sửa bàn thành công và bạn cần đăng nhập lại để xem thay đổi");
                loadTable();
            }
            else
            {
                MessageBox.Show("Sửa bàn thất bại");
            }
        }

        private void btn_ViewTable_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void btn_DeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDTable.Text);
            if (TableDAO.Instance.deleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công và bạn cần đăng nhập lại để xem thay đổi");
                loadTable();
            }
            else
            {
                MessageBox.Show("Xóa bàn thất bại");
            }
        }

        #endregion

         void addCategoryBinding()
        {
            txt_CategoryID.DataBindings.Add(new Binding("Text", dtgv_Category.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txt_CategoryName.DataBindings.Add(new Binding("Text",dtgv_Category.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        private void btn_ViewCategory_Click(object sender, EventArgs e)
        {
            loadCategory();
        }

        private void btn_AddCategory_Click(object sender, EventArgs e)
        {
            string name = txt_CategoryName.Text;
            addCategory(name);
        }

        private void btn_DeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_CategoryID.Text);
            deleteCategory(id);
        }

        private void btn_EditCategory_Click(object sender, EventArgs e)
        {
            string name = txt_CategoryName.Text;
            int id = Convert.ToInt32(txt_CategoryID.Text);
            updateCategory(name, id);
        }

        public void addCategory(string name)
        {
            if (CategoryDAO.Instance.insertCategory(name))
            {
                MessageBox.Show("Thêm danh mục món ăn thành công và bạn cần đăng nhập lại để xem thay đổi");
                loadCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục món ");
            }
        }

        void updateCategory(string name,int id)
        {
            if (CategoryDAO.Instance.updateCategory(name, id))
            {
                MessageBox.Show("Sửa danh mục món thành công và bạn cần đăng nhập lại để xem thay đổi");
                loadCategory();
            }
            else
            {
                MessageBox.Show("Sửa danh mục món thất bại");
            }
        }

        void deleteCategory(int id)
        {
            if (CategoryDAO.Instance.deleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục món thành công và bạn cần đăng nhập lại để xem thay đổi");
                loadCategory();
            }
            else
            {
                MessageBox.Show("Xóa danh mục món thất bại");
            }
        }

        void loadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
    }
}
