using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdmveira.aTareado.Test.Entities.GtdAction
{
    internal static class ScheduleInfoTestHelper
    {
        public static DateTime CreateForBeginOfDay (DateTime date, DateTimeKind kind = DateTimeKind.Local)
        {
            return CreateOfSpecificHour(date, 0, 0, 0, kind);
        }

        public static DateTime CreateForEndOfDay (DateTime date, DateTimeKind kind = DateTimeKind.Local)
        {
            return CreateOfSpecificHour(date, 23, 59, 59, kind);
        }

        public static DateTime CreateOfSpecificHour (DateTime date, int hour, int minute, int second, DateTimeKind kind)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, kind);
        }
    }
}
