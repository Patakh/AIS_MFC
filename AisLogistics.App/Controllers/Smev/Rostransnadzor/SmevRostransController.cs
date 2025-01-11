using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev
{
    public class SmevRostransnadzorController : SmevBaseController
    {
        public SmevRostransnadzorController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Сведения из реестра лицензий по перевозкам пассажиров автомобильным транспортом, оборудованным для перевозок более 8 человек
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">3301</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRostransPassengersVehicles(Guid serviceId, int smevId, RostransPassengersVehiclesRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = _smevService.RostransPassengersVehiclesRequestData(request);
            return SmevResponse(response);
        }
    }
}