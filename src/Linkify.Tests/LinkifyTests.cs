using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linkify.Tests
{
    [TestClass]
    public class LinkifyTests
    {
        [TestMethod]
        public void Sample()
        {
            string url = @"Hi, I am bhushan. Here are my links:

google.com
www.google.com
http://google.com
http://www.google.com
https://google.com
https://www.google.com
http://google.com/images/1
http://google.com?product=1
www.google.com:91
http://google.com:80
http://www.google.com:91/images/fdsfdsgfds?cached=false
";
            string output = url.Linkify();
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void Prepend()
        {
            string url = @"Hi, I am bhushan. Here are my links:

google.com
www.google.com
http://google.com
http://www.google.com
https://google.com
https://www.google.com
http://google.com/images/1
http://google.com?product=1
www.google.com:91
http://google.com:80
http://www.google.com:91/images/fdsfdsgfds?cached=false
";
            string output = url.Linkify(new LinkifyConfig
            {
                UrlPrependedText = "http://tracker.test.com?sample=1&url=",
                ReplaceNewLineWithBr = true
            });
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void ContainsUrl()
        {
            string url = @"Hi, I am bhushan. Here are my links:

co.za
my.salesforce.edu
google.com
www.google.com
http://google.com
http://www.google.com
https://google.com
https://www.google.com
http://google.com/images/1
http://google.com?product=1
www.google.com:91
http://google.com:80
http://www.google.com:91/images/fdsfdsgfds?cached=false
";
            var matches = Regex.Matches(url, "([a-zA-Z0-9]+://)?([a-zA-Z0-9_]+:[a-zA-Z0-9_]+@)?([a-zA-Z0-9.-]+\\.[A-Za-z]{2,4})(:[0-9]+)?(/.*)?");
            foreach (var match in matches)
            {
                string matchedValue = match.ToString();
                int i = 0;
            }
        }
    }
}
