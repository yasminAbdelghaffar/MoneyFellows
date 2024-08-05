namespace Core.DTOs.Registration
{
    public class RegistrationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public long? UserId { get; set; }
    }
}
