namespace NineDotsAssesment.Shared.Models
{
    public class RegisterationProcessResponse : ResponseModel
    {
        public List<ValidationErrors> ValidationErrors { get; set; }
    }
}
