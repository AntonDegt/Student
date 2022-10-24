

namespace ConsoleСSApp
{
    struct Date
    {
        public int Day { set; get; }
        public int Month { set; get; }
        public int Year { set; get; }

        public Date(int Day, int Month, int Year)
        {
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;

        }

        public override string ToString()
        {
            return (Day + "/" + Month + "/" + Year);
        }
        public int CompareTo(Date date)
        {
            if (Year > date.Year) return 1;
            else if (Year < date.Year) return -1;
            else if (Month > date.Month) return 1;
            else if (Month < date.Month) return -1;
            else if (Day > date.Day) return 1;
            else if (Day < date.Day) return -1;
            else return 0;
            
        }
    }
}
