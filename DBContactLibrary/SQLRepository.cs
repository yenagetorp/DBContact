using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using DBContactLibrary.Models;

namespace DBContactLibrary
{

    public class SQLRepository
    {
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBContact;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int CreateContact(string ssn, string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "CreateContact";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    SqlParameter sqlSsn = new SqlParameter("@ssn", ssn);
                    SqlParameter sqlFirstName = new SqlParameter("@firstName", firstName);
                    SqlParameter sqlLastName = new SqlParameter("@lastName", lastName);

                    SqlParameter sqlId = new SqlParameter("@ID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(sqlSsn);
                    command.Parameters.Add(sqlFirstName);
                    command.Parameters.Add(sqlLastName);
                    command.Parameters.Add(sqlId);

                    int returnValue = command.ExecuteNonQuery();

                    connection.Close();
                    if (returnValue > 0)
                    {
                        return int.Parse(sqlId.Value.ToString());

                    }

                    else return 0;

                }

            }
        }// Returns ID

        public Contact ReadContact(int ID)
        {

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "ReadContact";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    SqlParameter sqlId = new SqlParameter("@id", ID);

                    command.Parameters.Add(sqlId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Contact contact = new Contact
                        {
                            ID = (int)reader["ID"],
                            SSN = (string)reader["SSN"],//(string) cast
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"]
                        };

                        connection.Close();
                        return contact;

                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }

                }


            }

        }

        public List<Contact> ReadAllContacts()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "Select * from Contact";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        List<Contact> contacts = new List<Contact>();
                        //loppar igenom alla poster in list Contact;
                        while (reader.Read())
                        {
                            var contact = new Contact
                            {
                                ID = (int)reader["ID"],
                                SSN = (string)reader["SSN"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"]
                            };
                            contacts.Add(contact);
                        };


                        connection.Close();
                        return contacts;

                    }
                    connection.Close();

                    return null;
                }

            }
        }

        public bool UpdateContact(int Id, string ssn, string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UpdateContact";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    SqlParameter sqlSsn = new SqlParameter("@ssn", ssn);
                    SqlParameter sqlFirstName = new SqlParameter("@firstName", firstName);
                    SqlParameter sqlLastName = new SqlParameter("@lastName", lastName);

                    SqlParameter sqlId = new SqlParameter("@ID", Id);


                    command.Parameters.Add(sqlSsn);
                    command.Parameters.Add(sqlFirstName);
                    command.Parameters.Add(sqlLastName);
                    command.Parameters.Add(sqlId);

                    int returnValue = command.ExecuteNonQuery();

                    connection.Close();
                    return returnValue > 0;
                    //if (returnValue > 0)
                    //{
                    //    return true;

                    //}

                    //else return false;

                }

            }
        }

        public bool DeleteContact(int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DeleteContact";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;



                    SqlParameter sqlId = new SqlParameter("@ID", id);



                    command.Parameters.Add(sqlId);

                    int returnValue = command.ExecuteNonQuery();

                    connection.Close();
                    return returnValue > 0;
                    //if (returnValue > 0)
                    //{
                    //    return true;

                    //}

                    //else return false;

                }

            }
        }

        public int CreateAddress(string street, string city, string zip)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "CreateAddress";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    SqlParameter sqlStreet = new SqlParameter("@street", street);
                    SqlParameter sqlCity = new SqlParameter("@city", city);
                    SqlParameter sqlZip = new SqlParameter("@zip", zip);

                    SqlParameter sqlId = new SqlParameter("@ID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(sqlStreet);
                    command.Parameters.Add(sqlCity);
                    command.Parameters.Add(sqlZip);
                    command.Parameters.Add(sqlId);

                    int returnValue = command.ExecuteNonQuery();//returns a number of rows been affacted

                    connection.Close();
                    if (returnValue > 0)
                        return int.Parse(sqlId.Value.ToString());
                    else return 0;
                }

            }
        }// Returns ID

        public Address ReadAddress(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "ReadAddress";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    SqlParameter sqlId = new SqlParameter("@id", Id);
                    command.Parameters.Add(sqlId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Address address = new Address
                        {
                            ID = (int)reader["Id"],
                            Street =(string)reader["Street"],
                            City = (string)reader["City"],
                            Zip = (string)reader["Zip"]
                        };
                        connection.Close();
                        return address;
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    } 

                }

                
            }

        }
    }
}
