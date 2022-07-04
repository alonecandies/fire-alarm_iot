using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using MVC = System.Mvc;

namespace DeviceDemo
{
    using Models;
    partial class BaseController : MVC.Controller
    {
        #region Call API
        WebRequest _webRequest;
        public event Action Completed;
        public WebRequest WebRequest
        {
            get
            {
                if (_webRequest == null)
                {
                    //_webRequest = new WebRequest("http://localhost:44397/");
                    _webRequest = new WebRequest("https://postman-echo.com/post");
                    _webRequest.Responsed += o => Completed?.Invoke();
                }
                return _webRequest;
            }
        }

        protected ApiRequestContext CreateApiContext(object value, string objectId = null, string serviceRoute = null)
        {
            var context = new ApiRequestContext { 
                Token = User?.Id,
                Url = serviceRoute,
                Value = value,
                ObjectId = objectId,
            };
            if (context.Controller == null)
            {
                context.Controller = RequestContext.ControllerName;
                context.Action = RequestContext.ActionName;
            }
            return context;
        }
        public MVC.ActionResult Post(ApiRequestContext context, Action<JToken> callback, int timeout = 30000)
        {
            context.Token = this.User?.Id;

            if (callback != null)
            {
                WebRequest.ResponseOK += r => callback.Invoke(r.Value);
            }
            WebRequest.Post("/api/access/post", context, timeout);
            return Wait();
        }
        #endregion

        #region Database
        static BsonData.DataBase _mainDB;
        public BsonData.DataBase MainDB
        {
            get
            {
                if (_mainDB == null)
                {
                    _mainDB = new BsonData.DataBase(System.IO.Directory.GetCurrentDirectory() + "/app_data", "MainDB");
                }
                return _mainDB;
            }
        }
        public virtual BsonData.Collection Collection
        {
            get
            {
                return MainDB.GetCollection(RequestContext.ControllerName);
            }
        }
        #endregion

        static UserInfo _user;
        public UserInfo User
        {
            get => _user;
            set => _user = value;
        }
        public virtual MVC.ActionResult Wait()
        {
            return View(new Views.WaitApi(), WebRequest);
        }
        public virtual MVC.ActionResult GoFirst()
        {
            return RedirectToAction("Default");
        }
    }
}
