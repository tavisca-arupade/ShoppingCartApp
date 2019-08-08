namespace ShppingCartv2
{
    public class DiscountFactory
    {
        

        public IDiscount GetDiscount(Category category)
        {
            if (category == Category.Clothing)
                return new ClothingDiscount();
            else if (category == Category.Education)
                return new EducationDiscount();
            return new FootwearDiscount();
        }
    }
}