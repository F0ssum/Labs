namespace Portfolio.Infrastructure.Data
{
    public class GenerateUnique

    {
        public int GetGenerateUniqueUserId()
        {
            var guid = Guid.NewGuid();
            return Math.Abs(guid.GetHashCode());
        }
        public int GetGenerateUniqueProjectId()
        {
            var guid = Guid.NewGuid();
            return Math.Abs(guid.GetHashCode());
        }
    }
}
