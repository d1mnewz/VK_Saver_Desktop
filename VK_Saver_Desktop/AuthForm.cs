﻿using System;
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
        //String folderName;

        // TODO: strong code refactoring;
        // started %) xd

        // TODO: separate files
        // done

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

        // TODO: captcha handling with new Form. 
        // DONE BUT NOT TESTED

        // TODO: add regExp for loginBox and passBox
        // DONE

        // TODO: Install Jira or similar
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
                // done, but NOT TESTED

                // maybe add while(!helper.apiInst.IsAuthorized){body}

                MessageBox.Show("Solve captcha!");
                using (CaptchaForm cf = new CaptchaForm(ex))
                {
                    cf.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (helper.apiInst.IsAuthorized)
            {
                this.SubmitButton.Enabled = false;
                this.PassBox.Text = "";
                this.LoginBox.Text = "";
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


        public bool ValidId(string text)
        {
            long tempNum = 0;
            return Int64.TryParse(text, out tempNum);

        }



        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadButton.Enabled = false;
            if (ValidId(this.IdTextBox.Text))
            {
                helper.DownLoadCollection(helper.GetSelectedColl(this.AlbumsList, Convert.ToInt64(this.IdTextBox.Text)));

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
        }

        private void CurrentTimeTimer_Tick(object sender, EventArgs e)
        {
            this.TimeLabel.Text = DateTime.Now.ToShortTimeString();
        }

        private void AlbumsList_DoubleClick(object sender, EventArgs e)
        {
            long? userID;
            if (ValidId(this.IdTextBox.Text))
            {
                userID = Convert.ToInt64(this.IdTextBox.Text);
            }
            else userID = helper.GetCurrentUserID();
            var selectedColl = helper.GetSelectedColl(this.AlbumsList, userID);
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
            

            if(ValidId(this.IdTextBox.Text))
                helper.LoadUserAlbumsToList(this.AlbumsList, Convert.ToInt64(this.IdTextBox.Text));
            else if (String.IsNullOrEmpty(this.IdTextBox.Text))
            {
                if (helper.apiInst.IsAuthorized)
                    helper.LoadUserAlbumsToList(this.AlbumsList, helper.GetCurrentUserID());
            }
            if (AlbumsList.Items.Count > 0)
            {
                DownloadButton.Enabled = true;
            }
        }
    }
}

