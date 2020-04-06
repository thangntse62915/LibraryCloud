using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryCloud.Models
{
    public class BookViewModel
    {
        [JsonProperty("id")]
        public int id { get;  set;}

        public int idd { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("author")]
        public string author { get; set; }
        [JsonProperty("position")]
        public string position { get; set; }
        [JsonProperty("publishYear")]
        public string publishYear { get; set; }
        [JsonProperty("total")]
        public int total { get; set; }
        [JsonProperty("image")]
        private string image { get; set; }
        [JsonProperty("category")]
        private CategoryViewModel category { get; set; }
    }
    public class CategoryViewModel
    {
        [JsonProperty("id")]
        private int id { get; set; }
        [JsonProperty("name")]
        private string name { get; set; }
    }
}