using AisLogistics.App.Models;

namespace AisLogistics.App.ViewModels.ModelBuilder
{
    public class AbstractModalViewModelBuilder
    {
        public string ModalTitle { get; set; }
        public ModalType ModalType { get; set; }
        public string ModalViewPath { get; set; }
        public string CloseButtonText { get; set; } = "Закрыть";
        public bool ShowModalHeader { get; set; } = true;
        public bool ShowModalFooter { get; set; } = true;
        public bool ShowSubmitButton { get; set; } = true;
        
        public ActionType ActionType { get; set; }
        public object Model { get; set; }

    }
}
