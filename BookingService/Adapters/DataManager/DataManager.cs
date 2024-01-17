using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Domain.Models;
//TODO using Sap.Data.Hana;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCD.SAPAPI.DataAcessObjects
{
    //public static class DataManager
    //{
//        private static Settings prov = null;
//        public static Task<string> GetData(string sSQL, [Optional] string Database)
//        {
//            try
//            {
//                using (StreamReader r = new StreamReader(Path.Combine(AppContext.BaseDirectory, "appsettings.json")))
//                {
//                    string json = r.ReadToEnd();
//                    prov = JsonConvert.DeserializeObject<Settings>(json);
//                }
//                if (Database == null) Database = prov.Providers.CompanyDB;
//                if (prov.Providers.DbServerType.ToUpper() == "HANA")
//                {
//                    string con = $@"Server={prov.Providers.Server}:30015;
//                                    UID={prov.Providers.DbUserName};
//                                    PWD={prov.Providers.DbPassword};
//                                    Current Schema={Database}";
//                    HanaConnection conn = new HanaConnection(con);
//                    conn.Open();
//                    HanaCommand cmd = new HanaCommand(sSQL, conn);
//                    HanaDataReader dr = null;
//                    try
//                    {
//                        dr = cmd.ExecuteReader();
//                        IEnumerable<Dictionary<string, object>> r = Serialize(dr);
//                        return Task.FromResult(JsonConvert.SerializeObject(r, Formatting.Indented));
//                    }
//                    finally
//                    {
//                        if (dr != null)
//                            dr.Close();
//                        if (conn.State == ConnectionState.Open)
//                        {
//                            try
//                            {
//                                conn.Close();
//                                conn.Dispose();
//                            }
//                            catch { }
//                        }
//                        HanaConnection.ClearAllPools();
//                    }
//                }
//                else
//                {
//                    string ConnectTimeout = prov.Providers.ConnectTimeout == null ? "60" : prov.Providers.ConnectTimeout;
//                    /*string con = "";
//                    if (prov.Providers.AttachDbFilename != null)
//                    {
//                        con = $@"Data Source={prov.Providers.Server};
//                               AttachDbFilename=""{AppContext.BaseDirectory+prov.Providers.AttachDbFilename}"";Integrated Security=True";
//                    }
//                    else
//                    {
//                        con = $@"Data Source={prov.Providers.Server};Initial Catalog={Database};
//                                 TrustServerCertificate=True;Persist Security Info=True;
//                                 User ID={prov.Providers.DbUserName};Password={prov.Providers.DbPassword};
//                                 Connect Timeout={ConnectTimeout}";
//                    }*/

//                    string con = $@"Data Source={prov.Providers.Server};Initial Catalog={Database};
//                                 TrustServerCertificate=True;Persist Security Info=True;
//                                 User ID={prov.Providers.DbUserName};Password={prov.Providers.DbPassword};
//                                 Connect Timeout={ConnectTimeout}";
//                    SqlConnection conn = new SqlConnection(con);
//                    conn.Open();
//                    SqlCommand command = new SqlCommand(sSQL, conn);
//                    SqlDataReader dr = null;
//                    try
//                    {
//                        dr = command.ExecuteReader(CommandBehavior.CloseConnection);
//                        var r = Serialize(dr);
//                        return Task.FromResult(JsonConvert.SerializeObject(r, Formatting.Indented));
//                    }
//                    finally
//                    {
//                        if (dr != null)
//                            dr.Close();
//                        if (conn.State == ConnectionState.Open)
//                        {
//                            try
//                            {
//                                conn.Close();
//                                conn.Dispose();
//                            }
//                            catch { }
//                        }
//                        SqlConnection.ClearAllPools();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex.Message);
//                throw;
//            }
//        }
//        TODO public static Task<object> GetDataEscalar(string sSQL, [Optional] string Database)
//        {
//            try
//            {
//                using (StreamReader r = new StreamReader(Path.Combine(AppContext.BaseDirectory, "appsettings.json")))
//                {
//                    var json = r.ReadToEnd();
//                    prov = JsonConvert.DeserializeObject<Settings>(json);
//                }
//                if (Database == null) Database = prov.Providers.CompanyDB;
//                if (prov.Providers.DbServerType.ToUpper() == "HANA")
//                {
//                    string con = $"Server={prov.Providers.Server}:30015;UID={prov.Providers.DbUserName};PWD={prov.Providers.DbPassword};Current Schema={Database}";
//                    HanaConnection conn = new HanaConnection(con);
//                    conn.Open();
//                    HanaCommand cmd = new HanaCommand(sSQL, conn);
//                    HanaDataReader dr = null;
//                    try
//                    {
//                        dr = cmd.ExecuteReader();
//                        dr.Read();
//                        if (dr.HasRows)
//                        {
//                            return Task.FromResult(dr.GetValue(0));
//                        }
//                        else
//                        {
//                            return Task.FromResult((object)"");
//                        }
//                    }
//                    finally
//                    {
//                        if (dr != null)
//                            dr.Close();
//                        if (conn.State == ConnectionState.Open)
//                        {
//                            try
//                            {
//                                conn.Close();
//                                conn.Dispose();
//                            }
//                            catch { }
//                        }
//                        HanaConnection.ClearAllPools();
//                    }
//                }
//                else
//                {
//                    string ConnectTimeout = prov.Providers.ConnectTimeout == null ? "60" : prov.Providers.ConnectTimeout;
//                    string con = "";
//                    if (prov.Providers.AttachDbFilename != null)
//                    {
//                        con = $@"Data Source={prov.Providers.Server};AttachDbFilename=""{AppContext.BaseDirectory + prov.Providers.AttachDbFilename}"";Integrated Security=True";
//                    }
//                    else
//                    {
//                        con = $"Data Source={prov.Providers.Server};Initial Catalog={Database};" +
//                            $"TrustServerCertificate=True;Persist Security Info=True;" +
//                            $"User ID={prov.Providers.DbUserName};Password={prov.Providers.DbPassword};" +
//                            $"Connect Timeout={ConnectTimeout}";
//                    }
//                    SqlConnection conn = new SqlConnection(con);
//                    conn.Open();
//                    SqlCommand command = new SqlCommand(sSQL, conn);
//                    SqlDataReader dr = null;
//                    try
//                    {
//                        dr = command.ExecuteReader(CommandBehavior.CloseConnection);
//                        dr.Read();
//                        if (dr.HasRows)
//                        {
//                            return Task.FromResult(dr.GetValue(0));
//                        }
//                        else
//                        {
//                            return Task.FromResult((object)"");
//                        }
//                    }
//                    finally
//                    {
//                        if (dr != null)
//                            dr.Close();
//                        if (conn.State == ConnectionState.Open)
//                        {
//                            try
//                            {
//                                conn.Close();
//                                conn.Dispose();
//                            }
//                            catch { }
//                        }
//                        SqlConnection.ClearAllPools();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex.Message);
//                throw;
//            }
//        }
//        public static Task<string> GetDataProc(string sSQL, [Optional] string Database)
//        {
//            try
//            {
//                using (StreamReader r = new StreamReader(Path.Combine(AppContext.BaseDirectory, "appsettings.json")))
//                {
//                    var json = r.ReadToEnd();
//                    prov = JsonConvert.DeserializeObject<Settings>(json);
//                }
//                if (Database == null) Database = prov.Providers.CompanyDB;
//                sSQL += " ";
//                if (prov.Providers.DbServerType.ToUpper() == "HANA")
//                {
//                    string con = $"Server={prov.Providers.Server}:30015;UID={prov.Providers.DbUserName};PWD={prov.Providers.DbPassword};Current Schema={Database}";
//                    var conn = new HanaConnection(con);
//                    conn.Open();
//                    int CharIndex = sSQL.IndexOf(" ");
//                    string script = "CALL " + sSQL.Substring(0, CharIndex) + "(" + sSQL.Substring(CharIndex, sSQL.Length - CharIndex) + ")";
//                    HanaCommand cmd = null;
//                    try
//                    {
//                        cmd = new HanaCommand(script, conn);
//                    }
//                    catch (Exception ex)
//                    {
//                        string error = ex.Message;
//                    }

//                    HanaDataReader dr = null;
//                    try
//                    {
//                        dr = cmd.ExecuteReader();
//                        var r = Serialize(dr);
//                        return Task.FromResult(JsonConvert.SerializeObject(r, Formatting.Indented));
//                    }
//                    finally
//                    {
//                        if (dr != null)
//                            dr.Close();
//                        if (conn.State == ConnectionState.Open)
//                        {
//                            try { conn.Close(); }
//                            catch (Exception ex) { string error = ex.Message; }
//                            try { conn.Dispose(); }
//                            catch (Exception ex) { string error = ex.Message; }

//                        }
//                        HanaConnection.ClearAllPools();
//                        GC.Collect();
//                    }
//                }
//                else
//                {
//                    string ConnectTimeout = prov.Providers.ConnectTimeout == null ? "60" : prov.Providers.ConnectTimeout;
//                    string con = "";
//                    if (prov.Providers.AttachDbFilename != null)
//                    {
//                        con = $@"Data Source={prov.Providers.Server};AttachDbFilename=""{AppContext.BaseDirectory + prov.Providers.AttachDbFilename}"";Integrated Security=True";
//                    }
//                    else
//                    {
//                        con = $"Data Source={prov.Providers.Server};Initial Catalog={Database};" +
//                            $"TrustServerCertificate=True;Persist Security Info=True;" +
//                            $"User ID={prov.Providers.DbUserName};Password={prov.Providers.DbPassword};" +
//                            $"Connect Timeout={ConnectTimeout}";
//                    }
//                    SqlConnection conn = new SqlConnection(con);
//                    int CharIndex = sSQL.IndexOf(" ");
//                    string script = "EXEC " + sSQL;
//                    SqlCommand command = new SqlCommand(script, conn);
//                    conn.Open();
//                    SqlDataReader dr = null;
//                    try
//                    {
//                        dr = command.ExecuteReader(CommandBehavior.CloseConnection);
//                        var r = Serialize(dr);
//                        return Task.FromResult(JsonConvert.SerializeObject(r, Formatting.Indented));
//                    }
//                    finally
//                    {
//                        if (dr != null)
//                            dr.Close();
//                        if (conn.State == ConnectionState.Open)
//                        {
//                            try
//                            {
//                                conn.Close();
//                                conn.Dispose();
//                            }
//                            catch { }
//                        }
//                        SqlConnection.ClearAllPools();
//                        GC.Collect();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                if (!ex.Message.Contains("SPS_C1_AUTHORIZATION"))
//                    Log.Error(ex.Message);
//                throw;
//            }
//        }
//        public static Task<int> SetData(string sSQL, [Optional] string Database)
//        {
//            try
//            {
//                using (StreamReader r = new StreamReader(Path.Combine(AppContext.BaseDirectory, "appsettings.json")))
//                {
//                    var json = r.ReadToEnd();
//                    prov = JsonConvert.DeserializeObject<Settings>(json);
//                }
//                if (Database == null) Database = prov.Providers.CompanyDB;
//                if (prov.Providers.DbServerType.ToUpper() == "HANA")
//                {
//                    string con = $"Server={prov.Providers.Server}:30015;UID={prov.Providers.DbUserName};PWD={prov.Providers.DbPassword};Current Schema={Database}";
//                    HanaConnection conn = new HanaConnection(con);
//                    HanaCommand cmd = new HanaCommand(sSQL, conn);
//                    conn.Open();
//                    try
//                    {
//                        int r = cmd.ExecuteNonQuery();
//                        return Task.FromResult(r);
//                    }
//                    finally
//                    {
//                        if (conn.State == ConnectionState.Open)
//                        {
//                            try
//                            {
//                                conn.Close();
//                                conn.Dispose();
//                            }
//                            catch { }
//                        }
//                        HanaConnection.ClearAllPools();
//                        GC.Collect();
//                    }
//                }
//                else
//                {
//                    string ConnectTimeout = prov.Providers.ConnectTimeout == null ? "60" : prov.Providers.ConnectTimeout;
//                    string con = "";
//                    if (prov.Providers.AttachDbFilename != null)
//                    {
//                        con = $@"Data Source={prov.Providers.Server};AttachDbFilename=""{AppContext.BaseDirectory + prov.Providers.AttachDbFilename}"";Integrated Security=True";
//                    }
//                    else
//                    {
//                        con = $"Data Source={prov.Providers.Server};Initial Catalog={Database};" +
//                            $"TrustServerCertificate=True;Persist Security Info=True;" +
//                            $"User ID={prov.Providers.DbUserName};Password={prov.Providers.DbPassword};" +
//                            $"Connect Timeout={ConnectTimeout}";
//                    }
//                    SqlConnection conn = new SqlConnection(con);
//                    SqlCommand command = new SqlCommand(sSQL, conn);
//                    conn.Open();
//                    try
//                    {
//                        int r = command.ExecuteNonQuery();
//                        return Task.FromResult(r);
//                    }
//                    finally
//                    {
//                        if (conn.State == ConnectionState.Open)
//                        {
//                            try
//                            {
//                                conn.Close();
//                                conn.Dispose();
//                            }
//                            catch { }
//                        }
//                        SqlConnection.ClearAllPools();
//                        GC.Collect();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex.Message);
//                throw;
//            }
//        }

//        public static IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
//        {
//            var results = new List<Dictionary<string, object>>();
//            var cols = new List<string>();
//            for (var i = 0; i < reader.FieldCount; i++)
//                cols.Add(reader.GetName(i));

//            while (reader.Read())
//                results.Add(SerializeRow(cols, reader));
//            reader.Close();
//            GC.Collect();
//            return results;
//        }
//        TODO public static IEnumerable<Dictionary<string, object>> Serialize(HanaDataReader reader)
//        {
//            var results = new List<Dictionary<string, object>>();
//            var cols = new List<string>();
//            for (var i = 0; i < reader.FieldCount; i++)
//                cols.Add(reader.GetName(i));

//            while (reader.Read())
//                results.Add(SerializeRow(cols, reader));
//            reader.Close();
//            GC.Collect();
//            return results;
//        }
//        private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols, SqlDataReader reader)
//        {
//            var result = new Dictionary<string, object>();
//            foreach (var col in cols)
//                result.Add(col, reader[col]);
//            return result;
//        }
//        TODO private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols, HanaDataReader reader)
//        {
//            var result = new Dictionary<string, object>();
//            foreach (var col in cols)
//                result.Add(col, reader[col].ToString());
//            return result;
//        }
//    }
}
