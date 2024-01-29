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
    public partial class frmSearchProductStockin : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        frmStockIn slist;

        public frmSearchProductStockin(frmStockIn flist)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            slist = flist;

            this.KeyPreview = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            //if(slist.dataGridView1.Rows.Count > 0)
            //{
            //    if (colName == "colSelect")
            //    {
            //        //if (slist.txtRefNo.Text == string.Empty) { MessageBox.Show("Please enter reference no", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Warning); slist.txtRefNo.Focus(); return; }
            //        //if (slist.txtBy.Text == string.Empty) { MessageBox.Show("Please enter stock in name", "ALL J SHOP GENERAL MERCHANDISE", MessageBoxButtons.OK, MessageBoxIcon.Warning); slist.txtBy.Focus(); return; }

            //        if (MessageBox.Show("Add this item?", "ADD ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            cn.Open();
            //            string query = "INSERT INTO tblstockin (refno, pcode, sdate)VALUES(@refno, @pcode, @sdate)";
            //            cm = new SqlCommand(query, cn);
            //            cm.Parameters.AddWithValue("@refno", slist.textBoxRefNo.Text);
            //            cm.Parameters.AddWithValue("@pcode", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            //            cm.Parameters.AddWithValue("@sdate", slist.dt2.Value);
            //            cm.ExecuteNonQuery();
            //            cn.Close();

            //            MessageBox.Show("Item added.", "ADD ITEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //slist.LoadStockIn();
            //            return;
            //        }
            //    }
            //}

            try
            {

                if (colName == "colSelect")
                {
                    //if (slist.txtRefNo.Text == string.Empty) { MessageBox.Show("Please enter reference no", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Warning); slist.txtRefNo.Focus(); return; }
                    //if (slist.txtBy.Text == string.Empty) { MessageBox.Show("Please enter stock in name", "ALL J SHOP GENERAL MERCHANDISE", MessageBoxButtons.OK, MessageBoxIcon.Warning); slist.txtBy.Focus(); return; }

                    //string slistColumnName = slist.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    //string searchColumnName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                    //if (slistColumnName == searchColumnName)
                    //{
                    //    MessageBox.Show("Item " + slistColumnName + " already added.", "ADD ITEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    if (MessageBox.Show("Add this item?", "ADD ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        string query = "INSERT INTO tblstockin (refno, pcode, sdate)VALUES(@refno, @pcode, @sdate)";
                        cm = new SqlCommand(query, cn);
                        cm.Parameters.AddWithValue("@refno", slist.textBoxRefNo.Text);
                        cm.Parameters.AddWithValue("@pcode", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cm.Parameters.AddWithValue("@sdate", slist.dt2.Value);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        MessageBox.Show("Item added.", "ADD ITEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        slist.LoadStockIn();
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadProduct()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            string query = "SELECT pcode, pdesc, qty FROM tblproduct WHERE pdesc LIKE '%" + txtSearch.Text + "%' ORDER BY pdesc";
            cm = new SqlCommand(query, cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmSearchProductStockin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSearch;
        }

        private void frmSearchProductStockin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button1_Click(sender, e);
            }
        }
    }
}
