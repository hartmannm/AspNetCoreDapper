namespace ANCD.Application.Messages.Queries
{
    public abstract class Query<T> : Message, IQuery<QueryResult<T>>
    {
    }
}
