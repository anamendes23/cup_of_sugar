namespace CupOfSugar.WebSite.Models
{
    /// <summary>
    /// Enum for product unit
    /// </summary>
    public enum UnitTypeEnum
    {
        Unit = 0,
        Ounce = 1,
        Pound = 2,
        Cup = 3,
        Bag = 4,
        Box = 5,
        Slice = 6,
        Loaf = 7,
        Bottle = 8,
        Can = 9
    }

    /// <summary>
    /// Class representing enum for product unit
    /// </summary>
    public static class UnitTypeEnumExtensions
    {
        /// <summary>
        /// String to display for enum value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DisplayName(this UnitTypeEnum data)
        {
            return data switch
            {
                UnitTypeEnum.Unit   => "unit(s)",
                UnitTypeEnum.Ounce  => "oz(s)",
                UnitTypeEnum.Pound  => "lb(s)",
                UnitTypeEnum.Cup    => "cup(s)",
                UnitTypeEnum.Bag    => "bag(s)",
                UnitTypeEnum.Box    => "box(es)",
                UnitTypeEnum.Slice  => "slice(s)",
                UnitTypeEnum.Loaf   => "loaf/loaves",
                UnitTypeEnum.Bottle => "bottle(s)",
                UnitTypeEnum.Can    => "can(s)",
                _ => $"Unknown unit {data}"
            };
        }
    }
}