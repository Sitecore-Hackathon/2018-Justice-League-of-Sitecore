using System;
using Sitecore.XConnect;

namespace AlexConnect.Feature.AlexaSkill.Model
{
    public class FactEvent : Event
    {
        public FactEvent(Guid definitionId, DateTime timestamp) : base(definitionId, timestamp)
        {
        }
        
	    public string FactItemId { get; set; }
        public string FactDetails { get; set; }
    }
}
