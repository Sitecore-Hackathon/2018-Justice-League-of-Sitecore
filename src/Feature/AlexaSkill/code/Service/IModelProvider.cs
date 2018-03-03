using Sitecore.XConnect.Schema;

namespace AlexConnect.Feature.AlexaSkill.Service
{
    public interface IModelProvider
    {
        XdbModel Model { get; }
    }
}
