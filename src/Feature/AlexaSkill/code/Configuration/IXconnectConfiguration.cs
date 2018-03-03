namespace AlexConnect.Feature.AlexaSkill.Configuration
{
	public interface IXconnectConfiguration
	{
		string XconnectUrl { get; }
		string FactEventId { get; }
	    string FactChannelId { get; }
    }
}
