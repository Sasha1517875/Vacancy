namespace Vacancy.DataAccess.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        Guid ExternalId { get; set; }
        DateTime ModificationTime { get; set; }
        DateTime CreationTime { get; set; }
    }
}
