using AisLogistics.API.Models.Request;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Models.Responce.MKGU;

namespace AisLogistics.API.Service
{
    public interface IIasMkguQuestionServiceAPI
    {
        Task<List<IasMkguQuestionResponse>?> GetAllIasMkguQuestionAsync();
        Task<SaveIasMkguQuestionResponse>SaveIasMkguInformatAnswerAsync(SaveIasMkguQuestionRequest request);
    }
}
