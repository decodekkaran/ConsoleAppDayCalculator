using System;

class DayCalculator
{
    public class Date
    {
        public int d, m, y;
        public Date(int d, int m, int y)
        {
            this.d = d;
            this.m = m;
            this.y = y;
        }
    };

    // To store number of days in months from Jan to Dec.
    static int[] monthDays = { 31, 28, 31,
							30, 31, 30,
							31, 31, 30,
							31, 30, 31 };

	// for counts number of leap years before the given date
	static int countLeapYears(Date d)
	{
		int years = d.y;

		if (d.m <= 2)
		{
			years--;
		}

		return years / 4
			- years / 100
			+ years / 400;
	}

	// number of days between two given dates
	static int getDifference(Date startdt, Date enddt)
	{
		int n1 = startdt.y * 365 + startdt.d;

		for (int i = 0; i < startdt.m - 1; i++)
		{
			n1 += monthDays[i];
		}

		// Since every leap year is of 366 days Add a day for every leap year
		n1 += countLeapYears(startdt);

		int n2 = enddt.y * 365 + enddt.d;
		for (int i = 0; i < enddt.m - 1; i++)
		{
			n2 += monthDays[i];
		}
		n2 += countLeapYears(enddt);

		return (n2 - n1);
	}

	public static void Main(String[] args)
	{
		Console.Write("Enter Start Date:(mm/DD/YYYY): ");
		DateTime startDate = DateTime.Parse(Console.ReadLine());
		Console.Write("Enter End Date:(mm/DD/YYYY): ");
		DateTime endDate = DateTime.Parse(Console.ReadLine());

        int startmm = startDate.Month;
        int startdd = startDate.Day;
        int startyy = startDate.Year;
        int endmm = endDate.Month;
        int enddd = endDate.Day;
        int endyy = endDate.Year;

        Date startdt = new Date(startdd, startmm, startyy);
        Date enddt = new Date(enddd, endmm, endyy);

		Console.WriteLine("Number of day in between {0} and {1} is:: {2}", startDate, endDate, +getDifference(startdt, enddt));
	}
}
