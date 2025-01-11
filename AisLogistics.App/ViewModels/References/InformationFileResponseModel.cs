using AisLogistics.App.ViewModels.ModelBuilder;

namespace AisLogistics.App.ViewModels.References
{
    public class InformationFileResponseModel : AbstractResponseBuilder<InformationFileResponseModel>
    {
        public IEnumerable<Guid>? Ids { get; private set; }

        public InformationFileResponseModel SetFileIds(IEnumerable<Guid> ids)
        {
            Ids = ids;
            return this;
        }

        public override InformationFileResponseModel Build() => this;
    }
}
