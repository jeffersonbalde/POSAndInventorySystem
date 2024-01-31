﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_System
{
    public partial class CashierItemSales : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        frmSoldItems frmS;
        frmAddDebt frmAdd;


        public CashierItemSales(frmSoldItems form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());

            frmS = form;

            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("All");
            cn.Open();
            string query = "SELECT name from tblUser WHERE role = 'Cashier'";
            string query1 = "SELECT name from tblUser";
            cm = new SqlCommand(query1, cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboCashier.Items.Add(dr["name"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void LoadRecord()
        {
            try
            {
                int i = 0;
                double _total = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                //if (cboCashier.Text == "All")
                //{
                //    string query2 = "SELECT c.transno, c.pcode, p.pdesc, c.price, SUM(c.qty) AS qty, SUM(c.disc) AS disc, SUM(c.total) AS total, c.cashier, c.MOP FROM tblcart AS c INNER JOIN tblProduct as p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' AND MOP LIKE '" + comboBoxCategory.Text + "' GROUP BY c.cashier, c.pcode, p.pdesc, c.price, c.transno, c.MOP ORDER BY c.transno DESC";
                //    //string query1 = "SELECT c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, SUM(c.total) AS total FROM tblCart as c INNER JOIN tblProduct as p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' GROUP BY c.transno ORDER BY total DESC";
                //    cm = new SqlCommand(query2, cn);
                //}
                //else
                //{

                //    string query = "SELECT c.transno, c.pcode, p.pdesc, c.price, SUM(c.qty) AS qty, SUM(c.disc) AS disc, SUM(c.total) AS total, c.cashier, c.MOP FROM tblcart AS c INNER JOIN tblProduct as p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' AND cashier LIKE '" + cboCashier.Text + "' AND MOP LIKE '" + comboBoxCategory.Text + "' GROUP BY c.cashier, c.pcode, p.pdesc, c.price, c.transno, c.MOP ORDER BY c.transno DESC";
                //    //string query = "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total FROM tblCart as c INNER JOIN tblProduct as p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' AND cashier LIKE '" + cboCashier.Text + "'";
                //    cm = new SqlCommand(query, cn);
                //}

                //if(comboBoxCategory.Text == "")
                //{
                //    string query2 = "SELECT c.transno, c.pcode, p.pdesc, c.price, SUM(c.qty) AS qty, SUM(c.disc) AS disc, SUM(c.total) AS total, c.cashier, c.MOP FROM tblcart AS c INNER JOIN tblProduct as p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' GROUP BY c.cashier, c.pcode, p.pdesc, c.price, c.transno, c.MOP ORDER BY c.transno DESC";
                //    cm = new SqlCommand(query2, cn);
                //}
                //else
                //{
                //    string query = "SELECT c.transno, c.pcode, p.pdesc, c.price, SUM(c.qty) AS qty, SUM(c.disc) AS disc, SUM(c.total) AS total, c.cashier, c.MOP FROM tblcart AS c INNER JOIN tblProduct as p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' AND cashier LIKE '" + cboCashier.Text + "' AND MOP LIKE '" + comboBoxCategory.Text + "' GROUP BY c.cashier, c.pcode, p.pdesc, c.price, c.transno, c.MOP ORDER BY c.transno DESC";
                //    //string query = "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total FROM tblCart as c INNER JOIN tblProduct as p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' AND cashier LIKE '" + cboCashier.Text + "'";
                //    cm = new SqlCommand(query, cn);
                //}

                string query2 = "SELECT c.transno, c.pcode, p.pdesc, c.price, SUM(c.qty) AS qty, SUM(c.disc) AS disc, SUM(c.total) AS total, c.cashier, c.MOP FROM tblcart AS c INNER JOIN tblProduct as p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' GROUP BY c.cashier, c.pcode, p.pdesc, c.price, c.transno, c.MOP ORDER BY c.transno DESC";
                cm = new SqlCommand(query2, cn);

                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    i += 1;
                    _total += double.Parse(dr["total"].ToString());
                    //dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
                    dataGridView1.Rows.Add(i, dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString(), dr["cashier"].ToString(), dr["MOP"].ToString());

                }
                dr.Close();
                cn.Close();
                lblTotal.Text = _total.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "colCancel")
            {
                frmCancelDetails f = new frmCancelDetails(this);
                //f.txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtTransnoNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtPCode.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                f.txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.txtQty.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.txtDiscount.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                f.txtTotal.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                f.txtCancel.Text = cboCashier.Text;

                f.ShowDialog();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmViewDebt frm = new frmViewDebt();
            frm.LoadCustomer();
            frm.DefaultCustomerDebtTotal();
            frm.cboCashier.Text = "All";
            frm.LoadCustomerName();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerDetails frm = new CustomerDetails();
            frm.LoadCustomerInformation();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CompletePayment frm = new CompletePayment(this, null);
            frm.LoadCustomerName();
            frm.ShowDialog();
        }

        private void CashierItemSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.F1)
            {
                btnAddItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                button2_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                button3_Click(sender, e);
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void comboBoxCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
