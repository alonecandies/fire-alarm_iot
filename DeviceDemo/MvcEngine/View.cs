namespace System.Mvc
{
    public partial interface IView
    {
        void Render(Controller controller);
    }

    public interface IAsyncView
    {
    }
}
