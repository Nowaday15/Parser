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
using VkNet.Model.Attachments;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Abstractions;
using VkNet.Abstractions.Utils;
//using VkNet.AudioBypassService;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using System.IO;
using TLSharp.Core;
using TeleSharp.TL.Messages;
using TeleSharp.TL;
using TLSharp.Core.Utils;
using System.Diagnostics;
using MTProtoProxy;
using System.Net;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections;
using System.Net.Http;
using Telegram;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace memedump
{

    public partial class Form1 : Form
    {
        List<MediaAttachment> mediaattachment = new List<MediaAttachment>(); //вложения в нашу группу
        List<Attachment> attachment = new List<Attachment>();

        string fullphotoname;
        string filepath_archive = "posted_photos.txt"; //нет создания!!!
        int erasecount = 1000000; //удаляем когда превысит число символов (переделать в число строк)
        string groupsfilepath = "groupsid.txt"; //файл со списком пабликов для парсинга - нет создания!!!
        string photofilename = "tempimage"; //скачанное фото

        string vkLogin = "79*********";
        string vkPassword = "*********";  
        string Token = "****************"; //для HVM можно и без приложения, авторизироваться через логин и пароль
                                                                           //Получается https://oauth.vk.com/authorize?client_id=  APPID &scope=notify,photos,friends,audio,video,notes,pages,docs,status,questions,offers,wall,groups,messages,notifications,stats,ads,offline&redirect_uri=http://api.vk.com/blank.html&display=page&response_type=token
        //для телеги
        //Create a developer account in Telegram. https://my.telegram.org/apps
        // Goto API development tools and copy API_ID and API_HASH from your account.You'll need it later.
        int ApiId = *****;
        string ApiHash = "*************";
        string usernumber = "7916*******";
        string MessageToAttach;
        string firstpart= "https://api.vk.com/method/photos.get?owner_id=";
        //string countofposts = "50";
        string lastpart = "&album_id=wall&rev=0&extended=0&photo_sizes=0&count=50&access_token=57da846be4093a126adc01a970a971b2fd699fca108fda53090dd41a180385988775854c6b0da7c88d602&v=5.87";
        string filepath = "request.txt";
        private static IVkApi _api;
        
        string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
        string apiToken = "7756*****:*****************; //bot father
        private string chatId = "-**********"; //https://api.telegram.org/bot<YourBOTToken>/getUpdates

        ulong PostCount = 50;

        public Form1()
        {
            InitializeComponent();
            var secret = GenerateRandomSecret();
            var mtprotoProxy = new MTProtoProxyServer(secret, 443);
            mtprotoProxy.StartAsync();
        }

		//для проксика
        public static string GenerateRandomSecret()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TB_Count.Maximum =400;
            TB_Count.Minimum = 1;
            TB_Count.Value = 10;
        }

        private string CreateApiReq(string idpart)
        {
            string req = firstpart + idpart + lastpart;
            return req;
        }

        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
                cert.Subject,
                error.ToString());

            return false;
        }

        public string JsonReq(string url)
        {
            string json, page, response;
			
            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {

                // System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                try
                {
                    response = webClient.DownloadString(url);
                }
                catch (Exception)
                {
                    MessageBox.Show("Слишком много запросов! Повтори позднее");
                    response = null;
                    Invoke(new Action(() =>
                    {
                        // PB_Download.Value = 0;
                    }));
                }
                json = JsonConvert.SerializeObject(response);

            }
            return json;
        }

        /// Возращает URL самой большой фотографиии из существующих
        public static string GetUrlOfBigPhoto(VkNet.Model.Attachments.Photo photo)
        {
            if (photo == null)
                return null;
            if (photo.Photo2560 != null)
                return photo.Photo2560.AbsoluteUri;
            if (photo.Photo1280 != null)
                return photo.Photo1280.AbsoluteUri;
            if (photo.Photo807 != null)
                return photo.Photo807.AbsoluteUri;
            if (photo.Photo604 != null)
                return photo.Photo604.AbsoluteUri;
            if (photo.Photo130 != null)
                return photo.Photo130.AbsoluteUri;
            if (photo.Photo75 != null)
                return photo.Photo75.AbsoluteUri;
            if (photo.Sizes?.Count > 0)
            {
                var bigSize = photo.Sizes[0];
                for (int i = 0; i < photo.Sizes.Count; i++)
                {
                    var photoSize = photo.Sizes[i];
                    if (photoSize.Height > bigSize.Height && photoSize.Width > bigSize.Width)
                        bigSize = photoSize;
                }
                return bigSize.Src.AbsoluteUri;
            }
            return null;
        }

        public void AddedFile(string photos)
        {
            //если файл существует
            int charCount = File.ReadAllText(filepath_archive).Length;
            int linesCount = File.ReadAllLines(filepath_archive).Length;
            //Если число строк в файле больше или равно 10000
            if (charCount >= erasecount)
            {
                //Нужно удалить начало файла
                File.WriteAllText(filepath_archive, String.Empty); //очистили файл
            }
            else
            {
                FileStream file1 = new FileStream(filepath_archive, FileMode.Append); //открытие файла на дозапись в конец файла
                StreamWriter writer = new StreamWriter(file1, Encoding.UTF8); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.WriteLine(photos);
                //writer.Write(photos); //записываем в файл (раньше было json)
                writer.Close();
            }
        }

        private async Task ReadGroupsFileAsync()
        {
            var _api = new VkApi();
            //Авторизация
            _api.Authorize(new ApiAuthParams
            {
                Login = vkLogin,
                Password = vkPassword,
                AccessToken = Token
            });

            int y = 0; //порядковый номер группы
            string[] lines = File.ReadAllLines(groupsfilepath);
            foreach (var K in lines) //для каждой группы получаем список записей
            {
                long? id2 = Convert.ToInt64(K);
                WallGetObject wallposts = _api.Wall.Get(new WallGetParams
                {
                    OwnerId = id2,//Идентификатор пользователя или сообщества, со стены которого необходимо получить записи 
                    //(по умолчанию — текущий пользователь). Обратите внимание, идентификатор сообщества в параметре owner_id
                    //необходимо указывать со знаком “-“ — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1) целое число
                   // Domain = id,  //- Короткий адрес пользователя или сообщества. строка
                                  //Filter=,  //all
                                  // Offset=, // Смещение, необходимое для выборки определенного подмножества записей. положительное число
                    Count = PostCount, //- Количество записей, которое необходимо получить (но не более 100). 
                    Extended = true
                    //Fields=Photo
                });
                var count = wallposts.TotalCount;
                Console.WriteLine("Количество постов в группе " + K + " = " + count);
                Console.ReadLine();

                var postelem = wallposts.WallPosts; //Получили посты

               // int j = 0;//число постов
                int numphot = 0; //номер фото
                for (int j = 0; j < (int)PostCount; j++) //пока не дошли до макс значения постов одной группы
                {

                    foreach (var i in postelem) //Для каждого поста
                    {
                        if(numphot== (int)PostCount-1) //если дошли числа постов, то обнуляем №фото, чтобы перезаписывать
                        {
                            numphot = 0;
                        }

                        //текст
                        if ((postelem[j].MarkedAsAds != true) && (postelem[j].Text != null)/*&&(postelem[j].PostType==post)*/)
                        {
                            //Удаление \n
                            //string deleteenters = postelem[j].Text.Replace("\n","");
                            MessageToAttach = postelem[j].Text;

                            Invoke(new Action(() =>
                            {
                                LB_Messages.Items.Add(MessageToAttach);

                            }));
                            //Сделать отправку сообщений, почему-то нулевые приходят 
                            // SendMessageToChannelTest(MessageToAttach);
                        }
                        //Получить информацию о записи, первого вложения и текст
                        var atts = postelem[j].Attachments;
                        foreach (var att in postelem[j].Attachments) //для каждого вложения одного поста
                        {
                            if (att.Type == typeof(Photo)) //если вложения = фото
                            {
                                Console.WriteLine("Ссылка на фото: " + GetUrlOfBigPhoto(att.Instance as Photo));
                                //получили ссылку на фотку
                                var url = GetUrlOfBigPhoto(att.Instance as Photo);
                                //Если ссылка уже есть в файле истории, continue, если нет, то идем дальше
                                string s = File.ReadAllText(filepath_archive); //Открываем файл с историей
                                if (s.IndexOf(url) != -1) //пока не дошли до конца ищем первое совпадение
                                {
                                    //Нашли фото уже был опубликован, значит пропускаем
                                    Console.WriteLine("Нашли повтор фото: " + s);
                                    Console.ReadLine();
                                    continue;
                                }

                                else
                                {
                                    //Запомнили что опубликовали такую фотку
                                    AddedFile(url);
                                    //скачали на ПК 
                                    numphot = DownloadTempPhoto(url, j);
                                    Console.WriteLine("Скачали и сохранили фото под № " + numphot);
                                    Console.ReadLine();

                                    fullphotoname = photofilename + numphot + ".jpg";
                                    // string apiToken = "775672851:AAEUjIvm-Vc4ZWIWmvfUffK5Rh4fLIP2jDE"; //BotFather
                                    //string chatId = "-1001115479085"; //https://api.telegram.org/bot<YourBOTToken>/getUpdates

                                    await SendPhoto(chatId, fullphotoname, apiToken);
                                    // continue;                               
                                    Console.WriteLine("Отправили в телегу");
                                    numphot++;

                                    //Delay
                                    Random rnd = new Random();
                                    int number = rnd.Next(3000, 11000);
                                    Console.WriteLine("Ждем  " + number / 1000 + " секунд");
                                    Console.ReadLine();
                                    await Task.Delay(number);
                                }
                            }
                        }
                        Console.WriteLine("Обработали пост № " + j);
                        Console.ReadLine();
                    }
                    y++;
                    Console.WriteLine("Обработали группу № " + y);
                    Console.ReadLine();
                }
            }
            return;
        }

        private int DownloadTempPhoto(string photourl, int i)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
					//Отображение скачанной фотки
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    webClient.DownloadFile(photourl, photofilename+i+".jpg");
                    webClient.Dispose();
                    Invoke(new Action(() =>
                    {
                        //LB_Messages.Items.Add(MessageToAttach);
                        Bitmap bit2 = new Bitmap(photofilename + i + ".jpg");
                        pictureBox1.Image = bit2;
                    }));

                }
                catch (Exception)
                {
                    string message = "Невозможно подключиться к серверу загрузки фото.\nПопробуйте добавить другую картинку";
                    string caption = "Ошибка!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon iconsMB = MessageBoxIcon.Error;
                    MessageBox.Show(message, caption, buttons, iconsMB);
                }
            }
            return i;
        }

        private void BT_GetPosts_Click(object sender, EventArgs e)
        {
           Task stepone= ReadGroupsFileAsync();
           
        }

        public async static Task SendPhoto(string chatId, string filePath, string token)
        {
            var url = string.Format("https://api.telegram.org/bot{0}/sendPhoto", token);
            var fileName = filePath.Split('\\').Last();

            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId.ToString(), Encoding.UTF8), "chat_id");

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "photo", fileName);

                    using (var client = new HttpClient())
                    {
                        await client.PostAsync(url, form);
                    }
                }
            }
        }

        public virtual void SendMessageToChannelTest(string MessageToAttach)
        {     
            string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
            string text = MessageToAttach;
            urlString = String.Format(urlString, apiToken, chatId, text);
            WebRequest request = WebRequest.Create(urlString);

            Stream rs = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(rs);
            string line = "";
            StringBuilder sb = new StringBuilder();
            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                    sb.Append(line);
            }
            string response = sb.ToString();
        }

        //-----------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            PostCount = Convert.ToUInt64(TB_Count.Value);
            LB_Count.Text = TB_Count.Value.ToString();
            TB_ApiToken.Text = apiToken;
            TB_ChatID.Text = chatId;
            TB_Pass.Text = vkPassword;
            TB_vkLogin.Text = vkLogin;
        }


        private void TB_Count_Scroll(object sender, EventArgs e)
        {
            PostCount = Convert.ToUInt64(TB_Count.Value);
        }

        private void TB_ApiToken_TextChanged(object sender, EventArgs e)
        {
            apiToken = TB_ApiToken.Text;
        }

        private void BT_GetChatID_Click(object sender, EventArgs e)
        {
            string first = "https://api.telegram.org/bot";
            string last = "/getUpdates";
            string url = first + apiToken + last;
            System.Diagnostics.Process.Start(url);
        }

        private void TB_ChatID_TextChanged(object sender, EventArgs e)
        {
            chatId = TB_ChatID.Text;
        }

        private void TB_Pass_TextChanged(object sender, EventArgs e)
        {
            vkPassword = TB_Pass.Text;
            TB_Pass.PasswordChar = '*';
        }

        private void TB_vkLogin_TextChanged(object sender, EventArgs e)
        {
            vkLogin = TB_vkLogin.Text;
        }
    }
}
