namespace ProjectDTO
{
    public enum eDay { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }
    public class OpeningHoursDTO
    {
        public string StoreID { get; set; }
        public eDay Day { get; set; }
        public string OpeningHour { get; set; }
        public string ClosingHour { get; set; }
    }
}
