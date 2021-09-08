using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    public class Predp
    {
        static SqlConnection connectio;
        public int ID { get; set; }

        public string Name_Company { get; set; }

        public string Name_enginer { get; set; }

        public DateTime Service_time { get; set; }

        public string Service_type  { get; set; }

        public Decimal Service_cost_work { get; set; }

        public Decimal Service_cost_zapcast { get; set; }

        // DateTime date1 = new DateTime();

        public static void newConnection()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // подключаем базу данных
            connectio = new SqlConnection(connstring);
            connectio.Open(); 
        }

        public static IEnumerable<Predp> getallPerd()
        {
            newConnection();
            var commandString = "SELECT * FROM DataServis";
            SqlCommand getAllComand = new SqlCommand(commandString, connectio);
            var reader = getAllComand.ExecuteReader();
            if( reader.HasRows)
            {
                while(reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var ser_tepy = reader.GetString(2);
                    var ser_cost_work = reader.GetDecimal(3);
                    var ser_cost_zapcast = reader.GetDecimal(4);
                    var Name_enginer = reader.GetString(5);
                    var Service_time = reader.GetDateTime(6);

                    var data = new Predp { ID = id, Name_Company = name, Service_type = ser_tepy,
                        Service_cost_work = ser_cost_work, Service_cost_zapcast = ser_cost_zapcast,
                        Name_enginer = Name_enginer,  Service_time = Service_time
                    };
                    yield return data;
                }
            }
            connectio.Close();
        }

        public static Predp Find (string name)
        {
            foreach(var pred in getallPerd() )
            {
                if (pred.Name_Company == name)
                    return pred;
            }
            return null;

        }

        public static void Delete(int id)
        {
            newConnection();
            var commandString = "DELETE FROM DataServis WHERE(Id=@id)";
            SqlCommand deleteCommand = new SqlCommand(commandString, connectio);
            deleteCommand.Parameters.AddWithValue("Id",id);
            deleteCommand.ExecuteNonQuery();
            connectio.Close();
        }

        public void Insert()
        {
         
            newConnection();
            var commandString = "INSERT INTO DataServis (Name_Prepriat, Service_type, Service_cost_work, Service_cost_zapcast, Name_engineer, Service_time)" +
                "VALUES (@name_Company, @service_type, @service_cost_work, @service_cost_zapcast, @name_engineer, @service_time)";
            SqlCommand insertComand = new SqlCommand(commandString,connectio);
            insertComand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("name_Company",Name_Company),
                    new SqlParameter("service_type", " "),
                    new SqlParameter("service_cost_work", Service_cost_work = 0),
                    new SqlParameter("service_cost_zapcast", Service_cost_zapcast =0),
                    new SqlParameter("name_engineer"," "),
                    new SqlParameter("service_time",Service_time)
                });
            insertComand.ExecuteNonQuery();
            connectio.Close();
        }

        public void Update()
        {
            newConnection();
            var commandString = "UPDATE DataServis SET Name_Prepriat=@name_Company WHERE(Id=@id)";
            SqlCommand updateComand = new SqlCommand(commandString, connectio);
            updateComand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("Id",ID),
                    new SqlParameter("name_Company",Name_Company)
                   // new SqlParameter("Service_type",Service_cost),
                });
            updateComand.ExecuteNonQuery();
            connectio.Close();
        }


        public void updatePred (Predp pred)
        {   // огбновление обьекта всеми непустыми полями в pred
            if (pred.Name_Company?.Length > 0) Name_Company = pred.Name_Company;
            // if (pred.Service_type?.Length > 0) Service_type = pred.Service_type;
            //if (pred.Service_cost > 0) Service_cost = pred.Service_cost;
        }


        public override string ToString()
        {
            return $"ID = {ID}  КОМПАНИЯ: {Name_Company} ВИД ОБСЛУЖИВОНИЯ: {Service_type} СТОИМОСТЬ ОБСЛУЖИВАНИЕ: {Service_cost_work}" +
                $" СТОИМОСТЬ ЗАПЧАСТЕЙ {Service_cost_zapcast} ИМЯ ИНЖЕНЕРА {Name_enginer} ДАТА ОБСЛУЖИВАНИЕ {Service_time}";
        }

        internal class Update_Pers
        {
        }
    }
}
