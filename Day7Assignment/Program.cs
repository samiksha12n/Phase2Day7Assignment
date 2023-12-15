using System;
using System.Data;
using System.Data.SqlClient;


namespace ConAppDataAdapter
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static string constr = "server=DESKTOP-OBBRFUM\\MSSQLSERVER01;database=Day7Assignment;trusted_connection=true;";
        static SqlDataAdapter sda;
        static DataSet ds;
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("Choose Operation");
                Console.WriteLine("1.Display table\n2.Add Book\n3.Update Books Table");
                int op=int.Parse(Console.ReadLine());
                switch(op)
                {
                    case 1:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand("select * from Books", con);
                                sda = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                sda.Fill(ds);
                                con.Close();
                                Console.WriteLine("Book Details as follows");
                                Console.WriteLine("BookId\t\tBookTitle\t\tAuthor  \t\t  Genre\t\t      Quantity\n");
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    Console.Write(row[0]+"\t \t");
                                    Console.Write(row[1]+"\t\t");
                                    Console.Write(row[2]+"\t\t");
                                    Console.Write(row[3]+"\t \t");
                                    Console.Write(row[4]+"\t \t");
                                    Console.WriteLine("\n");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand("select * from Books", con);
                                sda = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                sda.Fill(ds, "Books");
                                DataTable dt = ds.Tables["Books"];
                                DataRow dr = dt.NewRow();
                                Console.WriteLine("Enter Book ID");
                                dr["BookId"] = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Book Title");
                                dr["Title"] = Console.ReadLine();
                                Console.WriteLine("Enter Author");
                                dr["Author"] = Console.ReadLine();
                                Console.WriteLine("Enter Book Genre");
                                dr["Genere"] = Console.ReadLine();
                                Console.WriteLine("Enter Quantity");
                                dr["Quantity"] = int.Parse(Console.ReadLine()) ;
                                dt.Rows.Add(dr);
                                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                                sda.Update(ds, "Books");
                                Console.WriteLine("Books Record Inserted!!!");
                                con.Close();

                                con.Close();
                                Console.WriteLine("Book Details as follows");
                                Console.WriteLine("BookId\t\tBookTitle\t\tAuthor  \t\t  Genre\t\t      Quantity\n");
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    Console.Write(row[0] + "\t \t");
                                    Console.Write(row[1] + "\t\t");
                                    Console.Write(row[2] + "\t\t");
                                    Console.Write(row[3] + "\t \t");
                                    Console.Write(row[4] + "\t \t");
                                    Console.WriteLine("\n");
                                }


                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand("select * from Books", con);
                                sda = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                sda.Fill(ds, "Books");
                                Console.WriteLine("Enter Book Id to Update the Book Details");
                                int Bookid = int.Parse(Console.ReadLine());
                                DataRow dr = null;

                                foreach (DataRow row in ds.Tables["Books"].Rows)
                                {
                                    if ((int)row["BookId"] == Bookid)
                                    {
                                        dr = row;
                                        break;
                                    }
                                }
                                if (dr == null)
                                {
                                    Console.WriteLine($"No Such BookId {Bookid} exist in Customers Table");
                                }
                                else
                                {

                                    Console.WriteLine("Enter New Book title");
                                    dr["Title"] = Console.ReadLine();
                                    Console.WriteLine("Enter New Author");
                                    dr["Author"] = Console.ReadLine();
                                    Console.WriteLine("Enter New Genre");
                                    dr["Genere"] = Console.ReadLine();
                                    Console.WriteLine("Enter New Quantity");
                                    dr["Quantity"] = int.Parse(Console.ReadLine());
                                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                                    sda.Update(ds, "Books");
                                    Console.WriteLine("Record Updated!!!");

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                Console.ReadKey();
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice!!!");
                            break;
                        }
                       
                }
                Console.WriteLine("Do you want to continue press ....y");
                choice = Console.ReadLine();

            } while (choice == "y");
        }
    }
}