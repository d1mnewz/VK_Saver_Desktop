using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using System.Configuration;
using VkNet.Model.RequestParams;
using System.Net;
using VkNet.Utils;
using System.IO;
using VkNet.Model;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

namespace VK_Saver_Desktop
{
    public partial class Form1 : Form
    {
        public ulong appId = Convert.ToUInt32(ConfigurationManager.AppSettings["appId"]);
        VkApi api;
        String folderName;
        public Form1()
        {

            InitializeComponent();
            api = new VkApi();


        }
        private void LoadAlbums()
        {
            var list = api.Photo.GetAlbums(new PhotoGetAlbumsParams { OwnerId = api.UserId });
            this.AlbumsList.Items.Add("Profile");
            this.AlbumsList.Items.Add("Wall");
            this.AlbumsList.Items.Add("Saved");
            foreach (var el in list)
            { this.AlbumsList.Items.Add(el.Title); }
           
            this.AlbumsList.Enabled = true;

        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {


            api.Authorize(new ApiAuthParams
            {
                ApplicationId = appId,
                Login = LoginBox.Text,
                Password = PassBox.Text,
                Settings = VkNet.Enums.Filters.Settings.All
            });
            
            if (api.IsAuthorized)
            {
                this.SubmitButton.Enabled = false;
                MessageBox.Show(api.UserId.ToString());
                LoadAlbums();
                

            }

        }
        VkCollection<Photo> GetAlbumAsCollection(PhotoAlbum album)
        {
            folderName = FolderCheck(album.Title.ToString(), album.OwnerId.ToString());

            return api.Photo.Get(new PhotoGetParams { OwnerId = album.OwnerId, AlbumId = PhotoAlbumType.Id(album.Id) });

        }
        void DownLoadCollection(VkCollection<Photo> list)
        {
            
            using (WebClient client = new WebClient())
            {

                int count = 0;

                foreach (var el in list)
                {
                    if (el.Photo2560 != null)
                    {

                        client.DownloadFile(new Uri(el.Photo2560.ToString()),
                                                            String.Format(@"{0}\n{1}.jpg ", folderName, el.Id));

                    }
                    else if (el.Photo1280 != null)
                    {
                        client.DownloadFile(new Uri(el.Photo1280.ToString()),
                                            String.Format(@"{0}\n{1}.jpg ", folderName, el.Id));

                    }
                    else if (el.Photo807 != null)
                    {
                        client.DownloadFile(new Uri(el.Photo807.ToString()),
                                String.Format(@"{0}\n{1}.jpg ", folderName, el.Id));
                    }
                    else if (el.Photo604 != null)
                    {
                        client.DownloadFile(new Uri(el.Photo604.ToString()),
                                     String.Format(@"{0}\n{1}.jpg ", folderName, el.Id));

                    }
                    else if (el.Photo130 != null)
                    {
                        client.DownloadFile(new Uri(el.Photo130.ToString()),
                                    String.Format(@"{0}\n{1}.jpg ", folderName, el.Id));

                    }
                    else if (el.Photo75 != null)
                    {
                        client.DownloadFile(
                            new Uri(el.Photo75.ToString()),
                           String.Format(@"{0}\n{1}.jpg ", folderName, el.Id));
                    }
                    count++;
                    CountLabel.Text = String.Format("{0}/{1}", count, list.TotalCount);
                }
            }
        }
        
        String FolderCheck(string AlbumId, string UserId)
        {



            string folderName = UserId;
            bool exists = System.IO.Directory.Exists(folderName);

            if (!Directory.Exists(folderName))
                System.IO.Directory.CreateDirectory(folderName);
            folderName += @"\" + AlbumId;
            if(!Directory.Exists(folderName))
                System.IO.Directory.CreateDirectory(folderName);
            return folderName;
            //MessageBox.Show(api.Users.Get((long)api.UserId).FirstName);
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadButton.Enabled = false;
            var selected = AlbumsList.Items[AlbumsList.SelectedIndex].ToString();
            var listAlbums = api.Photo.GetAlbums(new PhotoGetAlbumsParams { OwnerId = api.UserId });
            VkCollection<Photo> exactColl;
            if (selected == "Saved")
            {
            
                exactColl = api.Photo.Get(new PhotoGetParams { AlbumId = PhotoAlbumType.Saved, OwnerId = api.UserId });
                folderName = FolderCheck("Saved", exactColl[0].OwnerId.ToString());                
                //folderName = FolderCheck(exactColl[0]Title.ToString(), album.OwnerId.ToString());

            }

            else if (selected == "Wall")
            {
                exactColl = api.Photo.Get(new PhotoGetParams { AlbumId = PhotoAlbumType.Wall, OwnerId = api.UserId });
                folderName = FolderCheck("Wall", exactColl[0].OwnerId.ToString());

            }
            else if (selected == "Profile")
            {
                exactColl = api.Photo.Get(new PhotoGetParams { AlbumId = PhotoAlbumType.Profile, OwnerId = api.UserId });
                folderName = FolderCheck("Profile", exactColl[0].OwnerId.ToString());

            }
            else
                exactColl = GetAlbumAsCollection(listAlbums.First(x => x.Title == selected));
            
            DownLoadCollection(exactColl);
            DownloadButton.Enabled = true;

        }
    }
}

