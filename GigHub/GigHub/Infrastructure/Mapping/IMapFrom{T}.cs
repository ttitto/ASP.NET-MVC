namespace GigHub.Mapping
{
    public interface IMapFrom<T> : IMapFrom
        where T : class
    {
    }
    public interface IMapFrom
    {
    }
}