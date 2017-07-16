using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace MACCopyEvent.RecurringEventAdded
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class RecurringEventAdded : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
            using (SPSite site = properties.OpenSite())
            { 
            using (SPWeb web = site.OpenWeb())
                {
                    var destinationWeb = "http://becky.aepdev.com/sites/ET/Test1/cal1/cal3/";

                    using (SPSite destSite = new SPSite(destinationWeb))
                    {
                        using (SPWeb destWeb = destSite.OpenWeb())
                        { 

                        var list = destWeb.Lists["cal4"];
                        var itemPromote = list.Items.Add();
                        itemPromote["Title"] = properties.ListItem["Title"];
                        itemPromote["RecurrenceData"] = properties.ListItem["RecurrenceData"];
                        itemPromote["EventType"] = properties.ListItem["EventType"];
                        itemPromote["EventDate"] = properties.ListItem["EventDate"];
                        itemPromote["EndDate"] = properties.ListItem["EndDate"];
                        itemPromote["UID"] = System.Guid.NewGuid();
                        itemPromote["TimeZone"] = 13;
                        itemPromote["Recurrence"] = -1;
                        itemPromote.Update();
                    }
                    }
            }
            }
        }


    }
}