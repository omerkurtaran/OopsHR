namespace BaseFramework.Core.Entity
{
    public abstract class Entity<T> : EntityBase, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
