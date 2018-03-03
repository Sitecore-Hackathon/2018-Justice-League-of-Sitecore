using System;

using Amazon.Lambda.Core;

using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Schema;

using AlexConnect.Feature.AlexaSkill.Configuration;
using AlexConnect.Feature.AlexaSkill.Service;

namespace AlexConnect.Feature.AlexaSkill.Repository
{
    public class XconnectRepository : IContactRepository
    {
        private readonly AppConfiguration _xconnectConfiguration;
        private readonly XconnectModelProvider _modelProvider;
	    
        private XConnectClient _client = null;
        private readonly Contact _contact = null;

        public XconnectRepository(ILambdaContext context)
        {
            _xconnectConfiguration = new AppConfiguration();
            _modelProvider = new XconnectModelProvider();
            _contact = new Contact();
            Initialize(context);
        }

        public void RegisterFactEvent(string source, string factItemId, string factDetails)
	    {   
            var interaction = new Interaction(_contact, InteractionInitiator.Contact, Guid.Parse(_xconnectConfiguration.FactChannelId), source);

	        var factEvent = new Event(Guid.Parse(_xconnectConfiguration.FactEventId), DateTime.UtcNow);
	        factEvent.CustomValues.Add(factItemId, factDetails);

            interaction.Events.Add(factEvent);

		    _client.AddInteraction(interaction);
	    }
        
		public void Submit()
        {
            try
            {
                _client.Submit();
            }
            catch (Exception ex)
            {
                
                //throw;
            }
        }
        
        public void Initialize(ILambdaContext context)
        {
            var log = context.Logger;

            log.LogLine("Initializing xConnect...");

            var model = _modelProvider.Model;
            var config = new XConnectClientConfiguration(new XdbRuntimeModel(model), new Uri(_xconnectConfiguration.XconnectUrl), new Uri(_xconnectConfiguration.XconnectUrl));
            config.Initialize();

            _client = new XConnectClient(config);

            log.LogLine("xConnect initialization complete");
        }
	}
}
