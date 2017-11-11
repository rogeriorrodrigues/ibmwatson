using System;
using System.IO;
using System.Threading.Tasks;
using IBM.WatsonDeveloperCloud.VisualRecognition.v3;
using IBM.WatsonDeveloperCloud.VisualRecognition.v3.Model;
using Plugin.Media;
using Xamarin.Forms;

namespace jundev
{
    public partial class jundevPage : ContentPage
    {

        string imagem = "https://i.ytimg.com/vi/FAciZRkOKQs/maxresdefault.jpg";
        public jundevPage()
        {
            InitializeComponent();

            SelectedImage.Source = imagem;
        }


        VisualRecognitionService _visualRecognition = new VisualRecognitionService();

       
        public void GetImageDescription()
        {
            

            _visualRecognition.SetCredential("sua-chave_watson");

            var result =  _visualRecognition.Classify(imagem);

            TextInfo.Text = result.Images[0].Classifiers[0].Name;

            foreach (ClassResult tags in result.Images[0].Classifiers[0].Classes)
            {
                InfoLabel.Text += tags._Class + ", ";
            }

         
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            GetImageDescription();
        }
    }
}
