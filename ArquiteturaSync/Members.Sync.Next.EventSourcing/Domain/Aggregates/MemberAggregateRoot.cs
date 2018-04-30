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
                var t = x.GetType();

                if (t == typeof(MemberCreatedEvent))
                {
                    MapMemberCreatedEvent(x);
                }
                else if(t == typeof(MemberPersonalInfoUpdatedEvent))
                {
                    MapMemberPersonalInfoUpdatedEvent(x);
                }
                else if(t == typeof(AddressCreatedEvent))
                {
                    MapMemberAddressCreatedEvent(x);
                }
            });
        }

        public static MemberAggregateRoot New() => new MemberAggregateRoot { Events = new List<BaseMemberEvent>() };

        private void MapMemberCreatedEvent(BaseMemberEvent e)
        {
            var m = e as MemberCreatedEvent;
            if (!string.IsNullOrWhiteSpace(m.ID)) MemberState.ID = m.ID;
            if (!string.IsNullOrWhiteSpace(m.LegacyID)) MemberState.LegacyID = m.LegacyID;
            if (!string.IsNullOrWhiteSpace(m.FullName)) MemberState.FullName = m.FullName;
            if (m.Age > 0) MemberState.Age = m.Age;
            if (!string.IsNullOrWhiteSpace(m.CellNumber)) MemberState.CellNumber = m.CellNumber;
            if (m.DateOfBirth != null || MemberState.DateOfBirth != DateTime.MinValue) MemberState.DateOfBirth = m.DateOfBirth;
            if (m?.Addresses.Count > 0) MapMemberAddressCreatedEvent(e);
        }

        private void MapMemberPersonalInfoUpdatedEvent(BaseMemberEvent e)
        {
            var m = e as MemberPersonalInfoUpdatedEvent;
            if (!string.IsNullOrWhiteSpace(m.ID)) MemberState.ID = m.ID;
            if (!string.IsNullOrWhiteSpace(m.LegacyID)) MemberState.LegacyID = m.LegacyID;
            if (!string.IsNullOrWhiteSpace(m.FullName)) MemberState.FullName = m.FullName;
            if (m.Age > 0) MemberState.Age = m.Age;
            if (!string.IsNullOrWhiteSpace(m.CellNumber)) MemberState.CellNumber = m.CellNumber;
            if (m.DateOfBirth != null || MemberState.DateOfBirth != DateTime.MinValue) MemberState.DateOfBirth = m.DateOfBirth;

        }

        private void MapMemberAddressCreatedEvent(BaseMemberEvent e)
        {
            var m = e as AddressCreatedEvent;

            if (MemberState.Addresses == null) MemberState.Addresses = new List<Address>();
            MemberState.Addresses.Add(new Address
            {
                City = m.City,
                Country = m.Country,
                DefaultAddress = m.DefaultAddress,
                ID = m.ID,
                MemberID = m.MemberID,
                ReferencePoint = m.ReferencePoint,
                State = m.State,
                StreetName = m.StreetName,
                StreetNumber = m.StreetNumber,
                Type = m.Type
            });
        }
    }
}
