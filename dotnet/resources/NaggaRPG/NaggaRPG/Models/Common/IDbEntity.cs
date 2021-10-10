namespace NaggaRPG.Models.Common
{
    public interface IDbEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}