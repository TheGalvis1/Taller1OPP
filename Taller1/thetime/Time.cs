namespace thetime
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
            Millisecond = 0;
        }

        public Time(int hour)
        {
            Hour = hour;
            Minute = 0;
            Second = 0;
            Millisecond = 0;

        }

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
            Second = 0;
            Millisecond = 0;
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = 0;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        public int Hour
        {
            get => _hour;
            set => _hour = ValidateHour(value);
        }

        public int Minute
        {
            get => _minute;
            set => _minute = ValidateMinute(value);
        }

        public int Second
        {
            get => _second;
            set => _second = ValidateSecond(value);
        }

        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidateMillisecond(value);
        }

        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour}, is not valid");
            }
            return hour;
        }

        private int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
                throw new ArgumentException($"The minute: {minute}, is not valid.");
            return minute;
        }

        private int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
                throw new ArgumentException($"The second: {second}, is not valid.");
            return second;
        }

        private int ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
                throw new ArgumentException($"The millisecond: {millisecond}, is not valid.");
            return millisecond;
        }

        public override string ToString()
        {
            int hour12 = Hour % 12;

            if (hour12 == 0)
                hour12 = 12;

            string period = Hour < 12 ? "AM" : "PM";

            return $"{hour12:D2}:{Minute:D2}:{Second:D2}.{Millisecond:D3} {period}";

        }

        public int ToMilliseconds()
        {
            return Hour * 3600000 + Minute * 60000 + Second * 1000 + Millisecond;
        }

        public long ToSeconds()
        {
            return Hour * 3600 + Minute * 60 + Second;
        }

        public long ToMinutes()
        {
            return Hour * 60 + Minute;
        }

        public bool IsOtherDay(Time other)
        {

            int totalMs = (int)(ToMilliseconds() + other.ToMilliseconds());


            if (totalMs >= 86400000)
            {
                return true;
            }

            return false;
        }

        public Time Add(Time other)
        {
            int totalMs = (int)(ToMilliseconds() + other.ToMilliseconds());
            totalMs %= 86400000;


            int hr = (totalMs / 3600000);
            int mi = ((totalMs / 60000) % 60);
            int se = ((totalMs / 1000) % 60);
            int ms = (totalMs % 1000);

            return new Time(hr, mi, se, ms);
        }
    }
}