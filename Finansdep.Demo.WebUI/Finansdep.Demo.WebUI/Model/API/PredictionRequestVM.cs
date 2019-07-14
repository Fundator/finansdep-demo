using Finansdep.Demo.WebUI.Model.API.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansdep.Demo.WebUI.Model.API
{
	public class PredictionRequestVM
	{
		public string Suburb { get; set; }
		public int Rooms { get; set; }
		public string Type { get; set; }
		public string Method { get; set; }
		public int Postcode { get; set; }
		public string Regionname { get; set; }
		public int Propertycount { get; set; }
		public float Distance { get; set; }
		public string CouncilArea { get; set; }

		//[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
		//public DateTime Date { get; set; }
	}
}
