using System;
using System.Globalization;

namespace theplay
{
    public class Time
    {

        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;


        public int Hour => _hour;
        public int Minute => _minute;
        public int Second => _second;
        public int Millisecond => _millisecond;


        public Time() : this(0, 0, 0, 0) { }

        public Time(int hour) : this(hour, 0, 0, 0) { }

        public Time(int hour, int minute) : this(hour, minute, 0, 0) { }

        public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { }

        public Time(int hour, int minute, int second, int millisecond)
        {
            if (!ValidHour(hour))
                throw new Exception($"The hour {hour}, is not valid.");

            if (!ValidMinute(minute))
                throw new Exception($"The minute {minute}, is not valid.");

            if (!ValidSecond(second))
                throw new Exception($"The second {second}, is not valid.");

            if (!ValidMillisecond(millisecond))
                throw new Exception($"The millisecond {millisecond}, is not valid.");

            _hour = hour;
            _minute = minute;
            _second = second;
            _millisecond = millisecond;
        }


        private bool ValidHour(int hour)
        {
            return hour >= 0 && hour <= 23;
        }

        private bool ValidMinute(int minute)
        {
            return minute >= 0 && minute <= 59;
        }

        private bool ValidSecond(int second)
        {
            return second >= 0 && second <= 59;
        }

        private bool ValidMillisecond(int millisecond)
        {
            return millisecond >= 0 && millisecond <= 999;
        }


        public long ToMilliseconds()
        {
            return (long)_hour * 3600000 +
                   (long)_minute * 60000 +
                   (long)_second * 1000 +
                   _millisecond;
        }

        public long ToSeconds()
        {
            return (long)_hour * 3600 +
                   (long)_minute * 60 +
                   _second;
        }

        public long ToMinutes()
        {
            return (long)_hour * 60 +
                   _minute;
        }


        public Time Add(Time other)
        {
            int ms = _millisecond + other._millisecond;
            int sec = _second + other._second;
            int min = _minute + other._minute;
            int hr = _hour + other._hour;

            if (ms >= 1000)
            {
                sec += ms / 1000;
                ms %= 1000;
            }

            if (sec >= 60)
            {
                min += sec / 60;
                sec %= 60;
            }

            if (min >= 60)
            {
                hr += min / 60;
                min %= 60;
            }

            hr %= 24;

            return new Time(hr, min, sec, ms);
        }

        public bool IsOtherDay(Time other)
        {
            int ms = _millisecond + other._millisecond;
            int sec = _second + other._second;
            int min = _minute + other._minute;
            int hr = _hour + other._hour;

            if (ms >= 1000) sec++;
            if (sec >= 60) min++;
            if (min >= 60) hr++;

            return hr >= 24;
        }


        public override string ToString()
        {
            DateTime dt = new DateTime(1, 1, 1, _hour, _minute, _second, _millisecond);
            return dt.ToString("hh:mm:ss.fff tt",
                CultureInfo.GetCultureInfo("en-US"));
        }

    }
}