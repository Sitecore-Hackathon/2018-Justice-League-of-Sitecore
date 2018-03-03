using Sitecore.XConnect.Schema;

namespace AlexConnect.Feature.AlexaSkill.Service
{
    public class XconnectModelProvider : IModelProvider
    {
        private XdbModel _model;
        public XdbModel Model => _model ?? (_model = BuildModel());

        public XconnectModelProvider()
        {
            
        }

        private static XdbModel BuildModel()
        {
            var builder = new XdbModelBuilder("AlexConnect.Model", new XdbModelVersion(1, 0));
            builder.ReferenceModel(Sitecore.XConnect.Collection.Model.CollectionModel.Model);
            var xdbModel = builder.BuildModel();
            return xdbModel;
        }
    }
}
