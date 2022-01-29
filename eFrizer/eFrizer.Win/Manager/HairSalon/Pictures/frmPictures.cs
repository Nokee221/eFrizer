using eFrizer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;

namespace eFrizer.Win
{
    public partial class frmPictures : Form
    {
        private APIService _pictureStreamService= new APIService("PictureStream");
        private APIService _pictureIdsService = new APIService("PictureIds");
        private APIService _pictureService = new APIService("Picture");
        private HairSalon _hairSalon;
        private int[] _pictureIds;
        private int _selectedIndex;

        public frmPictures(HairSalon hairSalon)
        {
            _hairSalon = hairSalon;
            InitializeComponent();
        }

        private void frmPictures_Load(object sender, EventArgs e)
        {

            initPictures();
        }

        private async void initPictures()
        {
            Gallery gallery = await _pictureIdsService.GetImageIds<Gallery>(_hairSalon.HairSalonId);
            if (gallery.pictureIds.Count() != 0)
            {
                pbHairSalon.SizeMode = PictureBoxSizeMode.StretchImage;
                _pictureIds = new int[gallery.pictureIds.Count()];
                for (int i = 0; i < gallery.pictureIds.Count(); i++)
                {
                    _pictureIds[i] = gallery.pictureIds.ElementAt(i);
                }
                _selectedIndex = _pictureIds.Count() - 1;
                renderPicture(_pictureIds[_selectedIndex]); 
            }
            else
            {
                pbHairSalon.Image = null;
                MessageBox.Show("No images to display! You can add some with the 'Add new image' button.");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_pictureIds[_selectedIndex] == _pictureIds.Last())
            {
                _selectedIndex = 0;
            }
            else
            {
                _selectedIndex++;
            }
            renderPicture(_pictureIds[_selectedIndex]);
        }

        private async void renderPicture(int selectedId)
        {
            ImageConverter converter = new ImageConverter();
            var pictureSource = await _pictureStreamService.GetImageStream<byte[]>(selectedId);
            pbHairSalon.Image = null;
            pbHairSalon.Image = (Image)converter.ConvertFrom(pictureSource);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(_selectedIndex == 0)
            {
                _selectedIndex = _pictureIds.Count() - 1;
            }
            else
            {
                _selectedIndex--;
            }
            
            renderPicture(_pictureIds[_selectedIndex]);
        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            var result = ofdNewImage.ShowDialog();
            if(result == DialogResult.OK)
            {
                var request = new PictureInsertRequest
                {
                    HairSalonId = _hairSalon.HairSalonId
                };
                using (var fileStream = File.Open(ofdNewImage.FileName, FileMode.Open))
                {
                    using (var client = new HttpClient())
                    {
                        var serializedRequest = JsonConvert.SerializeObject(request);
                        var stringContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
                        var multipartContent = new MultipartFormDataContent();
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            await fileStream.CopyToAsync(memoryStream);
                            var byteContent = new ByteArrayContent(memoryStream.ToArray());
                            multipartContent.Add(
                                byteContent,
                                Path.GetFileNameWithoutExtension(ofdNewImage.FileName) +
                                DateTime.Now.ToString("yymmssfff") +
                                Path.GetExtension(ofdNewImage.FileName),
                                ofdNewImage.FileName);
                            multipartContent.Add(new StringContent(request.HairSalonId.ToString()), "HairSalonId");
                            var response = await client.PostAsync($"{Properties.Settings.Default.ApiURL}/Picture", multipartContent);
                            MessageBox.Show("Successfully added new image!");
                            initPictures();
                        };
                  
                    }
                }

            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int pictureId = _pictureIds[_selectedIndex];
            var picture = await _pictureService.DeletePicture<Picture>(pictureId);
            MessageBox.Show("Successfully deleted selected picture.");
            initPictures();
        }
    }
}
