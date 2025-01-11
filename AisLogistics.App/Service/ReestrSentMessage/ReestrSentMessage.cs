using AisLogistics.App.Models.DTO.ReestrSentMessage;
using AisLogistics.DataLayer.Concrete;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    public class ReestrSentMessage : IReestrSentMessage
    {
        private readonly AisLogisticsContext _context;
        public ReestrSentMessage(AisLogisticsContext context)
        {
            _context = context;
        }
        public async Task<(List<ReestrSentMessageDto>, int, int)> GetReestrSentMessageDocuments(IDataTablesRequest request)
        {
            try
            {
                var allDataCount = await _context.DServicesCustomersMessages.CountAsync() + await _context.AServicesCustomersMessages.CountAsync();

                var dataPage = new List<ReestrSentMessageDto>();
                var filterCount = 0;

                var allData = _context.DServicesCustomersMessages.Select(s => new ReestrSentMessageDto
                {
                    Id = s.Id,
                    EnqueueDateSort = s.EnqueueDate,
                    SetDate = s.DateAdd.ToString("dd.MM.yyyy hh:mm:ss"),
                    EnqueueDate = s.EnqueueDate.HasValue ? s.EnqueueDate.Value.ToString("dd.MM.yyyy hh:mm:ss") : string.Empty,
                    CasesId = s.DCasesId,
                    CustomerName = s.CustomerName,
                    SmsText = s.TextMessage,
                    PhoneNumber = s.CustomerPhone,
                    SendStatus = s.Status,
                    SmsId = s.SmsId
                }
                ).AsEnumerable()
                .Concat(_context.AServicesCustomersMessages.Select(s => new ReestrSentMessageDto
                {
                    Id = s.Id,
                    EnqueueDateSort = s.EnqueueDate,
                    SetDate = s.DateAdd.ToString("dd.MM.yyyy hh:mm:ss"),
                    EnqueueDate = s.EnqueueDate.HasValue ? s.EnqueueDate.Value.ToString("dd.MM.yyyy hh:mm:ss") : string.Empty,
                    CasesId = s.ACasesId,
                    CustomerName = s.CustomerName,
                    SmsText = s.TextMessage,
                    PhoneNumber = s.CustomerPhone,
                    SendStatus = s.Status,
                    SmsId = s.SmsId
                }
                ))
                .OrderByDescending(o => o.EnqueueDateSort);


                if (String.IsNullOrWhiteSpace(request.Search.Value))
                {
                    filterCount = allData.Count();
                    dataPage = allData.Skip(request.Start).Take(request.Length).ToList();
                }
                else
                {
                    var filterSearch = allData.Search(s => s.CasesId.ToLower(), s => s.CustomerName.ToLower()).ContainingAll(request.Search.Value.ToLower().Split(""));
                    filterCount = filterSearch.Count();
                    dataPage = filterSearch.Skip(request.Start).Take(request.Length).ToList();
                }

                return (dataPage, allDataCount, filterCount);
            }
            catch
            {
                return (new List<ReestrSentMessageDto>(), 0, 0);
            }
        }
    }
}
