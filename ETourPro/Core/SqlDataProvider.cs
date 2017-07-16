using System;
using System.Data;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.IO;

namespace Core
{
    public class SqlDataProvider : DataProvider
    {
        public string connectionString = "";

        public SqlDataProvider(string connectionStringName)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
        }

        private void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if (commandParameters == null || parameterValues == null)
                return;
            if (commandParameters.Length != parameterValues.Length)
                throw new ArgumentException("Parameter count does not match Parameter Value cout.");
            for (int i = 0, j = commandParameters.Length; i < j; i++)
                commandParameters[i].Value = parameterValues[i];
        }

        public override object ExecuteNonQueryWithOutput(string outputParam, string spName, params object[] parameterValues)
        {
            if (string.IsNullOrEmpty(outputParam)) throw new ArgumentException("OutputParam is null or empty");

            SqlParameter[] parameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
            SqlParameter sqlParameter = null;
            foreach (SqlParameter item in parameters)
            {
                if (String.Compare(item.ParameterName, outputParam, true) == 0)
                {
                    sqlParameter = item;
                    break;
                }
            }
            if (sqlParameter == null) throw new Exception("Paremeter does not found");

            AssignParameterValues(parameters, parameterValues);

            int rs = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, parameters);

            if (rs > 0)
                return sqlParameter.Value;
            return null;
        }

        public override int ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, spName, parameterValues);
        }

        public override DataSet ExecuteDataset(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteDataset(connectionString, spName, parameterValues);
        }

        public override IDataReader ExecuteReader(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteReader(connectionString, spName, parameterValues);
        }

        public override IDataReader ExecuteReader(string commandText)
        {
            return SqlHelper.ExecuteReader(connectionString, CommandType.Text, commandText);
        }

        public override object ExecuteScalar(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteScalar(connectionString, spName, parameterValues);
        }
    }
}
