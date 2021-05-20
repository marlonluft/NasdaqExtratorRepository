using Microsoft.Extensions.Logging;
using NasdaqExtrator.Core.Constants;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Calendar = NasdaqExtrator.Core.DTO.Calendar;
using Dividends = NasdaqExtrator.Core.DTO.Quote.Dividends;
using Info = NasdaqExtrator.Core.DTO.Quote.Info;

namespace NasdaqExtrator.Core.External
{
    public class NasdaqAPIExternal : INasdaqAPIExternal
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;
        private readonly ILogger<NasdaqAPIExternal> _logger;

        public NasdaqAPIExternal(IHttpClientFactory clientFactory, ILogger<NasdaqAPIExternal> logger)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient(HttpClientNameConstant.NASDAQ_API);
            _logger = logger;
        }

        public async Task<Calendar.DividendsDTO> GetDividends(DateTime date)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/calendar/dividends?date={date:yyyy-MM-dd}");
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "PostmanRuntime/7.26.8");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<Calendar.DividendsDTO>(responseStream);
                }
            }
            else
            {
                _logger.LogError("Falha ao realizar a listagem de dados");
            }

            return null;
        }

        public async Task<Info.InfoDTO> GetStockInfo(string stock)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/quote/{stock}/info?assetclass=stocks");
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "PostmanRuntime/7.26.8");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<Info.InfoDTO>(responseStream);
                }
            }
            else
            {
                _logger.LogError("Falha ao realizar a consulta de dados");
            }

            return null;
        }

        public async Task<Dividends.QuoteDividendsDTO> GetStockDividends(string stock)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/quote/{stock}/dividends?assetclass=stocks");
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "PostmanRuntime/7.26.8");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<Dividends.QuoteDividendsDTO>(responseStream);
                }
            }
            else
            {
                _logger.LogError("Falha ao realizar a consulta de dados");
            }

            return null;
        }
    }
}
