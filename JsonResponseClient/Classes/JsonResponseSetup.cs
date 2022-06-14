using JsonResponseClient.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace JsonResponseClient.Classes
{
	public class JsonResponseSetup : IJsonResponseClient
	{
		private readonly JsonSerializerSettings _jsonSerializerSettings;

		public JsonResponseSetup()
		{
			_jsonSerializerSettings = new JsonSerializerSettings()
			{
				MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
				DateParseHandling = DateParseHandling.None,
				Converters =
				{
					new IsoDateTimeConverter()
					{
						DateTimeStyles = DateTimeStyles.AssumeUniversal
					}
				}
			};
		}

		public T DeserializeResponse<T>(string response)
		{
			if (string.IsNullOrWhiteSpace(response))
				throw new ArgumentException($"'{nameof(response)}' cannot be null or whitespace.", nameof(response));

			var deserialized = JsonConvert.DeserializeObject<T>(response, _jsonSerializerSettings);

			if (deserialized is null)
				throw new JsonSerializationException($"'{nameof(response)}' was null when deserialized. Review the JSON configuration template.");

			return deserialized;
		}

		public string SerializeResponse<T>(T model)
		{
			var json = JsonConvert.SerializeObject(model, _jsonSerializerSettings);

			return json;
		}
	}
}