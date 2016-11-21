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

namespace VK_Saver_Desktop
{
    public partial class AuthForm : Form
    {
        public ulong appId = Convert.ToUInt32(ConfigurationManager.AppSettings["appId"]);
        VK_Saver_Helper helper;
        String folderName;

        // TODO: strong code refactoring;
        // TODO: separate files
        // TODO: goodlooking flexible UI with multiple forms
        // TODO: opportunity to save photos of other users 
        // TODO: opportunity to save photos of community albums
        // TODO: visualize thumb of every album
        // TODO: opportunity to see photos of album
        // TODO: create an additional VK account so user wont need to login by himself
        //              * but allow to login so user can download his private albums
        // TODO: captcha handling with new Form.
        // TODO: add regExp for loginBox and passBox

        public AuthForm()
        {

            InitializeComponent();
            helper = new VK_Saver_Helper();
            this.DownloadButton.Enabled = false;

        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {

            ApiAuthParams authParams = new ApiAuthParams
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
            catch (CaptchaNeededException ex)
            {
                // create new form with picturebox(ex.img.absoluteUri) and textBox to type in captchaKey
                // repeat while captchakey != true captchaKey
                
                MessageBox.Show(ex.Img.AbsoluteUri + ex.Img.UserInfo);
                var request = WebRequest.Create(ex.Img.AbsoluteUri);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    CaptchBox.Image = Bitmap.FromStream(stream);
                }
                CaptchaTextBox.Visible = true;
               //helper.apiInst.Authorize()
               //Button on click 
                 helper.apiInst.Authorize((int)authParams.ApplicationId, authParams.Login, authParams.Password, authParams.Settings,null , ex.Sid, this.CaptchaTextBox.Text);
                //this.CaptchBox.ImageLocation = ex.Img.AbsolutePath;
                //this.CaptchBox.Load();
            }

            if (helper.apiInst.IsAuthorized)
            {
                this.SubmitButton.Enabled = false;
                MessageBox.Show(helper.GetCurrentUserID().ToString());
                helper.LoadUserAlbumsToList(this.AlbumsList);
                if (this.AlbumsList.Items.Count > 0)
                    DownloadButton.Enabled = true;

            }

        }





        
        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadButton.Enabled = false;
            
            helper.DownLoadCollection(helper.GetSelectedColl(this.AlbumsList));
            DownloadButton.Enabled = true;

        }

       
    }
}

