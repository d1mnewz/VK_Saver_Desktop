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
namespace VK_Saver_Desktop
{
    public partial class Form1 : Form
    {
        public const int appId = 5733434;
        VkApi api;

        public Form1()
        {
            InitializeComponent();
            api = new VkApi();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //api.Authorize(appId, LoginBox.Text, this.PassBox.Text, VkNet.Enums.Filters.Settings.All); // авторизуемся
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = appId,
                Login = LoginBox.Text,
                Password = PassBox.Text,
                Settings = VkNet.Enums.Filters.Settings.All
            });
            MessageBox.Show(api.UserId.ToString());
        }
    }
}
