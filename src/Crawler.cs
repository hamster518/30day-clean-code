using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluent.Sync;
namespace Ithome.IronMan.Example
{

    using Fluent.Async;
    public class Crawler : ICrawler
    {
        private IHttpClient _http;
        private IHtmlLoader _html;

        public Crawler(IHttpClient http,IHtmlLoader html)
        {
            this._http = http;
            this._html = html;
        }
        
        /// <summary>
        /// 依照提供的Request定義 => Action<HttpRequestMessage>
        /// 以非同步方式取得 　　　=> GetAsync
        /// Html物件序列          => IEnumerable<HtmlElement>
        /// </summary>
        /// <param name="config">Action[HttpRequestMessage]</param>
        /// <returns>IEnumerable[HtmlElement]</returns>
        public Task<IEnumerable<HtmlElement>> GetAsync(Action<HttpRequestMessage> config)
            => Chain.Create(CreateRequest(config))
            // IChain<HttpRequestMessage>.ThenAsync<Task<HttpResponseMessage>>
            .Then(SendAsync)
            // IChainAsync<HttpResponseMessage>.WaitThen<Task<Stream>>
            .Then(GetContentAsync)
            // IChainAsync<Stream>.Then<IEnumerable<HtmlElement>>
            .Then(LoadHtml)
            // Result = Task<IEnumerable<HtmlElement>>
            .Result;
        
        /// <summary>
        /// 建立並設定 Request
        /// </summary>
        /// <param name="factory">request factory</param>
        /// <param name="config">request config</param>
        /// <returns>requets</returns>
        private HttpRequestMessage CreateRequest(Action<HttpRequestMessage> config)
        {
            var req = new HttpRequestMessage();
            config(req);
            return req;
        }

        /// <summary>
        /// 送出request
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>response</returns>
        private Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => _http.SendAsync(request);

        /// <summary>
        /// 從response 中取得 content stream
        /// </summary>
        /// <param name="response">response</param>
        /// <returns>stream</returns>
        private Task<Stream> GetContentAsync(HttpResponseMessage response)
            => response.EnsureSuccessStatusCode().Content.ReadAsStreamAsync();

        /// <summary>
        /// 從 stream 中取得 html
        /// </summary>
        /// <param name="stream">stream</param>
        /// <returns>html structures</returns>
        private IEnumerable<HtmlElement> LoadHtml(Stream stream)
            => _html.Load(stream).Select(node => new HtmlElement(node));
    }
}
