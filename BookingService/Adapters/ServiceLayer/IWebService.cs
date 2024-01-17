using Domain.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCD.SAPAPI
{
    public interface IWebService
    {
        Task<LoginValues> Login([Optional] string SessionId, [Optional] string UserName, [Optional] string Password);
        Task<LoginValues> Login(string UserName, string Password, string Type, [Optional] string Database, [Optional] string SessionId);
        Task<Boolean> Logout();
        Task<T> Get<T>(string KeyValue, [Optional] string SessionId, [Optional] string UserNam, [Optional] string Passworde);
        Task<List<T>> Get<T>([Optional] string SessionId, [Optional] string UserName, [Optional] string Password, [Optional] string select, [Optional] string orderby, [Optional] string filter, [Optional] string top, [Optional] string skip, [Optional] string maxPageSize);
        Task<int> Count<T>([Optional] string filter, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password);
        Task<T> Post<T>(T objeto, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password);
        Task<Boolean> Patch<T>(T objeto, string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password, bool B1SReplaceCollectionsOnPatch = true);
        Task<Boolean> Delete<T>(string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password);
        Task<Boolean> Close<T>(string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password);
        Task<Boolean> Cancel<T>(string KeyValue, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password);
        Task<List<Batch>> Batch(List<Batch> objetos, [Optional] string SessionId, [Optional] string UserName, [Optional] string Password, bool B1SReplaceCollectionsOnPatch = true);
    }
}
