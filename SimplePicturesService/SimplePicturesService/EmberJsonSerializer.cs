using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplePicturesService
{
    public class EmberJsonSerializer
    {
        public virtual JObject Deserialize(string json)
        {
            var rootRemovedJson = this.RemoveRoot(json);
            return JObject.Parse(rootRemovedJson);
        }

        private string RemoveRoot(string json)
        {
            json = json.Trim();
            if (json.StartsWith("{") || json.StartsWith("["))
            {
                return json;
            }

            return json.Substring(json.IndexOf(":") + 1);
        }
    }
}