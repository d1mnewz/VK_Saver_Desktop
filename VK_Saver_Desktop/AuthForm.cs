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
using VkNet.Exception;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace VK_Saver_Desktop
{
    public partial class AuthForm : Form
    {
        public static ulong appId = Convert.ToUInt32(ConfigurationManager.AppSettings["appId"]);
        public static VK_Saver_Helper helper;
        public static ApiAuthParams authParams;


        // TODO: strong code refactoring;
        // started %) xd


        // TODO: goodlooking flexible UI with multiple forms
        // started

        // TODO: opportunity to save photos of other users 

        // TODO: opportunity to save photos of community albums

        // TODO: visualize thumb of every album

        // TODO: opportunity to see photos of album
        // done but not perfectly; to rework

        // TODO: create an additional VK account so user wont need to login by himself
        //              * but allow to login so user can download his private albums
        // OR to use methods that dont require auth







        // TODO: separate login and choosing user to show albums;
        // TODO: an opportunity to select user not only by long? id but by /durov like id.
        //          * maybe to use apiInst.Call() || apiInst.Execute() || api.Invoke()

        // TODO: make a presentation of this app on youtube in english
        //          * write a good text ( at some point i faced a problem blah blah blah...)
        //          * to up bandicam on home PC
        //          * to make it look and sound good.
        //

        // a radiobutton in left top that shows connection to internet.
        //          * make it async 
        //          * maybe by pinging oauth.vk.com

        public AuthForm()
        {

            InitializeComponent();
            this.CurrentTimeTimer.Start();
            helper = new VK_Saver_Helper();
            this.DownloadButton.Enabled = false;

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            authParams = new ApiAuthParams
            {
                ApplicationId = appId,
                Login = LoginBox.Text,
                Password = PassBox.Text,
                Settings = VkNet.Enums.Filters.Settings.All
            };
            try
            {
                helper.apiInst.Authorize(authParams);
            }
            catch (VkApiAuthorizationException ex)
            {
                MessageBox.Show("Invalid login&password combination. Try again.");
                this.PassBox.Text = "";
            }

            catch (CaptchaNeededException ex)
            {
                // tested works fine


                using (CaptchaForm cf = new CaptchaForm(ex))
                {
                    cf.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something bad happend. Try again.");
            }

            if (helper.apiInst.IsAuthorized)
            {
                this.SubmitButton.Enabled = false;

                this.PassBox.Text = "";
                this.LoginBox.Text = "";
                this.LoginBox.BackColor = Color.Empty;

                this.LoginBox.Enabled = false;
                this.PassBox.Enabled = false;
                this.IdTextBox.Text = helper.GetCurrentUserID().ToString();
                this.Text = String.Format(@"{0} {1}, /id{2}.",
                    helper.apiInst.Users.Get(helper.GetCurrentUserID()).FirstName,
                    helper.apiInst.Users.Get(helper.GetCurrentUserID()).LastName,
                    helper.GetCurrentUserID());
                helper.LoadUserAlbumsToList(this.AlbumsList, helper.GetCurrentUserID());
                if (this.AlbumsList.Items.Count > 0)
                    DownloadButton.Enabled = true;

            }
            else { this.Text = "VK AlbumSaver Tool"; }

        }


        public bool ValidNumberId(string text)
        {
            long tempNum = 0;
            return Int64.TryParse(text, out tempNum);

        }



        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadButton.Enabled = false;
            if (ValidNumberId(this.IdTextBox.Text))
            {
                helper.DownLoadCollection(helper.GetSelectedColl(this.AlbumsList, Convert.ToInt64(this.IdTextBox.Text)));

            }
            else
            {
                try
                {
                    helper.DownLoadCollection(helper.GetSelectedColl(this.AlbumsList, this.IdTextBox.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            DownloadButton.Enabled = true;

        }



        private void PassBox_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.LoginBox.Text))
            {
                if (!helper.IsValidMail(this.LoginBox.Text) && !helper.IsValidPhone(this.LoginBox.Text))
                {
                    this.LoginBox.BackColor = Color.Red;
                }
                else
                    this.LoginBox.BackColor = Color.White;
            }
            else this.LoginBox.BackColor = Color.White;


        }

        private void CurrentTimeTimer_Tick(object sender, EventArgs e)
        {
            this.TimeLabel.Text = DateTime.Now.ToShortTimeString();
        }


        private void AlbumsList_DoubleClick(object sender, EventArgs e)
        {
            long? userID;
            VkCollection<Photo> selectedColl = null;
            if (ValidNumberId(this.IdTextBox.Text))
            {
                userID = Convert.ToInt64(this.IdTextBox.Text);
                selectedColl = helper.GetSelectedColl(this.AlbumsList, userID);

            }
            else if (String.IsNullOrEmpty(this.IdTextBox.Text))
            {
                if (helper.apiInst.IsAuthorized)
                    helper.LoadUserAlbumsToList(this.AlbumsList, helper.GetCurrentUserID());
            }
            else
            {
                try
                {
                    selectedColl = helper.GetSelectedColl(this.AlbumsList, this.IdTextBox.Text);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }




            if (selectedColl != null)

            {

                using (PicturesOfAlbum picForm = new PicturesOfAlbum(selectedColl))
                {
                    picForm.ShowDialog();
                }

            }
        }

        private void AlbumsByUserIdButton_Click(object sender, EventArgs e)
        {
            // helper.apiInst.Users.Get(this.IdTextBox.Text).Id;


            if (ValidNumberId(this.IdTextBox.Text))
            {
                helper.LoadUserAlbumsToList(this.AlbumsList, Convert.ToInt64(this.IdTextBox.Text));
            }
            else if (String.IsNullOrEmpty(this.IdTextBox.Text))
            {
                if (helper.apiInst.IsAuthorized)
                    helper.LoadUserAlbumsToList(this.AlbumsList, helper.GetCurrentUserID());
            }
            else
            {
                try
                {
                    helper.LoadUserAlbumsToList(this.AlbumsList, this.IdTextBox.Text);
                    // LoadUserAlbumsToList is overloaded and takes (listbox, long) or (listbox, string)
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            if (AlbumsList.Items.Count > 0)
            {
                DownloadButton.Enabled = true;
            }
        }


    }
}

