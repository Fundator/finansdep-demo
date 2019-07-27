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

using Finansdep.Demo.WebUI.Model.API;
using Finansdep.Demo.WebUI.Model.API.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansdep.Demo.WebUI.Util.Extensions.Models
{
	public static class MappingExtensions
	{
		public static MlFlowPredictionRequest ToMlFlowPredictionRequest(this PredictionRequest predictionFormData)
		{
			return new MlFlowPredictionRequest
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

		public static PredictionResponse MapFrom(this PredictionResponse self, MlFlowPredictionResponse data)
		{
			// Assumption that we will get one and only one
			// response since we are not doing bulk prediction
			var prediction = data.Predictions.First();
			var explanation = data.Explanations.First();

			// Map the response structure from the MLFLow API
			// to the response structure for this API
			self.Status = RequestStatus.Ok;
			self.Prediction = prediction;
			self.Suburb = explanation.Suburb;
			self.Rooms = explanation.Rooms;
			self.Type = explanation.Type;
			self.Method = explanation.Method;
			self.Postcode = explanation.Postcode;
			self.Regionname = explanation.Regionname;
			self.Propertycount = explanation.Propertycount;
			self.Distance = explanation.Distance;
			self.CouncilArea = explanation.CouncilArea;
			self.Month = explanation.Month;
			self.Year = explanation.Year;
			self.GlobalMean = explanation.GlobalMean;

			return self;
		}
	}
}
