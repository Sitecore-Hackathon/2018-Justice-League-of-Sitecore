using Sitecore.XConnect;

namespace AlexConnect.Feature.AlexaSkill.Model
{
    [FacetKey(FacetName)]
    public class Fact : Facet
    {
        public const string FacetName = "Fact";

        public string Text { get; set; }
    }
}
