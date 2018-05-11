﻿using System;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function subscribe
    /// Description: 
    ///     Subscribe for one single relay function. The data field consists of three ASCII digits, the relay number,
    ///     which corresponds to the specific relay function.The relay numbers can be found in Table 101 above.
    ///     At a subscription of a tracking event, MID 0217 Relay function immediately returns the current relay
    ///     status to the subscriber.
    ///     MID 0216 can only subscribe for one single relay function at a time, but still, Open Protocol supports
    ///     keeping several relay function subscriptions simultaneously.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, The relay function subscription already exists
    /// </summary>
    public class MID_0216 : Mid, IIOInterface
    {
        public const int MID = 216;
        private const int length = 23;
        private const int revision = 1;

        public Relay.RelayNumbers RelayNumber { get; set; }

        public MID_0216() : base(length, MID, revision) { }

        internal MID_0216(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + ((int)RelayNumber).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.RELAY_NUMBER].Size, '0');
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.RELAY_NUMBER];
                RelayNumber = (Relay.RelayNumbers)Convert.ToInt32(package.Substring(dataField.Index, dataField.Size));
                return this;
            }
                

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.RELAY_NUMBER, 20, 3));
        }

        public enum DataFields
        {
            RELAY_NUMBER
        }
    }
}
