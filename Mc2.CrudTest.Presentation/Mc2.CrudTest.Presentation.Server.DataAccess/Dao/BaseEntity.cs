namespace Mc2.CrudTest.Presentation.Server.DataAccess.Dao
{
    public interface IEntity
    {


    }
    public interface IEntity<TKey> : IEntity
    {
        public TKey Id { get; protected set; }
    }

    public interface ISoftDelete
    {
        public Status Status { get; set; }
    }


    public abstract class BaseEntity<TKey> : IEntity<TKey>, ISoftDelete
    {
        public TKey Id { get; set; }
        public Status Status { get; set; }

    }




}
