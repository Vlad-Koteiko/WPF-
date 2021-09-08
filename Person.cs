using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{

     public  class Person
    {
        static SqlConnection connectio;

        public int id;

        private string name_person;

        private string service_type;

        private string zapcasti;

        private Decimal cost_work;

        private Decimal cost_zapcast;

        public int Id { get => id; set => id = value; }
        public string Name_person { get => name_person; set => name_person = value;}
        public string Service_type { get => service_type; set => service_type = value; }
        public string Zapcasti { get => zapcasti; set => zapcasti = value; }
        public Decimal Cost_work { get => cost_work; set => cost_work = value; }
        public Decimal Cost_zapcast { get => cost_zapcast; set => cost_zapcast = value; }

        public Person()
        {

        }

        public void Insert()
        {
            Predp.newConnection();

            string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // подключаем базу данных
            connectio = new SqlConnection(connstring);
            connectio.Open();

            var commandString = "UPDATE DataServis SET Name_engineer=@Name_engineer, Service_type=@Service_type," +
                " Service_cost_work=@Service_cost_work, Service_cost_zapcast=@Service_cost_zapcast   WHERE(Id=@id)";

            SqlCommand updateComand = new SqlCommand(commandString, connectio);
            updateComand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("Id",Id),
                    new SqlParameter("Name_engineer",Name_person),
                    new SqlParameter("Service_type",Service_type),
                    new SqlParameter("Service_cost_work",Cost_work),
                    new SqlParameter("Service_cost_zapcast",Cost_zapcast)
                });
            updateComand.ExecuteNonQuery();
            connectio.Close();
        }

        public void UPdateSkald()
        {
            Predp.newConnection();

            string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // подключаем базу данных
            connectio = new SqlConnection(connstring);
            connectio.Open();

            var commandString = "UPDATE Sklad SET Amount=Amount - 1 " +
                "WHERE(Name_Detali=@zapcasti)";

            SqlCommand updateComand = new SqlCommand(commandString, connectio);
            updateComand.Parameters.AddRange(new SqlParameter[]
                {
                  //  new SqlParameter("Id",Id),
                    new SqlParameter("zapcasti",Zapcasti)
                });
            updateComand.ExecuteNonQuery();
            connectio.Close();

        }

        public override string ToString()
        {
            return $"Имя {Name_person} Тип обслуживания {Service_type} запчасти {Zapcasti} стоимость работы {Cost_work} стоимость запчастей {Cost_zapcast}";
        }
    }
}
