using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    class Sklad
    {
        static SqlConnection connectio;

        public int id;

        private string name_Detali;

        private Decimal cost_work;

        private int amount;



        public int Id { get => id; set => id = value; }

        public string Name_Detali { get => name_Detali; set => name_Detali = value; }
    
        public Decimal Detali_cost { get => cost_work; set => cost_work = value; }
        public int Amount { get => amount; set => amount = value; }

        public Sklad()
        {

        }

        public static void newConnection()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // подключаем базу данных
            connectio = new SqlConnection(connstring);
            connectio.Open();
        }

        public static IEnumerable<Sklad> getallPerd()
        {
            newConnection();
            var commandString = "SELECT * FROM Sklad";
            SqlCommand getAllComand = new SqlCommand(commandString, connectio);
            var reader = getAllComand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var cost_Detal = reader.GetDecimal(2);
                    var det_amount = reader.GetInt32(3);
                    var data_skald = new Sklad
                    {
                        Id = id,
                        Name_Detali = name,
                        Detali_cost = cost_Detal,
                        Amount = det_amount
                    };
                    yield return data_skald;
                }
            }
            connectio.Close();
            
        }

        public void Update()
        {
            newConnection();
            var commandString = "UPDATE Sklad SET Amount=@amount WHERE(Id=@id)";
            SqlCommand updateComand = new SqlCommand(commandString, connectio);
            updateComand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("id",Id),
                    new SqlParameter("amount",Amount)
                   // new SqlParameter("Service_type",Service_cost),
                });
            updateComand.ExecuteNonQuery();
            connectio.Close();
        }







        //public void Insert()
        //{
        //    Predp.newConnection();

        //    string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // подключаем базу данных
        //    connectio = new SqlConnection(connstring);
        //    connectio.Open();

        //    var commandString = "UPDATE DataServis SET Name_engineer=@Name_engineer, Service_type=@Service_type," +
        //        " Service_cost_work=@Service_cost_work, Service_cost_zapcast=@Service_cost_zapcast   WHERE(Id=@id)";

        //    SqlCommand updateComand = new SqlCommand(commandString, connectio);
        //    updateComand.Parameters.AddRange(new SqlParameter[]
        //        {
        //            new SqlParameter("Id",Id),
        //            new SqlParameter("Name_engineer",Name_person),
        //            new SqlParameter("Service_type",Service_type),
        //            new SqlParameter("Service_cost_work",Cost_work),
        //            new SqlParameter("Service_cost_zapcast",Cost_zapcast)
        //        });
        //    updateComand.ExecuteNonQuery();
        //    connectio.Close();
        //}


        public override string ToString()
        {
            return $"ID {Id} Имя детали {Name_Detali} стоимость запчасти {Detali_cost} количество штук на складе {Amount} ";
        }


    }
}
