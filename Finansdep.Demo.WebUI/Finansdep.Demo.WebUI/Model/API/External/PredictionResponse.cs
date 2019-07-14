using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansdep.Demo.WebUI.Model.API.External
{

	public class PredictionResponse
	{
		public List<float> Predictions = new List<float>();

		public List<PredictionExplanation> Explanations = new List<PredictionExplanation>();
	}

	public class PredictionExplanation
	{
		public float Suburb { get; set; }
		public float Rooms { get; set; }
		public float Type { get; set; }
		public float Method { get; set; }
		public float Postcode { get; set; }
		public float Regionname { get; set; }
		public float Propertycount { get; set; }
		public float Distance { get; set; }
		public float CouncilArea { get; set; }
		public float Month { get; set; }
		public float Year { get; set; }
		public float GlobalMean { get; set; }
	}
}
