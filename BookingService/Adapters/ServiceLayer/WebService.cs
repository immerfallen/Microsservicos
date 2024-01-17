//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Domain.SB1.Objects;
//using Domain.Models;
//using MCD.SAPAPI.DataAcessObjects;
//using Serilog;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using System.Threading.Tasks;

//namespace MCD.SAPAPI
//{
//    public class WebService : IWebService
//    {
    //    private LoginValues _LoginValue = null;
    //    private Settings LoginWS = null;
    //    private DateTime _sessionTimeout;
    //    private readonly ILogger<IWebService> logger;

    //    public LoginValues LoginValue
    //    {
    //        get { return _LoginValue; }
    //        set
    //        {
    //            _LoginValue = value;
    //            if (value != null)
    //                _sessionTimeout = DateTime.Now.AddMinutes((double)value.SessionTimeout);
    //        }
    //    }
    //    public WebService(ILogger<IWebService> logger)
    //    {
    //        try
    //        {
    //            using (StreamReader r = new StreamReader(Path.Combine(AppContext.BaseDirectory, "appsettings.json")))
    //            {
    //                var json = r.ReadToEnd();
    //                LoginWS = JsonConvert.DeserializeObject<Settings>(json);
    //                LoginWS.CompanyDB = LoginWS.Providers.CompanyDB;
    //            }
    //            this.logger = logger;
    //            Log.Logger = new LoggerConfiguration()
    //                .MinimumLevel.Debug()
    //                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs\\WebService.txt"), rollingInterval: RollingInterval.Day)
    //                .WriteTo.Console()
    //             .CreateLogger();
    //            Task.Run(async () =>
    //            {
    //                try
    //                {
    //                    await checkLoginTable();
    //                }
    //                catch (Exception ex)
    //                {
    //                    Log.Error(ex.Message);
    //                    throw;
    //                }

    //            });
    //        }
    //        catch (Exception ex)
    //        {
    //            Log.Error(ex.Message);
    //        }
    //    }
    //    private LoginValues conn()
    //    {
    //        try
    //        {
    //            WebService ws = new WebService(logger);
    //            using (StreamReader r = new StreamReader(Path.Combine(AppContext.BaseDirectory, "appsettings.json")))
    //            {
    //                var json = r.ReadToEnd();
    //                LoginWS = JsonConvert.DeserializeObject<Settings>(json);
    //            }
    //            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{LoginWS.LoginUrl}/Login/Login");
    //            req.ContentType = "text/json";
    //            req.Method = "POST";
    //            req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //            var httpResponse = (HttpWebResponse)req.GetResponse();
    //            if (httpResponse.StatusCode == HttpStatusCode.OK)
    //            {
    //                var responseValue = string.Empty;
    //                var responseStream = httpResponse.GetResponseStream();
    //                if (responseStream != null)
    //                    using (var reader = new StreamReader(responseStream))
    //                    {
    //                        responseValue = reader.ReadToEnd();
    //                        var post = JsonConvert.DeserializeObject<LoginValues>(responseValue.ToString());
    //                        return post;
    //                    }
    //                return null;
    //            }
    //            else
    //                return null;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    private Type GetKeyType(Type tipoEntidade)
    //    {
    //        PropertyInfo[] properties = tipoEntidade.GetProperties();

    //        foreach (PropertyInfo property in properties)
    //        {
    //            var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute))
    //                as KeyAttribute;

    //            if (attribute != null) // This property has a KeyAttribute
    //            {
    //                return property.PropertyType;
    //            }
    //        }
    //        return null;
    //    }
    //    /// <summary>
    //    /// Aceitar todas as certificações
    //    /// </summary>
    //    /// <param name = "sender" ></ param >
    //    /// < param name="certification"></param>
    //    /// <param name = "chain" ></ param >
    //    /// < param name="sslPolicyErrors"></param>
    //    /// <returns></returns>
    //    private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    //    {
    //        return true;
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    public async Task<LoginValues> Login([Optional] string SessionId, [Optional] string UserName, [Optional] string Password)
    //    {
    //        DateTime? _sessionTimeout = null;
    //        LoginValues RetReq = null;
    //        string Type = LoginWS.LoginType;
    //        await Task.Run(async () =>
    //        {
    //            try
    //            {
    //                bool Login = true;
    //                if (SessionId != null)
    //                {
    //                    string jsonLogin = await DataManager.GetData($@"SELECT ""Code"", ""U_SessionTimeout"", ""U_SessionId"", ""U_UserName"" FROM ""@RBH_LOGIN"" WHERE ""Code"" LIKE '%{SessionId}'");
    //                    if (jsonLogin != "[]")
    //                    {
    //                        List<Session> prog = JsonConvert.DeserializeObject<List<Session>>(jsonLogin);
    //                        if (prog.Count > 0)
    //                        {
    //                            if (Type != "SAP")
    //                            {
    //                                if (UserName == "")
    //                                    UserName = prog[0].U_UserName;
    //                            }
    //                            if (prog[0].U_SessionTimeout != null && prog[0].U_SessionTimeout != "")
    //                                _sessionTimeout = Convert.ToDateTime(prog[0].U_SessionTimeout);
    //                            else
    //                            {
    //                                await DataManager.SetData(string.Format(@"UPDATE ""@RBH_LOGIN"" SET ""U_Progress""='Y' WHERE ""U_SessionId""='{0}'", SessionId));
    //                                _sessionTimeout = null;
    //                            }
    //                            if (_sessionTimeout != null)
    //                                Login = (_sessionTimeout < DateTime.Now);
    //                            else
    //                                Login = true;
    //                        }
    //                        else
    //                        {
    //                            if (UserName == "" || UserName == null)
    //                                UserName = LoginWS.Providers.UserName;
    //                            if (Password == "" || Password == null)
    //                                Password = LoginWS.Providers.Password;
    //                        }
    //                    }
    //                }
    //                string codeLogin = UserName + '-' + SessionId;
    //                if (Login)
    //                {
    //                    if (UserName == "" || UserName == null)
    //                        UserName = LoginWS.Providers.UserName;
    //                    if (Password == "" || Password == null)
    //                        Password = LoginWS.Providers.Password;
    //                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/Login");
    //                    req.ContentType = "text/json";
    //                    req.Method = "POST";
    //                    req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                    using (var streamWriter = new StreamWriter(req.GetRequestStream()))
    //                    {
    //                        Settings LWS = new Settings();
    //                        LWS.CompanyDB = LoginWS.Providers.CompanyDB;
    //                        LWS.UserName = UserName;
    //                        LWS.Password = Password;
    //                        LWS.Language = LoginWS.Providers.Language;
    //                        LWS.Server = LoginWS.Providers.Server;

    //                        string json = JsonConvert.SerializeObject(LWS, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

    //                        streamWriter.Write(json);
    //                    }

    //                    var httpResponse = (HttpWebResponse)req.GetResponse();
    //                    if (httpResponse.StatusCode == HttpStatusCode.OK)
    //                    {
    //                        var responseValue = string.Empty;
    //                        var responseStream = httpResponse.GetResponseStream();
    //                        if (responseStream != null)
    //                            using (var reader = new StreamReader(responseStream))
    //                            {
    //                                responseValue = reader.ReadToEnd();
    //                                var post = JsonConvert.DeserializeObject<LoginValues>(responseValue.ToString());

    //                                if (_sessionTimeout != null)
    //                                    _sessionTimeout = DateTime.Now.AddMinutes((double)post.SessionTimeout);
    //                                DateTime datetime = DateTime.Now.AddMinutes((double)post.SessionTimeout);
    //                                string code = (await DataManager.GetDataEscalar($@"SELECT ""Code"" FROM ""@RBH_LOGIN"" WHERE ""Code""='{codeLogin}'")).ToString();
    //                                if (code == "")
    //                                {
    //                                    string SQL = $@"INSERT INTO ""@RBH_LOGIN"" (""Code"", ""Name"", ""U_Progress"", ""U_SessionTimeout"", ""U_SessionId"") VALUES('{codeLogin}', '{codeLogin}', 'N','{datetime}','{post.SessionId}')";
    //                                    await DataManager.SetData(SQL);
    //                                }
    //                                else
    //                                {
    //                                    string SQL = $@"UPDATE ""@RBH_LOGIN"" SET ""U_SessionTimeout""='{datetime}', ""U_SessionId""='{post.SessionId}' WHERE ""Code""='{codeLogin}'";
    //                                    await DataManager.SetData(SQL);
    //                                }
    //                                LoginValue = post;
    //                                RetReq = post;
    //                            }
    //                    }
    //                }
    //                else
    //                {
    //                    //return _LoginValue;
    //                    TimeSpan dtdif = (TimeSpan)(_sessionTimeout - DateTime.Now);
    //                    if (SessionId == null)
    //                    {
    //                        RetReq = new LoginValues
    //                        {
    //                            SessionId = LoginValue.SessionId,
    //                            SessionTimeout = dtdif.TotalSeconds / 60
    //                            //,Version = LoginValue.Version
    //                        };
    //                    }
    //                    else
    //                    {
    //                        string SessionId = (await DataManager.GetDataEscalar($@"SELECT ""U_SessionId"" FROM ""@RBH_LOGIN"" WHERE ""Code""='{codeLogin}'")).ToString();
    //                        RetReq = new LoginValues
    //                        {
    //                            SessionId = SessionId,
    //                            SessionTimeout = dtdif.TotalSeconds / 60
    //                            //,Version = LoginValue.Version
    //                        };
    //                    }
    //                }
    //            }
    //            catch (WebException we)
    //            {
    //                try
    //                {
    //                    var resp = we.Response as HttpWebResponse;
    //                    var responseValue = string.Empty;
    //                    var responseStream = resp.GetResponseStream();
    //                    if (responseStream != null)
    //                        using (var reader = new StreamReader(responseStream))
    //                        {
    //                            responseValue = reader.ReadToEnd();
    //                        }
    //                    ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //                    if (jsonObj != null)
    //                        throw new Exception(jsonObj.error.message.value, we);
    //                    else
    //                        throw new Exception(we.Message, we);
    //                }
    //                catch
    //                {
    //                    throw new Exception(we.Message, we);
    //                }
    //            }
    //        });
    //        return RetReq;
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    public async Task<LoginValues> Login(string UserName, string Password, string Type, [Optional] string Database, [Optional] string SessionId)
    //    {
    //        DateTime? _sessionTimeout = null;
    //        LoginValues RetReq = null;
    //        await Task.Run(async () =>
    //        {
    //            try
    //            {
    //                bool Login = false;
    //                List<Session> prog = null;
    //                string jsonLogin = await DataManager.GetData($@"SELECT ""U_SessionTimeout"", ""U_SessionId"", ""U_CompanyDB"" FROM ""@RBH_LOGIN"" WHERE ""Code""='{UserName + '-' + SessionId}'");
    //                if (jsonLogin != "")
    //                {
    //                    prog = JsonConvert.DeserializeObject<List<Session>>(jsonLogin);
    //                    if (prog.Count > 0)
    //                    {
    //                        if (prog[0].U_SessionTimeout != null && prog[0].U_SessionTimeout != "")
    //                            _sessionTimeout = Convert.ToDateTime(prog[0].U_SessionTimeout);
    //                        else
    //                        {
    //                            await DataManager.SetData(string.Format(@"UPDATE ""@RBH_LOGIN"" SET ""U_Progress""='N' WHERE ""Code""='{0}'", UserName));
    //                            _sessionTimeout = null;
    //                        }
    //                    }
    //                }
    //                if (_sessionTimeout != null)
    //                    Login = (_sessionTimeout < DateTime.Now);
    //                else
    //                    Login = true;
    //                if (Login)
    //                {
    //                    string codeLogin = UserName + '-' + SessionId;
    //                    logger.LogInformation("WebService Login...");
    //                    string url = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/Login";
    //                    logger.LogInformation(url);
    //                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
    //                    req.ContentType = "text/json";
    //                    req.Method = "POST";
    //                    req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
    //                    if (prog != null && prog.Count > 0)
    //                    {
    //                        if (prog[0].U_CompanyDB != "")
    //                            LoginWS.CompanyDB = prog[0].U_CompanyDB;
    //                        else
    //                            LoginWS.CompanyDB = Database;
    //                    }
    //                    else
    //                    {
    //                        if (Database != null)
    //                            LoginWS.CompanyDB = Database;
    //                    }
    //                    if (LoginWS.CompanyDB == null)
    //                        LoginWS.CompanyDB = LoginWS.Providers.CompanyDB;

    //                    using (var streamWriter = new StreamWriter(req.GetRequestStream()))
    //                    {
    //                        Settings LWS = new Settings();
    //                        LWS.CompanyDB = LoginWS.CompanyDB;
    //                        LWS.UserName = UserName;
    //                        LWS.Password = Password;
    //                        LWS.Language = LoginWS.Language;

    //                        string json = JsonConvert.SerializeObject(LWS, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    //                        logger.LogInformation(json);
    //                        streamWriter.Write(json);
    //                    }

    //                    var httpResponse = (HttpWebResponse)req.GetResponse();
    //                    if (httpResponse.StatusCode == HttpStatusCode.OK)
    //                    {
    //                        var responseValue = string.Empty;
    //                        var responseStream = httpResponse.GetResponseStream();
    //                        if (responseStream != null)
    //                            using (var reader = new StreamReader(responseStream))
    //                            {
    //                                responseValue = reader.ReadToEnd();
    //                                var post = JsonConvert.DeserializeObject<LoginValues>(responseValue.ToString());

    //                                post.SessionDateTimeOut = DateTime.Now.AddMinutes((double)post.SessionTimeout);
    //                                if (Type == "SAP")
    //                                {
    //                                    DateTime datetime = DateTime.Now.AddMinutes((double)post.SessionTimeout);
    //                                    string code = (await DataManager.GetDataEscalar($@"SELECT ""Code"" FROM ""@RBH_LOGIN"" WHERE ""Code""='{codeLogin}'")).ToString();
    //                                    if (code == "")
    //                                    {
    //                                        string SQL = $@"INSERT INTO ""@RBH_LOGIN"" (""Code"", ""Name"", ""U_Progress"", ""U_SessionTimeout"", ""U_SessionId"") VALUES('{codeLogin}', '{codeLogin}', 'N','{datetime}','{post.SessionId}')";
    //                                        await DataManager.SetData(SQL);
    //                                    }
    //                                    else
    //                                    {
    //                                        string SQL = $@"UPDATE ""@RBH_LOGIN"" SET ""U_SessionTimeout""='{datetime}', ""U_SessionId""='{post.SessionId}' WHERE ""Code""='{codeLogin}'";
    //                                        await DataManager.SetData(SQL);
    //                                    }
    //                                }
    //                                //if (_sessionTimeout != null)
    //                                //    //{
    //                                //    //  _session.SetString("LoginSessionId", post.SessionId);
    //                                //    
    //                                //  _session.SetString("SessionTimeout", SessionTimeout.ToString("dd/MM/yyyy hh:mm:ss"));
    //                                //}
    //                                //return await Task.FromResult<LoginValues>(post);
    //                                LoginValue = post;
    //                                RetReq = post;
    //                            }
    //                    }
    //                }
    //                else
    //                {
    //                    TimeSpan dtdif = (TimeSpan)(_sessionTimeout - DateTime.Now);
    //                    RetReq = new LoginValues
    //                    {
    //                        SessionId = prog[0].U_SessionId,
    //                        SessionTimeout = (int)dtdif.Minutes,
    //                        SessionDateTimeOut = _sessionTimeout
    //                    };
    //                }
    //            }
    //            catch (WebException we)
    //            {
    //                var resp = we.Response as HttpWebResponse;
    //                var responseValue = string.Empty;
    //                var responseStream = resp.GetResponseStream();
    //                if (responseStream != null)
    //                    using (var reader = new StreamReader(responseStream))
    //                    {
    //                        responseValue = reader.ReadToEnd();
    //                    }
    //                ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //                if (jsonObj != null)
    //                    throw new Exception(jsonObj.error.message.value, we);
    //                else
    //                    throw new Exception(we.Message, we);
    //            }
    //            catch (Exception ex)
    //            {
    //                string retError = ex.Message;
    //                throw new Exception(retError);
    //            }
    //        });
    //        return RetReq;
    //    }

    //    /// <summary>
    //    /// Procedimento de realizar o Logout, tanto no Service Layer quanto API para SQL a ser densevolvida
    //    /// </summary>
    //    /// <param name="config">Dados de configurações das conexões</param>
    //    /// <returns></returns>
    //    public async Task<Boolean> Logout()
    //    {
    //        Boolean RetReq = false;
    //        await Task.Run(() =>
    //        {
    //            try
    //            {
    //                //string Url = LoginWS.Url;
    //                //string Port = LoginWS.Port;

    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/Login");
    //                req.ContentType = "text/json";
    //                req.Method = "POST";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                RetReq = (httpResponse.StatusCode == HttpStatusCode.NoContent);
    //            }
    //            catch (WebException we)
    //            {
    //                var resp = we.Response as HttpWebResponse;
    //                var responseValue = string.Empty;
    //                var responseStream = resp.GetResponseStream();
    //                if (responseStream != null)
    //                    using (var reader = new StreamReader(responseStream))
    //                    {
    //                        responseValue = reader.ReadToEnd();
    //                    }
    //                ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //                throw new Exception(jsonObj.error.message.value, we);
    //            }
    //        });
    //        return RetReq;
    //    }

    //    /// <summary>
    //    /// Função responsável por recuperar uma coleção de 'typeparam T' com todas ou algumas propriedades selecionadas na ordem especificada, especificando a condição de filtro especificada.
    //    /// </summary>
    //    /// <typeparam name="T">Tipo do objeto a ser trabalhado</typeparam>
    //    /// <param name="_session">Sessão com os dados do login guardados.</param>
    //    /// <param name="config">Dados de configurações das conexões</param>
    //    /// <param name="select">Parametro opcional: Restrinja o serviço para retornar apenas as propriedades solicitadas pelo cliente</param>
    //    /// <param name="orderby">Parametro opcional: Especifique a ordem em que os objetos de negócios são retornados do serviço</param>
    //    /// <param name="filter">Parametro opcional: Restringir o conjunto de objetos de negócios retornados</param>
    //    /// <param name="top">Parametro opcional: Especifique que apenas os primeiros n registros devem ser retornados.</param>
    //    /// <param name="skip">Parametro opcional: Especifique que o resultado exclua as primeiras n entidades.</param>
    //    /// <returns></returns>
    //    public async Task<List<T>> Get<T>([Optional] string SessionId, [Optional] string UserName, [Optional] string Password, [Optional] string select, [Optional] string orderby, [Optional] string filter, [Optional] string top, [Optional] string skip, [Optional] string maxPageSize)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {
    //                //string Url = config.GetSection("EnvironmentSAP")["Url"];
    //                //string Port = config.GetSection("EnvironmentSAP")["Port"];
    //                //string CompanyDB = config.GetSection("EnvironmentSAP")["CompanyDB"];

    //                Type tipoEntidade = typeof(T);

    //                string newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}";
    //                if (select != null || orderby != null || filter != null || top != null || skip != null)
    //                    newUrl = newUrl + "?";
    //                string addUrl = "";
    //                addUrl = addUrl + (select != null ? "&$select=" + select : "");
    //                addUrl = addUrl + (orderby != null ? "&$orderby=" + orderby : "");
    //                addUrl = addUrl + (filter != null ? "&$filter=" + filter : "");
    //                addUrl = addUrl + (top != null ? "&$top=" + top : "");
    //                addUrl = addUrl + (skip != null ? "&$skip=" + skip : "");
    //                if (addUrl != "")
    //                    addUrl = addUrl.Substring(1, addUrl.Length - 1);
    //                newUrl = newUrl + addUrl;


    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newUrl);
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.Headers.Add("B1S-CaseInsensitive", "true");
    //                req.ContentType = "text/json";
    //                req.Method = "GET";
    //                if (maxPageSize != null)
    //                {
    //                    req.Headers.Add("Prefer", "odata.maxpagesize=" + maxPageSize);
    //                }
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                if (httpResponse.StatusCode == HttpStatusCode.OK)
    //                {
    //                    var responseValue = string.Empty;
    //                    var responseStream = httpResponse.GetResponseStream();
    //                    if (responseStream != null)
    //                        using (var reader = new StreamReader(responseStream))
    //                        {
    //                            responseValue = reader.ReadToEnd();
    //                            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(responseValue.ToString());
    //                            JArray a = (JArray)jsonObj["value"];
    //                            List<T> ObjectList = a.ToObject<List<T>>();
    //                            return ObjectList;
    //                        }
    //                    return null;
    //                }
    //                else
    //                    return null;
    //            }
    //            else
    //                return null;
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception(e.Message, e);
    //        }
    //        //finally
    //        //{
    //        //    await Logout(config);
    //        //}
    //    }

    //    /// <summary>
    //    /// Função responsável por recuperar uma coleção de 'typeparam T' com todas ou algumas propriedades selecionadas na ordem especificada, especificando a condição de filtro especificada.
    //    /// </summary>
    //    /// <typeparam name="T">Tipo do objeto a ser trabalhado</typeparam>
    //    /// <param name="_session">Sessão com os dados do login guardados.</param>
    //    /// <param name="config">Dados de configurações das conexões</param>
    //    /// <param name="select">Parametro opcional: Restrinja o serviço para retornar apenas as propriedades solicitadas pelo cliente</param>
    //    /// <param name="orderby">Parametro opcional: Especifique a ordem em que os objetos de negócios são retornados do serviço</param>
    //    /// <param name="filter">Parametro opcional: Restringir o conjunto de objetos de negócios retornados</param>
    //    /// <param name="top">Parametro opcional: Especifique que apenas os primeiros n registros devem ser retornados.</param>
    //    /// <param name="skip">Parametro opcional: Especifique que o resultado exclua as primeiras n entidades.</param>
    //    /// <returns></returns>
    //    public async Task<List<T>> GetView<T>([Optional] string SessionId, [Optional] string UserName, [Optional] string Password, [Optional] bool count, [Optional] string select, [Optional] string orderby, [Optional] string filter, [Optional] string top, [Optional] string skip, [Optional] string maxPageSize)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {
    //                //string Url = config.GetSection("EnvironmentSAP")["Url"];
    //                //string Port = config.GetSection("EnvironmentSAP")["Port"];
    //                //string CompanyDB = config.GetSection("EnvironmentSAP")["CompanyDB"];

    //                Type tipoEntidade = typeof(T);

    //                string newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}";
    //                if (count)
    //                {
    //                    newUrl = newUrl + "/$count";
    //                }
    //                if (select != null || orderby != null || filter != null || top != null || skip != null)
    //                    newUrl = newUrl + "?";
    //                string addUrl = "";
    //                addUrl = addUrl + (select != null ? "&$select=" + select : "");
    //                addUrl = addUrl + (orderby != null ? "&$orderby=" + orderby : "");
    //                addUrl = addUrl + (filter != null ? "&$filter=" + filter : "");
    //                addUrl = addUrl + (top != null ? "&$top=" + top : "");
    //                addUrl = addUrl + (skip != null ? "&$skip=" + skip : "");
    //                if (addUrl != "")
    //                    addUrl = addUrl.Substring(1, addUrl.Length - 1);
    //                newUrl = newUrl + addUrl;


    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newUrl);
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.Headers.Add("B1S-CaseInsensitive", "true");
    //                req.ContentType = "text/json";
    //                req.Method = "GET";
    //                if (maxPageSize != null)
    //                {
    //                    req.Headers.Add("Prefer", "odata.maxpagesize=" + maxPageSize);
    //                }
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                if (httpResponse.StatusCode == HttpStatusCode.OK)
    //                {
    //                    var responseValue = string.Empty;
    //                    var responseStream = httpResponse.GetResponseStream();
    //                    if (responseStream != null)
    //                        using (var reader = new StreamReader(responseStream))
    //                        {
    //                            responseValue = reader.ReadToEnd();
    //                            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(responseValue.ToString());
    //                            JArray a = (JArray)jsonObj["value"];
    //                            List<T> ObjectList = a.ToObject<List<T>>();
    //                            return ObjectList;
    //                        }
    //                    return null;
    //                }
    //                else
    //                    return null;
    //            }
    //            else
    //                return null;
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception(e.Message, e);
    //        }
    //        //finally
    //        //{
    //        //    await Logout(config);
    //        //}
    //    }

    //    /// <summary>
    //    /// Função responsável por recuperar um objeto de 'typeparam T' com todas ou algumas propriedades selecionadas, buscando pela chave do objeto.
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="_session">Sessão com os dados do login guardados.</param>
    //    /// <param name="config">Dados de configurações das conexões.</param>
    //    /// <param name="KeyValue">Valor valido da chave do objeto.</param>
    //    /// <returns></returns>
    //    public async Task<T> Get<T>(string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {
    //                Type tipoEntidade = typeof(T);
    //                string newUrl = "";
    //                try
    //                {
    //                    var type = GetKeyType(tipoEntidade);

    //                    if (tipoEntidade.Name.Substring(0, 2) == "U_")
    //                        newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                    else
    //                    {
    //                        if (type.Name == "Int32" || type.GenericTypeArguments[0].Name == "Int32")
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}({KeyValue})";
    //                        }
    //                        else
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                        }
    //                    }
    //                }
    //                catch
    //                {
    //                    newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                }

    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newUrl);
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.Headers.Add("B1S-CaseInsensitive", "True");
    //                req.ContentType = "text/json";
    //                req.Method = "GET";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                if (httpResponse.StatusCode == HttpStatusCode.OK)
    //                {
    //                    var responseValue = string.Empty;
    //                    var responseStream = httpResponse.GetResponseStream();
    //                    if (responseStream != null)
    //                        using (var reader = new StreamReader(responseStream))
    //                        {
    //                            responseValue = reader.ReadToEnd();
    //                            T jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseValue.ToString());
    //                            return jsonObj;
    //                        }
    //                    return default(T);
    //                }
    //                else
    //                    return default(T);
    //            }
    //            else
    //                return default(T);
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            if (jsonObj.error.code == -2028)
    //                return default(T);
    //            else
    //                throw new Exception(jsonObj.error.message.value, we);
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception(e.Message, e);
    //        }
    //    }

    //    /// <summary>
    //    /// Função responsável por retornar a quantitade de registros de uma coleção de 'typeparam T'.
    //    /// </summary>
    //    /// <typeparam name="T">Tipo do objeto a ser trabalhado</typeparam>
    //    /// <param name="config">Dados de configurações das conexões</param>
    //    /// <param name="filter">Parametro opcional: Restringir o conjunto de objetos de negócios retornados</param>
    //    /// <returns></returns>
    //    public async Task<int> Count<T>([Optional] string filter, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {
    //                //string Url = config.GetSection("EnvironmentSAP")["Url"];
    //                //string Port = config.GetSection("EnvironmentSAP")["Port"];
    //                //string CompanyDB = config.GetSection("EnvironmentSAP")["CompanyDB"];

    //                Type tipoEntidade = typeof(T);

    //                string newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}/$count";
    //                if (filter != null)
    //                    newUrl = newUrl + "?";
    //                string addUrl = "";
    //                addUrl = addUrl + (filter != null ? "&$filter=" + filter : "");
    //                if (addUrl != "")
    //                    addUrl = addUrl.Substring(1, addUrl.Length - 1);
    //                newUrl = newUrl + addUrl;


    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newUrl);
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.Headers.Add("B1S-CaseInsensitive", "True");
    //                req.ContentType = "text/json";
    //                req.Method = "GET";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                if (httpResponse.StatusCode == HttpStatusCode.OK)
    //                {
    //                    var responseValue = string.Empty;
    //                    var responseStream = httpResponse.GetResponseStream();
    //                    if (responseStream != null)
    //                        using (var reader = new StreamReader(responseStream))
    //                        {
    //                            responseValue = reader.ReadToEnd();
    //                            int jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(responseValue.ToString());
    //                            return jsonObj;
    //                        }
    //                    return 0;
    //                }
    //                else
    //                    return 0;
    //            }
    //            else
    //                return 0;
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //    }

    //    /// <summary>
    //    /// Limpar Propertys com Id
    //    /// </summary>
    //    /// <param name="json"></param>
    //    /// <returns></returns>
    //    private async Task<string> ClearProperty(string json)
    //    {
    //        string ret = json;
    //        await Task.Run(() =>
    //        {
    //            var o = (JObject)JsonConvert.DeserializeObject(json);
    //            //bool Ok = false;
    //            //while (true)
    //            //{
    //            try
    //            {
    //                bool finalizado = false;
    //                while (!finalizado)
    //                {
    //                    try
    //                    {
    //                        foreach (var prop in o.Properties())
    //                        {
    //                            if (prop.Value.Type == JTokenType.Array)
    //                            {
    //                                JArray items = (JArray)o[prop.Name];
    //                                if (items.Count == 0)
    //                                    prop.Remove();

    //                                foreach (JObject o2 in items.Children<JObject>())
    //                                {
    //                                    try
    //                                    {
    //                                        foreach (JProperty p in o2.Properties())
    //                                        {
    //                                            if (p.Name == "Id")
    //                                                p.Remove();
    //                                            if (prop.Name.StartsWith("PO"))
    //                                                prop.Remove();
    //                                        }
    //                                    }
    //                                    catch { }
    //                                }
    //                                //Remover Propriedade BusinessPlaces (usada apenas na view)
    //                                if (prop.Name == "BusinessPlaces")
    //                                {
    //                                    prop.Remove();
    //                                }

    //                            }
    //                            if (prop.Value.Type == JTokenType.Date)
    //                            {
    //                                prop.Value = DateTime.Parse(prop.Value.ToString()).ToString("yyyyMMdd");
    //                            }
    //                            if (prop.Name == "Id")
    //                                prop.Remove();
    //                            if (prop.Name.StartsWith("PO"))
    //                                prop.Remove();
    //                        }
    //                        finalizado = true;
    //                    }
    //                    catch
    //                    {
    //                        finalizado = false;
    //                    }
    //                }
    //                ret = o.ToString();
    //            }
    //            catch { }
    //        });
    //        return ret;
    //    }
    //    public async Task<T> Post<T>()
    //    {
    //        LoginValue = await Login();
    //        try
    //        {
    //            if (LoginValue != null)
    //            {

    //                //string Url = config.GetSection("EnvironmentSAP")["Url"];
    //                //string Port = config.GetSection("EnvironmentSAP")["Port"];
    //                //string CompanyDB = config.GetSection("EnvironmentSAP")["CompanyDB"];

    //                Type tipoEntidade = typeof(T);

    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}");
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.ContentType = "text/json";
    //                req.Method = "POST";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                if (httpResponse.StatusCode == HttpStatusCode.Created || httpResponse.StatusCode == HttpStatusCode.OK)
    //                {
    //                    var responseValue = string.Empty;
    //                    var responseStream = httpResponse.GetResponseStream();
    //                    if (responseStream != null)
    //                        using (var reader = new StreamReader(responseStream))
    //                        {
    //                            responseValue = reader.ReadToEnd();
    //                            T jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseValue.ToString());
    //                            return jsonObj;
    //                        }
    //                    return default(T);
    //                }
    //                else
    //                {
    //                    return default(T);
    //                }
    //            }
    //            else
    //                return default(T);
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //        //finally
    //        //{
    //        //  if (_session == null)
    //        //    await Logout(config);
    //        //}
    //    }

    //    /// <summary>
    //    /// Função responsável em criar uma instância de 'typeparam T' com a carga útil especificada do tipo 'typeparam T' no formato JSON.
    //    /// </summary>
    //    /// <typeparam name="T">Tipo do objeto a ser trabalhado</typeparam>
    //    /// <param name="_session">Sessão com os dados do login guardados.</param>
    //    /// <param name="objeto">Objeto com seus dados</param>
    //    /// <param name="config">Dados de configurações das conexões</param>
    //    /// <returns></returns>
    //    public async Task<T> Post<T>(T objeto, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        var settings = new JsonSerializerSettings();
    //        settings.NullValueHandling = NullValueHandling.Ignore;
    //        //settings.DefaultValueHandling = DefaultValueHandling.Ignore;
    //        string json = JsonConvert.SerializeObject(objeto, Formatting.Indented, settings);
    //        try { json = await ClearProperty(json); } catch { }
    //        try
    //        {
    //            if (LoginValue != null)
    //            {

    //                //string Url = config.GetSection("EnvironmentSAP")["Url"];
    //                //string Port = config.GetSection("EnvironmentSAP")["Port"];
    //                //string CompanyDB = config.GetSection("EnvironmentSAP")["CompanyDB"];

    //                Type tipoEntidade = typeof(T);

    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}");
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.ContentType = "text/json";
    //                req.Method = "POST";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
    //                {
    //                    streamWriter.Write(json);
    //                }

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                if (httpResponse.StatusCode == HttpStatusCode.Created || httpResponse.StatusCode == HttpStatusCode.OK)
    //                {
    //                    var responseValue = string.Empty;
    //                    var responseStream = httpResponse.GetResponseStream();
    //                    if (responseStream != null)
    //                        using (var reader = new StreamReader(responseStream))
    //                        {
    //                            responseValue = reader.ReadToEnd();
    //                            T jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseValue.ToString());
    //                            return jsonObj;
    //                        }
    //                    return default(T);
    //                }
    //                else
    //                {
    //                    return default(T);
    //                }
    //            }
    //            else
    //                return default(T);
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            if (jsonObj.error.code == -2028 &&
    //                jsonObj.error.message.value.Contains("(ODBC -2028)"))
    //            {
    //                Type tipoEntidade = typeof(T);
    //                PropertyInfo[] properties = tipoEntidade.GetProperties();
    //                string C1ID = "";
    //                foreach (var propValue in properties)
    //                {
    //                    if (propValue.Name == "U_RBH_C1ID")
    //                        C1ID = propValue.GetValue(objeto).ToString();
    //                }
    //                if (C1ID != "")
    //                {
    //                    List<Drafts> drafts = await Get<Drafts>(filter: "U_RBH_C1ID eq '" + C1ID + "'");
    //                    if (drafts.Count > 0)
    //                    {
    //                        Drafts oDrf = drafts.FirstOrDefault();
    //                        oDrf.DocObjectCode = "oDrafts";
    //                        string json2 = JsonConvert.SerializeObject(oDrf, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    //                        json2 = await ClearProperty(json2);
    //                        try
    //                        {
    //                            T jObj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json2);
    //                            return jObj;
    //                        }
    //                        catch
    //                        {
    //                            return default(T);
    //                        }
    //                    }
    //                }
    //            }
    //            Log.Error(jsonObj.error.message.value + Environment.NewLine + json);
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //    }

    //    /// <summary>
    //    /// Função responsável em atualizar uma instância de 'typeparam T' com a carga útil especificada do tipo 'typeparam T' no formato JSON e com o ID especificado.
    //    /// </summary>
    //    /// <typeparam name="T">Tipo do objeto a ser trabalhado</typeparam>
    //    /// <param name="_session">Sessão com os dados do login guardados.</param>
    //    /// <param name="objeto">Objeto com seus dados</param>
    //    /// <param name="config">Dados de configurações das conexões</param>
    //    /// <param name="KeyValue">ID especificado</param>
    //    /// <returns></returns>
    //    public async Task<Boolean> Patch<T>(T objeto, string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password, bool B1SReplaceCollectionsOnPatch = true)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {
    //                Type tipoEntidade = typeof(T);
    //                string newUrl = "";

    //                try
    //                {
    //                    var type = GetKeyType(tipoEntidade);

    //                    if (tipoEntidade.Name.Substring(0, 2) == "U_")
    //                        newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                    else
    //                    {
    //                        if (type.Name == "Int32" || type.GenericTypeArguments[0].Name == "Int32")
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}({KeyValue})";
    //                        }
    //                        else
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                        }
    //                    }
    //                }
    //                catch
    //                {
    //                    newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                }
    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newUrl);
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                if (B1SReplaceCollectionsOnPatch)
    //                    req.Headers.Add("B1S-ReplaceCollectionsOnPatch", "True");

    //                req.ContentType = "text/json";
    //                req.Method = "PATCH";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
    //                {
    //                    var settings = new JsonSerializerSettings();
    //                    settings.NullValueHandling = NullValueHandling.Ignore;
    //                    //settings.DefaultValueHandling = DefaultValueHandling.Ignore;
    //                    string json = JsonConvert.SerializeObject(objeto, Formatting.Indented, settings);
    //                    json = await ClearProperty(json);
    //                    streamWriter.Write(json);
    //                }

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                return (httpResponse.StatusCode == HttpStatusCode.NoContent);
    //            }
    //            else
    //                return false;
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //    }

    //    /// <summary>
    //    /// Função responsável em excluir uma instância de 'typeparam T' com o ID especificado.
    //    /// </summary>
    //    /// <typeparam name="T">Tipo do objeto a ser trabalhado</typeparam>
    //    /// <param name="_session">Sessão com os dados do login guardados.</param>
    //    /// <param name="config">Dados de configurações das conexões</param>
    //    /// <param name="KeyValue">ID especificado</param>
    //    /// <returns></returns>
    //    public async Task<Boolean> Delete<T>(string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {

    //                //string Url = config.GetSection("EnvironmentSAP")["Url"];
    //                //string Port = config.GetSection("EnvironmentSAP")["Port"];
    //                //string CompanyDB = config.GetSection("EnvironmentSAP")["CompanyDB"];

    //                Type tipoEntidade = typeof(T);
    //                string newUrl = "";

    //                try
    //                {
    //                    var type = GetKeyType(tipoEntidade);

    //                    if (tipoEntidade.Name.Substring(0, 2) == "U_")
    //                        newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                    else
    //                    {
    //                        if (type.Name == "Int32" || type.GenericTypeArguments[0].Name == "Int32")
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}({KeyValue})";
    //                        }
    //                        else
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                        }
    //                    }
    //                }
    //                catch
    //                {
    //                    newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                }

    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newUrl);
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.ContentType = "text/json";
    //                req.Method = "DELETE";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                return (httpResponse.StatusCode == HttpStatusCode.NoContent);
    //            }
    //            else
    //                return false;
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //        //finally
    //        //{
    //        //  if (_session == null)
    //        //    await Logout(config);
    //        //}
    //    }
    //    public async Task<Boolean> Cancel<T>(string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {
    //                Type tipoEntidade = typeof(T);
    //                string newUrl = "";

    //                try
    //                {
    //                    var type = GetKeyType(tipoEntidade);

    //                    if (tipoEntidade.Name.Substring(0, 2) == "U_")
    //                        newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                    else
    //                    {
    //                        if (type.Name == "Int32" || type.GenericTypeArguments[0].Name == "Int32")
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}({KeyValue})";
    //                        }
    //                        else
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                        }
    //                    }
    //                }
    //                catch
    //                {
    //                    newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')";
    //                }
    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newUrl);
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.Headers.Add("B1S-ReplaceCollectionsOnPatch", "True");

    //                req.ContentType = "text/json";
    //                req.Method = "POST";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                return (httpResponse.StatusCode == HttpStatusCode.NoContent);
    //            }
    //            else
    //                return false;
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //    }
    //    public async Task<Boolean> Close<T>(string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {
    //                Type tipoEntidade = typeof(T);
    //                string newUrl = "";

    //                try
    //                {
    //                    var type = GetKeyType(tipoEntidade);

    //                    if (tipoEntidade.Name.Substring(0, 2) == "U_")
    //                        newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')/Close";
    //                    else
    //                    {
    //                        if (type.Name == "Int32" || type.GenericTypeArguments[0].Name == "Int32")
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}({KeyValue})/Close";
    //                        }
    //                        else
    //                        {
    //                            newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')/Close";
    //                        }
    //                    }
    //                }
    //                catch
    //                {
    //                    newUrl = $"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/{tipoEntidade.Name}('{KeyValue}')/Close";
    //                }
    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newUrl);
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                req.Headers.Add("B1S-ReplaceCollectionsOnPatch", "True");

    //                req.ContentType = "text/json";
    //                req.Method = "POST";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                return (httpResponse.StatusCode == HttpStatusCode.NoContent);
    //            }
    //            else
    //                return false;
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //    }
    //    public async Task<List<Batch>> Batch(List<Batch> objetos, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password, bool B1SReplaceCollectionsOnPatch = true)
    //    {
    //        LoginValue = await Login(SessionId, UserName, Password);
    //        try
    //        {
    //            if (LoginValue != null)
    //            {
    //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{LoginWS.Providers.SL}/b1s/{LoginWS.Providers.SLVS}/$batch");
    //                req.Headers.Add(HttpRequestHeader.Cookie, string.Format(
    //                              "CompanyDB={0};" +
    //                              "B1SESSION={1}", LoginWS.CompanyDB, LoginValue.SessionId));
    //                Guid BatchGuid = Guid.NewGuid();
    //                Guid ChangeSet = Guid.NewGuid();
    //                req.Headers.Add("Content-Type", "multipart/mixed;boundary=batch_" + BatchGuid.ToString());
    //                if (B1SReplaceCollectionsOnPatch)
    //                    req.Headers.Add("B1S-ReplaceCollectionsOnPatch", "True");
    //                req.Timeout = 36000000;
    //                req.Method = "POST";
    //                req.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

    //                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
    //                {
    //                    List<string> writer = new List<string>();
    //                    int c = 0;
    //                    foreach (var item in objetos)
    //                    {
    //                        if (c == 0)
    //                        {
    //                            writer.Add(@"--batch_" + BatchGuid.ToString());
    //                            writer.Add(@"Content-Type: multipart/mixed;boundary=changeset_" + ChangeSet.ToString());
    //                            writer.Add(@"--changeset_" + ChangeSet.ToString());
    //                            writer.Add(@"Content-Type: application/http");
    //                            writer.Add(@"Content-Transfer-Encoding:binary");
    //                            if (item.ContentID != null)
    //                                writer.Add(@"Content-ID:" + item.ContentID);
    //                            else
    //                                writer.Add(@"Content-ID:" + c);
    //                            writer.Add(@"");
    //                            writer.Add($@"{item.Action} /b1s/v1/" + item.Object);
    //                            if (item.JsonObject != null)
    //                            {
    //                                writer.Add(@"");
    //                                string json = await ClearProperty(item.JsonObject);
    //                                writer.Add(json);
    //                            }
    //                            writer.Add(@"");
    //                        }
    //                        else
    //                        {
    //                            writer.Add(@"--changeset_" + ChangeSet.ToString());
    //                            writer.Add(@"Content-Type: application/http");
    //                            writer.Add(@"Content-Transfer-Encoding:binary");
    //                            if (item.ContentID != null)
    //                                writer.Add(@"Content-ID:" + item.ContentID);
    //                            else
    //                                writer.Add(@"Content-ID:" + c);
    //                            writer.Add(@"");
    //                            writer.Add($@"{item.Action} /b1s/v1/" + item.Object);
    //                            if (item.JsonObject != null)
    //                            {
    //                                writer.Add(@"");
    //                                string json = await ClearProperty(item.JsonObject);
    //                                writer.Add(json);
    //                            }
    //                            writer.Add(@"");
    //                        }
    //                        c++;
    //                    }
    //                    writer.Add(@"--changeset_" + ChangeSet.ToString() + "--");
    //                    writer.Add(@"--batch_" + BatchGuid.ToString() + "--");
    //                    string output = string.Join(Environment.NewLine, writer.ToArray());
    //                    Log.Information(BatchGuid.ToString() + "\n" + output);
    //                    foreach (var item in writer)
    //                    {
    //                        streamWriter.WriteLine(item);
    //                    }
    //                }

    //                var httpResponse = (HttpWebResponse)req.GetResponse();
    //                if (httpResponse.StatusCode == HttpStatusCode.Accepted)
    //                {
    //                    var responseValue = string.Empty;
    //                    var responseStream = httpResponse.GetResponseStream();
    //                    if (responseStream != null)
    //                        using (var reader = new StreamReader(responseStream))
    //                        {
    //                            responseValue = reader.ReadToEnd();
    //                            if (responseValue.ToString().Contains("400 Bad Request"))
    //                            {
    //                                string Error = responseValue.ToString();
    //                                string contentID = "";
    //                                string[] splitted = Error.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    //                                foreach (var item in splitted)
    //                                {
    //                                    if (item.Contains("Content-ID:"))
    //                                    {
    //                                        contentID = item;
    //                                        break;
    //                                    }
    //                                }

    //                                Error = Error.Substring(Error.IndexOf("{") - 1, Error.Length - Error.IndexOf("{") - 1);
    //                                Error = Error.Substring(0, Error.LastIndexOf("}") + 1).Trim();
    //                                ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(Error);
    //                                throw new Exception(contentID + " - " + jsonObj.error.message.value);

    //                            }
    //                            //List<Batch> jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Batch>>(responseValue.ToString());
    //                            return null;
    //                        }
    //                    return objetos;
    //                }
    //                else
    //                {
    //                    return objetos;
    //                }
    //            }
    //            else
    //                return objetos;
    //        }
    //        catch (WebException we)
    //        {
    //            var resp = we.Response as HttpWebResponse;
    //            var responseValue = string.Empty;
    //            var responseStream = resp.GetResponseStream();
    //            if (responseStream != null)
    //                using (var reader = new StreamReader(responseStream))
    //                {
    //                    responseValue = reader.ReadToEnd();
    //                }
    //            ErrorSL jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorSL>(responseValue.ToString());
    //            throw new Exception(jsonObj.error.message.value, we);
    //        }
    //        catch (Exception ex)
    //        {
    //            string retError = ex.Message;
    //            throw new Exception(retError);
    //        }
    //    }
    //    private async Task checkLoginTable()
    //    {
    //        try
    //        {
    //            string sql = @"SELECT COUNT(*) as ""A"" FROM OUTB WHERE ""TableName""='RBH_LOGIN'";
    //            string ret = await DataManager.GetData(sql);
    //            dynamic jsonObj = JsonConvert.DeserializeObject(ret.ToString());
    //            JArray a = (JArray)jsonObj;
    //            int c = 0;
    //            if (a.Count > 0)
    //                c = a[0].Value<int>("A");
    //            if (c == 0)
    //            {
    //                try
    //                {
    //                    UserTablesMD TBLOGIN = (new UserTablesMD
    //                    {
    //                        TableName = "RBH_LOGIN",
    //                        TableDescription = "Login do WebApi",
    //                        TableType = "bott_NoObject"
    //                    });
    //                    var table = await Post<UserTablesMD>(TBLOGIN);
    //                }
    //                catch { }
    //                List<UserFieldsMD> fields = new List<UserFieldsMD>();
    //                fields.Add(new UserFieldsMD
    //                {
    //                    TableName = "@RBH_LOGIN",
    //                    Name = "SessionTimeout",
    //                    Description = "SessionTimeout",
    //                    Type = "db_Alpha",
    //                    Size = 100
    //                });
    //                fields.Add(new UserFieldsMD
    //                {
    //                    TableName = "@RBH_LOGIN",
    //                    Name = "SessionId",
    //                    Description = "SessionId",
    //                    Type = "db_Alpha",
    //                    Size = 100
    //                });
    //                fields.Add(new UserFieldsMD
    //                {
    //                    TableName = "@RBH_LOGIN",
    //                    Name = "CompanyDB",
    //                    Description = "CompanyDB",
    //                    Type = "db_Alpha",
    //                    Size = 100
    //                });
    //                fields.Add(new UserFieldsMD
    //                {
    //                    TableName = "@RBH_LOGIN",
    //                    Name = "Progress",
    //                    Description = "Progress",
    //                    Type = "db_Alpha",
    //                    Size = 1
    //                });
    //                foreach (var field in fields)
    //                {
    //                    try
    //                    {
    //                        var retF = await Post<UserFieldsMD>(field);
    //                    }
    //                    catch (Exception ex) { logger.LogError(ex.Message); }
    //                }
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }
    //}
    //public class Session
    //{
    //    public string Code { get; set; }
    //    public string U_SessionTimeout { get; set; }
    //    public string U_SessionId { get; set; }
    //    public string U_CompanyDB { get; set; }
    //    public string U_UserName { get; set; }
    //}
//}
