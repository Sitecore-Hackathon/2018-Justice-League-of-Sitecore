namespace AlexConnect.Feature.AlexaSkill
{
    public class FactItem
    {
        public enum FactType
        {
            Tennis,
            Baseball,
            Football
        };

        public string Detail { get; set; }
	    public string Name { get; set; }
        public FactType Type { get; set; }
	}
}
