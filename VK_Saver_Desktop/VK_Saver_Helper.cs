using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using System.Windows.Forms;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using VkNet.Model;
using VkNet.Model.Attachments;
using System.IO;
using VkNet.Enums.SafetyEnums;
using System.Net;

namespace VK_Saver_Desktop
{
    class VK_Saver_Helper
    {
        public VkApi apiInst;
        String folderName;
        public VK_Saver_Helper()
        {
            apiInst = new VkApi();
        }
        public void DownLoadCollection(VkCollection<Photo> list)
        {

            using (WebClient client = new WebClient())
            {

                //int count = 0;

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
                    //count++;
                    //CountLabel.Text = String.Format("{0}/{1}", count, list.TotalCount);
                }
            }
        }
        public long GetCurrentUserID()
        {
            if (apiInst.IsAuthorized)
                return (long)apiInst.UserId;
            else return 0;
        }
        public VkCollection<PhotoAlbum> GetCurrUserAlbumsAsColl()
        {
            return this.apiInst.Photo.GetAlbums(new PhotoGetAlbumsParams { OwnerId = this.GetCurrentUserID() });
        }
        public VkCollection<Photo> GetSelectedColl(ListBox list)
        {

            var selected = list.Items[list.SelectedIndex].ToString();
            var listAlbums = this.GetCurrUserAlbumsAsColl();
            VkCollection<Photo> exactColl;
            if (selected == "Saved")
            {

                exactColl = this.apiInst.Photo.Get(new PhotoGetParams { AlbumId = PhotoAlbumType.Saved, OwnerId = this.GetCurrentUserID() });
                folderName = this.FolderCheck("Saved", exactColl[0].OwnerId.ToString());


            }

            else if (selected == "Wall")
            {
                exactColl = this.apiInst.Photo.Get(new PhotoGetParams { AlbumId = PhotoAlbumType.Wall, OwnerId = this.GetCurrentUserID() });
                folderName = this.FolderCheck("Wall", exactColl[0].OwnerId.ToString());

            }
            else if (selected == "Profile")
            {
                exactColl = this.apiInst.Photo.Get(new PhotoGetParams { AlbumId = PhotoAlbumType.Profile, OwnerId = this.GetCurrentUserID() });
                folderName = this.FolderCheck("Profile", exactColl[0].OwnerId.ToString());

            }
            else
                exactColl = this.GetAlbumAsCollection(listAlbums.First(x => x.Title == selected));
            return exactColl;

        }
        public String FolderCheck(string AlbumId, string UserId)
        {



            //string folderName = UserId;
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + UserId;

            bool exists = System.IO.Directory.Exists(folderName);

            if (!Directory.Exists(folderName))
                System.IO.Directory.CreateDirectory(folderName);
            folderName += @"\" + AlbumId;
            if (!Directory.Exists(folderName))
                System.IO.Directory.CreateDirectory(folderName);
            return folderName;
            //MessageBox.Show(api.Users.Get((long)api.UserId).FirstName);
        }
        public VkCollection<Photo> GetAlbumAsCollection(PhotoAlbum album)
        {
            folderName = FolderCheck(album.Title.ToString(), album.OwnerId.ToString());

            return this.apiInst.Photo.Get(new PhotoGetParams { OwnerId = album.OwnerId, AlbumId = PhotoAlbumType.Id(album.Id) });

        }



        public void LoadUserAlbumsToList(ListBox list)
        {
            var listOfAlbums = apiInst.Photo.GetAlbums(new PhotoGetAlbumsParams { OwnerId = this.GetCurrentUserID() });
            list.Items.Add("Profile");
            list.Items.Add("Wall");
            list.Items.Add("Saved");
            foreach (var el in listOfAlbums)
            {
                list.Items.Add(el.Title);
            }

            list.Enabled = true;

        }


    }





}
