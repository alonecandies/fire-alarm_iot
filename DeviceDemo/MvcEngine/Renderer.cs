using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Mvc
{
    public interface IRenderer
    {
        object GetResult();
    }
    public partial class Renderer<TView, TModel> : IView, IRenderer
        where TView : new()
    {
        public virtual object GetResult()
        {
            return MainContent;
        }
        protected virtual TView CreateMainContent()
        {
            return new TView();
        }
        public TView MainContent { get; protected set; }
        public TModel Model { get; private set; }
        public ViewDataDictionary ViewBag { get; private set; }
        public Controller Controller { get; private set; }

        public virtual void Render(Controller controller)
        {
            RenderCore(
                Controller = controller, 
                ViewBag = controller.ViewData, 
                Model = (TModel)controller.ViewData.Model,
                MainContent = CreateMainContent()
                );
        }

        protected virtual void RenderCore(
            Controller controller, 
            ViewDataDictionary viewData, 
            TModel model,
            TView mainContent)
        {

        }
    }
}
