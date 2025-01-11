namespace AisLogistics.App.ViewModels.ModelBuilder
{
    public abstract class AbstractResponseBuilder<T>
    {
        public virtual AbstractResponseBuilder<T> Success()
        {
            ResponseStatus = new ResponseStatus(true);
            return this;
        }

        public virtual AbstractResponseBuilder<T> Error(string? message)
        {
            ResponseStatus = new ResponseStatus(false, message);
            return this;
        }

        public ResponseStatus ResponseStatus { get; private set; } = new(true);

        public abstract T Build();
    }

    public class ResponseStatus
    {
        public ResponseStatus(bool isSuccess, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }
    }
}
