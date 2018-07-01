using System;

namespace Events
{
    public class CreatedCellPhoneEvent : BaseUserEvent
    {
        protected CreatedCellPhoneEvent(string userName, DateTime eventDate, string source, string version)
                                        : base(userName, eventDate, source, version)
        {
        }

        public int AreaCode { get; }
        public int Number { get; }
        public string Description { get; }
    }
}
