using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    public class Util
    {
        public class MicroEpoch
        {
            private static DateTime Jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1 tick is 100ns, 10 tick = 1us
            private static DateTimePrecise precise = new DateTimePrecise(10);

            public static DateTime MicroEpochToDateTime(long microEpoch)
            {
                DateTime ret = Jan1St1970;
                return ret.AddTicks(microEpoch * 10);
            }
            public static DateTime CurrentDateTime()
            {
                return MicroEpochToDateTime(CurrentMicroEpoch());
            }

            public static long DateTimeToMicroEpoch(DateTime dateTime)
            {
                return (dateTime.Ticks - Jan1St1970.Ticks) / 10;
            }

            public static long CurrentMicroEpoch()
            {
                return (precise.UtcNow.Ticks - Jan1St1970.Ticks) / 10; // Stopwatch should have better precision then DateTime.Now (15ms yuck)
            }
        }

        public class DateTimePrecise
        {
            public DateTimePrecise(long synchronizePeriodSeconds)
            {
                Stopwatch = Stopwatch.StartNew();
                this.Stopwatch.Start();

                DateTime t = DateTime.UtcNow;
                _immutable = new DateTimePreciseSafeImmutable(t, t, Stopwatch.ElapsedTicks,
                    Stopwatch.Frequency);

                _synchronizePeriodSeconds = synchronizePeriodSeconds;
                _synchronizePeriodStopwatchTicks = synchronizePeriodSeconds *
                    Stopwatch.Frequency;
                _synchronizePeriodClockTicks = synchronizePeriodSeconds *
                    _clockTickFrequency;
            }

            public DateTime UtcNow
            {
                get
                {
                    long s = this.Stopwatch.ElapsedTicks;
                    DateTimePreciseSafeImmutable immutable = _immutable;

                    if (s < immutable._s_observed + _synchronizePeriodStopwatchTicks)
                    {
                        return immutable._t_base.AddTicks(((
                            s - immutable._s_observed) * _clockTickFrequency) / (
                            immutable._stopWatchFrequency));
                    }
                    else
                    {
                        DateTime t = DateTime.UtcNow;

                        DateTime t_base_new = immutable._t_base.AddTicks(((
                            s - immutable._s_observed) * _clockTickFrequency) / (
                            immutable._stopWatchFrequency));

                        _immutable = new DateTimePreciseSafeImmutable(
                            t,
                            t_base_new,
                            s,
                            ((s - immutable._s_observed) * _clockTickFrequency * 2)
                            /
                            (t.Ticks - immutable._t_observed.Ticks + t.Ticks +
                                t.Ticks - t_base_new.Ticks - immutable._t_observed.Ticks)
                        );

                        return t_base_new;
                    }
                }
            }

            public DateTime Now
            {
                get
                {
                    return this.UtcNow.ToLocalTime();
                }
            }

            public Stopwatch Stopwatch;

            private long _synchronizePeriodStopwatchTicks;
            private long _synchronizePeriodSeconds;
            private long _synchronizePeriodClockTicks;
            private const long _clockTickFrequency = 10000000;
            private DateTimePreciseSafeImmutable _immutable;
        }

        internal sealed class DateTimePreciseSafeImmutable
        {
            internal DateTimePreciseSafeImmutable(DateTime t_observed, DateTime t_base,
                 long s_observed, long stopWatchFrequency)
            {
                _t_observed = t_observed;
                _t_base = t_base;
                _s_observed = s_observed;
                _stopWatchFrequency = stopWatchFrequency;
            }
            internal readonly DateTime _t_observed;
            internal readonly DateTime _t_base;
            internal readonly long _s_observed;
            internal readonly long _stopWatchFrequency;
        }
    }
}
