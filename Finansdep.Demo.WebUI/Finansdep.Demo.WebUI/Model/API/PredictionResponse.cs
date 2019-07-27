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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansdep.Demo.WebUI.Model.API
{
	public class PredictionResponse
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
}
