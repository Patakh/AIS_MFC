using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AisLogistics.App.ViewModels.ModelBuilder
{
    public class AbstractViewModelBuilder
    {
        public string? ViewTitle { get; internal set; }
        public string? ViewDescription { get; internal set; }
        public string TableName { get; internal set; } = "mainDataTable";
        public string? TableMethodAction { get; internal set; }
        public string? EditMethodAction { get; internal set; }
        public string? RemoveMethodAction { get; internal set; }
        public object? Model { get; set; }

        public bool IsVisibleTitle { get; internal set; } 
        public bool IsVisibleDescription { get; internal set; }
    }
}
