namespace AisLogistics.API.Models.Responce.References
{
    public class MfcShedulesInfoResponse
    {
        public Guid Id { get; set; }
        public int DayType { get; set; }
        public string DayTypeName => GetDisplayTypeName();
        public int DaysWeekId { get; set; }
        public string DaysWeekName { get; set; }
        public string DaysWeekSmall { get; set; }
        public string? WorkStart { get; set; }
        public string? WorkStop { get; set; }
        public string? DinnerStart { get; set; }
        public string? DinnerStop { get; set; }

        private string GetDisplayTypeName()
        {
            return DayType switch
            {
                1 => "Рабочий",
                2 => "Выходной",
                3 => "Неприемный",
                _ => string.Empty,
            };
        }
    }
}
