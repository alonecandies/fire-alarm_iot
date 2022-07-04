using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;

namespace System.Mvc
{
    public class ControllerCollection : Dictionary<string, Type>
    {
        public ControllerCollection(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                var name = type.Name.ToLower();
                if (name.EndsWith("controller"))
                {
                    this.Add(name.Substring(0, name.Length - 10), type);
                }
            }
        }
        public Controller CreateController(string name)
        {
            Type type;
            if (this.TryGetValue(name.ToLower(), out type))
            {
                return (Controller)Activator.CreateInstance(type);
            }
            return null;
        }
    }

    public partial class Controller
    {
        public ViewDataDictionary ViewData { get; private set; } = new ViewDataDictionary();
        public RequestContext RequestContext { get; set; }

        public string ControllerName
        {
            get
            {
                var name = this.GetType().Name;
                return name.Substring(0, name.Length - 10);
            }
        }

        public MethodInfo GetMethod(string name)
        {
            name = name.ToLower();
            foreach (var method in this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                if (method.Name.ToLower() == name)
                {
                    return method;
                }
            }
            return null;
        }
        public MethodInfo GetMethod(string name, object[] values)
        {
            MethodInfo result = null;

            name = name.ToLower();
            foreach (var method in this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                if (method.Name.ToLower() != name)
                {
                    continue;
                }

                var parameters = method.GetParameters();
                if (parameters.Length != values.Length) continue;

                result = method;

                for (int i = 0; i < values.Length; i++)
                {
                    var type = parameters[i].ParameterType;
                    object v = values[i];
                    if (v == null)
                    {
                        if (type.IsValueType)
                        {
                            result = null;
                            break;
                        }
                        continue;
                    }

                    if (v.GetType() != type)
                    {
                        try
                        {
                            values[i] = Convert.ChangeType(v, type);
                        }
                        catch
                        {
                            result = null;
                            break;
                        }
                    }
                }

                if (result != null) { break; }
            }
            return result;
        }

        protected virtual T GetActionResult<T>(string actionName, RequestValues values, Action<T> execute)
        {
            var param = values.ToArray();
            var method = GetMethod(actionName, param);
            if (method == null) { return default(T); }

            this.RequestContext.ActionName = method.Name;

            var result = (T)method.Invoke(this, param);

            execute?.Invoke(result);
            return result;
        }

        protected virtual void ExecuteCore(string actionName, RequestValues values, Action<ActionResult> callBack)
        {
            if (RequestContext == null)
                RequestContext = new RequestContext();
            RequestContext.ActionName = actionName;

            try
            {
                GetActionResult<ActionResult>(actionName, values, result => {
                    if (result != null && result.Handled == false)
                    {
                        if (callBack == null)
                            callBack = Engine.ValidateActionResult;

                        callBack?.Invoke(result);
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Execute(RequestContext requestContext, Action<ActionResult> callBack)
        {
            RequestContext = requestContext;
            var name = requestContext.ActionName ?? "Default";

            ExecuteCore(name, requestContext.Values, callBack);
        }

        public void Execute(string actionName, params object[] values)
        {
            ExecuteCore(actionName, values, null);
        }

        protected virtual void OnExecuteError(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(e);
            Console.ResetColor();
        }

        protected ActionResult View(string name, object model)
        {
            var view = Engine.CreateObject<IView>(name);
            return View(view, model);
        }

        protected ActionResult View(object model)
        {
            return View(Engine.CreateObject<IView>("Views." + ControllerName + '.' + RequestContext.ActionName), model);
        }

        protected virtual ActionResult View(IView view, object model)
        {
            ViewData.Model = model;

            if (!(view is IAsyncView))
            {
                view.Render(this);
            }

            return new ActionResult {
                View = view,
                Controller = this,
            };
        }

        protected ActionResult View()
        {
            return View(null);
        }

        protected ActionResult RedirectToAction(string actionName)
        {
            Engine.Execute(RequestContext.ControllerName + '/' + actionName);
            return new ActionResult { Handled = true };
        }

        protected ActionResult Redirect(string url)
        {
            Engine.Execute(url);
            return new ActionResult { Handled = true };
        }

        public virtual ActionResult Done()
        {
            return new ActionResult { Handled = true };
        }

    }
}
