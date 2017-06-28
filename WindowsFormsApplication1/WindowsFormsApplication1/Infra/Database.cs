using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace WindowsFormsApplication1.Infra
{
    public class Database
    {
        private readonly string _connString;

        /// <summary>
        /// Inicializa com todas as informações
        /// </summary>
        /// <param name="database"></param>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <param name="port"></param>
        /// <param name="host"></param>
        public Database(string database, string password, string user, string port, string host)
        {
            _connString = $"Server={host};Port={port};" +
                          $"User Id={user};Password={password};Database={database};";
        }
        
        public void RealizaConsulta(string sql, out DataTable dt)
        {
            var ds = new DataSet();
            var conn = new NpgsqlConnection(_connString);
            conn.Open();

            var da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
        }

        public void RealizaConsulta(string sql, out DataSet ds)
        {
            var dsResult = new DataSet();
            var conn = new NpgsqlConnection(_connString);
            conn.Open();

            var da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(dsResult);
            conn.Close();

            ds = dsResult;
        }

        public int ExecutaComando(string sql)
        {
            var conn = new NpgsqlConnection(_connString);
            conn.Open();

            var cmd = new NpgsqlCommand(sql, conn);

            var ret = cmd.ExecuteNonQuery();

            return ret;
        }

        public int ExecutaComando(string sql, out int id)
        {
            var conn = new NpgsqlConnection(_connString);
            conn.Open();

            var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", NpgsqlDbType.Integer, 4).Direction = ParameterDirection.Output;
            
            var ret = cmd.ExecuteNonQuery();

            id = int.Parse(cmd.Parameters["@ID"].Value.ToString());
            
            return ret;
        }
    }
}
