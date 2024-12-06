
namespace NineDotsAssesment.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? IC { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? PIN { get; set; }
        public bool Verified { get; set; }
    }
}
