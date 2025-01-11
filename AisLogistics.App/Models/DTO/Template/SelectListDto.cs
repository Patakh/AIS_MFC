namespace AisLogistics.App.Models.DTO.Template
{
    public class SelectListDto<T>
    {
        public T Id { get; }
        public string Name { get; }
        public SelectListDto(T id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
