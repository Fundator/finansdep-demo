using Finansdep.Demo.WebUI.Util.Serialization.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansdep.Demo.WebUI.Model.API.External
{
	public class PredictionRequest
	{
		[JsonProperty("columns")]
		readonly List<string> Columns = new List<string>()
		{
			"Suburb", "Rooms", "Type", "Method", "Postcode", "Regionname", "Propertycount", "Distance", "CouncilArea", "Date"
		};

		[JsonProperty("data")]
		public List<List<object>> Data = new List<List<object>>();
	}
}
