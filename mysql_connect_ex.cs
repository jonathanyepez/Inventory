using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

string MyConnectionString = "Server=localhost;Database=testdb;Uid=root;Pwd=password;";

private void btnSubmit_Click(object sender, EventArgs e){
	int MobileNo;
	string Mobile = txtMobile.Text;
	int.TryParse(Mobile, out MobileNo);
	MySqlConnection connection = new MySqlConnection(MyConnectionString);
	MySqlCommand cmd;
	connection.Open();
	try{
		cmd = connection.CreateCommand();
		cmd.CommandText = "INSERT INTO PhoneBook(Id, Name, MobileNo) VALUES (@Id,@Name,@MobileNo)";
		cmd.Parameters.AddWithValue("@Id",int.Parse(txtId.Text));
		cmd.Parameters.AddWithValue("@Name",txtName.Text);
		cmd.Parameters.AddWithValue("@MobileNo",Mobile);
		cmd.ExecuteNonQuery();
	}
	catch(Exception){
		throw;
	}
	finally{
		if(connection.State==ConnectionState.Open){
			connection.Close();
			LoadData();
		}
	}
}

private void LoadData(){
	MySqlConnection connection = new MySqlConnection(MyConnectionString);
	connection.Open();
	try{
		MySqlCommand cmd = connection.CreateCommand();
		cmd.CommandText = "SELECT * FROM PhoneBook";
		MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
		DataSet ds = new DataSet();
		adap.Fill(ds);
		dataGridView1.DataSource = ds.Tables[0].DefaultView;
	}
	catch(Exception){
		throw;
	}
	finally{
		if(connection.State == ConnectionState.Open){
			connection.Clone();
		}
	}
}