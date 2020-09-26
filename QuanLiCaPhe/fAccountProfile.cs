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
    public partial class frm_AccountProfile : Form
    {
        private Account login;

        public Account Login
        {
            get { return login; }
            set { login = value; changeAccount(login); }
        }

        public frm_AccountProfile(Account acc)
        {
            InitializeComponent();

            Login = acc;
        }

        void changeAccount(Account acc)
        {
            txt_UserName.Text = Login.UserName;
            txt_DisplayName.Text = Login.DisplayName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void updateAccount()
        {
            string displayName = txt_DisplayName.Text;
            string passWord = txt_PassWord.Text;
            string newPassWord = txt_NewPassWord.Text;
            string rePassWord = txt_ReEnter.Text;
            string userName = txt_UserName.Text;

            if (!newPassWord.Equals(rePassWord))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, passWord, newPassWord))
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu ");
                }
            }
        }

       private void AccountProfile_Load(object sender, EventArgs e)
        {

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            updateAccount();
        }
    }
}
