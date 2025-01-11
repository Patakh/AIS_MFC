using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AisLogistics.App.Service
{
    // Справочники - Информация

    /// <summary>
    /// Получить список "Информация"
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        public async Task<(List<InformationDto>, int, int)> GetInformations(IDataTablesRequest request)
        {
            var results = _context.DInformations
                .AsNoTracking()
                .Where(x => !x.IsRemove)
                .OrderByDescending(x => x.DateStart);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new InformationDto()
                {
                    Id = x.Id,
                    DateStart = x.DateStart.ToString("dd.MM.yyyy"),
                    DateStop = x.DateStop == null ? null : x.DateStop.Value.ToString("dd.MM.yyyy"),
                    InformationTopic = x.InformationTopic,
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    DateAdd = x.DateAdd.ToString("dd.MM.yyyy")
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Типы информации
        /// </summary>
        public async Task<Dictionary<string, string>> GetInformationTypesAsync()
        {
            return await _context.SInformationTypes
                .ToDictionaryAsync(x => x.Id.ToString(), x => x.TypeName);
        }

        /// <summary>
        /// Модель для редактирования информации
        /// </summary>
        public async Task<InformationModelDto> GetInformationDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.DInformations.FindAsync(Id);
            if (result == null)
                throw new InvalidOperationException("Данные не найдены!");

            var data = _mapper.Map<InformationModelDto>(result);

            data.Offices = await GetInformationOfficesAsyncV2(Id);

            return data ;
        }

        /// <summary>
        /// Добавить информацию
        /// </summary>
        public async Task AddInformationAsync(InformationModelDto model)
        {
            Guid newId = Guid.NewGuid();

            var entity = _mapper.Map<DInformation>(model);

            try
            {
                entity.Id = newId;

                var offices = await _filterManager.GetOfficesIdForReceptionCustomer(model.Offices, true, false);

                // выбрать всех активных сотрудников
                var activeEmployees = await GetReferencesActiveEmployees(offices.OfficesId);

                List<DInformationRecipient> recipients = new();
                // добавить записи в d_information_recipient
                foreach (var employee in activeEmployees)
                {
                    recipients.Add(new DInformationRecipient()
                    {
                        DInformationId = newId,
                        EmployeesFioAdd = model.EmployeesFioAdd,
                        SEmployeesId = employee.SEmployeesId,
                        EmployeesFio = employee.EmployeeName,
                        OfficeName = employee.EmployeeOfficeInfo.OfficeName,
                        JobPositionName = employee.EmployeeOfficeInfo.JobPositionName,
                    });
                }

                if (!recipients.Any())
                    throw new InvalidOperationException("В выбраных офисах нет сотрудников!");

                //await _context.DInformationRecipients.AddRangeAsync(recipients);

                entity.DInformationRecipients = recipients;

                List<DInformationFile> informationFiles = new();
                if (model.AddedFiles is not null and { Count: > 0 })
                {
                    // добавить в d_information_file
                    foreach (var file in model.AddedFiles)
                    {
                        var newInfoFile = new DInformationFile()
                        {
                            DInformationId = newId,
                            EmployeesFioAdd = model.EmployeesFioAdd,
                            FileName = Path.GetFileNameWithoutExtension(file.FileName),
                            FileSize = (int)file.Length,
                            FileExtention = Path.GetExtension(file.FileName)
                        };

                        using (var ms = new MemoryStream())
                        {
                            await file.CopyToAsync(ms);
                            newInfoFile.File = ms.ToArray();
                        }

                        informationFiles.Add(newInfoFile);
                    }
                }

                //await _context.DInformationFiles.AddRangeAsync(informationFiles);
                entity.DInformationFiles = informationFiles;

                await _context.DInformations.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (newId != Guid.Empty)
                {
                    // удалить навсегда, если добавлена новая запись и произошла ошибка
                    _context.DInformations.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                throw new InvalidOperationException(ex.Message);
            }

        }

        /// <summary>
        /// Обновить информацию
        /// </summary>
        public async Task UpdateInformationAsync(InformationModelDto model)
        {
            var entity = await _context.DInformations.FindAsync(model.Id);
            if (entity == null)
                throw new InvalidOperationException("Данные не найдены!");

            var offices = await _filterManager.GetOfficesIdForReceptionCustomer(model.Offices, true,false);

            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // удалить предыдущих добавленных активных пользователей офисов,
                    // т.к. список офисов может измениться

                    _context.Database.ExecuteSqlRaw($"DELETE FROM core.d_information_recipient WHERE d_information_id='{model.Id}'");
                    //await _context.SaveChangesAsync();


                    _mapper.Map<InformationModelDto, DInformation>(model, entity);

                    // выбрать всех активных сотрудников
                    var activeEmployees = await GetReferencesActiveEmployees(offices.OfficesId);

                    List<DInformationRecipient> recipients = new();
                    // добавить записи в d_information_recipient
                    foreach (var employee in activeEmployees)
                    {
                        recipients.Add(new DInformationRecipient()
                        {
                            DInformationId = entity.Id,
                            EmployeesFioAdd = model.EmployeesFioAdd,
                            SEmployeesId = employee.SEmployeesId,
                            EmployeesFio = employee.EmployeeName,
                            OfficeName = employee.EmployeeOfficeInfo.OfficeName,
                            JobPositionName = employee.EmployeeOfficeInfo.JobPositionName,
                        });
                    }

                    if (!recipients.Any())
                        throw new InvalidOperationException("В выбраных офисах нет сотрудников!");

                    entity.DInformationRecipients = recipients;

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException(ex.Message);
                }
            }



        }

        /// <summary>
        /// Пометить на удаление информацию
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveInfornmationAsync(Guid Id, string comment)
        {
            var entity = await _context.DInformations.FindAsync(Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Скачать информационный файл
        /// </summary>
        /// <param name="Id">Id записи</param>
        public async Task<FormFile> DownloadInformationFileAsync(Guid Id)
        {
            var entity = await _context.DInformationFiles.FindAsync(Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");

            var file = new FormFile(new MemoryStream(entity.File), 0, entity.FileSize,
                $"{entity.FileName}{entity.FileExtention}",
                $"{entity.FileName}{entity.FileExtention}")
            {
                Headers = new HeaderDictionary(),
                ContentType = MimeTypes.GetMimeType($"{entity.FileName}{entity.FileExtention}")
            };

            //TODO если не картинка подгружать соотв thumb

            return file;
        }

        /// <summary>
        /// Скачать превью информационного файла
        /// </summary>
        /// <param name="Id">Id записи</param>
        public async Task<FormFile> DownloadInformationFileThumbnailAsync(Guid Id)
        {
            var entity = await _context.DInformationFiles.FindAsync(Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");

            //размер должен быть 120x120
            //int height = 120;

            string outputFileName = $"{entity.FileName}{entity.FileExtention}";
            string wwwrootImagesPath = Path.Combine(_environment.WebRootPath, "assets\\img\\icons\\misc");
            string thumbFileName = Path.Combine(wwwrootImagesPath, "nothumb.png");

            switch (entity.FileExtention.ToLower())
            {
                case ".pdf":
                    thumbFileName = Path.Combine(wwwrootImagesPath, "pdf.png");
                    break;
                case ".txt":
                    thumbFileName = Path.Combine(wwwrootImagesPath, "txt.png");
                    break;
                case ".ppt":
                    thumbFileName = Path.Combine(wwwrootImagesPath, "ppt.png");
                    break;
                case ".psd":
                    thumbFileName = Path.Combine(wwwrootImagesPath, "psd.png");
                    break;
                case ".zip":
                    thumbFileName = Path.Combine(wwwrootImagesPath, "zip.png");
                    break;
                case ".doc":
                case ".docx":
                    thumbFileName = Path.Combine(wwwrootImagesPath, "doc.png");
                    break;
                case ".xls":
                case ".xlsx":
                    thumbFileName = Path.Combine(wwwrootImagesPath, "xls.png");
                    break;
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                    return
                        new FormFile(new MemoryStream(entity.File), 0, entity.FileSize, outputFileName, outputFileName)
                        {
                            Headers = new HeaderDictionary(),
                            ContentType = MimeTypes.GetMimeType(outputFileName)
                        };
            }

            var fileThumb = new FileStream(thumbFileName, FileMode.Open, FileAccess.Read);
            return new FormFile(fileThumb, 0, fileThumb.Length, outputFileName, outputFileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png"
            };
        }

        /// <summary>
        /// Добавить файлы к информации
        /// </summary>
        public async Task<InformationFileResponseModel> UploadInformationFilesAsync(UploadInformationFilesModel model)
        {
            var response = new InformationFileResponseModel();//.SetFileId(Guid.NewGuid());

            var entity = await _context.DInformations.FindAsync(model.Id);
            if (entity == null)
            {
                return response.Error("Запись не найдена!").Build();
            }
            //throw new InvalidOperationException("Запись не найдена!");

            List<DInformationFile> informationFiles = new();
            if (model.AddedFiles != null && model.AddedFiles.Any())
            {
                // добавить в d_information_file
                foreach (var file in model.AddedFiles)
                {
                    var newInfoFile = new DInformationFile()
                    {
                        DInformationId = model.Id,
                        EmployeesFioAdd = model.EmployeesFioAdd,
                        FileName = Path.GetFileNameWithoutExtension(file.FileName),
                        FileSize = (int)file.Length,
                        FileExtention = Path.GetExtension(file.FileName)
                    };

                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        newInfoFile.File = ms.ToArray();
                    }

                    informationFiles.Add(newInfoFile);
                }
            }

            entity.DInformationFiles = informationFiles;

            await _context.SaveChangesAsync();

            response.SetFileIds(informationFiles.Select(x => x.Id).ToList());
            return response.Success().Build();
        }

        /// <summary>
        /// Получить файлы информации
        /// </summary>
        /// <param name="InformationId">Id информации</param>
        public async Task<List<InformationFileDto>> GetInformationFilesAsync(Guid InformationId)
        {
            return await _context.DInformationFiles
                .AsNoTracking()
                .Where(x => x.DInformationId == InformationId)
                .Select(x => new InformationFileDto()
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    FileSize = x.FileSize,
                    DInformationId = InformationId,
                    FileExtention = x.FileExtention,
                }).ToListAsync();
        }

        /// <summary>
        /// Удалить информационный файл
        /// </summary>
        /// <param name="Id">Id файла(записи)</param>
        public async Task RemoveInformationFileAsync(Guid Id)
        {
            var entity = await _context.DInformationFiles.FindAsync(Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");

            _context.DInformationFiles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получить офисы, связанные с информацией
        /// </summary>
        /// <param name="InformationId">Id информации</param>
        public async Task<List<Guid>> GetInformationOfficesAsync(Guid? InformationId)
        {
            var employees = _context.DInformationRecipients
                .AsNoTracking()
                .Where(x => x.DInformationId == InformationId)
                .Select(x => x.SEmployeesId);
            //.ToListAsync();

            return (await _context.SEmployeesOfficesJoins
                .AsNoTracking()
                .Where(x => employees.Contains(x.SEmployeesId) && !x.IsRemove)
                .ToListAsync())
                .DistinctBy(x => x.SOfficesId)
                .Select(x => x.SOfficesId)
                .ToList();
        }

        public async Task<List<string>> GetInformationOfficesAsyncV2(Guid? InformationId)
        {
            var date = DateTime.Today;
            var offices = await _context.SEmployeesOfficesJoins.
                AsNoTracking()
                .Where(w => !w.IsRemove && w.DateStart.Date <= date.Date &&
                          (w.DateStop == null || w.DateStop >= date.Date) &&
                           w.SEmployees.DInformationRecipients.Any(a => a.DInformationId == InformationId))
                .Select(s => s.SOfficesId.ToString())
                .Distinct()
                .ToListAsync();

            return offices;
        }

    }
}
