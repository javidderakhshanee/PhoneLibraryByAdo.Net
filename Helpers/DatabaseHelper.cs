using PhoneLibrary.Helpers;
using PhoneLibrary.Models;
using PhoneLibrary.Models.Enums;

using System.Data;
using System.Data.SqlClient;

namespace PhoneLibrary;

public sealed class DatabaseHelper
{
    private static DatabaseHelper instance = null;
    public static DatabaseHelper Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DatabaseHelper();
            }
            return instance;
        }
    }


    private Logger logger = new Logger();
    private DatabaseHelper()
    {

    }
    private SqlConnection GetConnection()
    {
        var conn = new SqlConnection(getCurrentConnection());
        try
        {
            conn.Open();
            return conn;
        }
        catch (Exception ex)
        {
            writeError(ex.Message, nameof(GetConnection), enumTypeLog.ERROR, string.Empty, ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }
    private void CloseConnection(SqlConnection conn)
    {
        try
        {
            conn.Close();
            conn.Dispose();
        }
        catch (Exception ex)
        {
            writeError(ex.Message, nameof(CloseConnection), enumTypeLog.ERROR, string.Empty, ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }
    private string getCurrentConnection()
    {
        return $"server=(local);database=phonelibrary;Integrated Security=true";
    }

    public void writeError(string errMSG, string func, enumTypeLog _typeLog, string comm = "", string trace = "")
    {
        logger.saveLog(new LogsViewModel
        {
            Trace = trace,
            Log = errMSG,
            Form = "DB",
            Extra = comm,
            TypeLog = _typeLog
        });
    }

    public void writeLogs(string command, string trace, enumTypeLog _typeLog)
    {
        logger.saveLog(new LogsViewModel
        {
            Log = "",
            Trace = trace,
            Form = $"DB",
            Extra = command,
            TypeLog = _typeLog
        });
    }

    public void RunTransaction(List<string> cmd)
    {
        var conn = GetConnection();
        try
        {
            var transaction = conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            var commandTxt = string.Empty;
            try
            {
                foreach (var command in cmd)
                {
                    commandTxt = command;
                    if (!string.IsNullOrWhiteSpace(commandTxt))
                        new SqlCommand(commandTxt, conn, transaction).ExecuteNonQuery();
                }

                transaction.Commit();

                CloseConnection(conn);
            }
            catch (Exception x)
            {
                transaction.Rollback();
                writeError(x.Message, nameof(RunTransaction), enumTypeLog.ERROR, commandTxt, x.StackTrace);
                CloseConnection(conn);
                throw new Exception(x.Message);
            }
        }
        catch (Exception ex)
        {
            writeError(ex.Message, nameof(RunTransaction), enumTypeLog.ERROR, string.Empty, ex.StackTrace);
            throw new Exception(ex.Message);
        }

        CloseConnection(conn);
    }
    private string SetIsolateLevelInQuery(string query)
    {
        return $"SET TRANSACTION ISOLATION LEVEL READ COMMITTED;{query}";
    }
    public DataSet RunQueryWithDataSetResult(string query)
    {
        var conn = GetConnection();
        query = SetIsolateLevelInQuery(query);
        try
        {

            var adapt = new SqlDataAdapter(query, conn);
            var dt = new DataSet();
            adapt.Fill(dt);
            CloseConnection(conn);
            return dt;
        }
        catch (Exception ex)
        {
            CloseConnection(conn);
            writeError(ex.Message, "RunQueryWithDataSetResult", enumTypeLog.ERROR, query, ex.StackTrace);
            throw new Exception(ex.Message);
        }

    }
    public DataTable RunQueryWithDatatableResult(string query)
    {
        var conn = GetConnection();
        query = SetIsolateLevelInQuery(query);

        try
        {
            var adapt = new SqlDataAdapter(query, conn);
            var dt = new DataTable();
            adapt.Fill(dt);
            CloseConnection(conn);
            return dt;
        }
        catch (Exception ex)
        {
            CloseConnection(conn);
            writeError(ex.Message, "SelectOP", enumTypeLog.ERROR, query, ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }

    public T RunQueryScalerResult<T>(string cmd)
    {
        var temp = default(T);
        var conn = GetConnection();
        try
        {
            var adapt = new SqlCommand(cmd, conn);
            var result = adapt.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                var typeResult = result.GetType();
                if (typeResult != typeof(T))
                    temp = (T)Convert.ChangeType(result.ToString(), typeof(T));
                else
                    temp = (T)Convert.ChangeType(result, typeof(T));
            }
        }
        catch (Exception ex)
        {
            writeError(ex.Message, nameof(RunQueryScalerResult), enumTypeLog.ERROR, cmd);
        }

        CloseConnection(conn);
        return temp;
    }
    public void RunCommand(string cmd)
    {
        if (string.IsNullOrEmpty(cmd))
            throw new Exception($"Invalid command query");

        var conn = GetConnection();
        try
        {
            var comm = new SqlCommand(cmd, conn);
            comm.ExecuteNonQuery();
            CloseConnection(conn);
        }
        catch (Exception ex)
        {
            CloseConnection(conn);
            writeError(ex.Message, nameof(RunCommand), enumTypeLog.ERROR, cmd, ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }
}
