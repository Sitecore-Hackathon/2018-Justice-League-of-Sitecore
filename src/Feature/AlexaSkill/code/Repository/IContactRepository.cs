using Amazon.Lambda.Core;

namespace AlexConnect.Feature.AlexaSkill.Repository
{
	public interface IContactRepository
	{
	    void Initialize(ILambdaContext context);
		
		void Submit();
	}
}
