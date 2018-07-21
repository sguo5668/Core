namespace ConsoleRepo.DomainObjecs
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
