using System;
using System.Linq;

using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;

using Amazon.Lambda.Core;

using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlexConnect.Feature.AlexaSkill
{
    public class Function
    {
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var response = new SkillResponse {Response = new ResponseBody {ShouldEndSession = false}};
            IOutputSpeech innerResponse = null;
            var log = context.Logger;
            log.LogLine($"Skill Request Object:");
            log.LogLine(JsonConvert.SerializeObject(input));

            var allResources = ItemResource.GetResources();
            var resource = allResources.FirstOrDefault();

            if (input.GetRequestType() == typeof(LaunchRequest))
            {
                log.LogLine($"Default LaunchRequest made: 'Alexa, open Sports Facts");
                innerResponse = new PlainTextOutputSpeech();
                ((PlainTextOutputSpeech) innerResponse).Text = emitNewFact(resource, true);

            }
            else if (input.GetRequestType() == typeof(IntentRequest))
            {
                var intentRequest = (IntentRequest)input.Request;
                
                switch (intentRequest.Intent.Name)
                {
                    case "AMAZON.CancelIntent":
                        log.LogLine($"AMAZON.CancelIntent: send StopMessage");
                        innerResponse = new PlainTextOutputSpeech();
                        ((PlainTextOutputSpeech) innerResponse).Text = resource.StopMessage;
                        response.Response.ShouldEndSession = true;
                        break;
                    case "AMAZON.StopIntent":
                        log.LogLine($"AMAZON.StopIntent: send StopMessage");
                        innerResponse = new PlainTextOutputSpeech();
                        ((PlainTextOutputSpeech) innerResponse).Text = resource.StopMessage;
                        response.Response.ShouldEndSession = true;
                        break;
                    case "AMAZON.HelpIntent":
                        log.LogLine($"AMAZON.HelpIntent: send HelpMessage");
                        innerResponse = new PlainTextOutputSpeech();
                        ((PlainTextOutputSpeech) innerResponse).Text = resource.HelpMessage;
                        break;
                    case "GetTennisFactIntent":
                        log.LogLine($"GetTennisFactIntent sent: send new fact");
                        innerResponse = new PlainTextOutputSpeech();
                        ((PlainTextOutputSpeech) innerResponse).Text = emitNewFact(resource, false);
                        break;
                    case "GetBaseballFactIntent":
                        log.LogLine($"GetBaseballFactIntent sent: send new fact");
                        innerResponse = new PlainTextOutputSpeech();
                        ((PlainTextOutputSpeech) innerResponse).Text = emitNewFact(resource, false);
                        break;
                    case "GetFootballFactIntent":
                        log.LogLine($"GetFootballFactIntent sent: send new fact");
                        innerResponse = new PlainTextOutputSpeech();
                        ((PlainTextOutputSpeech)innerResponse).Text = emitNewFact(resource, false);
                        break;
                    default:
                        log.LogLine($"Unknown intent: " + intentRequest.Intent.Name);
                        innerResponse = new PlainTextOutputSpeech();
                        ((PlainTextOutputSpeech) innerResponse).Text = resource.HelpReprompt;
                        break;
                }
            }

            response.Response.OutputSpeech = innerResponse;
            response.Version = "1.0";
            log.LogLine($"Skill Response Object...");
            log.LogLine(JsonConvert.SerializeObject(response));
            return response;
        }

        public string emitNewFact(ItemResource resource, bool withPreface)
        {
            Random r = new Random();
            if (withPreface)
                return resource.GetFactMessage + resource.Facts[r.Next(resource.Facts.Count)];
            return resource.Facts[r.Next(resource.Facts.Count)];
        }

    }
}
