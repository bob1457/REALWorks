using MediatR;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Events
{
    public class PropertyCreatedEvent : INotification
    {
        //public PropertyCreatedEvent(int propertyId, string propertyName, DateTime created)
        //{
        //    PropertyId = propertyId;
        //    PropertyName = propertyName;
        //    Created = created;
        //}

        //public int PropertyId { get; set; }
        //public string PropertyName { get; set; }
        //public DateTime Created { get; set; }

        public PropertyCreatedEvent (Property property)
        {
            Property = property;
        }

        public Property Property { get; set; }
    }
}
