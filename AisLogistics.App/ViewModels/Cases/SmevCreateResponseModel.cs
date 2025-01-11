using System.Text.Json;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;

namespace AisLogistics.App.ViewModels.Cases
{
    public sealed class SmevCreateResponseModel : SmevCreateAbstract
    {
        public SmevCreateResponseModel()
        {
           
        }
        public SmevCreateResponseModel AddApplicants(List<ApplicantAdditionalDto> applicants)
        {
            Applicants = applicants;
            return this;
        }
        public SmevCreateResponseModel AddAdditionalDataJson(string additionalData)
        {
            AdditionalData = additionalData;
            return this;
        }
        private List<ApplicantAdditionalDto> Applicants { get; set; }
        private string AdditionalData { get; set; }
        /// <summary>
        /// Получить список всех заявителей
        /// </summary>
        /// <returns></returns>
        public List<ApplicantAdditionalDto> GetApplicants() => Applicants.OrderBy(a => a.Type).ToList();
        /// <summary>
        /// Получить заявителя
        /// </summary>
        /// <param name="customerType">Тип заявителя</param>
        /// <returns></returns>
        public ApplicantAdditionalDto? GetApplicant(CustomerType customerType = CustomerType.Applicant) => Applicants.FirstOrDefault(f => f.Type == customerType&&f.SubjectCustomerType==SubjectCustomerType.Physical);
        /// <summary>
        /// Получить Юр лицо
        /// </summary>
        /// <returns></returns>
        public ApplicantAdditionalDto? GetLegal() => Applicants.FirstOrDefault(f => f.SubjectCustomerType == SubjectCustomerType.Legal);
        /// <summary>
        /// Получить дополнительные данные
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T? GetAdditionalData<T>() => JsonSerializer.Deserialize<T>(AdditionalData);
    }

    public abstract class SmevCreateAbstract
    {
        public Guid ServiceId { get; set; }
        public int SmevId { get; set; }
    }
}
