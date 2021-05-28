using System.Collections.Generic;
using Common.DB;
using Newtonsoft.Json;

namespace ProcessSystem.Contracts
{
    public class Register : IAggregateRoot
    {
        public long Id { get; private set; }
        public string Token { get; private set; }
        public string Url { get; private set; }
        public string Channel { get; private set; }
        public string EventTypes { get; private set; }

        public Register(string token, string url, string channel)
        {
            Token = token;
            Url = url;
            Channel = channel;
        }

        public void SetEventTypes(IList<string> eventTypesList) => EventTypes = JsonConvert.SerializeObject(eventTypesList);
    }
}