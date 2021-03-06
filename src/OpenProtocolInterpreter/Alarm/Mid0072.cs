﻿namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm acknowledge
    /// Description: 
    ///      Acknowledgement for MID 0071 Alarm.
    /// 
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0072 : Mid, IAlarm
    {
        private const int LAST_REVISION = 2;
        public const int MID = 72;

        public Mid0072(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        internal Mid0072(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
