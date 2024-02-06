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
    public partial class frmDiscount : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        frmPOS f;

        Double discount;

        public frmDiscount(frmPOS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            f = frm;
            this.KeyPreview = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {

        }

        private void txtPercent_TextChanged(object sender, EventArgs e)
        {


            //if (txtPercent.Text == "")
            //{
            //    return;
            //}else if(txtPercent.Text == ".")
            //{
            //    return;
            //}

            //try
            //{

                //double discount = Double.Parse(txtPrice.Text) * Double.Parse(txtPercent.Text);
                //txtAmount.Text = discount.ToString("#,##0.00");

                //discount = Double.Parse(txtTotal.Text) - Double.Parse(txtPercent.Text);
                //txtAmount.Text = discount.ToString("#,##0.00");
            //}
            //catch(Exception ex)
            //{
            //    txtAmount.Text = "0.00";
            //    MessageBox.Show(ex.Message);
            //}

            



            try
            {

                double inputDiscount = double.Parse(txtPercent.Text);
                double total = double.Parse(txtTotal.Text);

                discount = total - inputDiscount;
                txtAmount.Text = discount.ToString("#,##0.00");

            }
            catch (Exception ex)
            {
                
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if(MessageBox.Show("Add discount? Click yes to confirm.", "ALL J GENERAL MERCHANDISE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    string query = "UPDATE tblcart SET disc = @disc WHERE id = @id";
                    cm = new SqlCommand(query, cn);
                    cm.Parameters.AddWithValue("@disc", Double.Parse(txtPercent.Text));
                    cm.Parameters.AddWithValue("@id", int.Parse(lblID.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();
                    f.LoadCart();
                    this.Dispose();
                }

            }catch(Exception ex)
            {
                cn.Close();

            }
        }

        private void frmDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                button3_Click_1(sender, e);   
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnEnter_Click(sender, e);
            }
        }

        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            //accept only numbers
            if (e.KeyChar == 46)
            {
                //accept . character
            }
            else if (e.KeyChar == 8)
            {
                //accept backspace
            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57)) //accept code 48-57 between 0-9
            {
                e.Handled = true;
            }
        }


        //button controls

        private void btn7_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn7.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn0.Text;
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn00.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn3.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn6.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtPercent.Text += btn9.Text;
        }


        private void btndot_Click(object sender, EventArgs e)
        {
            //txtPercent.Text += btndot.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnless_Click(object sender, EventArgs e)
        {
            int length = txtPercent.Text.Length;

            if(txtPercent.Text == "")
            {
                return;
            }
            else
            {
                txtPercent.Text = txtPercent.Text.Substring(0, length - 1);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            txtPercent.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn7_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn7.Text;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(txtPercent.Text == "")
            {
                MessageBox.Show("Insufficient Amount!", "ADD DISCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (double.Parse(txtAmount.Text) < 0)
            {
                MessageBox.Show("Insufficient Amount!", "ADD DISCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Add discount? Click yes to confirm.", "ADD DISCOUNT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    string query = "UPDATE tblcart SET disc = @disc WHERE id = @id";
                    cm = new SqlCommand(query, cn);
                    cm.Parameters.AddWithValue("@disc", Double.Parse(txtPercent.Text));
                    cm.Parameters.AddWithValue("@id", int.Parse(lblID.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();
                    f.LoadCart();
                    this.Dispose();
                }
            }
        }

        private void btn8_Click_1(object sender, EventArgs e)
        {

        }

        private void btn7_Click_2(object sender, EventArgs e)
        {
            txtPercent.Text += btn7.Text;
        }

        private void btn8_Click_2(object sender, EventArgs e)
        {
            txtPercent.Text += btn8.Text;
        }

        private void btn9_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn9.Text;
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn4.Text;
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn5.Text;
        }

        private void btn6_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn6.Text;
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn1.Text;
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn2.Text;
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn3.Text;
        }

        private void btn0_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn0.Text;
        }

        private void btn00_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += btn00.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtPercent.Text += button1.Text;
        }

        private void btnc_Click_1(object sender, EventArgs e)
        {
            txtPercent.Clear();
            txtPercent.Focus();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            int length = txtPercent.Text.Length;


            if (txtPercent.Text == "")
            {
                return;
            }
            else
            {
                txtPercent.Text = txtPercent.Text.Substring(0, length - 1);
            }
        }
    }
}
