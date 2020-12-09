using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace MMSSender
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ButtonShare_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            Image img = new Image();
            System.IO.Stream stream = await client.GetStreamAsync("https://prolist.net.au/WebServices/AgentFileService.asmx/PublicDownload?id=30fe9a79-ea96-46a7-8399-7737bd0bf323&inline=true");
            img.Source = ImageSource.FromStream(() => stream);
            string tempFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "imagedata.tmp");
            var fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write);

            using (fileStream)
                {
                stream.CopyTo(fileStream);
                }

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = EntryShare.Text,
                Title = "Share!"
            }) ;

            await Share.RequestAsync(new ShareFileRequest
            {
                File = new ShareFile(tempFile)
            }); ;

        }

        private async void ImageShare_Clicked(object sender, EventArgs e)
        {

            await Task.Run(async () => {

                HttpClient client = new HttpClient();
                Image img = new Image();
                System.IO.Stream stream = await client.GetStreamAsync("https://prolist.net.au/WebServices/AgentFileService.asmx/PublicDownload?id=30fe9a79-ea96-46a7-8399-7737bd0bf323&inline=true");
                img.Source = ImageSource.FromStream(() => stream);
                string tempFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "imagedata.tmp");
                var fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write);

                using (fileStream)
                {
                    stream.CopyTo(fileStream);
                }
                await Share.RequestAsync(new ShareFileRequest
                {
                    File = new ShareFile(tempFile)
                }); ;

            });

        }
    }
}
