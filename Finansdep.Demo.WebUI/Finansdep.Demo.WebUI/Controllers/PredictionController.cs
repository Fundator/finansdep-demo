/*
	MIT License

	Copyright (c) 2019 Norconsult Informasjonssystemer AS

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finansdep.Demo.WebUI.Model.API;
using Finansdep.Demo.WebUI.Model.API.External;
using Finansdep.Demo.WebUI.Util.Extensions.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Finansdep.Demo.WebUI.Controllers
{
	/// <summary>
	/// Controller for housing value prediction
	/// </summary>
	[Route("api/[controller]")]
	public class PredictionController : Controller
	{

		/// <summary>
		/// Predict a market value for a house with the given features, 
		/// and return an explanatory data structure as well as the prediction itself.
		/// </summary>
		/// <param name="predictionFormData"></param>
		/// <returns></returns>
		[HttpPost("[action]")]
		public PredictionResponse PredictHousingValue([FromBody]PredictionRequest predictionFormData)
		{
			// Map incoming form data to the request structure of the MLFlow API
			var predictionRequest = predictionFormData.ToMlFlowPredictionRequest();

			// Create and configure a REST request using RestSharp
			var restRequest = new RestRequest("score", Method.POST, DataFormat.Json)
									.AddParameter("application/json", 
												JsonConvert.SerializeObject(predictionRequest),
												ParameterType.RequestBody);

			// Execute the request
			var response = GetClient().Post(restRequest);

			// Deserialize response
			var data = JsonConvert.DeserializeObject<MlFlowPredictionResponse>(response.Content);

			// Handle errors
			if (!response.IsSuccessful)
			{
				return new PredictionResponse
				{
					Status = RequestStatus.Error,
					StatusMessage = response.Content
				};
			}
			// Map the response structure from the MLFLow API
			// to the response structure for this API and return it
			return new PredictionResponse().MapFrom(data);
		}

		private static RestClient GetClient()
		{
			return new RestClient("http://5364e0bd-1a4e-4579-98de-4bd9b11ca807.westus.azurecontainer.io");
		}
	}
}
