using AisLogistics.App.Models.DTO.ReestrSentMessage;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Service
{
    public interface IReestrSentMessage
    {
        Task<(List<ReestrSentMessageDto>, int, int)> GetReestrSentMessageDocuments(IDataTablesRequest request);
    }
}
