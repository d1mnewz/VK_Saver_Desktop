﻿using System;
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
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace VK_Saver_Desktop
{
    public class VK_Saver_Helper
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

                        client.DownloadFile(new Uri(GetPhotoSrcLink(el)),
                                                            String.Format(@"{0}\n{1}.jpg ", folderName, el.Id));

                 
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
        public PhotoAlbum GetSelectedAlbum(ListBox list)
        {
            var selected = list.Items[list.SelectedIndex].ToString();
            var listAlbums = this.apiInst.Photo.GetAlbums(new PhotoGetAlbumsParams { OwnerId = this.GetCurrentUserID() });
            switch (selected)
            {

                default:
                    return listAlbums.First(x => x.Title == selected);
            }

            // return this.apiInst.Photo.GetAlbums(new PhotoGetAlbumsParams { OwnerId = this.GetCurrentUserID() });
        }
        public String GetPhotoSrcLink(Photo ph)
        {
            if (ph.Photo2560 != null)
            {

                return ph.Photo2560.ToString();


            }
            else if (ph.Photo1280 != null)
            {
                return ph.Photo1280.ToString();


            }
            else if (ph.Photo807 != null)
            {
                return ph.Photo807.ToString();

            }
            else if (ph.Photo604 != null)
            {
                return ph.Photo604.ToString();

            }
            else if (ph.Photo130 != null)
            {
                return ph.Photo130.ToString();


            }
            else if (ph.Photo75 != null)
            {

                return ph.Photo75.ToString();

            }
            else return null;
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
        public bool IsValidPhone(string phone)
        {
            return Regex.Match(phone, @"^((\+\d{3})|(\d{3}))\d{9,10}$").Success;
            // explained https://regex101.com/r/EUUely/3 

        }
        public bool IsValidMail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


    }





}
