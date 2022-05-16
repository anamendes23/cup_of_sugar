namespace CupOfSugar.WebSite.Models
{
    /// <summary>
    /// Enum for product category
    /// </summary>
    public enum ProductTypeEnum
    {
        Fruit = 0,
        Vegetable = 1,
        Poultry = 2,
        Meat = 3,
        Dairy = 4,
        Entree = 5,
        Savory = 6,
        Dessert = 7,
        Drink = 8,
        Miscellaneous = 9
    }

    /// <summary>
    /// Class representing enum for product category
    /// used for grouping products together by category
    /// </summary>
    public static class ProductTypeEnumExtensions
    {
        /// <summary>
        /// String to display for enum value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                ProductTypeEnum.Fruit => "Fruit",
                ProductTypeEnum.Vegetable => "Vegetable",
                ProductTypeEnum.Poultry => "Poultry",
                ProductTypeEnum.Meat => "Meat",
                ProductTypeEnum.Dairy => "Dairy",
                ProductTypeEnum.Entree => "Entree",
                ProductTypeEnum.Savory => "Savory",
                ProductTypeEnum.Dessert => "Dessert",
                ProductTypeEnum.Drink => "Drink",
                ProductTypeEnum.Miscellaneous => "Miscellaneous",
                // Default, Unknown
                _ => "",
            };
        }
    }
}