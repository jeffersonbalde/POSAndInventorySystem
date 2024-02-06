﻿using System;
using System.Collections;
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
    public partial class UpdateCustomer : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        ManageCustomer frm;

        public UpdateCustomer(ManageCustomer form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());

            frm = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtContactNo.Text == "" || txtAddress.Text == "")
                {
                    MessageBox.Show("Please fill up all fields", "ADD ITEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to update this customer?", "UPDATE ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //int customerID = 0;

                    //CUSTOMER ID
                    //cn.Open();
                    //string query1 = "SELECT ID FROM CustomerInformation WHERE Name LIKE '" + txtName.Text + "'";
                    //cm = new SqlCommand(query1, cn);
                    //dr = cm.ExecuteReader();
                    //dr.Read();
                    //if (dr.HasRows)
                    //{
                    //    customerID = int.Parse(dr["ID"].ToString());
                    //}
                    //dr.Close();
                    //cn.Close();

                    cn.Open();
                    string query2 = "UPDATE CustomerInformation SET Name = @name, ContactNo = @contactNo, Address = @address WHERE ID LIKE '" + customerID.Text + "'";
                    cm = new SqlCommand(query2, cn);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@contactNo", txtContactNo.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Customer has been successfully updated.");

                    frm.LoadCustomerName();
                    this.Dispose();

                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
