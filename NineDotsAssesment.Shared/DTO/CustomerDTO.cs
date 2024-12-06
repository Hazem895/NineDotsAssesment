namespace NineDotsAssesment.Shared.DTO
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? IC { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? PIN { get; set; }
        public string? ConfirmedPIN { get; set; }
        public bool Verified { get; set; }

    }
}
