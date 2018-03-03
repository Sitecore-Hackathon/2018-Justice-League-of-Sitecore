using System.Collections.Generic;

namespace AlexConnect.Feature.AlexaSkill
{
    public class ItemResource
    {
	    public string Language { get; set; }
	    public string SkillName { get; set; }
	    public List<string> Facts { get; set; }
	    public string GetFactMessage { get; set; }
	    public string HelpMessage { get; set; }
	    public string HelpReprompt { get; set; }
	    public string StopMessage { get; set; }

		public ItemResource(string language)
	    {
		    Language = language;
		    Facts = new List<string>();
		}

	    public static List<ItemResource> GetResources()
	    {
		    var resources = new List<ItemResource>();

		    var enUsResource = new ItemResource("en-US")
		    {
			    SkillName = "Sitecore AlexConnect",
			    GetFactMessage = "Here's your fact: ",
			    HelpMessage = "You can say tell me a space fact, or, you can say exit... What can I help you with?",
			    HelpReprompt = "What can I help you with?",
			    StopMessage = "Goodbye!"
		    };

		    enUsResource.Facts.Add("A year on Mercury is just 88 days long.");
		    enUsResource.Facts.Add("Despite being farther from the Sun, Venus experiences higher temperatures than Mercury.");
		    enUsResource.Facts.Add("Venus rotates counter-clockwise, possibly because of a collision in the past with an asteroid.");
		    enUsResource.Facts.Add("On Mars, the Sun appears about half the size as it does on Earth.");
		    enUsResource.Facts.Add("Earth is the only planet not named after a god.");
		    enUsResource.Facts.Add("Jupiter has the shortest day of all the planets.");
		    enUsResource.Facts.Add("The Milky Way galaxy will collide with the Andromeda Galaxy in about 5 billion years.");
		    enUsResource.Facts.Add("The Sun contains 99.86% of the mass in the Solar System.");
		    enUsResource.Facts.Add("The Sun is an almost perfect sphere.");
		    enUsResource.Facts.Add("A total solar eclipse can happen once every 1 to 2 years. This makes them a rare event.");
		    enUsResource.Facts.Add("Saturn radiates two and a half times more energy into space than it receives from the sun.");
		    enUsResource.Facts.Add("The temperature inside the Sun can reach 15 million degrees Celsius.");
		    enUsResource.Facts.Add("The Moon is moving approximately 3.8 cm away from our planet every year.");

		    resources.Add(enUsResource);
		    return resources;
	    }
	}
}
