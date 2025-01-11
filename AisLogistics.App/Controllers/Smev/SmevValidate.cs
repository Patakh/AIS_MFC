using SmevRouter;

namespace AisLogistics.App.Controllers.Smev
{
    public static class SmevValidate
    {
        public static void Validate(this PfrPostAddress address)
        {
            address.Region = Validate(address.Region);
            address.Area = Validate(address.Area);
            address.City = Validate(address.City);
            address.Settlement = Validate(address.Settlement);
            address.Street = Validate(address.Street);
            address.House = Validate(address.House);
            address.Building = Validate(address.Building);
            address.Housing = Validate(address.Housing);
            address.Flat = Validate(address.Flat);
        }

        private static PfrGeographyAddressPart? Validate(PfrGeographyAddressPart el)
        {
            return string.IsNullOrWhiteSpace(el.Name)
                ? null
                : el;
        }

        private static PfrNumericAddressPart? Validate(PfrNumericAddressPart el)
        {
            return string.IsNullOrWhiteSpace(el.Number)
                ? null
                : el;
        }

        public static void Validate(this SocialProtectMfcAddress adr)
        {
            if (adr.Area?.Value is null) adr.Area = null;
            if (adr.City?.Value is null) adr.City = null;
            if (adr.CityArea?.Value is null) adr.CityArea = null;
            if (adr.Place?.Value is null) adr.Place = null;
            if (adr.Street?.Value is null) adr.Street = null;
            if (adr.House?.Value is null) adr.House = null;            
        }
    }
}
