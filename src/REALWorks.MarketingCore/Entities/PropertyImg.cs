using REALWorks.MarketingCore.Base;

namespace REALWorks.MarketingCore.Entities
{
    public class PropertyImg: Entity
    {
        private PropertyImg()
        {
        }

        public PropertyImg(string propertyImgTitle, string propertyImgUrl,
            int rentalPropertyId)//, RentalProperty rentalProperty)
        {
            PropertyImgTitle = propertyImgTitle;
            PropertyImgUrl = propertyImgUrl;
            RentalPropertyId = rentalPropertyId;
            //RentalProperty = rentalProperty;
        }

        public string PropertyImgTitle { get; private set; }
        public string PropertyImgUrl { get; private set; }
        public int RentalPropertyId { get; private set; }

        public RentalProperty RentalProperty { get; private set; }
    }
}