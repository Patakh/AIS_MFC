using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.ModelBuilder;

namespace AisLogistics.App.ViewModels.Cases
{
    public sealed class CaseDetailsResponseModel<T>
    {
        public CaseDetailsResponseModel(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }

    public class CaseCustomerResponseModel : AbstractResponseBuilder<CaseCustomerResponseModel>
    {
        public override CaseCustomerResponseModel Build() => this;
    }

    public class ServiceFileResponseModel : AbstractResponseBuilder<ServiceFileResponseModel>
    {
        public Guid Id { get; private set; }

        public ServiceFileResponseModel SetFileId(Guid id)
        {
            Id = id;
            return this;
        }

        public override ServiceFileResponseModel Build() => this;
    }
}