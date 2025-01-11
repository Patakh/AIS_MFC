using AisLogistics.App.Models.DTO.Services;

namespace AisLogistics.App.ViewModels.Cases
{
    public class SmevDetailsResponseModel
    {
        public SmevDetailsResponseModel()
        {
            ResponseStatus = new SmevResponseStatus(false);
        }
        public SmevDetailsResponseModel ResponseError(string? message)
        {
            ResponseStatus = new SmevResponseStatus(true, message);
            return this;
        }
        public SmevDetailsResponseModel AddDocument(byte[] bytes)
        {
            Document = bytes;
            return this;
        }

        public SmevDetailsResponseModel AddRequestInformation(CaseServiceSmevRequestDto request)
        {
            RequestInformation = request;
            return this;
        }

        public byte[] Document { get; private set; }
        public SmevResponseStatus ResponseStatus { get; private set; }
        public CaseServiceSmevRequestDto RequestInformation { get; private set; }
    }

    public class SmevResponseStatus
    {
        public SmevResponseStatus(bool isError, string? message = null)
        {
            IsError = isError;
            Message = message;
        }
        public bool IsError { get; }
        public string? Message { get; }
    }
}
