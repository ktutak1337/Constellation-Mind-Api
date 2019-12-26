using System;

namespace ConstellationMind.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToTimestamp(this DateTime dateTime)
        {
            var UnixEpochTime = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc);
            var time = dateTime.Subtract(new TimeSpan(UnixEpochTime.Ticks));

            return time.Ticks / 10000;
        }
    }
}
