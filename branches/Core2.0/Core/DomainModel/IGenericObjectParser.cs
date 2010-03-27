namespace Core.DomainModel
{
    public interface IGenericObjectParser<T>
    {
        T Parse();
    }
}
