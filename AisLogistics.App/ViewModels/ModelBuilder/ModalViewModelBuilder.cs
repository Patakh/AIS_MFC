using AisLogistics.App.Models;

namespace AisLogistics.App.ViewModels.ModelBuilder
{
    public class ModalViewModelBuilder : AbstractModalViewModelBuilder
    {
        public ModalViewModelBuilder AddModel(object model)
        {
            Model = model;
            return this;
        }
        public ModalViewModelBuilder AddModalTitle(string modalTitle)
        {
            ModalTitle = modalTitle;
            return this;
        }
        public ModalViewModelBuilder AddModalViewPath(string modalViewPath)
        {
            ModalViewPath = modalViewPath;
            return this;
        }
        public ModalViewModelBuilder AddActionType(ActionType actionType)
        {
            ActionType = actionType;
            return this;
        }
        public ModalViewModelBuilder AddModalType(ModalType modalType)
        {
            ModalType = modalType;
            return this;
        }
        public ModalViewModelBuilder HideModalFooter()
        {
            ShowModalFooter = false;
            return this;
        }
        public ModalViewModelBuilder HideModalHeader()
        {
            ShowModalHeader = false;
            return this;
        }
        public ModalViewModelBuilder HideSubmitButton()
        {
            ShowSubmitButton = false;
            return this;
        }
    }
}
