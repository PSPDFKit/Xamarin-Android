/*
 * 
 * WebPreviewApiClient.cs: Interfaces with our web-preview server.
 * 
 * This is just networking and JSON parsing. It’s very specific our backend so not very useful as sample code.
 * In your own app you would connect to your own server backend to get Instant document identifiers and authentication tokens.
 *
 */

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace PSPDFCatalog {
	public class WebPreviewApiClient {

		public const int CodeLength = 7;
		static readonly string instantCodeEndpointUrl = "https://web-preview.pspdfkit.com/api/";
		readonly HttpClient httpClient = new HttpClient ();

		public async Task<InstantDocumentInfo> CreateNewDocument ()
		{
			try {
				var response = await httpClient.PostAsync ($"{instantCodeEndpointUrl}/instant-landing-page", null);
				response.EnsureSuccessStatusCode ();

				// Do not allocate a string for the json reponse, read directly from the stream
				using (var stream = await response.Content.ReadAsStreamAsync ())
				using (var reader = new StreamReader (stream))
				using (var json = new JsonTextReader (reader)) {
					return InstantDocumentInfo.FromJson (json);
				}
			} catch (HttpRequestException ex) {
				Console.WriteLine (ex.Message);
				return null;
			}
		}

		public async Task<InstantDocumentInfo> ResolveDocument (string code)
		{
			try {
				var response = await httpClient.GetAsync ($"{instantCodeEndpointUrl}/instant/{WebUtility.UrlEncode (code)}");
				response.EnsureSuccessStatusCode ();

				// Do not allocate a string for the json reponse, read directly from the stream
				using (var stream = await response.Content.ReadAsStreamAsync ())
				using (var reader = new StreamReader (stream))
				using (var json = new JsonTextReader (reader)) {
					return InstantDocumentInfo.FromJson (json);
				}
			} catch (HttpRequestException ex) {
				Console.WriteLine (ex.Message);
				return null;
			}
		}
	}

	// Generated with https://quicktype.io
	// The object returned by API calls to our web-preview server.
	public partial class InstantDocumentInfo {
		[JsonProperty ("encodedDocumentId")]
		public string EncodedDocumentId { get; set; }

		[JsonProperty ("documentId")]
		public string DocumentId { get; set; }

		[JsonProperty ("jwt")]
		public string Jwt { get; set; }

		[JsonProperty ("url")]
		public string Url { get; set; }

		[JsonProperty ("serverUrl")]
		public string ServerUrl { get; set; }
	}

	public partial class InstantDocumentInfo {
		public static InstantDocumentInfo FromJson (string json) => JsonConvert.DeserializeObject<InstantDocumentInfo> (json, Converter.Settings);

		internal static readonly JsonSerializer serializer = new JsonSerializer ();
		public static InstantDocumentInfo FromJson (JsonTextReader jsontr) => serializer.Deserialize<InstantDocumentInfo> (jsontr);
	}

	public static class Serialize {
		public static string ToJson (this InstantDocumentInfo self) => JsonConvert.SerializeObject (self, Converter.Settings);
		public static void ToJson (this InstantDocumentInfo self, JsonTextWriter jsontw) => InstantDocumentInfo.serializer.Serialize (jsontw, self, typeof (InstantDocumentInfo));
	}

	public class Converter {
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
		};
	}
}
