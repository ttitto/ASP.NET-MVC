namespace TtitterMvc.Infrastructure.ValidationErrors
{
    public interface IBaseError
    {
        string PropertyName { get; }
        string PropertyExceptionMessage { get; }
    }
}
