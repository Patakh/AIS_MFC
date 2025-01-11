namespace AisLogistics.App.Service
{
    public partial class ReferencesService : IReferencesService
    {
        public async Task<byte[]?> SystemFiles(int type)
        {
            var content = await _context.SForms.FindAsync(type);
            return content?.File;
        }

        //public async Task<List<DataBaseDictonaryDto>> DataBaseDictonary(DataBaseDictonaryType type)
        //{
        //   return await _context.SListValues.Where(w => w.SListId == (int)type)
        //        .Select(s=>new DataBaseDictonaryDto {Key = s.Id, Value = s.ListValue }).ToListAsync();
        //}
    }
}
