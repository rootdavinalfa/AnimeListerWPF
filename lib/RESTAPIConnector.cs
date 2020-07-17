// Copyright 2020 Davin Alfarizky Putra Basudewa
// WPF Implementation of AnimizeLister
// Based on Kotlin Version. Unfortunately Kotlin version not open sourced
// This Program just for testing only using WPF technology
// RESTAPIConnector helper to getting data from api.dvnlabs.xyz/animize/

using AnimeListerWPF.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListerWPF.lib
{
    public class RESTAPIConnector
    {
        static HttpClient client = new HttpClient();
        
        static RESTAPIConnector()
        {
            Console.WriteLine("INITIALIZE REST CONNECTOR");
            //client.BaseAddress = new Uri("https://api.dvnlabs.xyz/animize/");
            client.BaseAddress = new Uri("http://127.0.0.1/animize/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async static Task<AnimeList> GetAnimeList(string path)
        {
            AnimeList list = null;
            try
            {
                using (var response = await client.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<AnimeList>(data);
                        //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                    return list;
                }
            }
            catch
            {
                throw;
            }
            
        }

        public async static Task<Details> GetInfo(string path)
        {
            Details anim = null;
            try
            {
                using (var response = await client.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        anim = JsonConvert.DeserializeObject<Details>(data);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                    return anim;
                }
            }
            catch
            {
                throw;
            }

        }

    }
}
