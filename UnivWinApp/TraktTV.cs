using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace UnivWinApp {

    public static class TraktTV {

        public async static Task<List<RootObject>> DownloadData2() {
            var http = new HttpClient();
            http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            http.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-version", "2");
            http.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-key", "44852dfd06e564559ffda22f37bc74bff05c76019096ac56278df9af1967ee07");
            var response = await http.GetAsync("https://api-v2launch.trakt.tv/shows/popular?extended=full,images");
            var result = await response.Content.ReadAsStringAsync();
            List<RootObject> obj = JsonConvert.DeserializeObject<List<RootObject>>(result);

            Debug.WriteLine(result);
            Debug.WriteLine(obj.Count);

            return obj;
        }

        public async static Task<RootObject> DownloadData() {
            var http = new HttpClient();
            http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            http.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-version", "2");
            http.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-key", "44852dfd06e564559ffda22f37bc74bff05c76019096ac56278df9af1967ee07");
            var response = await http.GetAsync("https://api-v2launch.trakt.tv/shows/popular?extended=full,images");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject) serializer.ReadObject(ms);

            Debug.WriteLine(result);

            return data;
        }
    }

    [DataContract]
    public class Poster {
        [DataMember]
        public string full { get; set; }
        [DataMember]
        public string medium { get; set; }
        [DataMember]
        public string thumb { get; set; }
    }

    [DataContract]
    public class Images {
        [DataMember]
        public Poster poster { get; set; }
    }

    [DataContract]
    public class RootObject {
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public int year { get; set; }
        [DataMember]
        public string overview { get; set; }
        [DataMember]
        public double rating { get; set; }
        [DataMember]
        public int votes { get; set; }
        [DataMember]
        public DateTime updated_at { get; set; }
        [DataMember]
        public string language { get; set; }
        [DataMember]
        public int aired_episodes { get; set; }
        [DataMember]
        public Images images { get; set; }
    }
}
