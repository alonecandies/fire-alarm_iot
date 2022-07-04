using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Net;
//using System.Net.Http;
using System.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DeviceDemo
{
     using Models;
   public class ApiRequestContext
    {
        public string Token { get; set; }
        public string Url 
        {
            get { return '/' + Controller + '/' + Action + '/' + ObjectId; } 
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                var v = value.Split('/');
                int i = 0;
                while (i < v.Length && string.IsNullOrWhiteSpace(v[i])) i++;

                if (i < v.Length) Controller = v[i++];
                if (i < v.Length) Action = v[i++];
                if (i < v.Length) ObjectId = v[i++];
            }
        }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ObjectId { get; set; }
        public object Value { get; set; }
    }
    class WebRequest
    {
        string _domain;
        
        #region Response
        public int Code { get; set; }
        public string Message { get; set; }
        public JToken Value { get; set; }
        public event Action<WebRequest> ResponseError;
        public event Action<WebRequest> ResponseOK;
        public event Action<WebRequest> Responsed;
        #endregion

        public ApiRequestContext _context { get; set; }
        System.Net.WebRequest _request;

        public WebRequest(string domain)
        {
            if (domain.StartsWith("http") == false)
            {
                domain = "http://" + domain;
            }
            _domain = domain;
        }
        public void Execute()
        {
            try
            {
                using (var sw = new System.IO.StreamWriter(_request.GetRequestStream()))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(sw, _context);
                }
                var response = _request.GetResponse() as System.Net.HttpWebResponse;
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new System.IO.StreamReader(stream, Encoding.UTF8))
                    {
                        var responseString = reader.ReadToEnd();
                        var responseObject = JObject.Parse(responseString);

                        Code = responseObject.Get<int>("Code");
                        Message = responseObject.Get<string>("Message");
                        if (Code >= 0)
                        {
                            Value = responseObject.SelectToken("Value");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Code = -505;
                Message = e.Message;
            }
            finally
            {
                Responsed?.Invoke(this);
            }

            if (Code < 0)
            {
                ResponseError?.Invoke(this);
            }
            else
            {
                ResponseOK?.Invoke(this);
            }
        }
        public void Post(string apiRoute, ApiRequestContext context, int timeout)
        {
            var request = System.Net.WebRequest.Create(_domain + '/' + apiRoute);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = timeout;

            _context = context;
            _request = request;

            Engine.CreateThread(this.Execute);
        }
        public void Post(string apiRoute, string serviceRoute, object value, int timeout)
        {
            var context = new ApiRequestContext { 
                Value = value,
                Url = serviceRoute,
            };
            Post(apiRoute, context, timeout);
        }
    }
}
