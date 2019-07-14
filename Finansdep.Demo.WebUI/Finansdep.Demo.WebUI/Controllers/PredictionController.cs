using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finansdep.Demo.WebUI.Model.API;
using Finansdep.Demo.WebUI.Model.API.External;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Finansdep.Demo.WebUI.Controllers
{
	[Route("api/[controller]")]
	public class PredictionController : Controller
	{

		[HttpPost("[action]")]
		public PredictionResponseVM PredictHousingValue([FromBody]PredictionRequestVM predictionFormData)
		{
			var predictionRequest = MapFormDataToPredictionRequest(predictionFormData);
			var client = GetClient();
			var request = new RestRequest("score", Method.POST);
			request.RequestFormat = DataFormat.Json;
			var serializedPredictionRequest = JsonConvert.SerializeObject(predictionRequest);
			request.AddParameter("application/json", serializedPredictionRequest, ParameterType.RequestBody);
			var response = client.Post(request);

			// Deserialize response
			var data = JsonConvert.DeserializeObject<PredictionResponse>(
				JsonConvert.DeserializeObject<string>(response.Content)); // Temporary fix due to awkward serialization in MLFlow 
																		  // (possible double json serialization)

			if (!response.IsSuccessful)
			{
				return new PredictionResponseVM
				{
					Status = RequestStatus.Error,
					StatusMessage = response.Content
				};
			}

			var prediction = data.Predictions.First();
			var explanation = data.Explanations.First();

			return new PredictionResponseVM
			{
				Status = RequestStatus.Ok,
				Prediction = prediction,
				Suburb = explanation.Suburb,
				Rooms = explanation.Rooms,
				Type = explanation.Type,
				Method = explanation.Method,
				Postcode = explanation.Postcode,
				Regionname = explanation.Regionname,
				Propertycount = explanation.Propertycount,
				Distance = explanation.Distance,
				CouncilArea = explanation.CouncilArea,
				Month = explanation.Month,
				Year = explanation.Year,
				GlobalMean = explanation.GlobalMean,
			};
		}

		private static RestClient GetClient()
		{
			return new RestClient("http://5364e0bd-1a4e-4579-98de-4bd9b11ca807.westus.azurecontainer.io");
		}

		private static PredictionRequest MapFormDataToPredictionRequest(PredictionRequestVM predictionFormData)
		{
			return new PredictionRequest
			{
				Data = new List<List<object>> {
					new List<object> {
						predictionFormData.Suburb,
						predictionFormData.Rooms,
						predictionFormData.Type,
						predictionFormData.Method,
						predictionFormData.Postcode,
						predictionFormData.Regionname,
						predictionFormData.Propertycount,
						predictionFormData.Distance,
						predictionFormData.CouncilArea,
						DateTime.Now.ToString("yyyy-MM-dd")
					}
				}
			};
		}
	}
}
