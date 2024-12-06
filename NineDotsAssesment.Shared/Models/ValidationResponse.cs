namespace NineDotsAssesment.Shared.Models
{
    public class ValidationResponse
    {
        public bool IsValid { get; set; }
        public List<ValidationErrors> Errors { get; set; } = new();
    }

    public class ValidationErrors
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

    }
}
