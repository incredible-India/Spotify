using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Spotify
{
    public partial class MyToolWindowControl : UserControl
    {
        public MyToolWindowControl()
        {
            InitializeComponent();
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            Random rnd = new Random();
            string subFolder = rnd.Next().ToString();
            var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder: Path.Combine(Path.GetTempPath(), $"{Environment.UserName}", subFolder));
            await Spotify.EnsureCoreWebView2Async(env);
            var request = Spotify.CoreWebView2.Environment.CreateWebResourceRequest("https://open.spotify.com/", "GET", null, null);
            Spotify.CoreWebView2.NavigateWithWebResourceRequest(request);
        }
    }
}