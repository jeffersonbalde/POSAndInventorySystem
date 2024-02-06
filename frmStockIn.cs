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
    public partial class frmStockIn : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        Form1 form1;
        frmProductList frmpl;
        
        public frmStockIn(Form1 frm, frmProductList frmPL)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());

            form1 = frm;
            frmpl = frmPL;
            frm.GetDashboard();
            this.KeyPreview = true;
        }

        private void frmStockIn_Load(object sender, EventArgs e)
        {

        }


        //Not in use former refereance methods
        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string colName = dataGridView2.Columns[e.ColumnIndex].Name;
        //    if(colName == "colDelete")
        //    {
        //        if(MessageBox.Show("Remove this item", "REMOVE ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            cn.Open();
        //            string query = "DELETE FROM tblstockin WHERE id = '" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() +  "'";
        //            cm = new SqlCommand(query, cn);
        //            cm.ExecuteNonQuery();
        //            cn.Close();
        //            MessageBox.Show("Item has been successfully removed");
        //            LoadStockIn();
        //        }
        //    }
        //}

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        public void LoadStockIn()  //did not comment out gi refer ang method sa frmSearchProductStockIn
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            string query = "SELECT * FROM vwStockin WHERE refno LIKE '" + textBoxRefNo.Text + "' AND status LIKE 'Pending'";
            string query1 = "SELECT p.pdesc, s.refno, s.pcode, s.qty, s.sdate FROM tblProduct AS p INNER JOIN tblStockIn AS s ON s.pcode = p.pcode WHERE s.refno LIKE '" + textBoxRefNo.Text + "' AND status LIKE 'Pending'";
            cm = new SqlCommand(query, cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["refno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), DateTime.Parse(dr["sdate"].ToString()).ToShortDateString());
            }
            dr.Close();
            cn.Close();
        }



        //public void LoadStockInHistory()
        //{
        //int i = 0;
        //dataGridView1.Rows.Clear();
        //cn.Open();
        ////string query = "SELECT * FROM vwStockin WHERE cast(sdate as date) between '" + date1.Value.ToShortDateString() + "' and '" + date2.Value.ToShortDateString() + "' and status LIKE 'Done'"
        //cm = new SqlCommand("SELECT * from vwStockin where cast(sdate as date) between '" + date1.Value.ToString("yyyy-MM-dd") + "' and '" + date2.Value.ToString("yyyy-MM-dd") + "' and status like 'Done'", cn);
        //dr = cm.ExecuteReader();
        //while (dr.Read())
        //{
        //    i++;
        //    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["refno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), DateTime.Parse(dr["sdate"].ToString()).ToShortDateString());
        //}
        //dr.Close();
        //cn.Close();
        // }

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    this.Dispose();
        //}

        //private void txtSearch_Click(object sender, EventArgs e)
        //{

        //}

        //private void panel2_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    frmSearchProductStockin frm = new frmSearchProductStockin(this);
        //    frm.LoadProduct();
        //    frm.ShowDialog();
        //}

        //private void panel3_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //public void Clear()
        //{
        //    txtBy.Clear();
        //    txtRefNo.Clear();
        //    dt1.Value = DateTime.Now;
        //}

        //private void button1_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void btnLoad_Click(object sender, EventArgs e)
        //{
        //    LoadStockInHistory();
        //}

        //private void panel5_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Dispose();
        //}

        //private void button1_Click_2(object sender, EventArgs e) //exit button up
        //{
        //    this.Dispose();
        //}

        //private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    Random random = new Random();
        //    txtRefNo.Clear();
        //    txtRefNo.Text += random.Next();
        //    //string rndm = txtRefNo.Text += random.Next();
        //    //txtRefNo.Text = rndm.Substring(0, 5);
        //}

        //private void frmStockIn_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //}

        private void frmStockIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }


        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //end of former click actions

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmSearchProductStockin frm = new frmSearchProductStockin(this);
            frm.LoadProduct();
            frm.ShowDialog();
        }

        //end of former click actions

        public void GenerateRefNo()
        {
            Random random = new Random();
            textBoxRefNo.Clear();
            textBoxRefNo.Text += random.Next();
            //string rndm = txtRefNo.Text += random.Next();
            //txtRefNo.Text = rndm.Substring(0, 5);
        }

        private void textBoxRefNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this items?", "SAVE ITEMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            // update tblproduct quantity
                            cn.Open();
                            string query = "UPDATE tblproduct SET qty = qty + " + int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) + " WHERE pcode LIKE '" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "'";
                            cm = new SqlCommand(query, cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                            //update tblstockin quantity
                            cn.Open();
                            string query1 = "UPDATE tblstockin SET qty = qty + " + int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) + ", status = 'Done' WHERE id LIKE '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
                            cm = new SqlCommand(query1, cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        LoadStockIn();
                        form1.GetDashboard();
                        frmpl.LoadRecords();
                        MessageBox.Show("Items saved.", "SAVED ITEMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "ALL J SHOP GENERAL MERCHANDISE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item?", "REMOVE ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    string query = "DELETE FROM tblstockin WHERE id = '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                    cm = new SqlCommand(query, cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadStockIn();
                }
            }
        }
    }
}
