using System;
using System.Collections.Generic;
using System.Linq;
using DotzNext.EventSourcing;
using Members.Sync.Next.EventSourcing.Domain.Events;

namespace Members.Sync.Next.EventSourcing.Domain.Aggregates
{
    public class MemberAggregateRoot : AggregateRoot<BaseMemberEvent>
    {
        public string MemberID { get; set; }
        public string LegacyID { get; set; }

        /// <summary>
        /// This property contains the current Member state rebuilt by the event stream serialized
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        /// This property contains the current Member Addresses state rebuilt by the event stream serialized
        /// </summary>
        public string Addresses { get; set; }
        /// <summary>
        /// This property contains the current Member state rebuilt by the event stream deserialized 
        /// </summary>
        public Member MemberState { get; set; }
        /// <summary>
        /// This property contains the current Addresses state rebuilt by the event stream deserialized
        /// </summary>
        public List<Address> AddressState { get; set; }

        public override void AddEventToStream(BaseMemberEvent e)
        {
            Events.Add(e);
        }

        public override bool HasEvent(BaseMemberEvent e)
        {
            return Events.Any(x => x.Date == e.Date && x.GetVersion().Equals(e.GetVersion()));
        }

        public override void RebuildEventStream()
        {
            MemberState = new Member();

            Events.OrderBy(x => x.Date).ToList().ForEach(x =>
            {
                if (!string.IsNullOrWhiteSpace(x.ID))
                {
                    if (x.GetType() == typeof(MemberCreatedEvent))
                    {
                        var m = x as MemberCreatedEvent;
                        if (!string.IsNullOrWhiteSpace(m.ID)) MemberState.ID = m.ID;
                        if (!string.IsNullOrWhiteSpace(m.LegacyID)) MemberState.LegacyID = m.LegacyID;
                        if (!string.IsNullOrWhiteSpace(m.FullName)) MemberState.FullName = m.FullName;
                        if (m.Age > 0) MemberState.Age = m.Age;
                        if (!string.IsNullOrWhiteSpace(m.CellNumber)) MemberState.CellNumber = m.CellNumber;
                        if (m.DateOfBirth != null || MemberState.DateOfBirth != DateTime.MinValue) MemberState.DateOfBirth = m.DateOfBirth;
                    }
                }
            });
        }

        public static MemberAggregateRoot New() => new MemberAggregateRoot { Events = new List<BaseMemberEvent>() };
    }
}
