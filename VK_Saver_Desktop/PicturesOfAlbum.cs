using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VK_Saver_Desktop
{
    public partial class PicturesOfAlbum : Form
    {
        // currentAlbum;
        int counter;
        VkCollection<Photo> CurrentColl;
        int sizeAlbum;
        public PicturesOfAlbum(VkCollection<Photo> coll)
        {
            InitializeComponent();
            
                this.PicturesPanel.AutoScroll = true;

                //this.currentAlbum = album;
                this.CurrentColl = coll;
                sizeAlbum = coll.Count;
                if (sizeAlbum > 0)
                {
                    this.Text = String.Format(@"/{0}", CurrentColl[0].OwnerId);
                }

                LoadMore();
            
            
        }


        public void LoadMore()
        {

            for (int i = 0; i < 20 && counter < sizeAlbum; i++, counter++)
            {
                // TODO: normal size of pictureboxes
                PictureBox pic = new PictureBox();
                pic.LoadAsync(AuthForm.helper.GetPhotoSrcLink(this.CurrentColl[counter]));
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                // TODO: to attach a normal link to doubleClickEvent
                // ITS BUGGED
                pic.MouseDoubleClick += (sender, e) => AuthForm.helper.DownloadPhoto(CurrentColl[counter]);


                pic.Size = new Size((int)(this.PicturesPanel.Size.Width / 3.3f), this.PicturesPanel.Size.Height / 2);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Cursor = Cursors.Hand;

                pic.BorderStyle = BorderStyle.Fixed3D;

                this.PicturesPanel.Controls.Add(pic);


            }
        }



        private void LoadMoreButton_Click(object sender, EventArgs e)
        {
            this.LoadMore();

        }
    }
}
