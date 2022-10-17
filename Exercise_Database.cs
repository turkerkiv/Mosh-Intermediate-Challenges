using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ConsoleApp2
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; private set; }
        public TimeSpan Timeout { get; set; }

        public DbConnection(string connectionAdress)
        {
            if (String.IsNullOrWhiteSpace(connectionAdress))
                throw new ArgumentNullException("Connection adress cannot be empty");
            else
            ConnectionString= connectionAdress;

            //this.Timeout = timeout;
        }
        
        //protected void Sleep()
        //{
        //    Thread.Sleep((int) this.Timeout.TotalMilliseconds);
        //}

        public abstract void Open();

        public abstract void Close();
    }

    public class SqlConnection : DbConnection
    {
        public SqlConnection(string sqlAdress)
            : base(sqlAdress)
        {
        }

        public override void Open()
        {
            Console.WriteLine("Sql connection," + ConnectionString + " is opened");
            //base.Sleep();
        }
        public override void Close()
        {
            Console.WriteLine("Sql connection, " + ConnectionString + " is closed");
        }
    }

    public class OracleConnection : DbConnection
    {
        public OracleConnection(string oracleAdress)
            : base(oracleAdress)
        {
        }

        public override void Open()
        {
            Console.WriteLine("Oracle connection," + ConnectionString + " is opened");
            //base.Sleep();
        }
        public override void Close()
        {
            Console.WriteLine("Oracle connection," + ConnectionString + " is closed");
        }
    }
    
    public class DbCommand
    {
        private readonly DbConnection _dbConnection;
        private readonly string _instruction;

        public DbCommand(DbConnection dbConnection, string instruction)
        {
            if (dbConnection == null)
                throw new ArgumentNullException("Connection adress cannot be null");
            else
                _dbConnection = dbConnection;

            if (string.IsNullOrWhiteSpace(instruction))
                throw new ArgumentNullException("Instruction cannot be null");
            else
                _instruction = instruction;
        }

        public void Execute()
        {
            _dbConnection.Open();
            Console.WriteLine(_instruction);
            _dbConnection.Close();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sql= new SqlConnection("HI THIS IS SQL ADRESS");

            OracleConnection oracle= new OracleConnection("HI THIS IS ORACLE ADRESS");

            DbCommand Command = new DbCommand(sql, "Select * from TABLE");

            Command.Execute();
            Console.WriteLine();
        }
    }
}
