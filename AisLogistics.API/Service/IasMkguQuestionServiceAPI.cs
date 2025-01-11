using AisLogistics.API.Models.Request;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Models.Responce.MKGU;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.API.Service
{
    public class IasMkguQuestionServiceAPI : IIasMkguQuestionServiceAPI
    {
        private readonly AisLogisticsContext _context;

        public IasMkguQuestionServiceAPI(AisLogisticsContext context)
        {
            _context = context;
        }
        public async Task<List<IasMkguQuestionResponse>?> GetAllIasMkguQuestionAsync()
        {
            try
            {
                return await _context.SIasMkguQuestions.Select(s => new IasMkguQuestionResponse
                {
                    Id = s.Id,
                    Question = s.Question,
                    Answer = s.SIasMkguQuestionAnswers.Select(s => new IasMkguAnswer
                    {
                        Id = s.Id,
                        Answer = s.Answer,
                        AnswerRating = s.AnswerRating
                    }).ToList()
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SaveIasMkguQuestionResponse> SaveIasMkguInformatAnswerAsync(SaveIasMkguQuestionRequest request)
        {
            try
            {
                var answerList = new List<DIasMkguInfomatAnswer>();
                request.Answer.ForEach(f => {
                    answerList.Add(new DIasMkguInfomatAnswer
                    {
                        DCasesId = request.DCasesId,
                        SIasMkguQuestionId = f.QuestionId,
                        SIasMkguQuestionAnswerId = f.AnswerId,
                        DateAnswer = DateTime.Now,
                    });
                });
                if (answerList.Count > 0 )
                {
                    await _context.AddRangeAsync( answerList );
                }
                if(!string.IsNullOrEmpty(request.Comment))
                {
                    await _context.AddAsync(new DIasMkguInfomatAnswerCommentt
                    {
                        DCasesId = request.DCasesId,
                        CommenttAnswer = request.Comment,
                    });
                }

                await _context.SaveChangesAsync();
                return new SaveIasMkguQuestionResponse { Success = true };
            }
            catch (Exception ex)
            {
                return new SaveIasMkguQuestionResponse { Success = true };
            }
        }
    }
}
