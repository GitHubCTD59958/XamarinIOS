using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using UIKit;
using AVFoundation;
namespace CongnitiveServices
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            #region Using Siri's Voice
            //First we're gonna create the AvFundation in which we use it for reading the speech using the Siri's voice
            AVSpeechSynthesizer Siri = new AVSpeechSynthesizer();
            #endregion
            ButtonDesc.TouchUpInside+= Happiness;
            #region Hapiness Method Async
            //This is used for getting the Image which we're gonna use
            async void Happiness(object sender, EventArgs e)
            {
                var Path = await DownloadImageHappiness();
                ImgDetection.Image = UIImage.FromFile(Path);
                var StreamImage = ImgDetection.Image.AsJPEG(.5f).AsStream();
                {
                    try
                    {
                        float Percent = await HappinessLevel(StreamImage);
                        TextDescription.Text = GettingMessage(Percent);
                        var Voice = new AVSpeechUtterance(TextDescription.Text);
                        Voice.Voice = AVSpeechSynthesisVoice.FromLanguage("es-MX");
                        Siri.SpeakUtterance(Voice);
                    }
                    catch (Exception ex)
                    {TextDescription.Text = ex.Message;}
                }
            }
            #endregion
        }
        #region Method DownloadingImage
        public async Task<string> DownloadImageHappiness()
        {
            WebClient Client = new WebClient();
            byte[] DataImage = await Client.DownloadDataTaskAsync("https://thumbs.dreamstime.com/z/big-smile-beautiful-playful-excited-funny-young-woman-her-face-isolated-white-33269506.jpg");
            string LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string NameFile = "Foto1.jpg";
            string path = Path.Combine(LocalPath, NameFile);
            File.WriteAllBytes(path, DataImage);
            return path;

        }
        #endregion
        #region Method for Getting The HappinesLevel
        public static async Task<float> HappinessLevel(Stream stream)
        {
            Emotion[] Emotions = await GettingEmotion(stream);
            float level = 0;
            foreach (var emotion in Emotions)
            {level = level + emotion.Scores.Happiness;}
            return level / Emotions.Count();
        }
        #endregion
        #region Method for Getting the Emotion
        private static async Task<Emotion[]> GettingEmotion(Stream stream)
        {
            string KeyAppEmtion = "";
            EmotionServiceClient EmotionClient = new EmotionServiceClient(KeyAppEmtion);
            var emotion = await EmotionClient.RecognizeAsync(stream);
            if (emotion == null || emotion.Count() == 0)
            {throw new Exception("it can't do the Detection");}
            return emotion;
        }
        #endregion
        #region Method for GettingMEssageHappiness
        public static string GettingMessage(float Level)
        {
            Level = Level * 100;
            double Result = Math.Round(Level, 2);
            if (Level >= 60)
            {return "it's happy has a smile of " + Result + " %";}
            else{return "Needs a hug, has a  " + Result + " % of happiness";}
        }
        #endregion
    }
}