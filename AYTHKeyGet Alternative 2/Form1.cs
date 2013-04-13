using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AYTHKeyGet_Alternative_2
{
    public partial class frmBrowser : Form
    {
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookie(string lpszUrl, string lpszCookieName,
            StringBuilder lpszCookieData, ref int lpdwSize);

        private string authToken = "";  // authToken in HTTP headers
        private string rdk_uid = "";    // rdk_uid in cookies

        const string cPlayerURL = "http://radiko.jp/player/player.html#TBS";    // radiko player URL for authentication
        const string cAuth2URL = "https://radiko.jp/v2/api/auth2_fms";  // final authentication URL
        const string cAuthTokenHeader = "x-radiko-authtoken";   // http header of authentication token

        public frmBrowser()
        {
            InitializeComponent();
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            // Navigate to player for authentication
            this.browserEx.Navigate(cPlayerURL);
        }

        /* *****************************************************
         * OnResponse Event
         * 
         * Purpose:
         * 1. Find authToken in http headers
         * 2. Investigate when to close application
         * *****************************************************/
        private void browserEx_ProtocolHandlerOnResponse(object sender, csExWB.ProtocolHandlerOnResponseEventArgs e)
        {
            Console.WriteLine("Event: OnResponse");
            Console.WriteLine("URL: {0}", e.URL);

            // Split by \r\n and put headers into array
            string[] headers = e.ResponseHeaders.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Scanning http headers...");

            // Scan headers to find authToken
            foreach (string header in headers)
            {
                Console.WriteLine(header);
                if (authToken.Length == 0)  // Skip if found already
                {
                    string[] headerPair = header.Split(new char[] { ':' }); // Split header to key and value
                    if (headerPair.Length == 2)
                    {
                        string headerKey = headerPair[0].Trim().ToLower();  // http header key
                        string headerValue = headerPair[1].Trim();  // http header value

                        if (headerKey == cAuthTokenHeader)
                        {
                            // authToken found
                            authToken = headerValue;
                            Console.WriteLine("[Found authToken: {0}]", authToken);
                            break;
                        }
                    }
                }
                else if (e.URL.ToLower().Contains(cAuth2URL) && header.ToLower().Contains("200 ok"))    // If you successfully authenticated
                {
                    Console.WriteLine("[Successfully authenticated]");

                    // Close application
                    this.Close();
                    break;
                }
            }
        }

        /* *****************************************************
         * BeginTransacion Event (On Request)
         * 
         * Purpose:
         * 1. Find rdk_id in cookie
         * *****************************************************/
        private void browserEx_ProtocolHandlerBeginTransaction(object sender, csExWB.ProtocolHandlerBeginTransactionEventArgs e)
        {
            Console.WriteLine("Event: BeginTransaction");
            Console.WriteLine("URL: {0}", e.URL);

            if (rdk_uid.Length == 0)    // Skip if rdk_id found already
            {
                // Get cookies
                int size = 0;
                InternetGetCookie("http://radiko.jp/", null, null, ref size);   // Find out size of cookies
                StringBuilder cookieBuffer = new StringBuilder(size);   // Allocate buffer
                InternetGetCookie("http://radiko.jp/", null, cookieBuffer, ref size);   // Get cookies

                // Split cookie string and put them into array
                string[] cookies = cookieBuffer.ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine("Scanning cookies...");

                // Scan cookies
                foreach (string cookie in cookies)
                {
                    Console.WriteLine(cookie);
                    string[] cookiePair = cookie.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);  // Split cookie to key and value
                    if (cookiePair.Length == 2)
                    {
                        string cookieKey = cookiePair[0].Trim().ToLower();  // cookie key
                        string cookieValue = cookiePair[1].Trim();  // cookie value

                        if (cookieKey == "rdk_uid")
                        {
                            // rdk_uid found
                            rdk_uid = cookieValue;
                            Console.WriteLine("[Found rdk_uid: {0}]", rdk_uid);
                            break;
                        }
                    }
                }
            }
        }

        private void frmBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This is what I want
            Console.WriteLine("{0},{1}", authToken, rdk_uid);
        }
    }
}
