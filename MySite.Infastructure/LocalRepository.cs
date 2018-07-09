using MySiteCore.Interfaces;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySiteCore.Models;
using System;

namespace MySiteInfastructure
{
    public class LocalRepository : IMyRepository
    {
        public async Task<MyDbModel> getWebUrl(int IdDescriptor)
        {
            MyDbModel model = null;
            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jcarr\\source\\repos\\MySite\\LocalDatabase\\MyDB.mdf;Integrated Security=True")) {

                conn.Open();

                // create a SqlCommand object for this connection
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.MyInfo WHERE id=1", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader != null)
                        {
                            if(await reader.ReadAsync())
                            {
                                model = new MyDbModel();
                                model.id = Convert.ToInt32(reader["Id"]);
                                model.webUrl = reader["WebUrl"].ToString();
                            }

                        }
                    }
                }
                return model;

                
            }
        }
    }
}
