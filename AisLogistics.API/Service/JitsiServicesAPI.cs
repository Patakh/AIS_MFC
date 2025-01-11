using AisLogistics.API.Models.Dto;
using AisLogistics.API.Models.Request.Jitsi;
using AisLogistics.API.Models.Response.Jitsi;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using FluentFTP;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.API.Service
{
    public class JitsiServicesAPI : IJitsiServicesAPI
    {
        private readonly AisLogisticsContext _context;
        private readonly IFtpService _ftpService;

        public JitsiServicesAPI(AisLogisticsContext context,IFtpService ftpService)
        {
            _context = context;
            _ftpService = ftpService;
        }

        public async Task<SearchCustomerDto?> GetSearchCustomer(SearchCustomerRequest request)
        {
            try
            {
                var first = await _context.DCustomers
                    .AsNoTracking()
                    .Where(w => w.CustomerPhone1 == request.InputMaskPhoneNumber() || w.CustomerPhone2 == request.InputMaskPhoneNumber())
                    .Select(s => new SearchCustomerDto
                    {
                        customer_fio = $"{s.LastName} {s.FirstName} {s.SecondName}",
                        document_birth_date = s.DocumentBirthDate,
                        customer_sex = s.CustomerGender.ToString(),
                        customer_address = s.CustomerAddress,
                        customer_email = s.CustomerEmail,
                        customer_snils = s.CustomerSnils
                    }).FirstOrDefaultAsync();

                if (first is not null) return first;

                var second = await _context.DServicesCustomers
                   .AsNoTracking()
                   .Where(w => w.CustomerPhone1 == request.InputMaskPhoneNumber() || w.CustomerPhone2 == request.InputMaskPhoneNumber())
                   .OrderByDescending(o => o.DateAdd)
                   .Select(s => new SearchCustomerDto
                   {
                       customer_fio = $"{s.LastName} {s.FirstName} {s.SecondName}",
                       document_birth_date = s.DocumentBirthDate,
                       customer_sex = s.CustomerGender.ToString(),
                       customer_address = s.CustomerAddress,
                       customer_email = s.CustomerEmail,
                       customer_snils = s.CustomerSnils
                   }).FirstOrDefaultAsync();

                if (second is not null) return second;

                var third = await _context.AServicesCustomers
                   .AsNoTracking()
                   .Where(w => w.CustomerPhone1 == request.InputMaskPhoneNumber() || w.CustomerPhone2 == request.InputMaskPhoneNumber())
                   .OrderByDescending(o => o.DateAdd)
                   .Select(s => new SearchCustomerDto
                   {
                       customer_fio = $"{s.LastName} {s.FirstName} {s.SecondName}",
                       document_birth_date = s.DocumentBirthDate,
                       customer_sex = s.CustomerGender.ToString(),
                       customer_address = s.CustomerAddress,
                       customer_email = s.CustomerEmail,
                       customer_snils = s.CustomerSnils
                   }).FirstOrDefaultAsync();

                if (third is not null) return third;

                throw new InvalidOperationException();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<SearchCustomerCaseDto>?> GetSearchCustomerCase(SearchCustomerCaseRequest request)
        {
            try
            {
                return await _context.DServices
                    .AsNoTracking()
                    .Where(w =>w.CustomerPhone1 == request.InputMaskPhoneNumber() || w.CustomerPhone2 == request.InputMaskPhoneNumber())
                    .Select(s => new SearchCustomerCaseDto
                    {
                        dataServiceId = s.Id,
                        caseNumber = s.DCasesId,
                        serviceName = s.SServicesProcedure.ProcedureName,
                        caseStatusId = s.SServicesStatusId,
                        caseDateAdd = s.DateAdd.ToShortDateString(),
                    })
                    .ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<SaveCallResponse> SaveCallAsync(SaveCallRequest request)
        {
            SaveCallResponse response = new();
            string subFolder = request.callType == Jitsi_call_type.outgoing_callback ? "Incoming" : "Outgoing_callback";
            try
            {
                if (request.callType == Jitsi_call_type.incoming && request.caseNumber == null) // входящий без номера дела
                {
                    var data = new DIncomingCall();
                    data.Id = Guid.NewGuid();
                    data.CustomerName = request.customerName;
                    data.CustomerPhone = request.customerPhone;
                    data.AudioFormat = request.audioFormat;
                    data.DateCall = request.dateCall != null ? DateTime.Parse(request.dateCall.ToString()) : DateTime.Now;
                    data.TimeTalk = !string.IsNullOrEmpty(request.callDuration) ? request.callDuration : "00:00:00";

                    if (request.idEmployee != null)
                    {
                        try { data.SEmployeesId = Guid.Parse(request.idEmployee); } catch { }
                    }
                    if (request.idMfc != null)
                    {
                        try
                        {
                            data.SOfficesId = Guid.Parse(request.idMfc);
                            if (!string.IsNullOrEmpty(request.idFtp))
                            {
                                data.SFtpId = Guid.Parse(request.idFtp);
                            }
                            var officeFtpId = await _context.SOffices.AsNoTracking().Where(w => w.Id == data.SOfficesId).Select(s => s.SFtpId).FirstAsync();
                            if (officeFtpId.HasValue) { data.SFtpId = officeFtpId.Value; }
                        }
                        catch { }
                    }


                    if(data.SFtpId.HasValue)
                    {
                        var ftp = await _context.SFtps.AsNoTracking().Where(w => w.Id == data.SFtpId).Select(s => new FtpSettingsDto
                        {
                            Id = s.Id,
                            Login = s.FtpLogin,
                            Password = s.FtpPassword,
                            Server = s.FtpServer
                        }).FirstOrDefaultAsync();

                        if (await _ftpService.UploadFileAsync((byte[])(Array)request.fileByte,$"{subFolder}/{data.Id}{Path.GetExtension(request.audioFormat)}", ftp) == FtpStatus.Success)
                        {
                            data.IsSavedFtp = true;
                            response.Flag = true;   
                        }
                    }

                    await _context.DIncomingCalls.AddAsync(data);
                    await _context.SaveChangesAsync();

                    response.Id = data.Id;
                    response.Success = true;

                    return response;
                }
                else if (request.callType == Jitsi_call_type.outgoing || (request.callType == Jitsi_call_type.incoming && request.caseNumber != null)) // исходящий или входящий с номером дела
                {
                    DServicesCustomersCall data = new DServicesCustomersCall();
                    data.Id = Guid.NewGuid();
                    Guid empId = Guid.Parse(request.idEmployee);

                    data.CustomerName = request.customerName ?? "Не определен";
                    data.CustomerPhone = request.customerPhone;
                    data.DCasesId = request.caseNumber;
                    data.AudioFormat = request.audioFormat;
                    data.TimeTalk = !string.IsNullOrEmpty(request.callDuration) ? request.callDuration : "00:00:00";
                    data.DateCall = request.dateCall != null ? DateTime.Parse(request.dateCall.ToString()) : DateTime.Now;

                    if (request.idEmployee != null)
                    {
                        try { data.SEmployeesId = Guid.Parse(request.idEmployee); } catch { }
                    }

                    if (request.idMfc != null)
                    {
                        try
                        {
                            data.SOfficesId = Guid.Parse(request.idMfc);
                            if (!string.IsNullOrEmpty(request.idFtp))
                            {
                                data.SFtpId = Guid.Parse(request.idFtp);
                            }
                            var officeFtpId = await _context.SOffices.AsNoTracking().Where(w => w.Id == data.SOfficesId).Select(s => s.SFtpId).FirstAsync();
                            if (officeFtpId.HasValue) { data.SFtpId = officeFtpId.Value; }
                        }
                        catch { }
                    }

                    if (data.SFtpId.HasValue)
                    {
                        var ftp = await _context.SFtps.AsNoTracking().Where(w => w.Id == data.SFtpId).Select(s => new FtpSettingsDto
                        {
                            Id = s.Id,
                            Login = s.FtpLogin,
                            Password = s.FtpPassword,
                            Server = s.FtpServer
                        }).FirstOrDefaultAsync();

                        if (await _ftpService.UploadFileAsync((byte[])(Array)request.fileByte, $"{data.DCasesId}/{data.Id}{Path.GetExtension(request.audioFormat)}", ftp) == FtpStatus.Success)
                        {
                            data.SaveFtp = true;
                            response.Flag = true;
                        }
                    }

                    await _context.DServicesCustomersCalls.AddAsync(data);
                    await _context.SaveChangesAsync();

                    response.Id = data.Id;
                    response.Success = true;

                    return response;
                }
                throw new InvalidOperationException();
            }
            catch(Exception ex)
            {
                return response;
            }
        }
    }
}
