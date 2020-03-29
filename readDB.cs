using System;  
using System.Data.OleDb;  
namespace AccessDBSample{
	class Program{
		static void Main(string[] args){
			string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Jono Files\Renuncia EcoMachine\Database1.accdb;Persist Security Info=False";
			Console.WriteLine("Welcome\nTo create a new entry, type: 1\nTo read the info from the DB, type: 2");
			int act = Convert.ToInt32(Console.ReadLine());
			if(act==1){
				Console.WriteLine("Here we would interact with the .NET form");
			}else{
				string strSQL = "SELECT * FROM Status";
				using (OleDbConnection connection = new OleDbConnection(connectionstring)){
					OleDbCommand command = new OleDbCommand(strSQL, connection);
					try{
						connection.Open();
						using (OleDbDataReader reader = command.ExecuteReader()){
							Console.WriteLine("----------Original Data------------");
							while(reader.Read()){
								Console.WriteLine("{0} {1}", reader["Barcode"].ToString(), reader["Description"].ToString());
								Console.Write("Number of Available Items: ");
								Console.WriteLine("{0}\n",reader["Available"].ToString());
							}
						}
					}
					catch (Exception ex){
						Console.WriteLine(ex.Message);
					}
				}
			}
			Console.ReadKey();
		}
	}
}