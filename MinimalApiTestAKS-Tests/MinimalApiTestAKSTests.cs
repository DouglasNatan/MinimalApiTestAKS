using MinimalApiTestAKS.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using Microsoft.Net.Http.Headers;

namespace MinimalApiTestAKS_Tests
{
    public class MinimalApiTestAKSTests
    {
        [Fact]
        public async Task CreatingATodoItemShouldReturnIt()
        {
            // Arrange

            var payload = new Todo(new Random(0).Next(), "Teste Douglas", false);
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            HttpContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/todotest", content);
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}