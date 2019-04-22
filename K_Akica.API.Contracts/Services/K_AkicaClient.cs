using K_Akica.API.Contracts.Communication;
using K_Akica.API.Contracts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace K_Akica.API.Contracts.Services
{

    enum OperationType
    {
        Get,
        Post,
        Put,
        Delete
    }

    public class K_AkicaClient : HttpClient
    {
        public static Uri ApiUri { get; set; }

        private static K_AkicaClient getClient() => new K_AkicaClient();

        public static async Task<Pooper> GetPooperAsync(int id)
        {
            var holder = new ClientHolder()
            {
                Uri = $"{ApiUri.AbsoluteUri}/Poopers/{id}",
                OperationType = OperationType.Get,
                Content = null
            };

            return await ConsumeApi<Pooper>(holder);
        }

        public static async Task<List<Pooper>> GetAllPoopersAsync()
        {
            var holder = new ClientHolder()
            {
                Uri = $"{ApiUri.AbsoluteUri}/Poopers",
                OperationType = OperationType.Get,
                Content = null
            };

            return await ConsumeApi<List<Pooper>>(holder);
        }

        public static async Task<List<Pooper>> CreatePooper(PooperRequest request)
        {
            var holder = new ClientHolder()
            {
                Uri = $"{ApiUri.AbsoluteUri}/Poopers",
                OperationType = OperationType.Post,

                Content = MakeContent(request)
            };

            return await ConsumeApi<List<Pooper>>(holder);
        }

        public static async Task<Pooper> DeletePooperAsync(int id)
        {
            var holder = new ClientHolder()
            {
                Uri = $"{ApiUri.AbsoluteUri}/Poopers/{id}",
                OperationType = OperationType.Delete,
                Content = null
            };

            return await ConsumeApi<Pooper>(holder);
        }


        public static async Task<IEnumerable<FeedItem>> GetFeedForPooperAsync(int id)
        {
            var holder = new ClientHolder()
            {
                Uri = $"{ApiUri.AbsoluteUri}/FeedItems/pooper/{id}",
                OperationType = OperationType.Post,
                Content = null
            };

            return await ConsumeApi<IEnumerable<FeedItem>>(holder);
        }

        public static async Task<bool> AddFeedItemAsync(FeedItemRequest item)
        {
            var holder = new ClientHolder()
            {
                Uri = $"{ApiUri.AbsoluteUri}/FeedItems",
                OperationType = OperationType.Post,
                Content = MakeContent(item)
            };

            return await ConsumeApi(holder);
        }


        private static async Task<T> ConsumeApi<T>(ClientHolder holder)
        {
            using (var client = getClient())
            using (var responce = await MakeResponce(client, holder))
            {
                return JsonConvert.DeserializeObject<T>(await responce.Content.ReadAsStringAsync());
            }
        }

        private static async Task<bool> ConsumeApi(ClientHolder holder)
        {
            using (var client = getClient())
            using (var responce = await MakeResponce(client, holder))
            {
                return responce.IsSuccessStatusCode;
            }
        }

        private static async Task<HttpResponseMessage> MakeResponce(K_AkicaClient client, ClientHolder holder)
        {
            
            switch (holder.OperationType)
            {
                case OperationType.Get:
                    return await client.GetAsync(holder.Uri);

                case OperationType.Post:
                    return await client.PostAsync(holder.Uri, holder.Content);

                case OperationType.Put:
                    return await client.PutAsync(holder.Uri, holder.Content);

                case OperationType.Delete:
                    return await client.DeleteAsync(holder.Uri);
            }

            return null;
        }

        private static HttpContent MakeContent(object obj)
        {
            var result = new StringContent(JsonConvert.SerializeObject(obj));
            result.Headers.ContentType.MediaType = "application/json-patch+json";

            return result;
        }

        class ClientHolder
        {
            public string Uri { get; set; }
            public HttpContent Content { get; set; }

            public OperationType OperationType { get; set; }
        }
    }


}
