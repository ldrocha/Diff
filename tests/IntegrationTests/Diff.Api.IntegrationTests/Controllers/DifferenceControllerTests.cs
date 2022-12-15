using System;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Diff.ApplicationCore.Enums;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Diff.ApplicationCore.Services;
using Diff.Helpers.AutoData;
using Diff.Infrastructure.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Diff.Api.IntegrationTests.Controllers
{
	public class DifferenceControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public DifferenceControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Theory]
        [InlineData("111")]
        [InlineData("222")]
        [InlineData("333")]
        public async Task Get_WhenDataToCompareDoNotExist_ShouldReturnNotFound(string id)
        {
            var response = await _client.GetAsync($"/v1/diff/{id}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("123", DifferenceStatus.Equal)]
        [InlineData("456", DifferenceStatus.DifferentLength)]
        [InlineData("789", DifferenceStatus.SameLength)]
        public async Task Get_WhenDataExists_ShouldReturnResponse(string id, DifferenceStatus status)
        {
            var response = await _client.GetAsync($"/v1/diff/{id}");

            var responseBody = await response.Content.ReadFromJsonAsync<DifferenceResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseBody?.Id.Should().Be(id);
            responseBody?.Status.Should().Be(status);
        }

        [Theory]
        [InlineData("111")]
        [InlineData("222")]
        [InlineData("333")]
        public async Task GetLeft_WhenDataDoNotExist_ShouldReturnNotFound(string id)
        {
            var response = await _client.GetAsync($"/v1/diff/{id}/left");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("123", "MTIzIDEyMyAxMjMgMTIzIDEyMw==")]
        [InlineData("456", "NDU2IDQ1NiA0NTYgNDU2IDQ1Ng==")]
        [InlineData("789", "Nzg5IDc4OSA3ODkgNzg5IDc4OQ==")]
        public async Task GetLeft_WhenDataExists_ShouldReturnResponse(string id, string data)
        {
            var response = await _client.GetAsync($"/v1/diff/{id}/left");

            var responseBody = await response.Content.ReadFromJsonAsync<LeftBase64EncodedBinaryResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseBody?.Id.Should().Be(id);
            responseBody?.Data.Should().Be(data);
        }

        [Theory]
        [InlineData("111")]
        [InlineData("222")]
        [InlineData("333")]
        public async Task GetRight_WhenDataDoNotExist_ShouldReturnNotFound(string id)
        {
            var response = await _client.GetAsync($"/v1/diff/{id}/right");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("123", "MTIzIDEyMyAxMjMgMTIzIDEyMw==")]
        [InlineData("456", "NDU2IDQ1NiA0NTYgNDU2IA==")]
        [InlineData("789", "Nzg5IDc4OSAwMDAgNzg5IDAwMA==")]
        public async Task GetRight_WhenDataExists_ShouldReturnResponse(string id, string data)
        {
            var response = await _client.GetAsync($"/v1/diff/{id}/right");

            var responseBody = await response.Content.ReadFromJsonAsync<RightBase64EncodedBinaryResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseBody?.Id.Should().Be(id);
            responseBody?.Data.Should().Be(data);
        }

        [Theory]
        [InlineData("777", "Hello World")]
        public async Task PutLeft_WhenNotValidData_ShouldReturnBadRequest(string id, string data)
        {
            var request = new LeftBase64EncodedBinaryRequest { Data = data };

            var response = await _client.PutAsJsonAsync($"/v1/diff/{id}/left", request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("999", "MTIzIDEyMyAxMjMgMTIzIDEyMw==")]
        public async Task PutLeft_WhenValidData_ShouldSaveAndReturnResponse(string id, string data)
        {
            var request = new LeftBase64EncodedBinaryRequest { Data = data };

            var response = await _client.PutAsJsonAsync($"/v1/diff/{id}/left", request);

            var responseBody = await response.Content.ReadFromJsonAsync<LeftBase64EncodedBinaryResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            responseBody?.Id.Should().Be(id);
            responseBody?.Data.Should().Be(data);
        }

        [Theory]
        [InlineData("777", "Hello World")]
        public async Task PutRight_WhenNotValidData_ShouldReturnBadRequest(string id, string data)
        {
            var request = new RightBase64EncodedBinaryRequest { Data = data };

            var response = await _client.PutAsJsonAsync($"/v1/diff/{id}/left", request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("999", "MTIzIDEyMyAxMjMgMTIzIDEyMw==")]
        public async Task PutRight_WhenValidData_ShouldSaveAndReturnResponse(string id, string data)
        {
            var request = new RightBase64EncodedBinaryRequest { Data = data };

            var response = await _client.PutAsJsonAsync($"/v1/diff/{id}/left", request);

            var responseBody = await response.Content.ReadFromJsonAsync<RightBase64EncodedBinaryResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            responseBody?.Id.Should().Be(id);
            responseBody?.Data.Should().Be(data);
        }
    }
}