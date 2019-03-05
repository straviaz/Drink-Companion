using System;
using System.Net.Http.Headers;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System.Web;
using System.Net;

public class APIdata : MonoBehaviour
    {

         void Start()
        {
            MakeRequest();
           
        }

public async void MakeRequest()
        {
    HttpClientHandler handler = new HttpClientHandler()
    {
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate

    };
    var client = new HttpClient(handler);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", "ff567e78c22a4cfdb2d50fd8e451c42c");

            // Request parameters
            queryString["results"] = "100";
            queryString["page"] = "1";
        var x = "bananas";
            var uri = "https://api.wegmans.io/products/search?query="+x+"&api-version=2018-10-18&" + queryString;
            //var ur = "https://api.wegmans.io/products/92685/prices?api-version=2018-10-18";

            var response = await client.GetAsync(uri);
    var why = await response.Content?.ReadAsStringAsync();
        //var hi = why["results"[0]];
    Debug.Log(why);
}
    }
