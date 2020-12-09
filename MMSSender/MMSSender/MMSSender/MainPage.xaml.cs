using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
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
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = EntryShare.Text,
                Title = "Share"
            });
        }

        private async void ShareUri(object sender, EventArgs e)
        {
            string url = "https://prolist.net.au/WebServices/AgentFileService.asmx/PublicDownload?id=30fe9a79-ea96-46a7-8399-7737bd0bf323&inline=true";

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "imagedata.tmp");



            await Share.RequestAsync(new ShareFileRequest
            {
                Title = Title,
                //This crashes
                File = new ShareFile("https://prolist.net.au/WebServices/AgentFileService.asmx/PublicDownload?id=30fe9a79-ea96-46a7-8399-7737bd0bf323&inline=true")
            });
        }


    }
}
