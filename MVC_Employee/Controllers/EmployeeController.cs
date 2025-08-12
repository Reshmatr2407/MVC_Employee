using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace MVC_Employee.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Homepage() 
        {
            return View();
        }
        public IActionResult Searchbyid()
        {
            return View();
        }
        public IActionResult Searchbyid2()
        {
            return View();
        }
        public string getAPIData(string datas)     //Get API Response
        {
            // Split the input string 'datas' using '$' as the delimiter
            string[] datastring = datas.Split("$");

            // Construct the API path using the second and first elements of the split array
            string ApiPath = "http://localhost:5120/api/Employee/GetDetails2/" + datastring[0] + "/" + datastring[1] + "/1";
            // Create an instance of HttpClient to make the HTTP request
            using (var client = new HttpClient())
            {
                // Initialize a variable to hold the response data
                string data = "";
                // Set the base address of the HttpClient to the constructed API path
                client.BaseAddress = new Uri(ApiPath);
                // Make a GET request to the API and wait for the result

                HttpResponseMessage result = client.GetAsync(client.BaseAddress).Result;
                // Check if the response indicates success
                if (result.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    data = result.Content.ReadAsStringAsync().Result;
                }
                // Return the response data 
                return data;
            }
        }
        public IActionResult Searchbydept()
        {
            return View();
        }
        public IActionResult Insertemp()
        {
            return View();
        }
        public async Task<dynamic> postAPIData(string datas)     //Get API Response
        {
            // Define the API endpoint URL
            string ApiPath = "http://localhost:5120/api/Employee/PostDetails2/";
            // Initialize a variable to hold the response data
            var data = "";
            // Split the input string 'datas' using '$' as the delimiter
            string[] datastring = datas.Split("$");
            string[] datastring2 = datastring[1].Split("/");
            // Create an instance of HttpClient to make the HTTP request
            using (HttpClient client = new HttpClient())
            {
                // Serialize the data into JSON format
                string content = JsonConvert.SerializeObject(new
                {
                    flag = datastring[0] , // Second part of the split data
                    empId = datastring2[0],// First part of the split data
                    empName = datastring2[1],
                    designation = datastring2[2],
                    department = datastring2[3],// A fixed parameter value

                });
                // Convert the JSON string to a byte array
                var buffer = Encoding.UTF8.GetBytes(content);
                // Create ByteArrayContent from the byte array
                var byteContent = new ByteArrayContent(buffer);
                // Set the content type to JSON
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                // Make the POST request to the API

                // Await the response
                HttpResponseMessage response2 = await client.PostAsync(ApiPath, byteContent);
                // Check if the response indicates success
                if (response2.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    // Use await to avoid blocking
                    data = response2.Content.ReadAsStringAsync().Result;
                }
            }
            // Return the response data 
            return data;
        }
        public async Task<dynamic> putAPIData(string datas)     //Get API Response
        {
            // Define the API endpoint URL
            string ApiPath = "http://localhost:5120/api/Employee/PutDetails1/";
            // Initialize a variable to hold the response data
            var data = "";
            // Split the input string 'datas' using '$' as the delimiter
            string[] datastring = datas.Split("$");
            string[] datastring2 = datastring[1].Split("/");
            // Create an instance of HttpClient to make the HTTP request
            using (HttpClient client = new HttpClient())
            {
                // Serialize the data into JSON format
                string content = JsonConvert.SerializeObject(new
                {
                    flag = datastring[0], // Second part of the split data
                    empId = datastring2[0],// First part of the split data
                    empName = datastring2[1],
                    designation = datastring2[2],
                    department = datastring2[3],// A fixed parameter value

                });
                // Convert the JSON string to a byte array
                var buffer = Encoding.UTF8.GetBytes(content);
                // Create ByteArrayContent from the byte array
                var byteContent = new ByteArrayContent(buffer);
                // Set the content type to JSON
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                // Make the POST request to the API

                // Await the response
                HttpResponseMessage response2 = await client.PutAsync(ApiPath, byteContent);
                // Check if the response indicates success
                if (response2.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    // Use await to avoid blocking
                    data = response2.Content.ReadAsStringAsync().Result;
                }
            }
            // Return the response data 
            return data;
        }
        public string deleteAPIData(string datas)     //Get API Response
        {
            // Split the input string 'datas' using '$' as the delimiter
            string[] datastring = datas.Split("$");

            // Construct the API path using the second and first elements of the split array
            string ApiPath = "http://localhost:5120/api/Employee/DeleteDetails1/" + datastring[0] + "/" + datastring[1];
            // Create an instance of HttpClient to make the HTTP request
            using (var client = new HttpClient())
            {
                // Initialize a variable to hold the response data
                string data = "";
                // Set the base address of the HttpClient to the constructed API path
                client.BaseAddress = new Uri(ApiPath);
                // Make a GET request to the API and wait for the result

                HttpResponseMessage result = client.DeleteAsync(client.BaseAddress).Result;
                // Check if the response indicates success
                if (result.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    data = result.Content.ReadAsStringAsync().Result;
                    
                }
                // Return the response data 
                return data;
            }
        }
        // ------------   for image ---------------
        public IActionResult Insertimage()
        {
            return View();
        }
        public async Task<dynamic> postAPIImage(string datas)     //Get API Response
        {
            // Define the API endpoint URL
            string ApiPath = "http://localhost:5120/api/Employee/PostImage";
            // Initialize a variable to hold the response data
            var data = "";
            // Split the input string 'datas' using '$' as the delimiter
            string[] datastring = datas.Split("$");
            string[] datastring2 = datastring[1].Split("^");
            
            // Create an instance of HttpClient to make the HTTP request
            using (HttpClient client = new HttpClient())
            {
                // Serialize the data into JSON format
                string content = JsonConvert.SerializeObject(new
                {
                    flag = datastring[0], // Second part of the split data
                    id = datastring2[0],// First part of the split data
                    image = datastring2[1],
                    

                });
                // Convert the JSON string to a byte array
                var buffer = Encoding.UTF8.GetBytes(content);
                // Create ByteArrayContent from the byte array
                var byteContent = new ByteArrayContent(buffer);
                // Set the content type to JSON
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                // Make the POST request to the API

                // Await the response
                HttpResponseMessage response2 = await client.PostAsync(ApiPath, byteContent);
                // Check if the response indicates success
                if (response2.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    // Use await to avoid blocking
                    data = response2.Content.ReadAsStringAsync().Result;
                }
            }
            // Return the response data 
            return data;
        }
        public IActionResult Viewimage()
        {
            return View();
        }
        public string getAPIImage(string datas)     //Get API Response
        {
            // Split the input string 'datas' using '$' as the delimiter
            string[] datastring = datas.Split("$");

            // Construct the API path using the second and first elements of the split array
            string ApiPath = "http://localhost:5120/api/Employee/GetImage/" + datastring[0] + "/" + datastring[1] ;
            // Create an instance of HttpClient to make the HTTP request
            using (var client = new HttpClient())
            {
                // Initialize a variable to hold the response data
                string data = "";
                // Set the base address of the HttpClient to the constructed API path
                client.BaseAddress = new Uri(ApiPath);
                // Make a GET request to the API and wait for the result

                HttpResponseMessage result = client.GetAsync(client.BaseAddress).Result;
                // Check if the response indicates success
                if (result.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    data = result.Content.ReadAsStringAsync().Result;
                }
                // Return the response data 
                return data;
            }
        }

    }
}
