namespace Library.Common
{
    public static class EntityConstraints
    {
        // Book Constraints
        public const int BookTitleMaxLength = 50; 
        public const int BookTitleMinLength = 10;

        public const int AuthorNameMaxLength = 50;
        public const int AuthorNameMinLength = 5;

        public const int DescriptionMaxLength = 5000;
        public const int DescriptionMinLength = 5;

        public const double RatingMaxRate = 10.00;
        public const double RatingMinRate = 0.00;

        // Category Constraints
        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 5;
    }
}
