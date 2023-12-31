﻿// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using tracking.client;

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7095");
client.DefaultRequestHeaders.Accept. Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/Chat");
response.EnsureSuccessStatusCode();
if (response.IsSuccessStatusCode)
{
    var issues = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
    foreach (var issue in issues)
    {
        Console.WriteLine(issue.Id);
    }
}
else
{
    Console.WriteLine("no resalt");
}
Console.ReadLine();