using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
			CallWebAPIAsync().Wait();
		}

		static async Task CallWebAPIAsync()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:45435/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				//GET Method
				HttpResponseMessage response = await client.GetAsync("api/products/1");
				if (response.IsSuccessStatusCode)
				{
					Product department = await response.Content.ReadAsAsync<Product>();
					Console.WriteLine("Id:{0}\tName:{1}", department.Id, department.Name);
					//Console.WriteLine("No of Employee in Department: {0}", department.);
				}
				else
				{
					Console.WriteLine("Internal server Error");
				}

				//POST Method using PostAsJsonAsync
				var departmentPost = new Product() {Id=4, Name = "Test Department", Description="test" };
				//HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/products", departmentPost);
				//if (responsePost.IsSuccessStatusCode)
				//{
				//	// Get the URI of the created resource.
				//	Uri returnUrl = responsePost.Headers.Location;
				//	Console.WriteLine(returnUrl);
				//}


				//POST Method using PostAsync
				var myContent = JsonConvert.SerializeObject(departmentPost);
			 
				var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
				var byteContent = new ByteArrayContent(buffer);
			 
				byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				var result = client.PostAsync("api/products", byteContent).Result;

				if (result.IsSuccessStatusCode)
				{
					// Get the URI of the created resource.
					Uri returnUrl = result.Headers.Location;
					Console.WriteLine(returnUrl);
				}



				////PUT Method
				var departmentPut = new Product() { Id = 9, Name = "Updated product" };
				HttpResponseMessage responsePut = await client.PutAsJsonAsync("api/products", departmentPut);
				if (responsePut.IsSuccessStatusCode)
				{
					Console.WriteLine("Success");
				}

				//Delete Method
				int departmentId = 9;
				HttpResponseMessage responseDelete = await client.DeleteAsync("api/products/" + departmentId);
				if (responseDelete.IsSuccessStatusCode)
				{
					Console.WriteLine("Success");
				}
			}
			Console.Read();
		}
	}
}
