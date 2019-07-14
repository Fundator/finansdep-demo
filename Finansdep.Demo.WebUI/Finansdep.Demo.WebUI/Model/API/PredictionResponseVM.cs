using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansdep.Demo.WebUI.Model.API
{
	public class PredictionResponseVM
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public RequestStatus Status;
		public string StatusMessage;

		public float Prediction { get; set; }
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

	public enum RequestStatus
	{
		Ok, Error
	}
}
