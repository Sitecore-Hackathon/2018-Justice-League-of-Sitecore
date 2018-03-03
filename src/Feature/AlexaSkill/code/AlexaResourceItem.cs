using System.Collections.Generic;

namespace AlexConnect.Feature.AlexaSkill
{
    public class AlexaResourceItem
    {
	    public string Language { get; set; }
	    public string SkillName { get; set; }
	    public List<FactItem> Facts { get; set; }
	    public string GetFactMessage { get; set; }
	    public string HelpMessage { get; set; }
	    public string HelpReprompt { get; set; }
	    public string StopMessage { get; set; }

		public AlexaResourceItem(string language)
	    {
		    Language = language;
		    Facts = new List<FactItem>();
		}

	    public static List<AlexaResourceItem> GetResources()
	    {
            //TODO: Wire to Sitecore Fact API

	        var resources = new List<AlexaResourceItem>();

		    var enUsResource = new AlexaResourceItem("en-US")
		    {
			    SkillName = "Sitecore AlexConnect Sports Facts",
			    GetFactMessage = "Here's your fact: ",
			    HelpMessage = "You can say tell me a sports fact, or, you can say exit... What can I help you with?",
			    HelpReprompt = "What can I help you with?",
			    StopMessage = "Goodbye!"
		    };

	        enUsResource.Facts.Add(new FactItem
	        {
	            Detail = "Studies show high school tennis players score significantly lower on math tests, it is assumed because of the sport’s illogical 15–30–40 scoring system.",
	            Name = "High School Tennis",
	            Type = FactItem.FactType.Tennis
	        });

	        enUsResource.Facts.Add(new FactItem
	        {
	            Detail = "The NCAA required college football players to study during halftime until 1925.",
	            Name = "NCAA Studying",
	            Type = FactItem.FactType.Football
	        });

            resources.Add(enUsResource);
		    return resources;
	    }
	}
}
