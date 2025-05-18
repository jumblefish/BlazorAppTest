using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

[TestFixture]
public class WebsiteStatusCodeTests
{
    [Test]
    public async Task GetStatusCodeFromWebsite()
    {
        // Arrange
        string url = "https://www.example.com"; // Replace with the target URL
        using (HttpClient client = new HttpClient())
        {
            // Act
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                // Assert
                Assert.IsTrue(response.IsSuccessStatusCode, $"Expected a successful status code, but got {response.StatusCode}");
                TestContext.WriteLine($"Successfully retrieved status code: {response.StatusCode} from {url}");
            }
            catch (HttpRequestException ex)
            {
                Assert.Fail($"An error occurred during the request: {ex.Message}");
            }
        }
    }

    [Test]
    public async Task GetSpecificStatusCodeFromWebsite()
    {
        // Arrange
        string url = "https://httpbin.org/status/200"; // A URL that reliably returns 200 OK
        using (HttpClient client = new HttpClient())
        {
            // Act
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                // Assert
                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, $"Expected status code OK (200), but got {response.StatusCode}");
                TestContext.WriteLine($"Successfully retrieved expected status code: {response.StatusCode} from {url}");
            }
            catch (HttpRequestException ex)
            {
                Assert.Fail($"An error occurred during the request: {ex.Message}");
            }
        }
    }

    [Test]
    public async Task GetNotFoundStatusCode()
    {
        // Arrange
        string url = "https://www.example.com/nonexistentpage"; // Likely to return 404
        using (HttpClient client = new HttpClient())
        {
            // Act
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                // Assert
                Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode, $"Expected status code NotFound (404), but got {response.StatusCode}");
                TestContext.WriteLine($"Successfully retrieved expected status code: {response.StatusCode} from {url}");
            }
            catch (HttpRequestException ex)
            {
                Assert.Fail($"An error occurred during the request: {ex.Message}");
            }
        }
    }
}
