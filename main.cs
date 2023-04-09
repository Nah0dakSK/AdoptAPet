string apiUrl = "https://www.adoptapet.com/";

var requestData = new {
    petName = "Buddy",
    petAge = 2,
    petBreed = "Golden Retriever",
    ownerName = "Jan Krajci"
};

string requestBody = JsonConvert.SerializeObject(requestData);

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(requestBody, Encoding.UTF8, "application/json"));

if (response.IsSuccessStatusCode) {
    Console.WriteLine("Adoption successful");
} else {
    Console.WriteLine("Error in process");
}
