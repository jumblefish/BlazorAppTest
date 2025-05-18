
Explanation:

using NUnit.Framework; and using System.Net.Http; and using System.Threading.Tasks;: These lines import the necessary namespaces for NUnit testing, making HTTP requests, and using asynchronous operations.
[TestFixture]: This attribute marks the WebsiteStatusCodeTests class as a container for NUnit test methods.
[Test]: This attribute marks each method (GetStatusCodeFromWebsite, GetSpecificStatusCodeFromWebsite, GetNotFoundStatusCode) as an individual test case.
async Task ...(): The test methods are asynchronous to allow non-blocking HTTP requests.
string url = "...": Defines the URL of the website to test. Remember to replace "https://www.example.com" with the actual URL you want to test.
using (HttpClient client = new HttpClient()): Creates an instance of HttpClient. The using statement ensures that the HttpClient's resources are properly disposed of after use.
HttpResponseMessage response = await client.GetAsync(url);: This line sends an asynchronous GET request to the specified URL. The await keyword pauses the execution of the test method until the response is received.
Assert.IsTrue(response.IsSuccessStatusCode, ...): This assertion checks if the HTTP response status code indicates success (e.g., 2xx). The second argument provides a message that will be displayed if the assertion fails.
Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, ...): This assertion checks if the received status code is equal to the expected HttpStatusCode.OK (200). You can change HttpStatusCode.OK to other expected status codes like HttpStatusCode.NotFound, HttpStatusCode.BadRequest, etc.
TestContext.WriteLine(...): This allows you to write output to the NUnit test runner's console.
try...catch (HttpRequestException ex): This block handles potential exceptions that might occur during the HTTP request (e.g., network issues). If an exception occurs, the test will fail with an informative message.
To use this test case:

Make sure you have the NUnit3TestAdapter and NUnit NuGet packages installed in your C# project.
Replace "https://www.example.com" in the first test with the URL you want to primarily test for a successful response.
Run the tests using your preferred NUnit test runner (e.g., Visual Studio Test Explorer, NUnit Console Runner).
The tests will attempt to make GET requests to the specified URLs and assert the resulting HTTP status codes.
