using Dapper;
using StoreProcedural.Controllers;
using StoreProcedural.Dto.ContactDto;
using StoreProcedural.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StoreProcedural.Service
{
    public class ContactService : IContactService
    {
        private readonly IConfiguration configuration;

        public string connectionString { get; }
        public string providerName { get; }

        public ContactService(IConfiguration _configuration)
        {
            configuration = _configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
            providerName = "system.Data.SqlClient";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public ServiceResponse<GetContactDto> AddData(GetContactDto contact)
        {
            var response = new ServiceResponse<GetContactDto>();
            int result = 0;
            try
            {
                using (IDbConnection dbconnection =Connection )
                { 
                    dbconnection.Open();
                     result =dbconnection.Execute("AddContact", contact,commandType:CommandType.StoredProcedure);
                    if (result>=1)
                    {
                        response.message = "Success!";
                        response.Data = contact;
                    }
                    else
                    {
                        response.status = false;
                    }
                    dbconnection.Close();

                }
                return response;
            }
            catch(Exception ex)
            {
                response.status = false;
                response.message = ex.ToString();
                return response;

            }
        }

        public ServiceResponse<List<Contacts>> GetContacts()
        {
            var response = new ServiceResponse<List<Contacts>>();
            using (IDbConnection dbConnection = Connection )
            {
                dbConnection.Open();
                response.Data = (List<Contacts>?)dbConnection.Query<Contacts>("getContacts", commandType: CommandType.StoredProcedure);
                dbConnection.Close();
                response.message = "Success!";
            }
            return response;

        }

        public List<Contacts> DeleteContact(int Id)
        {
            List<Contacts> response = new List<Contacts>();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                response = (List<Contacts>)dbConnection.Query<Contacts>("DeleteContact",new { id = Id }, commandType: CommandType.StoredProcedure);
                dbConnection.Close();

                return response;
            }
        }

        public int UpdateContact(Contacts contact)
        {
            int res;
            var response = new ServiceResponse<Contacts>();
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                     res = conn.Execute("UpdateContact", contact, commandType: CommandType.StoredProcedure);
                    //response.Data = conn.Query("GetContactById", new { id = contact.Id }, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();

                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
