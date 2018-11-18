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
using memedump.Properties;
using System.Threading;
//using MihaZupan;

namespace memedump
{
    //Добавить отображение файла ID групп и добавление туда элементов  и выбор самого файла через BROWSE
    public partial class Form1 : Form
    {
        List<MediaAttachment> mediaattachment = new List<MediaAttachment>(); //вложения в нашу группу
        List<Attachment> attachment = new List<Attachment>();

        int startmin = 25;
        int endmin = 30;
        int mindelay = Settings.Default.mindelay;//milliseconds 5000/1000=5 sec
        int maxdelay = Settings.Default.maxdelay;
        string fullphotoname;
        string filepath_archive = "posted_photos.txt"; //нет создания!!!
        string text_archive = "posted_messages.txt"; //нет создания!
        int erasecount = Settings.Default.erasecount; //1000; //удаляем когда превысит число символов (переделать в число строк)
        string groupsfilepath = "groupsid.txt"; //файл со списком пабликов для парсинга - нет создания!!!
        string photofilename = "tempimage"; //скачанное фото
        long? groupid = -42377029;
        ulong? ownerid3 = 488489872;
        ulong? groupid3 = 42377029;
        string vkLogin = Settings.Default.vkLogin; //  "79164323262";
        string vkPassword = Settings.Default.vkPassword; //"strimtv2";  
        string Token = Settings.Default.Token; // "57da846be4093a126adc01a970a971b2fd699fca108fda53090dd41a180385988775854c6b0da7c88d602"; //для HVM
                                                                           //Получается https://oauth.vk.com/authorize?client_id=6707743&scope=notify,photos,friends,audio,video,notes,pages,docs,status,questions,offers,wall,groups,messages,notifications,stats,ads,offline&redirect_uri=http://api.vk.com/blank.html&display=page&response_type=token
                                                                                                                //string SettingsFile="settings.ini"; //Сюда будем писать токен после авторизации а так же acesstoken и загружать при каждом запуске, сделать кнопки ВЫХОД , загрузить сохранить настройки
       // string accesstoken = "BcG1n43FYQ4IPGGv43Qm"; //Приложение группы доступ к группе, получается в самом приложении в ручную Standalone приложение

        //для телеги
        //Create a developer account in Telegram. https://my.telegram.org/apps
        // Goto API development tools and copy API_ID and API_HASH from your account.You'll need it later.
        //int ApiId = 610464;
        //string ApiHash = "e3295165211c4728c0d5c1d7460fb08f";
        //string usernumber = "79164323262";
        //https://api.vk.com/method/photos.get?owner_id=210700286&album_id=wall&count=20&access_token=57da846be4093a126adc01a970a971b2fd699fca108fda53090dd41a180385988775854c6b0da7c88d602&v=5.87
        //api vk to get photos http://api.vk.com/method/photos.get?params[owner_id]=-31480508&params[album_id]=wall&params[rev]=0&params[extended]=0&params[photo_sizes]=0&params[count]=2&params[v]=5.87
        string MessageToAttach;
        string firstpart= "https://api.vk.com/method/photos.get?owner_id=";
        //string countofposts = "50";
        string lastpart = "&album_id=wall&rev=0&extended=0&photo_sizes=0&count=50&access_token=57da846be4093a126adc01a970a971b2fd699fca108fda53090dd41a180385988775854c6b0da7c88d602&v=5.87";
        string filepath = "request.txt";
        private static IVkApi _api;
        
        string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
        string apiToken = Settings.Default.apiToken; //bot father
        private string chatId = Settings.Default.chatId; //https://api.telegram.org/bot<YourBOTToken>/getUpdates

        ulong PostCount = Settings.Default.PostCount; //количество постов для парсинга
        string curTimeLong = DateTime.Now.ToLongTimeString(); //Результат: 8:49:10
        int hour;
        int min;
        bool f_postedall = false;
        bool f_start = false;
        //CancellationTokenSource tokenSource2;


        public Form1()
        {
            InitializeComponent();
            //var secret = GenerateRandomSecret();
            //var mtprotoProxy = new MTProtoProxyServer(secret, 2256);
            //mtprotoProxy.StartAsync();
            // Console.ReadLine();
            // Console.SetOut(new ControlWriter(textBox1));

            //var tokenSource2 = new CancellationTokenSource();
            //CancellationToken ct = tokenSource2.Token;

        }

        public static string GenerateRandomSecret()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TB_Count.Maximum =100;
            TB_Count.Minimum = 1;
            TB_Count.Value = (int)PostCount;
            numericUpDown1Min.Value = mindelay/1000;
            numericUpDown2Max.Value = maxdelay/1000;
            //PostCount = Convert.ToUInt64(TB_Count.Value);
            //TB_Code.MaxLength = 3;
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
          //return page;
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
                    if (photoSize.Height > bigSize.Height || photoSize.Width > bigSize.Width)
                        bigSize = photoSize;
                }
                return bigSize.Src.AbsoluteUri;
            }
            return null;
        }

        public void AddedFile(string info, string filename)
        {
            //если файл существует
            int charCount = File.ReadAllText(filename).Length;
            int linesCount = File.ReadAllLines(filename).Length;
            //Если число строк в файле больше или равно 10000
            if (linesCount >= erasecount)
            {
                //Нужно удалить начало файла
                File.WriteAllText(filename, String.Empty); //очистили файл
            }
            else
            {
                FileStream file1 = new FileStream(filename, FileMode.Append); //открытие файла на дозапись в конец файла
                StreamWriter writer = new StreamWriter(file1, Encoding.UTF8); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.WriteLine(info);
                //writer.Write(photos); //записываем в файл (раньше было json)
                writer.Close();
            }
        }

        private async Task ReadGroupsFileAsync(/*CancellationToken ct*/ CancellationToken cancellationToken)
        {
            // CancellationToken ct = tokenSource2.Token;
            // Were we already canceled?
            //ct.ThrowIfCancellationRequested();

            //if (ct.IsCancellationRequested)
            //{
            //    Console.WriteLine("Операция прервана токеном");
            //    return;
            //}

            //Task task = null;
            //if (cancellationToken.IsCancellationRequested)
            //{
            //    throw new TaskCanceledException(task);
                
            //   // cancellationToken.ThrowIfCancellationRequested();
            //}

            f_start = true;

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
                var last = File.ReadAllLines(groupsfilepath).Last();//последняя строка - группа
                var linescount = File.ReadAllLines(groupsfilepath).Length;//число строк
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
                    Invoke(new Action(() =>
                    {
                        textBox1.Text = "Количество постов в группе " + K + " = " + count;
                    //LB_Messages.Items.Add("Количество постов в группе " + K + " = " + count);

                }));
                    Console.WriteLine("Количество постов в группе " + K + " = " + count);
                    Console.ReadLine();

                    var postelem = wallposts.WallPosts; //Получили посты

                    int j = 0;//число постов
                    int numphot = 0; //номер фото
                    for (j = 0; j < (int)PostCount; j++) //пока не дошли до макс значения постов одной группы
                    {
                        string groupidWOmin2 = K.Replace("-", "");
                        var groups2 = _api.Groups.GetById(null, groupidWOmin2, null).FirstOrDefault();
                        string sourceLink2 = groups2.Name;// + " @" + groups.Id;
                                                          //Отправка источника записи
                        string sourcelb = sourceLink2;
                        Invoke(new Action(() =>
                        {
                            LB_Source.Text = "Parsing: " + sourcelb;
                        }));

                        if (CHB_AddWOPhoto.Checked == true)
                        {
                            var atts = postelem[j].Attachments;
                            if ((postelem[j].MarkedAsAds != true) && (postelem[j].Text != null) && (atts == null))
                            {
                                //Удаление \n
                                string deleteenters = postelem[j].Text.Replace("\n", "");
                                //string deletespace = postelem[j].Text.Replace("\n", "");
                                MessageToAttach = deleteenters;

                                //Проверка на повторы
                                string s = File.ReadAllText(text_archive); //Открываем файл с историей
                                if (s.IndexOf(MessageToAttach) != -1) //пока не дошли до конца ищем первое совпадение
                                {
                                    //Нашли текст уже был опубликован, значит пропускаем
                                    Console.WriteLine("Нашли повтор текста: " + s);
                                    Console.ReadLine();
                                    Invoke(new Action(() =>
                                    {
                                        textBox1.Text = "Нашли повтор текста: " + s;

                                    }));
                                    continue;
                                }

                                else
                                {
                                    //Запомнили что опубликовали такое сообщение
                                    AddedFile(MessageToAttach, text_archive);

                                    //Отправка сообщения поста
                                    if (string.IsNullOrEmpty(MessageToAttach) == false) //Если не пустое сообщение
                                    {
                                        Invoke(new Action(() =>
                                        {
                                            LB_Messages.Items.Add(MessageToAttach);

                                        }));
                                        await sendMessage(chatId, MessageToAttach);
                                    }

                                }
                            }
                        }
                        //текст

                        if (ChB_AddMessage.Checked == true) //если хотим сообщения добавлять к картинкам
                        {
                            // var atts = postelem[j].Attachments;
                            //Проверить если есть фотки или только текст, постить
                            var att = postelem[j].Attachment; //Получили первое вложение
                            if ((postelem[j].MarkedAsAds != true) && (postelem[j].Text != null) && (att != null) && (att.Type == typeof(Photo))/*&&(postelem[j].PostType==post)*/)
                            {
                                //Удаление \n
                                string deleteenters = postelem[j].Text.Replace("\n", "");
                                //string deletespace = postelem[j].Text.Replace("\n", "");
                                MessageToAttach = deleteenters;

                                //Проверка на повторы
                                string s = File.ReadAllText(text_archive); //Открываем файл с историей
                                if (s.IndexOf(MessageToAttach) != -1) //пока не дошли до конца ищем первое совпадение
                                {
                                    //Нашли текст уже был опубликован, значит пропускаем
                                    Console.WriteLine("Нашли повтор текста: " + s);
                                    Console.ReadLine();
                                    Invoke(new Action(() =>
                                    {
                                        textBox1.Text = "Нашли повтор текста: " + s;

                                    }));
                                    continue;
                                }

                                else
                                {
                                    //Запомнили что опубликовали такое сообщение
                                    AddedFile(MessageToAttach, text_archive);

                                    //Отправка сообщения поста
                                    if (string.IsNullOrEmpty(MessageToAttach) == false) //Если не пустое сообщение
                                    {
                                        Invoke(new Action(() =>
                                          {
                                              LB_Messages.Items.Add(MessageToAttach);

                                          }));
                                    var secret = GenerateRandomSecret();
                                    var mtprotoProxy = new MTProtoProxyServer(secret, 2256);
                                    mtprotoProxy.StartAsync();
                                    await sendMessage(chatId, MessageToAttach);

                                    }

                                }

                            }
                        }

                        List<MediaAttachment> vk_attachments = new List<MediaAttachment>();

                        foreach (var i in postelem) //Для каждого поста
                        {
                            if (numphot == (int)PostCount - 1) //если дошли числа постов, то обнуляем №фото, чтобы перезаписывать
                            {
                                numphot = 0;

                            }

                            //await SendMessageToChannelTest(MessageToAttach);
                            //Получить информацию о записи, первого вложения и текст
                            var atts = postelem[j].Attachments;
                            int currphoto = 0;

                            foreach (var att in postelem[j].Attachments) //для каждого вложения одного поста
                            {

                                //att.Type==typeof(Link)
                                if (att.Type == typeof(Photo) && att.Type != typeof(Link)) //если вложения = фото но не ссылка
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
                                    Invoke(new Action(() =>
                                    {
                                        textBox1.Text = "Нашли повтор фото: " + s;

                                    }));
                                    continue;
                                }

                                else
                                {
                                    //Запомнили что опубликовали такую фотку
                                    AddedFile(url, filepath_archive);
                                    //скачали на ПК 
                                    numphot = DownloadTempPhoto(url, j);

                                    currphoto++;

                                    Console.WriteLine("Скачали и сохранили фото под № " + numphot);
                                    Console.ReadLine();
                                    Invoke(new Action(() =>
                                    {
                                        textBox1.Text = "Скачали и сохранили фото под № " + numphot;

                                    }));

                                    fullphotoname = photofilename + numphot + ".jpg";

                                    //Залили на стену
                                    //IReadOnlyCollection<Photo> photolist = SendOnServer(fullphotoname);
                                    //vk_attachments.AddRange(photolist);
                                    var secret = GenerateRandomSecret();
                                    var mtprotoProxy = new MTProtoProxyServer(secret, 2256);
                                    mtprotoProxy.StartAsync();
                                    await SendPhoto(chatId, fullphotoname, apiToken);
                                    // continue;                               
                                    Console.WriteLine("Отправили в телегу");
                                    Invoke(new Action(() =>
                                    {
                                        textBox1.Text = "Отправили в телегу";

                                    }));

                                    ////Отправили ВК
                                    //var post = _api.Wall.Post(new WallPostParams
                                    //{
                                    //    OwnerId = groupid,
                                    //    FromGroup = true,
                                    //    Message = MessageToAttach,
                                    //    Attachments = vk_attachments

                                    //});

                                    //Delay
                                    Random rnd = new Random();
                                    int number = rnd.Next(mindelay, maxdelay);

                                    if (chb_addsource.Checked == true)
                                    {

                                        int photocount = postelem[j].Attachments.Count; //число вложений фото

                                        if (photocount == 1)//если вложение одно
                                        {
                                            string groupidWOmin = K.Replace("-", "");
                                            var groups = _api.Groups.GetById(null, groupidWOmin, null).FirstOrDefault();
                                            if (groups != null)
                                            {

                                                string sourceLink = groups.Name;// + " @" + groups.Id;
                                                                                //Отправка источника записи
                                                string source = "Источник: " + sourceLink;

                                                await sendMessage(chatId, source);
                                            }
                                        }
                                        //если вложений несколько - один раз пишем источник в конце после последнего вложения
                                        if ((currphoto == photocount) && (photocount != 1))
                                        {
                                            //Получение ссылки на сообщество 
                                            string groupidWOmin = K.Replace("-", "");
                                            var groups = _api.Groups.GetById(null, groupidWOmin, null).FirstOrDefault();
                                            if (groups != null)
                                            {

                                                string sourceLink = groups.Name;// + " @" + groups.Id;
                                                                                //Отправка источника записи
                                                string source = "Источник: " + sourceLink;
                                                await sendMessage(chatId, source);
                                            }
                                        }
                                    }
                                        numphot++;
                                        Invoke(new Action(() =>
                                        {
                                            textBox1.Text = "Ждем  " + number / 1000 + " секунд";
                                        }));
                                        Console.WriteLine("Ждем  " + number / 1000 + " секунд");
                                        Console.ReadLine();
                                        await Task.Delay(number);

                                    }
                                }

                                //если вложения не фотки другая функция отправки типа вложения
                            }

                            //j++;
                            Console.WriteLine("Обработали пост № " + j);
                            Console.ReadLine();
                            Invoke(new Action(() =>
                            {
                                textBox1.Text = "Обработали пост № " + j;

                            }));
                        }

                    }
                    y++;
                    Console.WriteLine("Обработали строку № " + y + " Группа: " + id2);
                    Console.ReadLine();
                    Invoke(new Action(() =>
                    {
                        textBox1.Text = "Обработали строку № " + y + " Группа: " + id2;

                    }));
                //это если постоянно
                    //if ((j == (int)PostCount - 1) && (y == linescount)) //последний пост последней группы в списке
                    //    j = 0; //запускаем обратно цикл
                }

                MessageBox.Show("Обработаны все группы и посты!");
                f_postedall = true;
                return;
            
        }

        //public Telegram.Bot.Types.Message SendPhoto(chatId, photo)
        //{ }
        //Загрузка фото на стену и добавление во вложенные
        public IReadOnlyCollection<Photo> SendOnServer(string filename)
        {
            var api = new VkApi();
            //Авторизация
            api.Authorize(new ApiAuthParams
            {
                AccessToken = Token
            });
            var res = api.Groups.Get(new GroupsGetParams());
            //label6.Text = "Авторизировались";
            var getWallUploadServer = api.Photo.GetWallUploadServer(groupid);
            string uploadurl = getWallUploadServer.UploadUrl;
            long? userid = getWallUploadServer.UserId;
            long? albumid = getWallUploadServer.AlbumId;

            // Загрузить фотографию.
            var wc = new WebClient();
            string responseImg = null;

                responseImg = Encoding.ASCII.GetString(wc.UploadFile(uploadurl, filename));
                responseImg.GetHashCode();
           
            var photolist = api.Photo.SaveWallPhoto(responseImg, ownerid3, groupid3); //Сохранили фото на стену
            return photolist;
        }


        private int DownloadTempPhoto(string photourl, int i)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    if (chb_auto.Checked == false)
                    {
                        if (pictureBox1.Image != null)
                            pictureBox1.Image.Dispose();
                    }

                    webClient.DownloadFile(photourl, photofilename+i+".jpg");
                    webClient.Dispose();
                    //Bitmap bit2 = new Bitmap(photofilename + i + ".jpg");
                    //pictureBox1.Image = bit2;
                    if (chb_auto.Checked == false)
                    {
                        Invoke(new Action(() =>
                        {
                        //LB_Messages.Items.Add(MessageToAttach);
                        Bitmap bit2 = new Bitmap(photofilename + i + ".jpg");
                            pictureBox1.Image = bit2;
                        }));
                    }

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
            //string curTimeLong = DateTime.Now.ToLongTimeString(); //Результат: 8:49:10
            // int hour = int.Parse(curTimeLong.Split(':')[0]);
            //int min = int.Parse(curTimeLong.Split(':')[1]);
            CancellationTokenSource tokenSource2 = new CancellationTokenSource();
            CancellationToken token = tokenSource2.Token;

            Task stepone = ReadGroupsFileAsync(token);
               // f = true;


        }

     
        public async static Task SendPhoto(string chatId, string filePath, string token)
        {
            var url = string.Format("https://api.telegram.org/bot{0}/sendPhoto", token);
            var fileName = filePath.Split('\\').Last();
            //bot.SendPhoto.send(chatId,)
          //  var secret = GenerateRandomSecret();
          //  var mtprotoProxy = new MTProtoProxyServer(secret, 443);
         // mtprotoProxy.StartAsync();
         
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

        //destID: destination ID
        //text: text to send
        public async Task sendMessage(string destID, string text)
        {
           // destID = chatId;
           // string apiToken = "775672851:AAEUjIvm-Vc4ZWIWmvfUffK5Rh4fLIP2jDE";
            try
            {
                var bot = new Telegram.Bot.TelegramBotClient(apiToken);
                await bot.SendTextMessageAsync(destID, text);
            }
            catch (Exception e)
            {
                Console.WriteLine("err");
            }
        }

        public virtual void SendMessageToChannelTest(string MessageToAttach)
        {
            //string authoString = "https://api.telegram.org/bot775672851:AAEUjIvm-Vc4ZWIWmvfUffK5Rh4fLIP2jDE/getMe";
            string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
           // string apiToken = "775672851:AAEUjIvm-Vc4ZWIWmvfUffK5Rh4fLIP2jDE";
            //string chatId = "-1001115479085";
            string text = MessageToAttach;
            urlString = String.Format(urlString, apiToken, chatId, text);
            //WebRequest request1 = WebRequest.Create(authoString);
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
        private void BT_Post_Click(object sender, EventArgs e)
        {

             //Task stepfour = SendMessageToChannelTest();
        }


        private void BT_Authorizer_Click(object sender, EventArgs e)
        {
           // Task steptwo = LoginTelegramAsync();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.SetOut(new ControlWriter(textBox1));
            //PostCount = Convert.ToUInt64(TB_Count.Value);
            //TB_count.Maximum = (int)n + 1;
            CancellationTokenSource tokenSource2 = new CancellationTokenSource();
            CancellationToken token = tokenSource2.Token;


            LB_Count.Text = PostCount.ToString();
            TB_ApiToken.Text = apiToken;
            TB_ChatID.Text = chatId;
            TB_Pass.Text = vkPassword;
            TB_vkLogin.Text = vkLogin;
            //LB_Messages.AutoScrollOffset = 3;
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
            curTimeLong = DateTime.Now.ToLongTimeString(); //Результат: 8:49:10
            hour = int.Parse(curTimeLong.Split(':')[0]);
            min = int.Parse(curTimeLong.Split(':')[1]);
            int sec = int.Parse(curTimeLong.Split(':')[2]);

            //if ((hour >= 7) && (hour <= 23) && (min > 25) && (min < 30))
            if (startmin < endmin)
            {
                if ((f_postedall == false) && (f_start == false) && (hour >= 7) && (hour <= 23) && (min > startmin) && (min < endmin) && (chb_auto.Checked == true))
                {
                    //Task task1 = new Task(() => ReadGroupsFileAsync(token));
                    //task1.Start();

                    Task stepone = ReadGroupsFileAsync(token); //1 раз прогнали парсер
                                                               //f = true;
                }
            }

            //if(min ==30)
            //{
                
            //    tokenSource2.Cancel();
            //}

            //Если время настало сбрасываем
            if ((hour >= 7) && (hour <= 23) && (min == startmin+1)&&(sec==01))
            {
                f_postedall = false;
                f_start = false;
            }

        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            Settings.Default.vkLogin = TB_vkLogin.Text;
            Settings.Default.apiToken = TB_ApiToken.Text;
            Settings.Default.vkPassword = TB_Pass.Text;
            Settings.Default.chatId = TB_ChatID.Text;
            Settings.Default.Save();
            
        }

        private void TB_Count_Scroll(object sender, EventArgs e)
        {
            PostCount = Convert.ToUInt64(TB_Count.Value); //сделать кратным 10
        }

        private void TB_ApiToken_TextChanged(object sender, EventArgs e)
        {
            //Settings.Default.apiToken = TB_ApiToken.Text;
            apiToken = TB_ApiToken.Text;
            TB_ApiToken.PasswordChar = '*';
           // Settings.Default.Upgrade();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BT_GetChatID_Click(object sender, EventArgs e)
        {
            string first = "https://api.telegram.org/bot";
            string last = "/getUpdates";
            string url = first + apiToken + last;
            System.Diagnostics.Process.Start(url);
           // string botfather = "https://telegram.me/BotFather";
        }

        private void TB_ChatID_TextChanged(object sender, EventArgs e)
        {
            //Settings.Default.chatId = TB_ChatID.Text;
            chatId = TB_ChatID.Text;
           // Settings.Default.Upgrade();
        }

        private void TB_Pass_TextChanged(object sender, EventArgs e)
        {
           // Settings.Default.vkPassword = TB_Pass.Text;
            vkPassword = TB_Pass.Text;
            TB_Pass.PasswordChar = '*';
          //  Settings.Default.Upgrade();
        }

        private void TB_vkLogin_TextChanged(object sender, EventArgs e)
        {
            //Settings.Default.vkLogin = TB_vkLogin.Text;
            vkLogin = TB_vkLogin.Text;
          //  Settings.Default.Upgrade();
        }

        private void numericUpDown1Min_ValueChanged(object sender, EventArgs e)
        {
            mindelay = (int)numericUpDown1Min.Value*1000; // 5000;//milliseconds 5000/1000=5 sec
            //int maxdelay = 15000;
        }

        private void numericUpDown2Max_ValueChanged(object sender, EventArgs e)
        {
            maxdelay = (int)numericUpDown2Max.Value * 1000;
        }

        private void BT_BotFather_Click(object sender, EventArgs e)
        {
            string botfather = "https://telegram.me/BotFather";
            System.Diagnostics.Process.Start(botfather);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            startmin = (int)numericUpDown2.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            endmin = (int)numericUpDown2.Value;
        }
    }

    public class ControlWriter : TextWriter
    {
        private Control textbox;
        public ControlWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            textbox.Text += value;
        }

        public override void Write(string value)
        {
            textbox.Text += value;
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }

}
