using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Domain.Models;
using MCD.SAPAPI.DataAcessObjects;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
//using WebApi.SAP;
using MCD.SAPAPI.L1Common.Models;

namespace MCD.SAPAPI.Controllers
{
    /// <summary>
    /// Controller resonsável por realizar as conexões possíveis com SAP;
    /// </summary>
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly IWebService webService;
        //private readonly IConfiguration configuration;


        ///// <summary>
        ///// Construtor da classe;
        ///// </summary>
        ///// <param name="webService"></param>
        ///// <param name="configuration"></param>
        //public LoginController(IWebService webService, IConfiguration configuration)
        //{
        //    try
        //    {
        //        this.webService = webService;
        //        this.configuration = configuration;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message);
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="UserName"></param>
        ///// <param name="Password"></param>
        ///// <param name="Database"></param>
        ///// <returns></returns>
        //[NonAction]
        //private async Task<LoginValues> Loginn(string UserName, string Password, [Optional] string Database)
        //{
        //    try
        //    {
        //        Log.ForContext("Action", $"Login.Loginn").Information($@"Iniciando autenticação de usuário!");
        //        LoginValues userExists = new LoginValues();
        //        List<Servers> srv = new List<Servers>();
        //        string LoginType = configuration.GetValue<string>("LoginType");
        //        Providers prov = configuration.GetSection("Providers").Get<Providers>();
        //        if (Database == null)
        //            Database = prov.CompanyDB;
        //        Log.ForContext("Action", $"Login.Loginn").Information($@"Conexão com o server: {prov.Server}");
        //        Log.ForContext("Action", $"Login.Loginn").Information($@"Conexão com a base de dados: {Database}");
        //        if (LoginType.ToUpper() == "LOCAL")
        //        {
        //            try
        //            {
        //                userExists = await webService.Login(UserName, Password, LoginType.ToUpper(), Database);
        //                if (userExists == null)
        //                    throw new Exception("Usuário e/ou senha está(ão) inválido(s).");

        //                string sql = $@"SELECT ""COMPANYNAME"" FROM [SLDModel.SLDData].dbo.CompanyDBs WHERE ""Name""='{Database.ToUpper()}'";
        //                if (prov.DbServerType == "HANA")
        //                    sql = $@"SELECT ""COMPANYNAME"" FROM ""SLDDATA"".""COMPANYDBS"" WHERE ""NAME""='{Database.ToUpper()}'";
        //                string CompanyName = (await DataManager.GetDataEscalar(sql)).ToString();
        //                if (CompanyName == "")
        //                    CompanyName = Database;
        //                srv.Add(new Servers()
        //                {
        //                    CompanyName = CompanyName,
        //                    DataBase = Database,
        //                    PathWebApi = ""
        //                });
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }
        //        }
        //        if (LoginType.ToUpper() == "WEB")
        //        {
        //            try
        //            {
        //                Log.ForContext("Action", $"Login.Loginn").Information($@"Validando conexão com WEB: UpdateSoftware - Iniciando a conexão...");
        //                string URL = configuration.GetValue<string>("LoginURL") + $@"?login={UserName}&senha={Password}";
        //                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
        //                req.ContentType = "application/x-www-form-urlencoded";
        //                req.Method = "GET";
        //                var httpResponse = (HttpWebResponse)req.GetResponse();
        //                if (httpResponse.StatusCode == HttpStatusCode.OK)
        //                {
        //                    var responseValue = string.Empty;
        //                    var responseStream = httpResponse.GetResponseStream();
        //                    if (responseStream != null)
        //                        using (var reader = new StreamReader(responseStream))
        //                        {
        //                            Log.ForContext("Action", $"Login.Loginn").Information($@"Validando conexão com WEB: UpdateSoftware - Conectado com sucesso!");
        //                            responseValue = reader.ReadToEnd();
        //                            LicenseAuth jsonObj = JsonConvert.DeserializeObject<LicenseAuth>(responseValue.ToString());
        //                            foreach (var servers in jsonObj.servidores)
        //                            {
        //                                int index = servers.Nome.IndexOf("|");
        //                                srv.Add(new Servers()
        //                                {
        //                                    CompanyName = "",
        //                                    DataBase = servers.Nome.Substring(index+1, servers.Nome.Length - index - 1),
        //                                    PathWebApi = servers.Caminho
        //                                });
        //                            }
        //                            if (srv.Where(w => w.DataBase == Database).FirstOrDefault() == null)
        //                                throw new Exception("Base de dados não liberado ao usuário");
        //                        }
        //                }
        //                else
        //                    throw new Exception("Usuário e/ou senha está(ão) inválido(s).");
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }
        //        }

        //        Log.ForContext("Action", $"Login.Loginn").Information($@"{UserName} - Usuário validado!");

        //        if (LoginType.ToUpper() != "SAP")
        //        {
        //            Log.ForContext("Action", $"Login.Loginn").Information($@"Validando conexão com SAP: Iniciando a conexão...");
        //            userExists = await webService.Login(prov.UserName, prov.Password, "SAP", Database);
        //            userExists.Name = UserName;
        //            userExists.Password = Password;
        //            userExists.Type = 1;
        //            Log.ForContext("Action", $"Login.Loginn").Information($@"Validando conexão com SAP: Conectado com sucesso!");
        //        }
        //        userExists.Servers = srv;
        //        userExists.Version = prov.SLVS;
        //        return userExists;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Método para a autenticação na WebApi, retornando o token de acesso
        ///// </summary>
        ///// <param name="UserName">Informar o usuário para conexão</param>
        ///// <param name="Password">Informar a senha para conexão</param>
        ///// <returns>Dados necessários a respeito da conexão do usuário</returns>
        //[HttpPost]
        //[AllowAnonymous]
        //[Route("/api/v1/auth/")]
        //[SwaggerResponse(200, "", Type = typeof(LoginToken))]
        //[SwaggerResponse(400, "", Type = typeof(Error))]
        //[Produces("application/json")]
        //public async Task<IActionResult> Auth([FromHeader] string UserName, [FromHeader] string Password, [Optional] string Database)
        //{
        //    try
        //    {
        //        Log.ForContext("Action", $"Login.Auth")
        //            .Information($@"{UserName} - Chamada de login...");
        //        LoginValues userExists = await Loginn(UserName, Password, Database);
        //        if (userExists != null)
        //        {
        //            try
        //            {
        //                string ret = await DataManager.GetDataProc($"SPS_C1_AUTHORIZATION '{UserName}'");
        //                userExists.Authorizations = JsonConvert.DeserializeObject<List<Domain.Models.Authorization>>(ret);
        //                if (userExists.Authorizations.Count > 0)
        //                    userExists.UserID = (int)userExists.Authorizations[0].USERID;
        //            }
        //            catch { }

        //            userExists.Name = UserName;
        //            var token = JwtAuth.GenerateToken(userExists, configuration.GetValue<string>("secretKey"));
        //            LoginToken login = new LoginToken();
        //            login.CompanyName = userExists.Servers[0].CompanyName;
        //            login.DataBase = userExists.Servers[0].DataBase;
        //            login.Token = token;
        //            login.Usuario = userExists;
        //            return Ok(login);
        //        }
        //        else
        //        {
        //            var token = JwtAuth.GenerateToken(userExists, configuration.GetValue<string>("secretKey"));
        //            return Ok(token);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.ForContext("Action", $"Login.Auth")
        //            .Error("{ApplicationName} / " + $@"{UserName} - {ex.Message}");
        //        Error error = new Error();
        //        Message men = new Message();
        //        men.value = ex.Message;
        //        error.message = men;
        //        return BadRequest(error);
        //    }
        //}
    }
}
