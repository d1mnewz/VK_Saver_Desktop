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
        PhotoAlbum currentAlbum;
        int counter;
        VkCollection<Photo> coll;
        int sizeAlbum;
        public PicturesOfAlbum(PhotoAlbum album)
        {
            InitializeComponent();
            this.PicturesPanel.AutoScroll = true;
            
            this.currentAlbum = album;
            this.Text = album.Title + @"/" + album.OwnerId;
            this.coll = AuthForm.helper.GetAlbumAsCollection(currentAlbum);
            sizeAlbum = coll.Count;
            LoadMore();

        }
        public void LoadMore()
        {

            for (int i = 0; i < 20 && counter < sizeAlbum; i++, counter++)
            {
                // TODO: normal size of pictureboxes
                PictureBox pic = new PictureBox();
                pic.LoadAsync(AuthForm.helper.GetPhotoSrcLink(coll[counter]));
                pic.SizeMode = PictureBoxSizeMode.StretchImage;



                pic.Size = new Size((int)(this.PicturesPanel.Size.Width / 3.3f), this.PicturesPanel.Size.Height / 2);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;


                this.PicturesPanel.Controls.Add(pic);


            }
        }

        private void PicturesOfAlbum_Load(object sender, EventArgs e)
        {

        }

        private void LoadMoreButton_Click(object sender, EventArgs e)
        {
            this.LoadMore();

        }
    }
}
