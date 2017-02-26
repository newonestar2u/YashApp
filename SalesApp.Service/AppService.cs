namespace SalesApp.Service
{
    using Model.Model;

    public class AppService<T> : ServiceBase<T> where T : BaseModel, new()
    {

    }
}
