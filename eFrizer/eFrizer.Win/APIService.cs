﻿using eFrizer.Model;
using Flurl.Http;
using System.Threading.Tasks;


namespace eFrizer.Win
{
    public class APIService
    {
        private string _route = null;

        public static string Username { get; set; }

        public static string Password { get; set; }

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object request = null)
        {
            var url = $"{Properties.Settings.Default.ApiURL}/{_route}";
            if (request != null)
            {
                url += "?";
                url += await request.ToQueryString();
            }
            var result = await url
                .WithBasicAuth(Username, Password)
                .GetJsonAsync<T>();
            return result;
        }

        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{Properties.Settings.Default.ApiURL}/{_route}/{id}"
                .WithBasicAuth(Username, Password)
                .GetJsonAsync<T>();
            return result;
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.ApiURL}/{_route}";
            var result = await url
                .WithBasicAuth(Username, Password)
                .PostJsonAsync(request).ReceiveJson<T>();
            return result;
        }

        public async Task<T> Update<T>(int id, object request)
        {
            var url = $"{Properties.Settings.Default.ApiURL}/{_route}/{id}";
            var result = await url
                .WithBasicAuth(Username, Password)
                .PutJsonAsync(request).ReceiveJson<T>();
            return result;
        }

    }
}

