using GameofThronesAPI.Models;
using GameofThronesAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameofThronesAPI
{
    public partial class Form2 : Form
    {
        private IThronesApiService thronesApiService;
        public Form2()
        {
            InitializeComponent();
            thronesApiService = new ThronesApiService();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            List<Characters> characterNames = await thronesApiService.GetCharacter();
            cbxNome.DisplayMember = "FullName";
            cbxNome.DataSource = characterNames;
        }

        private async void cbxNome_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxNome.SelectedItem != null)
            {

                Characters selectedCharacter = (Characters)cbxNome.SelectedItem;

                int characterId = selectedCharacter.Id;
                Characters characterDetails = await thronesApiService.GetCharacterById(characterId);

                lblFamilia.Text = characterDetails.Family;
                lblTitulo.Text = characterDetails.Title;
                imgPersonagem.Image = GetImagem(characterDetails.ImageUrl,225,282);

            }
        }

        public Image GetImagem(string imageUrl, int width, int height)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                       
                        byte[] imageData = webClient.DownloadData(imageUrl);

                       
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            Image originalImage = Image.FromStream(ms);

                            // Redimensiona a imagem 
                            Image resizedImage = new Bitmap(width, height);
                            using (Graphics graphics = Graphics.FromImage(resizedImage))
                            {
                                graphics.DrawImage(originalImage, 0, 0, width, height);
                            }

                            return resizedImage;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao baixar e redimensionar a imagem: " + ex.Message);
                }
            }

            return null;
        }

    }
}
