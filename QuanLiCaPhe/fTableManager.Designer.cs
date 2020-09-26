using System;
using System.Windows.Forms;

namespace QuanLiCaPhe
{
    partial class frm_TableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnTable = new System.Windows.Forms.Panel();
            this.pfl_Table = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lv_Bill = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtToTalPrice = new System.Windows.Forms.TextBox();
            this.nbDiscout = new System.Windows.Forms.NumericUpDown();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nb_AddFood = new System.Windows.Forms.NumericUpDown();
            this.btn_AddFood = new System.Windows.Forms.Button();
            this.cb_Food = new System.Windows.Forms.ComboBox();
            this.cb_Category = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnTable.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbDiscout)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_AddFood)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTable
            // 
            this.pnTable.Controls.Add(this.pfl_Table);
            this.pnTable.Location = new System.Drawing.Point(12, 31);
            this.pnTable.Name = "pnTable";
            this.pnTable.Size = new System.Drawing.Size(694, 569);
            this.pnTable.TabIndex = 0;
            // 
            // pfl_Table
            // 
            this.pfl_Table.AutoScroll = true;
            this.pfl_Table.Location = new System.Drawing.Point(3, 3);
            this.pfl_Table.Name = "pfl_Table";
            this.pfl_Table.Size = new System.Drawing.Size(688, 563);
            this.pfl_Table.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1311, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lv_Bill);
            this.panel2.Location = new System.Drawing.Point(709, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 416);
            this.panel2.TabIndex = 2;
            // 
            // lv_Bill
            // 
            this.lv_Bill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.lv_Bill.GridLines = true;
            this.lv_Bill.HideSelection = false;
            this.lv_Bill.Location = new System.Drawing.Point(3, 3);
            this.lv_Bill.Name = "lv_Bill";
            this.lv_Bill.Size = new System.Drawing.Size(577, 410);
            this.lv_Bill.TabIndex = 0;
            this.lv_Bill.UseCompatibleStateImageBehavior = false;
            this.lv_Bill.View = System.Windows.Forms.View.Details;
            this.lv_Bill.SelectedIndexChanged += new System.EventHandler(this.lvBill_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên món";
            this.columnHeader3.Width = 154;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Số lượng";
            this.columnHeader1.Width = 108;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Đơn giá";
            this.columnHeader2.Width = 109;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 138;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtToTalPrice);
            this.panel3.Controls.Add(this.nbDiscout);
            this.panel3.Controls.Add(this.btnCheckOut);
            this.panel3.Location = new System.Drawing.Point(709, 526);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(583, 74);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // txtToTalPrice
            // 
            this.txtToTalPrice.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToTalPrice.ForeColor = System.Drawing.Color.Red;
            this.txtToTalPrice.Location = new System.Drawing.Point(256, 38);
            this.txtToTalPrice.Name = "txtToTalPrice";
            this.txtToTalPrice.ReadOnly = true;
            this.txtToTalPrice.Size = new System.Drawing.Size(127, 28);
            this.txtToTalPrice.TabIndex = 8;
            this.txtToTalPrice.Text = "0";
            // 
            // nbDiscout
            // 
            this.nbDiscout.Location = new System.Drawing.Point(18, 44);
            this.nbDiscout.Name = "nbDiscout";
            this.nbDiscout.Size = new System.Drawing.Size(90, 22);
            this.nbDiscout.TabIndex = 5;
            this.nbDiscout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbDiscout.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(490, 4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(90, 62);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "Thanh toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nb_AddFood);
            this.panel4.Controls.Add(this.btn_AddFood);
            this.panel4.Controls.Add(this.cb_Food);
            this.panel4.Controls.Add(this.cb_Category);
            this.panel4.Location = new System.Drawing.Point(709, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(583, 67);
            this.panel4.TabIndex = 4;
            // 
            // nb_AddFood
            // 
            this.nb_AddFood.Location = new System.Drawing.Point(500, 27);
            this.nb_AddFood.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nb_AddFood.Name = "nb_AddFood";
            this.nb_AddFood.Size = new System.Drawing.Size(69, 22);
            this.nb_AddFood.TabIndex = 3;
            // 
            // btn_AddFood
            // 
            this.btn_AddFood.Location = new System.Drawing.Point(404, 10);
            this.btn_AddFood.Name = "btn_AddFood";
            this.btn_AddFood.Size = new System.Drawing.Size(90, 54);
            this.btn_AddFood.TabIndex = 2;
            this.btn_AddFood.Text = "Thêm món";
            this.btn_AddFood.UseVisualStyleBackColor = true;
            this.btn_AddFood.Click += new System.EventHandler(this.btn_AddFood_Click);
            // 
            // cb_Food
            // 
            this.cb_Food.FormattingEnabled = true;
            this.cb_Food.Location = new System.Drawing.Point(3, 33);
            this.cb_Food.Name = "cb_Food";
            this.cb_Food.Size = new System.Drawing.Size(392, 24);
            this.cb_Food.TabIndex = 1;
            this.cb_Food.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cb_Category
            // 
            this.cb_Category.FormattingEnabled = true;
            this.cb_Category.Location = new System.Drawing.Point(3, 3);
            this.cb_Category.Name = "cb_Category";
            this.cb_Category.Size = new System.Drawing.Size(392, 24);
            this.cb_Category.TabIndex = 0;
            this.cb_Category.SelectedIndexChanged += new System.EventHandler(this.cb_Category_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "GIảm giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tổng tiền";
            // 
            // frm_TableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 622);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_TableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lí Quán Cà Phê";
            this.pnTable.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbDiscout)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nb_AddFood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lvBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.Panel pnTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lv_Bill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cb_Food;
        private System.Windows.Forms.ComboBox cb_Category;
        private System.Windows.Forms.Button btn_AddFood;
        private System.Windows.Forms.FlowLayoutPanel pfl_Table;
        private System.Windows.Forms.NumericUpDown nbDiscout;
        private System.Windows.Forms.Button btnCheckOut;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader4;
        private TextBox txtToTalPrice;
        private NumericUpDown nb_AddFood;
        private Label label2;
        private Label label1;
    }
}