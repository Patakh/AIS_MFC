using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Identity.Applicant;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.DataLayer.Common.Dto.Case;
using AisLogistics.DataLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Packaging;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public partial class CaseService : ICaseService
    {
        public async Task<List<ApplicantAdditionalDto>> GetApplicantsByServiceId(Guid id)
        {
            try
            {
                var caseId = await _context.DServices.Where(w=>w.Id == id).Select(s=>s.DCasesId).FirstAsync();
                var applicants = await _context.DServicesCustomers.AsNoTracking().Where(f => f.DCasesId == caseId)
                    .Select(s => new ApplicantAdditionalDto()
                    {
                        Id = s.Id,
                        Name = s.Fio(),
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        SecondName = s.SecondName,
                        Gender = s.CustomerGender,
                        BirthDate = s.DocumentBirthDate,
                        Address = s.CustomerAddress,
                        BirthPlace = s.DocumentBirthPlace,
                        Phone = s.CustomerPhone1,
                        Email = s.CustomerEmail,
                        Snils = s.CustomerSnils,
                        Inn = s.CustomerInn,
                        Type = (CustomerType)s.CustomerType,
                        DocumentTypeCode = s.SDocumentsIdentityId.ToString(),
                        DocumentSerial = s.DocumentSerial,
                        DocumentNumber = s.DocumentNumber,
                        DocumentIssueDate = s.DocumentIssueDate,
                        DocumentIssueBody = s.DocumentIssueBody,
                        DocumentCode = s.DocumentCode,
                        SubjectCustomerType = SubjectCustomerType.Physical,
                        AddressDetails = s.CustomerAddressDetail!=null ? JsonConvert.DeserializeObject<AddressDetails>(s.CustomerAddressDetail) : new AddressDetails()
                    }).ToListAsync();

                var legal = await _context.DServicesCustomersLegals.AsNoTracking().Where(f => f.DCasesId == caseId)
                    .Select(s => new ApplicantAdditionalDto()
                    {
                        Id = s.Id,
                        Name = s.CustomerName,
                        FirstName = s.HeadFirstName,
                        LastName = s.HeadLastName,
                        SecondName = s.HeadSecondName,
                        Address = s.CustomerAddress,
                        Phone = s.CustomerPhone1,
                        Email = s.CustomerEmail,
                        Inn = s.CustomerInn,
                        Okato = s.CustomerOkato,
                        Ogrn = s.CustomerOgrn,
                        Kpp = s.CustomerKpp,
                        Oktmo = s.CustomerOktmo,
                        HeadPosition = s.HeadPosition,
                        AddressDetails = s.CustomerAddressDetail != null ? JsonConvert.DeserializeObject<AddressDetails>(s.CustomerAddressDetail) : new AddressDetails(),
                        SubjectCustomerType = SubjectCustomerType.Legal
                    }).FirstOrDefaultAsync();

                if (legal is not null) applicants.Add(legal);

                return applicants;
            }
            catch
            {
                return new List<ApplicantAdditionalDto>();
            }
        }

        //TODO переделать
        public async Task<CustomerModelDto?> GetCustomerByDocumentSerialAndNumberAsync(string serial, string number)
        {
            var find_first =  await _context.DCustomers
                .AsNoTracking()
                .OrderByDescending(o => o.DateAdd)
                .Select(s => new CustomerModelDto
                {
                    Id = s.Id,
                    SDocumentsIdentityId = s.SDocumentsIdentityId,
                    CustomerGender = s.CustomerGender,
                    DocumentNumber = s.DocumentNumber,
                    DocumentSerial = s.DocumentSerial,
                    DocumentBirthDate = s.DocumentBirthDate,
                    DocumentBirthPlace = s.DocumentBirthPlace,
                    DocumentIssueDate = s.DocumentIssueDate,
                    DocumentIssueBody = s.DocumentIssueBody,
                    DocumentCode = s.DocumentCode,
                    CustomerInn = s.CustomerInn,
                    CustomerPhone1 = s.CustomerPhone1,
                    CustomerPhone2 = s.CustomerPhone2,
                    CustomerEmail = s.CustomerEmail,
                    CustomerAddress = s.CustomerAddress,
                    CustomerOkato = s.CustomerOkato,
                    CustomerOktmo = s.CustomerOktmo,
                    CustomerCodeRegion = s.CustomerCodeRegion,
                    CustomerSnils = s.CustomerSnils,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    SecondName = s.SecondName,
                    CustomerAddressResidence = s.CustomerAddressResidence,
                    DateTempRegistration = s.DateTempRegistration,
                    CustomerAddressTemp = s.CustomerAddressTemp,
                    AddressDetails = s.CustomerAddressDetail!=null ? JsonConvert.DeserializeObject<AddressDetails>(s.CustomerAddressDetail) : null 
                })
                .FirstOrDefaultAsync(f => f.DocumentSerial == serial && f.DocumentNumber == number);

            if(find_first is not null) return find_first;

            var find_second = await _context.DServicesCustomers
            .AsNoTracking()
            .OrderByDescending(o => o.DateAdd)
            .Select(s => new CustomerModelDto
            {
                Id = s.Id,
                SDocumentsIdentityId = s.SDocumentsIdentityId,
                CustomerGender = s.CustomerGender,
                DocumentNumber = s.DocumentNumber,
                DocumentSerial = s.DocumentSerial,
                DocumentBirthDate = s.DocumentBirthDate,
                DocumentBirthPlace = s.DocumentBirthPlace,
                DocumentIssueDate = s.DocumentIssueDate,
                DocumentIssueBody = s.DocumentIssueBody,
                DocumentCode = s.DocumentCode,
                CustomerInn = s.CustomerInn,
                CustomerPhone1 = s.CustomerPhone1,
                CustomerPhone2 = s.CustomerPhone2,
                CustomerEmail = s.CustomerEmail,
                CustomerAddress = s.CustomerAddress,
                CustomerOkato = s.CustomerOkato,
                CustomerOktmo = s.CustomerOktmo,
                CustomerCodeRegion = s.CustomerCodeRegion,
                CustomerSnils = s.CustomerSnils,
                FirstName = s.FirstName,
                LastName = s.LastName,
                SecondName = s.SecondName,
                CustomerAddressResidence = s.CustomerAddressResidence,
                DateTempRegistration = s.DateTempRegistration,
                CustomerAddressTemp = s.CustomerAddressTemp,
                AddressDetails = s.CustomerAddressDetail != null ? JsonConvert.DeserializeObject<AddressDetails>(s.CustomerAddressDetail) : null
            })
            .FirstOrDefaultAsync(f => f.DocumentSerial == serial && f.DocumentNumber == number);

            if (find_second is not null) return find_second;

            var find_third = await _context.AServicesCustomers
            .AsNoTracking()
            .OrderByDescending(o => o.DateAdd)
            .Select(s => new CustomerModelDto
            {
                Id = s.Id,
                SDocumentsIdentityId = s.SDocumentsIdentityId,
                CustomerGender = s.CustomerGender,
                DocumentNumber = s.DocumentNumber,
                DocumentSerial = s.DocumentSerial,
                DocumentBirthDate = s.DocumentBirthDate,
                DocumentBirthPlace = s.DocumentBirthPlace,
                DocumentIssueDate = s.DocumentIssueDate,
                DocumentIssueBody = s.DocumentIssueBody,
                DocumentCode = s.DocumentCode,
                CustomerInn = s.CustomerInn,
                CustomerPhone1 = s.CustomerPhone1,
                CustomerPhone2 = s.CustomerPhone2,
                CustomerEmail = s.CustomerEmail,
                CustomerAddress = s.CustomerAddress,
                CustomerOkato = s.CustomerOkato,
                CustomerOktmo = s.CustomerOktmo,
                CustomerCodeRegion = s.CustomerCodeRegion,
                CustomerSnils = s.CustomerSnils,
                FirstName = s.FirstName,
                LastName = s.LastName,
                SecondName = s.SecondName,
                CustomerAddressResidence = s.CustomerAddressResidence,
                DateTempRegistration = s.DateTempRegistration,
                CustomerAddressTemp = s.CustomerAddressTemp,
                AddressDetails = s.CustomerAddressDetail != null ? JsonConvert.DeserializeObject<AddressDetails>(s.CustomerAddressDetail) : null
            })
            .FirstOrDefaultAsync(f => f.DocumentSerial == serial && f.DocumentNumber == number);

            if (find_third is not null) return find_third;

            return null;
        }

        //TODO переделать
        public async Task<LegalsDto?> GetLegalByInnAsync(string inn)
        {
            var find_first = await _context.DServicesCustomersLegals
                .AsNoTracking()
                .OrderByDescending(o => o.DateAdd)
                .Select(s => new LegalsDto
                {
                    Id = s.Id,
                    SServicesCustomerTypeId = s.SServicesCustomerTypeId,
                    CustomerInn = s.CustomerInn,
                    CustomerOkato = s.CustomerOkato,
                    CustomerOktmo = s.CustomerOktmo,
                    CustomerCodeRegion = s.CustomerCodeRegion,
                    CustomerKpp = s.CustomerKpp,
                    CustomerOgrn = s.CustomerOgrn,
                    CustomerAddress = s.CustomerAddress,
                    CustomerName = s.CustomerName,
                    CustomerAddressDetail = s.CustomerAddressDetail,
                    HeadPosition = s.HeadPosition,
                    CustomerPhone1 = s.CustomerPhone1,
                    CustomerPhone2 = s.CustomerPhone2,
                    CustomerEmail = s.CustomerEmail,
                    HeadFirstName = s.HeadFirstName,
                    HeadLastName = s.HeadLastName,
                    HeadSecondName = s.HeadSecondName
                })
                .FirstOrDefaultAsync(f => f.CustomerInn == inn);

            if (find_first is not null) return find_first;

            var find_second = await _context.AServicesCustomersLegals
            .AsNoTracking()
            .OrderByDescending(o => o.DateAdd)
            .Select(s => new LegalsDto
            {
                Id = s.Id,
                SServicesCustomerTypeId = s.SServicesCustomerTypeId,
                CustomerInn = s.CustomerInn,
                CustomerOkato = s.CustomerOkato,
                CustomerOktmo = s.CustomerOktmo,
                CustomerCodeRegion = s.CustomerCodeRegion,
                CustomerKpp = s.CustomerKpp,
                CustomerOgrn = s.CustomerOgrn,
                CustomerAddress = s.CustomerAddress,
                CustomerName = s.CustomerName,
                CustomerAddressDetail = s.CustomerAddressDetail,
                HeadPosition = s.HeadPosition,
                CustomerPhone1 = s.CustomerPhone1,
                CustomerPhone2 = s.CustomerPhone2,
                CustomerEmail = s.CustomerEmail,
                HeadFirstName = s.HeadFirstName,
                HeadLastName = s.HeadLastName,
                HeadSecondName = s.HeadSecondName
            })
            .FirstOrDefaultAsync(f => f.CustomerInn == inn);

            if (find_second is not null) return find_second;

            return null;

        }

        //TODO переделать
        public async Task<CustomerServiceModelDto?> GetCustomerByIdAsync(Guid id)
        {
            try
            {

                var model = await _context.DServicesCustomers.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
                if (model is null) throw new InvalidOperationException("Данные не найдены");

                var response = _mapper.Map<CustomerServiceModelDto>(model);
                response.AddressDetails = string.IsNullOrEmpty(model.CustomerAddressDetail) ? null : JsonConvert.DeserializeObject<AddressDetails>(model.CustomerAddressDetail);

                return response;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ApplicantDto>> GetCustomersByCaseNumberAsync(string caseId)
        {
            return await _context.DServicesCustomers.AsNoTracking().Where(w => w.DCasesId == caseId)
                .Select(s => new ApplicantDto
                {
                    Id = s.Id,
                    Name = s.Fio()
                }).ToListAsync();
        }

        //TODO переделать
        public async Task<DServicesCustomersLegal?> GetCustomerLegalByIdAsync(Guid id)
        {
            return await _context.DServicesCustomersLegals.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        //TODO переделать
        public async Task<CaseCustomerResponseModel> UpdateCustomerAsync(CustomerServiceModelDto request)
        {
            var response = new CaseCustomerResponseModel();
            try
            {
                var employee = await _employeeManager.GetFullInfoAsync();

                var updatedCustomer = await _context.DServicesCustomers.FindAsync(request.Id);
                if (updatedCustomer is null) return response.Error("Заявитель не найден.").Build();
                var dServices = await _context.DServices.FirstAsync(f => f.DCasesId == updatedCustomer.DCasesId && f.DServicesIdParent == Guid.Empty);

                updatedCustomer.FirstName = request.FirstName;
                updatedCustomer.LastName = request.LastName;
                updatedCustomer.SecondName = request.SecondName;
                updatedCustomer.CustomerAddress = request.CustomerAddress;
                updatedCustomer.CustomerAddressDetail = request.CustomerAddressDetail;
                updatedCustomer.CustomerAddressResidence = request.CustomerAddressResidence;
                updatedCustomer.CustomerAddressTemp = request.CustomerAddressTemp;
                updatedCustomer.CustomerCodeRegion = request.CustomerCodeRegion;
                updatedCustomer.CustomerEmail = request.CustomerEmail;
                updatedCustomer.CustomerPhone1 = request.CustomerPhone1;
                updatedCustomer.CustomerPhone2 = request.CustomerPhone2;
                updatedCustomer.CustomerGender = request.CustomerGender;
                updatedCustomer.CustomerInn = request.CustomerInn;
                updatedCustomer.CustomerSnils = request.CustomerSnils;
                updatedCustomer.DocumentIssueDate = request.DocumentIssueDate;
                updatedCustomer.DocumentBirthDate = request.DocumentBirthDate;
                updatedCustomer.DocumentBirthPlace = request.DocumentBirthPlace;
                updatedCustomer.DocumentCode = request.DocumentCode;
                updatedCustomer.DocumentIssueBody = request.DocumentIssueBody;
                updatedCustomer.DocumentNumber = request.DocumentNumber;
                updatedCustomer.DocumentSerial = request.DocumentSerial;
                updatedCustomer.SDocumentsIdentityId = request.SDocumentsIdentityId;
                updatedCustomer.NumberProcuration = request.NumberProcuration;
                updatedCustomer.IssueBodyProcuration = request.IssueBodyProcuration;
                updatedCustomer.NameProcuration = request.NameProcuration;
                updatedCustomer.IssueDateProcuration =  request.IssueDateProcuration;
                updatedCustomer.PeriodProcuration = request.PeriodProcuration;
                updatedCustomer.CustomerAddressDetail = JsonConvert.SerializeObject(request.AddressDetails);

                dServices.CustomerName = request.Fio();
                dServices.CustomerAddress = request.CustomerAddress;
                dServices.CustomerPhone1 = request.CustomerPhone1;
                dServices.CustomerPhone2 = request.CustomerPhone2;

                _context.UpdateWithAudit(updatedCustomer, employee);
                await _context.SaveChangesAsync();
                return response.Success().Build();
            }
            catch (Exception e)
            {
                return response.Error("").Build();
            }
        }

        //TODO переделать
        public async Task<CaseCustomerResponseModel> UpdateCustomerLegalAsync(DServicesCustomersLegal customer)
        {
            var response = new CaseCustomerResponseModel();
            try
            {
                var employee = await _employeeManager.GetFullInfoAsync();

                var updatedCustomer = await _context.DServicesCustomersLegals.FindAsync(customer.Id);
                if (updatedCustomer is null) return response.Error("Заявитель не найден.").Build();
                var dServices = await _context.DServices.FirstAsync(f => f.DCasesId == updatedCustomer.DCasesId && f.DServicesIdParent == Guid.Empty);

                updatedCustomer.HeadLastName = customer.HeadLastName;
                updatedCustomer.HeadFirstName = customer.HeadFirstName;
                updatedCustomer.HeadSecondName = customer.HeadSecondName;
                updatedCustomer.CustomerAddress = customer.CustomerAddress;
                updatedCustomer.CustomerAddressDetail = customer.CustomerAddressDetail;
                updatedCustomer.CustomerCodeRegion = customer.CustomerCodeRegion;
                updatedCustomer.CustomerEmail = customer.CustomerEmail;
                updatedCustomer.CustomerPhone1 = customer.CustomerPhone1;
                updatedCustomer.CustomerPhone2 = customer.CustomerPhone2;
                updatedCustomer.CustomerInn = customer.CustomerInn;
                updatedCustomer.CustomerOgrn = customer.CustomerOgrn;
                updatedCustomer.CustomerOkato = customer.CustomerOkato;
                updatedCustomer.CustomerOktmo = customer.CustomerOktmo;
                updatedCustomer.CustomerKpp = customer.CustomerKpp;
                updatedCustomer.HeadPosition = customer.HeadPosition;
                updatedCustomer.CustomerName = customer.CustomerName;

                dServices.CustomerName = customer.CustomerName;
                dServices.CustomerAddress = customer.CustomerAddress;
                dServices.CustomerPhone1 = customer.CustomerPhone1;
                dServices.CustomerPhone2 = customer.CustomerPhone2;

                _context.UpdateWithAudit(updatedCustomer, employee);
                await _context.SaveChangesAsync();
                return response.Success().Build();
            }
            catch (Exception e)
            {
                return response.Error("").Build();
            }
        }
    }
}
