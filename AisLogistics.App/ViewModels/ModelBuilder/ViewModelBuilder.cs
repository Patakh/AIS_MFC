using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AisLogistics.App.ViewModels.ModelBuilder
{
    public class ViewModelBuilder : AbstractViewModelBuilder
    {

        public ViewModelBuilder AddModel(object model)
        {
            Model = model;
            return this;
        }

        /// <summary>
        /// Путь к методу для получения данных
        /// </summary>
        /// <param name="tableMethodAction">Путь к методу</param>
        /// <returns></returns>
        public ViewModelBuilder AddTableMethodAction(string? tableMethodAction)
        {
            TableMethodAction = tableMethodAction;
            return this;
        }

        public ViewModelBuilder AddEditMethodAction(string? editMethodAction)
        {
            EditMethodAction = editMethodAction;
            return this;
        }

        public ViewModelBuilder AddRemoveMethodAction(string? removeMethodAction)
        {
            RemoveMethodAction = removeMethodAction;
            return this;
        }

        /// <summary>
        /// Добавить заголовок формы
        /// </summary>
        /// <param name="viewTitle">Заголовок</param>
        /// <returns></returns>
        public ViewModelBuilder AddViewTitle(string viewTitle)
        {
            ViewTitle = viewTitle;
            IsVisibleTitle = true;
            return this;
        }

        /// <summary>
        /// Добавить описание формы
        /// </summary>
        /// <param name="viewDescription">Описание</param>
        /// <returns></returns>
        public ViewModelBuilder AddViewDescription(string viewDescription)
        {
            ViewDescription = viewDescription;
            IsVisibleDescription = true;
            return this;
        }

        /// <summary>
        /// Изменить имя таблицы
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public ViewModelBuilder SetElementName(string elementName)
        {
            TableName = elementName;
            return this;
        }

        /// <summary>
        /// Скрыть заголовок формы
        /// </summary>
        /// <returns></returns>
        public ViewModelBuilder SetInvisibleViewTitle()
        {
            IsVisibleTitle = false;
            return this;
        }

        /// <summary>
        /// Скрыть описание формы
        /// </summary>
        /// <returns></returns>
        public ViewModelBuilder SetInvisibleViewDescription()
        {
            IsVisibleDescription = false;
            return this;
        }
    }
}
