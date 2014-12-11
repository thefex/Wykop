namespace Wykop.ApiProvider.Data.Types
{
    public class SortType
    {
        private SortType(string sortTextValue)
        {
            TextValue = sortTextValue;
        }

        public string TextValue { get; private set; }

        public static SortType CreateSortByDay()
        {
            return new SortType("day");
        }

        public static SortType CreateSortByWeek()
        {
            return new SortType("week");
        }

        public static SortType CreateSortByMonth()
        {
            return new SortType("month");
        }
    }
}
