using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace wpf_threading
{
    internal class WebCrawler
    {
        private string currentUrl;

        public WebCrawler(string startUrl) { 
            currentUrl = startUrl;
        }

        public async Task Run()
        {
            for(int i = 0; i < 10; i++)
            {
                HttpClient client = new HttpClient();
                string s = client.GetAsync(currentUrl).Result.Content.ReadAsStringAsync().Result;

                HtmlParser parser = new HtmlParser(s);
                if (parser.IsValidHtml())
                {

                }

                currentUrl = newUrl;
            }
            //<a class="bla" href="https://www.htlwy.at">Click mal</a>
        }
    }
}
