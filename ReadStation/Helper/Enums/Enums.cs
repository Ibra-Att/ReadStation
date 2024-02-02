namespace ReadStation.Helper.Enums
{
    public static class Enums
    {
        public enum Gender 
        {
            None = 1000,
            Male = 0,
            Female,
            
        }
        
       
        public enum DepartmentName 
        {
            None = 1000,
            Marketing = 0,
            Sales,
            Accounting,
            CustomerService,
            

        }
        public enum DepartmentNameAr
        {
            None = 1000,
            التسويق = 0,
            المبيعات,
            المحاسبة,
            خدمة_العملاء,
            
        }

        public enum ContentType 
        {
            None = 1000,
            Book = 0,
            AudioBook,
            Magazine,
            Manga,
            
        }
        public enum Category
        {
            Nonfiction = 1000,
            Documentary = 0,
            Scientific,
            Sport,
            Novel,
            Action,
            Comedy,
            Romance,
        }
        public enum Membership
        {
            None= 1000,
            Standard = 0,
            Premium,
            Ultimate,
            
        }

        public enum DurationInDays
        {
            None = 1000,
            Thirty = 30,
            NinetyOne = 91,
            OneEightyThree = 183,
            ThreeSixtyFive = 365,
            
        }

    }
}
