using Microsoft.AspNetCore.Mvc;
using MVC_Employee.DTOs;
using MVC_Employee.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Employee.Controllers
{
    public class EmployeeNewController : Controller
    {
        public IActionResult Postemp()
        {
            return View();
        }
        public IActionResult Getemp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> postAPIData([FromBody] EmployeePostReqModel employeePostReq) // Get API Response
        {
            // Define the API endpoint URL
            string ApiPath = "https://localhost:7057/api/Employee/PostDetails2/";

            // Initialize a variable to hold the response data
            var data = "";

            // Create an instance of HttpClient to make the HTTP request
            using (HttpClient client = new HttpClient())
            {
                // Serialize the data into JSON format
                string content = JsonConvert.SerializeObject(employeePostReq);

                // Convert the JSON string to a byte array
                var buffer = Encoding.UTF8.GetBytes(content);

                // Create ByteArrayContent from the byte array
                var byteContent = new ByteArrayContent(buffer);

                // Set the content type to JSON
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                // Make the POST request to the API
                HttpResponseMessage response2 = await client.PostAsync(ApiPath, byteContent);

                // Check if the response indicates success
                if (response2.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    data = await response2.Content.ReadAsStringAsync();
                    return Ok(data); // Return the response data
                }
            }
            return BadRequest("Error occurred while inserting employee data."); // Return an error response
        }

        public List<EmployeeRespModel> getAPIData(string datas) // Get API Response
        {
            // Split the input string 'datas' using '$' as the delimiter
            string[] datastring = datas.Split("$");

            // Construct the API path using the second and first elements of the split array
            string ApiPath = "https://localhost:7057/api/Employee/GetDetails2/" + datastring[0] + "/" + datastring[1] + "/1";

            using (var client = new HttpClient())
            {
                // Make a GET request to the API and wait for the result
                HttpResponseMessage result = client.GetAsync(ApiPath).Result;

                // Check if the response indicates success
                if (result.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    var data = result.Content.ReadAsStringAsync().Result;

                    // Deserialize the JSON response into a list of EmployeeRespDto
                    var employee = JsonConvert.DeserializeObject<List<EmployeeRespModel>>(data);
                    return employee;
                }
            }
            return null; // Return null if the request fails
        }


    }
}
