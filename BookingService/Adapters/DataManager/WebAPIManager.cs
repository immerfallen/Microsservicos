using Newtonsoft.Json;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCD.SAPAPI.DataAcessObjects
{
    public static class WebAPIManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<T> Get<T>(string url, [Optional] string token)
        {
            HttpResponseMessage res = null;
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("ContentType", "text/json");
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                }
                res = await client.GetAsync(url);
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var content = await res.Content.ReadAsStringAsync();
                    T ret = JsonConvert.DeserializeObject<T>(content);
                    return ret;
                }
                else
                {
                    throw new Exception(res.StatusCode.ToString() + "-" + res.RequestMessage.ToString());
                }
                //return default(T);
            }
            catch (Exception e)
            {
                if (res != null)
                {
                    string contentRet = await res.Content.ReadAsStringAsync();
                    contentRet = contentRet.Substring(0, contentRet.IndexOf(Environment.NewLine));
                    throw new Exception(contentRet);
                }
                else
                    throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="dataJson"></param>
        /// <returns></returns>
        public static async Task<T> Post<T>(string url, [Optional] object dataJson, [Optional] string token)
        {
            HttpResponseMessage res = null;
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(60);
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                }

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                //settings.DefaultValueHandling = DefaultValueHandling.Ignore;
                string json = JsonConvert.SerializeObject(dataJson, Formatting.Indented, settings);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                res = await client.PostAsync(url, content);
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var contentRet = await res.Content.ReadAsStringAsync();
                    T ret = JsonConvert.DeserializeObject<T>(contentRet);
                    return ret;
                }
                else
                {
                    throw new Exception(res.StatusCode.ToString() + "-" + res.RequestMessage.ToString());
                }
            }
            catch (Exception e)
            {
                if (res != null)
                {
                    string contentRet = await res.Content.ReadAsStringAsync();

                    try
                    {
                        contentRet = contentRet.Substring(0, contentRet.IndexOf(Environment.NewLine));
                    }
                    catch (Exception)
                    {
                        try
                        {
                            Error error = JsonConvert.DeserializeObject<Error>(contentRet);
                            contentRet = error.message.value;
                        }
                        catch { }
                    }
                    throw new Exception(contentRet);
                }
                else
                    throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dataJson"></param>
        /// <returns></returns>
        public static async Task<T> Post<T>(string url, Dictionary<string, string> fromHeader, [Optional] object dataJson)
        {
            try
            {
                HttpResponseMessage res = null;
                using var client = new HttpClient();
                if (fromHeader != null)
                {
                    foreach (var item in fromHeader)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                if (dataJson != null)
                {
                    var settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    //settings.DefaultValueHandling = DefaultValueHandling.Ignore;
                    string json = JsonConvert.SerializeObject(dataJson, Formatting.Indented, settings);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    res = await client.PostAsync(url, content);
                }
                else
                    res = await client.PostAsync(url, null);
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var contentRet = await res.Content.ReadAsStringAsync();
                    T ret = JsonConvert.DeserializeObject<T>(contentRet);
                    return ret;
                }
                else
                {
                    throw new Exception(res.StatusCode.ToString() + "-" + res.RequestMessage.ToString());
                }
                /*HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.ContentType = "text/json";
                req.Method = "POST";
                if (fromHeader != null)
                {
                    foreach (var item in fromHeader)
                    {
                        req.Headers.Add(item.Key, item.Value);
                    }
                }
                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                {
                    var settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    //settings.DefaultValueHandling = DefaultValueHandling.Ignore;
                    string json = JsonConvert.SerializeObject(dataJson, Formatting.Indented, settings);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)req.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var responseValue = string.Empty;
                    var responseStream = httpResponse.GetResponseStream();
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                            return responseValue.Replace("\"", "").ToString();
                        }
                }
                return null;*/
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dataJson"></param>
        /// <returns></returns>
        public static async Task<bool> Put(string url, [Optional] object dataJson, [Optional] string token)
        {
            HttpResponseMessage res = null;
            try
            {
                using var client = new HttpClient();
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                }

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                //settings.DefaultValueHandling = DefaultValueHandling.Ignore;
                string json = JsonConvert.SerializeObject(dataJson, Formatting.Indented, settings);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                res = await client.PutAsync(url, content);

                if (res.StatusCode == HttpStatusCode.OK || res.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                if (res != null)
                {
                    string contentRet = await res.Content.ReadAsStringAsync();
                    contentRet = contentRet.Substring(0, contentRet.IndexOf(Environment.NewLine));
                    throw new Exception(contentRet);
                }
                else
                    throw new Exception(e.Message);
            }
        }
        public static async Task<bool> Patch(string url, [Optional] object dataJson, [Optional] string token)
        {
            HttpResponseMessage res = null;
            try
            {
                using var client = new HttpClient();
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                }

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                //settings.DefaultValueHandling = DefaultValueHandling.Ignore;
                string json = JsonConvert.SerializeObject(dataJson, Formatting.Indented, settings);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                res = await client.PatchAsync(url, content);

                if (res.StatusCode == HttpStatusCode.OK || res.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                if (res != null)
                {
                    string contentRet = await res.Content.ReadAsStringAsync();
                    contentRet = contentRet.Substring(0, contentRet.IndexOf(Environment.NewLine));
                    throw new Exception(contentRet);
                }
                else
                    throw new Exception(e.Message);
            }
        }
    }
}
