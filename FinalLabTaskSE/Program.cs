using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace labTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int condition = 0;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\users\ali\documents\visual studio 2015\Projects\FinalLabTaskSE\FinalLabTaskSE\Database1.mdf;Integrated Security=True";
            SqlConnection c = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            
            c.Open();
            while (condition != 5)
            {
                Console.WriteLine("Press from following:\n");
                Console.WriteLine("1-Add new Member\n2-Update existing Member\n3-Delete Existing Member ");
                Console.Write("4-Show all Members\n5-Exit");
                condition = int.Parse(Console.ReadLine());
                Console.Clear();
                



                if (condition == 4)

                {
                    
                    Console.WriteLine("Every Member Ever:\n");
                    string q = "select * from Member";
                    SqlCommand cmd = new SqlCommand(q, c);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine("ID :        {0}", rdr[0]);
                        Console.WriteLine("Full name : {0}", rdr[1]);
                        Console.WriteLine("Email :     {0}", rdr[2]);
                        Console.WriteLine("Address :   {0}", rdr[3]);
                        Console.WriteLine("Phone :     {0}", rdr[4]);
                        Console.WriteLine("Gender :    {0}", rdr[5]);
                    }

                    c.Close();
                    // Console.ReadKey();


                }
                else if (condition == 1)

                {
                    Console.WriteLine("Adding New Member");
                    Console.WriteLine("Enter ID :");
                    int ID_add = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Full name :");
                    string fullName_add = Console.ReadLine();
                    Console.WriteLine("enter email address :");
                    string email_add = Console.ReadLine();
                    Console.WriteLine("enter address :");
                    string address_add = Console.ReadLine();
                    Console.WriteLine("enter phone # :");
                    string phonenumber_add = Console.ReadLine();
                    Console.WriteLine("press 1/2 for :");
                    Console.WriteLine("\t1-male\n\t2-female");
                    string gender_add = Console.ReadLine();
                    if (gender_add == "1")
                    {
                        gender_add = "male";
                    }
                    else
                    {
                        gender_add = "female";
                    }

                    


                    //String q = "insert into Member (Id,Fullname, Gender,Address,Phone,Email) values (" + ID_add +",'" + fullName_add+"'," + gender_add +", '" + address_add +"', " + phonenumber_add +" , '" + email_add + "')";
                    String q = "insert into Member (Id,Fullname,Email,Address,Phone,Gender) values (" + ID_add + ", '" + fullName_add + "', '" + email_add + "','" + address_add + "','" + phonenumber_add + "','" + gender_add + "')";
                    Console.WriteLine(q);
                    //String q1 = "insert into POS_table1 (name,selling_price,purchasing_price,quantity) values('" + name1 + "', " + selling_price1 + ", " + purchasing_price1 + ", " + quantity1 + ")";
                    adapter.InsertCommand = new SqlCommand(q, c);
                    adapter.InsertCommand.ExecuteNonQuery();
                    Console.WriteLine("Added Successfully!");
                }

                else if (condition == 2)
                {
                    Console.WriteLine("Updating Existing Member");
                    Console.WriteLine("Enter id number to update : ");
                    int id_update = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Full name :");
                    string fullName_add = Console.ReadLine();
                    Console.WriteLine("enter email address :");
                    string email_add = Console.ReadLine();
                    Console.WriteLine("enter address :");
                    string address_add = Console.ReadLine();
                    Console.WriteLine("enter phone # :");
                    string phonenumber_add = Console.ReadLine();
                    Console.WriteLine("press 1/2 for :");
                    Console.WriteLine("\t1-male\n\t2-female");
                    string gender_add = Console.ReadLine();
                    if (gender_add == "1")
                    {
                        gender_add = "male";
                    }
                    else
                    {
                        gender_add = "female";
                    }
                    string q = "update Member set Fullname= '" + fullName_add + "' ,  Email = '" + email_add + "', Address = '" + address_add + "', Phone= '" + phonenumber_add + "', Gender = '" + gender_add + "' where id=" + id_update + "";
                    Console.WriteLine(q);
                    adapter.UpdateCommand = new SqlCommand(q, c);
                    adapter.UpdateCommand.ExecuteNonQuery();
                    Console.WriteLine("Update Successful");

                }

                else if (condition == 3)
                {
                    Console.WriteLine("Deleting Member");
                    Console.WriteLine("Enter id to delete Member : ");
                    int id_delete=int.Parse(Console.ReadLine());
                    string q = "delete from Member where id=" + id_delete + "";

                    Console.WriteLine(q);
                    adapter.DeleteCommand = new SqlCommand(q, c);
                    adapter.DeleteCommand.ExecuteNonQuery();
                    Console.WriteLine("Delete successful");
                    
                }
            }
            c.Close();
            
        }
    }
}
