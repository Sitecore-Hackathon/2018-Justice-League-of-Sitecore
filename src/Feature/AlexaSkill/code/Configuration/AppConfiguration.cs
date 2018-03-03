using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;

namespace AlexConnect.Feature.AlexaSkill.Configuration
{
	public class AppConfiguration : IXconnectConfiguration
	{	

		public string XconnectUrl => GetValue<string>("https://sc901-557170-xc-single.azurewebsites.net");
		
	    public string FactEventId => GetValue<string>("FactEventId");

	    public string FactChannelId => GetValue<string>("FactChannelId");

        private static T GetValue<T>(string key)
		{
			var returnValue = default(T);
			var converter = TypeDescriptor.GetConverter(typeof(T));
			var value = ConfigurationManager.AppSettings[key];

			if (value != null)
			{
				try
				{
					returnValue = (T)converter.ConvertFrom(value);
				}
				catch (Exception)
				{
					Trace.TraceError($"Failed trying to convert '{value}' to type '{key}'");
				}
			}
			else
			{
				Trace.TraceError($"Could not find the config value '{key}'");
			}
			return returnValue;
		}
	}
}
