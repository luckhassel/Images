namespace ImagesStorage.Application.Models.ViewModels
{
    public class ResultViewModel
    {
        public ValidationResult ValidationResult { get; set; }
        public bool Success { get => ValidationResult?.IsValid ?? true; }
    }

    public class ResultViewModel<TResult> : ResultViewModel
    {
        public TResult Result { get; set; }
    }

    public sealed class ValidationResult
    {
        public int Code { get; }
        public string Message { get; }

        public bool IsValid => Code == 0 && string.IsNullOrWhiteSpace(Message);
        public static ValidationResult SetValidationResultError(string message, int code)
        {
            return new(message, code);
        }

        private ValidationResult(string message, int code)
        {
            Message = message;
            Code = code;
        }
    }
}