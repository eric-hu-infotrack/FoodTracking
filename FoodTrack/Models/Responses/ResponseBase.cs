using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodTrack.Models.Responses
{
    public interface IResponseBase
    {
        string Message { get; set; }               //response message
    }

    public interface IEntityResponseBase
    {
        string Entity { get; set; }     //entity type  e.g. category, item etc.
    }

    public interface IEntitiesResponseBase
    {
        string Entities { get; set; }    //entity types  e.g. categories, items etc.
    }


    public class ResponseBase : IResponseBase
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class EntityResponseBase : ResponseBase, IEntityResponseBase
    {
        [JsonProperty("object")]
        public string Entity { get; set; }
    }

    public class EntitiesResponseBase : ResponseBase, IEntitiesResponseBase
    {
        [JsonProperty("objects")]
        public string Entities { get; set; }
    }
}
