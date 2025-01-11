using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.MER
{
    public class SmevMerController : SmevBaseController
    {
        private readonly AisLogisticsContext _context;
        private readonly IEmployeeManager _employeeManager;

        public SmevMerController(ICaseService caseService, ISmevService smevService, IEmployeeManager employeeManager, IGarService garService, IOptions<SmevSettings> smevOptions, AisLogisticsContext context)
            : base(caseService, smevService, garService, smevOptions)
        {
            _context = context;
            _employeeManager = employeeManager;
        }

        /// <summary>
        /// Получение даты голосования
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetVoteDate()
        {
            string voteDate = _context.SSettings.FirstOrDefault(i => i.ParamName == "smev3_mer_vote_date")?.ParamValue ?? string.Empty;
            return voteDate;
        }

        /// <summary>
        /// Получение списка регионов для голосования
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRegions()
        {
            var regions = _context.SSmevClassUiks.GroupBy(i => i.RegionCode)
                .Select(i => new { id = i.FirstOrDefault().RegionCode, text = i.FirstOrDefault().RegionName });
            return Json(regions);
        }

        /// <summary>
        /// Получение списка участков избирательной комиссии для голосования
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRegionUik(string regionCode)
        {
            var regions = _context.SSmevClassUiks.OrderBy(i => i.RegionName)
                .Where(i => i.RegionCode == regionCode)
                .Select(i => new { id = i.Id, text = i.Address });
            return Json(regions);
        }

        /// <summary>
        /// Приём заявлений о включении избирателя в список избирателей по месту нахождения и на дистанционное электронное голосование на выборах в Российской Федерации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">2005</param>
        /// <param name="request"></param>
        /// <param name="uikId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CikElectionOrderRequest(Guid serviceId, int smevId, int uikId, GetDetachVoteOrderQueryRequestData request)
        {
            SSmevClassUik uik = _context.SSmevClassUiks.First(u => u.Id == uikId);
            request.OrderDateTime = DateTime.Now;
            request.OrderVoteUik = new DetachVoteOrderVoteUik
            {
                CountryCode = uik.CountryCode,
                RegionCode = uik.RegionCode,
                AddressUik = uik.Address,
                UikNum = uik.UikNumber
            };

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.CikElectionOrderRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявлений о включении избирателя в список избирателей по месту нахождения и на дистанционное электронное голосование на выборах в Российской Федерации (цифровой избирательный участок)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">2006</param>
        /// <param name="request"></param>
        /// <param name="uikId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CikElectionOrderDigitalUikRequest(Guid serviceId, int smevId, int uikId, GetDetachVoteOrderDigitalUikQueryRequestData request)
        {
            SSmevClassUik uik = _context.SSmevClassUiks.First(u => u.Id == uikId);
            request.OrderDateTime = DateTime.Now;
            request.OrderVoteUik = new DetachVoteOrderVoteUik
            {
                CountryCode = uik.CountryCode,
                RegionCode = uik.RegionCode,
                AddressUik = uik.Address,
                UikNum = uik.UikNumber,
            };

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.CikElectionOrderDigitalUikRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявлений об удалении ранее поданных заявлений для голосования на выборах в Российской Федерации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">2007</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CikElectionOrderDeletionRequest(Guid serviceId, int smevId, int uikId, GetDetachVoteOrderDeletionQueryRequestData request)
        {
            var employee = _employeeManager.GetFullInfoAsync().Result;
            string fio = employee.Name;
            string position = employee.Job.Name;
            request.DelUser = $"{fio} {position}";
            
            SSmevClassUik uik = _context.SSmevClassUiks.First(u => u.Id == uikId);
            request.OrderDateTime = DateTime.Now;
            request.OrderVoteUik = new DetachVoteOrderVoteUik
            {
                CountryCode = uik.CountryCode,
                RegionCode = uik.RegionCode,
                AddressUik = uik.Address,
                UikNum = uik.UikNumber,
            };

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.CikElectionOrderDeletionRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Прием заявлений об аннулировании включения избирателя в список избирателей по месту нахождения на выборах в Российской Федерации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">2008</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestVoteOrderAnnul(Guid serviceId, int smevId, VoteOrderAnnulRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.VoteOrderAnnulRequest(request);
            return SmevResponse(response);
        }
    }
}