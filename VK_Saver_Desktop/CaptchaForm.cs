using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Exception;

namespace VK_Saver_Desktop
{
    // TO TEST!!!
    public partial class CaptchaForm : Form
    {
        CaptchaNeededException usedException;
        public CaptchaForm(CaptchaNeededException ex)
        {
            InitializeComponent();
            this.usedException = ex;
            this.CaptchaPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            LoadCaptcha();

            //this.CaptchaPictureBox.
        }
        private void LoadCaptcha()
        {
            var request = WebRequest.Create(usedException.Img.AbsoluteUri);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                this.CaptchaPictureBox.Image = Bitmap.FromStream(stream);
            }
            CaptchaTextBox.Visible = true;
        }
        public String GetCaptchaKey()
        {

            return this.CaptchaTextBox.Text;
        }
        private void SendCaptchaButton_Click(object sender, EventArgs e)
        {
            try
            {

                AuthForm.helper.apiInst.Authorize(new ApiAuthParams
                {
                    ApplicationId = AuthForm.appId,
                    Login = AuthForm.authParams.Login,
                    Password = AuthForm.authParams.Password,
                    Settings = AuthForm.authParams.Settings,
                    CaptchaSid = usedException.Sid,
                    CaptchaKey = GetCaptchaKey()
                });

            }
            catch (CaptchaNeededException ex)
            {
                MessageBox.Show("Invalid captcha");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
