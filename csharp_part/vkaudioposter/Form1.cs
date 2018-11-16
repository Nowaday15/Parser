using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VkNet.Model.RequestParams;
using System.IO;
using System.Net;
using VkNet;
using VkNet.Model;
using VkNet.Model.Attachments;
using Newtonsoft.Json;
using System.Threading;
using AngleSharp;
using System.Diagnostics;
using System.Deployment.Application;
using System.Reflection;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Providers;
using IronPython.Runtime;
using System.Collections.ObjectModel;
//using ExtensionMethods;


//using Squirrel; //для обновления

namespace vkaudioposter
{

    public partial class Form1 : Form
    {
        private List<Track> SearchingList = new List<Track>();
        //string debug = "Список треков для поста";

        private List<Track> SelectedTrackList = new List<Track>();
        // string FullId;
        string nameofsoft = Properties.Settings.Default.nameofsoft.ToString();
        string error = "TEST";

        //string Token = "57da846be4093a126adc01a970a971b2fd699fca108fda53090dd41a180385988775854c6b0da7c88d602"; //для HVM
                                                                                                                //Получается https://oauth.vk.com/authorize?client_id=6707743&scope=notify,photos,friends,audio,video,notes,pages,docs,status,questions,offers,wall,groups,messages,notifications,stats,ads,offline&redirect_uri=http://api.vk.com/blank.html&display=page&response_type=token                                                                                                               
        string accesstoken = Properties.Settings.Default["accesstoken"].ToString(); //Приложение группы доступ к группе, получается в самом приложении в ручную Standalone приложение
                                                      //string accesskeypub = "79daf12051528f17da10ebc08c605cbb31aa0aca5630e76841413e98d64d6b758a3094770d892d7d7da29";		
        string Login = Properties.Settings.Default["Login"].ToString();
        string Password = Properties.Settings.Default["Password"].ToString();

        //string Token = "57da846be4093a126adc01a970a971b2fd699fca108fda53090dd41a180385988775854c6b0da7c88d602";
        string Token = Properties.Settings.Default["Token"].ToString();

        string MessageToAttach;
        //Для поиска
        string filepath = Properties.Settings.Default.filepath.ToString(); // файл с ответом запроса
        string url1 = "http://api.xn--41a.ws/api.php?method=search&q=";
        string url3 = Properties.Settings.Default["url3"].ToString();

        ulong? ownerid3 = Convert.ToUInt64(Properties.Settings.Default["ownerid3"]); //для сохранения фото на стене
        ulong ? groupid3 = Convert.ToUInt64(Properties.Settings.Default["groupid3"]);//для  сохранения фото на стене

        long groupid = (long)Properties.Settings.Default["groupid"]; //для загрузки на сервер
        string filechartname = Properties.Settings.Default.filechartname.ToString(); //размещение файла с чартом треков
        bool fileexist = false;
        //string picked_date = null; //обнуление
        DateTime publication_date; //для wall.post
        string filepath_archive = Properties.Settings.Default.filepath_archive.ToString();
        int resmes = 0;//результат поиска сообщение
        string ftpUsername = Properties.Settings.Default.ftpUsername.ToString();
        string ftpPassword = Properties.Settings.Default["ftpPassword"].ToString();
        string ftpAddress = Properties.Settings.Default["ftpAddress"].ToString();

        long ownid = -(long)Properties.Settings.Default["groupid"]; //может быть косяк, нужно сразу наверное ownid

        int number_of_strok = (int)Properties.Settings.Default["number_of_strok"]; //миллион символов


        int butflag = 0; //1- нажат треки, 2 - картинки, 0 - сброс после публикации
        //int tracksempty = 0;//1-если не набралось треков
        int resp_flag = 0; //Проверка выполения действия запроса  1 - треки успешно добавлены, 2 - картинка
        int min = 0;
        int flag = 0; //2-список вложений заполнен, 0 - пуст
        bool mode = false; //true-авто , false- ручной добавления треков
        bool posted = false; //опубликован?
        bool tracks_added = false;
        bool image_added = false;
        bool tracks_attached = false;
        bool downloaded = false;
        bool threadfinisghedmusic = false;
        bool deleteclicked = false;
        int addedcounter = 0;
        string style;
        string switcher;
        bool valuesSet = Properties.Settings.Default.Values_set;
        //  bool image_attached = false;
        List<MediaAttachment> attachments = new List<MediaAttachment>();
        List<MediaAttachment> atts = new List<MediaAttachment>();
        string photourl = null; //Прямая ссылка на фото
        string photofilename = Properties.Settings.Default.photofilename.ToString(); //скачанное фото
                                                //List<MediaAttachment> attachments = new List<MediaAttachment>();
                                                //string fourthpart = "&photo";
                                                //private IEnumerable<MediaAttachment> audio371745438_456560086;
                                                //int flagpost = 0; //1-опубликован
        string stylefilename =Properties.Settings.Default.stylefilename.ToString();
       // string newphotoname = "newtempimage.jpg";
        //string postpond_file = "postpond.txt";//файл отложки
        string imagefile;
        //Потоки
        // public delegate void AddListItem(int existcounter);
        // public AddListItem myDelegate;
        //private Button myButton;
        // private Thread myThread;
        string curDate = DateTime.Now.ToShortDateString();
        // public delegate void AddListItem(MakeUrlFromLines(url2));
        int trackscount=100;
        string HashTags = Properties.Settings.Default.HashTags;

        public Form1()
        {
            InitializeComponent();
           // label1.Text = debug;
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            CB_Styles.SelectedIndexChanged += CB_Styles_SelectedIndexChanged;
            //using (var mgr = new UpdateManager("C:\\Users\\Vladimir\\source\\repos\\vkaudioposter\\vkaudioposter\\bin\\Release"))
            //{
            //    //await mgr.UpdateApp();
            //}
            //  ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            //   fileItem.DropDownItems.Add("Создать");
            //   fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));

            //   menuStrip1.Items.Add(fileItem);

            //    ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            //    aboutItem.Click += TSMENU_About_Click;
            //   menuStrip1.Items.Add(aboutItem);
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_counter.Value = 10;
            //richTextBox1.MaxLength = 500;
            LoginForm loginForm = new LoginForm();
            //Проверка на long ulong нужна
            if ( string.IsNullOrEmpty(Properties.Settings.Default.Token.ToString()) || string.IsNullOrEmpty(Properties.Settings.Default.accesstoken.ToString()) ||
                 string.IsNullOrEmpty(Properties.Settings.Default.url3.ToString()) || string.IsNullOrEmpty(Properties.Settings.Default.ftpUsername.ToString()) ||
                 string.IsNullOrEmpty(Properties.Settings.Default.ftpPassword.ToString()) || string.IsNullOrEmpty(Properties.Settings.Default.ftpAddress.ToString()) ||
                 string.IsNullOrEmpty(Properties.Settings.Default.Login.ToString()) || string.IsNullOrEmpty(Properties.Settings.Default.Password.ToString()) ||
                 string.IsNullOrEmpty(Properties.Settings.Default.AppId.ToString())
                )//|| Properties.Settings.Default.ownerid3 == 1 || Properties.Settings.Default.groupid3 == 1 ||Properties.Settings.Default.groupid == 1 || Properties.Settings.Default.ownid == 1
            {
               // valuesSet = false;
                // Show the settings form
                loginForm.Show();
                
                //button1.Enabled = false;
               // repostToolStripMenuItem.Enabled = false;
                //loginForm.
            }
            else
            {
                valuesSet = true;
               // button1.Enabled = true;
                //repostToolStripMenuItem.Enabled = true;
            }

            //if (Properties.Settings.Default.FirstRun == true)
            //{
            //    //lblGreetings.Text = "Welcome New User";
            //    MessageBox.Show("В этой версии:" +
            //    "\n*Исправлен баг с добавлением более 9 треков вручную" +
            //    "\n*Добавлено меню информации о приложении" +
            //    "\n*");
            //    //Change the value since the program has run once now
            //    Properties.Settings.Default.FirstRun = false;
            //    Properties.Settings.Default.Save();
            //}
            //else
            //{
            //    // lblGreetings.Text = "Welcome Back User"; 
            //}
            CB_Styles.Items.Add("All styles");
            CB_Styles.Items.Add("AFRO HOUSE");
            CB_Styles.Items.Add("BIG ROOM");
            CB_Styles.Items.Add("BREAKS");
            CB_Styles.Items.Add("DJ TOOLS");
            CB_Styles.Items.Add("DANCE");
            CB_Styles.Items.Add("DEEP HOUSE");
            CB_Styles.Items.Add("DRUM & BASS");
            CB_Styles.Items.Add("DUBSTEP");
            CB_Styles.Items.Add("HARDCORE / HARD TECHNO");
            CB_Styles.Items.Add("HIP-HOP / R&B");
            CB_Styles.Items.Add("HOUSE");
            CB_Styles.Items.Add("INDIE DANCE / NU DISCO");
            CB_Styles.Items.Add("LEFTFIELD BASS");
            CB_Styles.Items.Add("LEFTFIELD HOUSE & TECHNO");
            CB_Styles.Items.Add("MELODIC HOUSE & TECHNO");
            CB_Styles.Items.Add("MINIMAL / DEEP #TECH");
            CB_Styles.Items.Add("ELECTRO HOUSE");
            CB_Styles.Items.Add("ELECTRONICA / DOWNTEMPO");
            CB_Styles.Items.Add("FUNK / SOUL / DISCO");
            CB_Styles.Items.Add("FUNKY / GROOVE / JACKIN' HOUSE");
            CB_Styles.Items.Add("FUTURE HOUSE");
            CB_Styles.Items.Add("GARAGE / BASSLINE / GRIME");
            CB_Styles.Items.Add("GLITCH HOP");
            CB_Styles.Items.Add("HARD DANCE");
            CB_Styles.Items.Add("PROGRESSIVE HOUSE");
            CB_Styles.Items.Add("PSY-TRANCE");
            CB_Styles.Items.Add("REGGAE / DANCEHALL / DUB");
            CB_Styles.Items.Add("TECH HOUSE");
            CB_Styles.Items.Add("TECHNO");
            CB_Styles.Items.Add("TRANCE");
            CB_Styles.Items.Add("TRAP / FUTURE BASS");

                if (ApplicationDeployment.IsNetworkDeployed == true)
                {
                    Version ver = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                    //LB_version.Enabled = true;
                    // LB_version.Text = "Версия сборки - v{0}" + ver.ToString(4);

                    Text = "High Volume Music Parser.                              Версия сборки - v_" + ver.ToString(4);
                }
                else
                {

                    Text = "High Volume Music Parser.                              Версия локальной сборки - v." + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    // LB_version.Enabled = false;
                }


            // button1_Click(sender,e); //загрузка списка найденных треков - тормозит систему при старте
            //button2.Enabled = false; //Нельзя картинку без треков
            button6.Enabled = false; //Нельзя опубликовать без треков
            textBox3.Enabled = false;//Не включать строку ввода ссылки без нажатия круглешка
                                     // RB_Auto.Checked = true;
            Btn_DeleteTrackFromSelectedList.Enabled = false;
            Btn_DeleteTrackFromSelectedList.Visible = false;
            pictureBox1.Visible = false;
            button3.Enabled = false;
            button2.Enabled = true;
            RB_Manual.Checked = false;
            // button1.Enabled = false; 

            LstBox_AddedTracks.Enabled = false;
            label4.Visible = false;//prewiev image
            CHB_ToAudio.Checked = false;
            //Обновление времени
            //dateTimePicker1.MinDate = new DateTime();
            string curDate = DateTime.Now.ToShortDateString();
            string curDate3 = DateTime.Now.ToString();
            //Значение по умолчанию для даты - сегодня сейчас
            // 06.03.2014 14:10:00
            int day2 = int.Parse(curDate.Split('.')[0]);
            int month2 = int.Parse(curDate.Split('.')[1]);
            int year2 = int.Parse(curDate.Split('.')[2]);
            string curTimeLong2 = DateTime.Now.ToLongTimeString();//Результат: 8:49:10
            int hour2 = int.Parse(curTimeLong2.Split(':')[0]);
            int min2 = int.Parse(curTimeLong2.Split(':')[1]);
            int sec2 = int.Parse(curTimeLong2.Split(':')[2]);
            dateTimePicker1.Value = new DateTime(Convert.ToInt32(year2), Convert.ToInt32(month2), Convert.ToInt32(day2), Convert.ToInt32(hour2), Convert.ToInt32(min2), Convert.ToInt32(sec2));

            //если файл пустой запарсите
            //timer1.Start;
            //VivodNaScreen(filechartname);
            timer1.Interval = 500; // 500 миллисекунд
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            //string curDate = DateTime.Now.ToShortDateString();
            //Результат: 06.03.2014
            //string curDate2 = DateTime.Now.ToLongDateString();
            //Результат: 6 марта 2014 г.
            //DateTime curFullDate = DateTime.Now;
            //Результат: 06.03.2014 14:10:00
            //string curDate3 = DateTime.Now.ToString();
            //label5.Text = curDate3;
            // richTextBox1.
           
            
            label6.Text = "Выбери картинку, введи сообщение";
            //int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            //long SelectedDate = DatePick(curDate3);
            //label6.Text = SelectedDate.ToString();


        }


        //[TEST пока нет! ]Получаем название стиля из файла асинхронно []
        private string GetStylec()
        {

            //проверить существует ли этот файл?
            if (System.IO.File.Exists(stylefilename))
            {
                FileStream file_style = new FileStream(stylefilename, FileMode.Open); //открытие существующего файла
                StreamReader reader = new StreamReader(file_style, Encoding.UTF8); // создаем «потоковый читатель» и связываем его с файловым потоком
                string style = reader.ReadLine();
                //style = GetStylec();

                Invalidate();
                //style_name = fileText;
                reader.Close();
                return style;
            } else
            {
                string style = null;
                // MessageBox.Show("Ошибка! Заупстите сначала парсер!"); //Пока не над
                return style;
            }

            //stylefilename
        }

        private void proverkanullfile()
        {
            //Проверка на файл чарт, если есть, включаем кнопку
            if (System.IO.File.Exists(filechartname))
            {
                // button1.Enabled = true;
                // button6.Enabled = true;
                VivodNaScreen(filechartname);
                string[] strok = File.ReadAllLines(filechartname);

                if (strok.Length == -0) //не работает Проверка на пустой файл
                {
                    button1.Enabled = false; //поиск

                    //string message = "Файл с чартом треков пуст!\nСначала нажмите Парсер (by Nowaday/Илья Опарин)";
                    //string caption = "Ошибка!";
                    //MessageBoxButtons buttons = MessageBoxButtons.OK;
                    //MessageBoxIcon iconsMB = MessageBoxIcon.Error;

                    //MessageBox.Show(message, caption, buttons, iconsMB);
                    //   Process.Start(nameofsoft);
                    fileexist = false;
                }
                else
                {
                    int count = System.IO.File.ReadAllLines(filechartname).Length;
                    label1.Text = "Список треков: [" + count + "] в стиле";
                    fileexist = true;
                    button1.Enabled = true;
                    //MakeUrlFromLines(filechartname);
                    //LoadListOfTracks
                }


            }
            else
            {
                fileexist = false;
                button1.Enabled = false; //поиск
                button6.Enabled = false;
                // MessageBox.Show("Ошибка! Файл с чартом треков отсутствует!\nСначала запустите BeatPort Parser.exe (by Nowaday/Илья Опарин)");
                //MessageBoxIcon
            }
        }

        public void AddListItemMethod(int i)
        {
            var context = SynchronizationContext.Current;
            // Способ 1
            //    while (true)
            //    {
            //        if (InvokeRequired)
            //        {


            Invoke(new Action(() =>
            {
                string lst1elem = i + 1 + ") " + SearchingList[i].GetTitle();
                // Concat(i+SearchingList[i].GetTitle());
                // Обновляем 
                listBox1.Items.Add(lst1elem);

                //  context.Send(obj => listBox1.Items.Add(SearchingList[i].GetTitle()), Task.CompletedTask);
            }));
            //  listBox1.Items.Add(SearchingList[i].GetTitle());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.MaxLength = 1000;
            MessageToAttach = richTextBox1.Text; //сообщение к посту
            //message = richTextBox1.Text.Replace(" ", "%20"); //это если мы вручную запрос формируем
        }

        //Вывод содержимого текстового файла с треками и удаление %20
        public void VivodNaScreen(string file_path)
        {
            //Графический вывод файла ЗАПРОСА в поле 
            FileStream file1 = new FileStream(file_path, FileMode.Open); //открытие существующего файла
            StreamReader reader = new StreamReader(file1, Encoding.UTF8); // создаем «потоковый читатель» и связываем его с файловым потоком
            string fileText = reader.ReadToEnd();
            var strWithoutSpaces = fileText.Replace("%20", " ");
            textBox1.Text = strWithoutSpaces;
            Invalidate();
            reader.Close();
        }

        //Создает из файла чарта Коллекцию вложенных аудио
        public void MakeUrlFromLines(string filename)
        {
           // JsonSearch getSearch = new JsonSearch();
           
            string url2;
            int existcounter = 0;
            string artistname = ""; //-получаем
            string tracktitle = ""; //-получаем
                                    //  int flag = 0;
            string[] lines = File.ReadAllLines(filename);
            int rows = lines.GetUpperBound(0) + 1;
            var api = new VkApi();
            //Авторизация
            api.Authorize(new ApiAuthParams
            {
                AccessToken = Token
            });

            // label6.Text = "Загружаем список треков";
            var res = api.Groups.Get(new GroupsGetParams());
            Invoke(new Action(() =>
            {
                label6.Text = "Ищем в поиске треки";
                //   PB_Download.Value += 1;
            }));

            //return Task.Run(() =>
            int unsearchtracks = 0; //не найдено
            int publishedtracks = 0; //уже опубликовано
            //для каждой строки с названием
            foreach (var K in lines)
            {
                AddedTracksFile(null); //дозаписываем строку
                string s = File.ReadAllText(filepath_archive); //одна большая строка
                //Проверяем, опубликован ли этот трек уже на стене? Если нет, выполняем поиск, если да, перескакиваем на след. строку и ищем след. трек
                //Нужно прочитать файл по строкам с архивом и выполнить поиск по совпадению названия элемента K
                //Пробегаем циклом по файлу архива
                if (s.IndexOf(K) != -1) //пока не дошли до конца ищем первое совпадение
                {
                    //Нашли такой же трек- он был опубликован, значит пропускаем
                    publishedtracks++;
                    continue;
                }

                else
                {
                    //Если такого трека нет в файле, выполняем поиск в ВК 
                    url2 = K;
                    string url = ConcatSearchReq(url1, url2, url3);
                    Invoke(new Action(() =>
                     {
                                     //  label6.Text = "Ищем в поиске треки";
                                     
                         if (PB_Download.Value >= PB_Download.Maximum-1)
                             PB_Download.Value = 0;
                         PB_Download.Value += 1;
                     }));
                    //---------------------------НЕ РАБОТАЕТ ПУБЛИЧНЫЙ АПИ----------------------------
                    //var strWithoutSpaces = url2.Replace("%20", " ");
                    ////Ищем треки в поиске, записываем все в лист элементов, затем сравниваем каждый эл.АудиоИмя из листа поиска с названием трека который нужно найти
                    ////если название и исполнитель совпадают, добавляем, если нет - прерываем поиск, переходим к след.элементу
                    //var audios = api.Audio.Search(new AudioSearchParams
                    //{
                    //    Query = strWithoutSpaces,
                    //    Autocomplete = false, //Исправлять ошибки, хз надо ли
                    //    //Query = url2,
                    //    Count = 30,
                    //    Sort = 0, //По дате добавления сортировка
                    //});
                    //for (int i = 0; i < audios.Count; i++)
                    //    Console.WriteLine(audios[i].Id); //Почему-то возвращает Аудио доступно на Vk.com
                    //Console.ReadLine();
                    //каждый элемент из запроса сравниваем с названием и исполнителем из списка парсера

                    //int j = 0;             
                    //for (ulong i =0; i<audios.TotalCount;i++)
                    //{
                    //    if ((audios[j].Artist == artistname && audios[j].Title == tracktitle)&&(j<=30)) //если нашли совпадение,
                    //    {
                    //        //получаем ID каждой совпавшей песни 
                    //        var ids = new string[] { audios[j].Id.ToString()};
                    //        Console.WriteLine(ids);
                    //        Console.ReadLine();
                    //        //Возвращаем инфу о найденной аудиозаписи в виде нумерованного списка {owner_id}_{audio_id}
                    //        var aud =  api.Audio.GetById(ids);
                    //        Console.WriteLine(aud);
                    //        Console.ReadLine();
                    //        SearchingList.Add(new Track(url2, aud.ToString())); //нужно переписать класс и добавить туда Artist & Title
                    //        AddedTracksFile(K); //Этот трек записали в файл с историей найденных треков
                    //        AddListItemMethod(existcounter);
                    //        existcounter++;
                    //        break;
                    //    }else
                    //    j++;
                    //}
                    //-----------------------------------------------------

                    //---------------Old-------------------------
                    string json = JsonSearch(url);

                    if (json != null)
                    {
                        FileWrite(json); //записали в файл, очистили после выполнения
                        var strWithoutSpaces = url2.Replace("%20", " "); //Запрос поиска Имя+трек+микс
                        string FullId = GetFullIdFromFile(strWithoutSpaces);//нашли в запросе ID первой песни 

                        if (FullId != "0") //если нашли трек в поиске
                        {
                            SearchingList.Add(new Track(url2, FullId));
                            //Если нашли трек, добавляем его в файл истории - чтобы его больше не добавлять. Затем проверяем перед этим есть ли данный трек в файле output, если есть, то не ищем

                            AddedTracksFile(K); //Этот трек записали в файл с историей найденных треков
                                                // Sel_Track.Add({ Title = KWithoutSpaces, FullId = FullId, MediaId = Audioid, OwnerId = ownerid }); //Добавили трек в класс, наполнили его
                            AddListItemMethod(existcounter);
                            Invoke(new Action(() =>
                            {
                                // label6.Text = "Ищем в поиске треки";

                                
                                label8.Text = "Результаты поиска: " + SearchingList.Count;
                                if (PB_Download.Value >= PB_Download.Maximum - 1)
                                    PB_Download.Value = 0;
                                PB_Download.Value += 1;
                                

                            }));
                            existcounter++;
                        } else { unsearchtracks++; }
                        //если не нашли не добавляем в массив
                        //если счетчик достиг 9 треков, остановить поиск!
                        if (existcounter == 9)
                        {
                            // threadfinisghedmusic = true;
                            Invoke(new Action(() =>
                            {
                                label8.Text = "Результаты поиска: " + SearchingList.Count;
                                // label6.Text = "Ищем в поиске треки";
                                if (PB_Download.Value >= PB_Download.Maximum - 1)
                                    PB_Download.Value = 0;
                                PB_Download.Value += 1;

                            }));
                            break;
                        }
                        //----------------------OLD------------
                    } else { break; }
                }
                // Thread.Sleep(300);
            }
            threadfinisghedmusic = true;
            if (SearchingList.Count == 0)
            {
                threadfinisghedmusic = false;
                // MessageBoxButtons.OK = 1;
                //ErrorD

                string message = "Все треки из списка были опубликованы или в поиске не нашлось свежих треков.\nОбновите список треков!";
                string caption = "Внимание!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon iconsMB = MessageBoxIcon.Warning;

                MessageBox.Show(message, caption, buttons, iconsMB);
                resmes = 1;
                //MessageBox.Show("Все треки из списка были опубликованы, обновите список треков!");
                Invoke(new Action(() =>
                {
                    PB_Download.Value = 0;
                }));
            }
            int count = System.IO.File.ReadAllLines(filechartname).Length;
            string message2 = "Список треков обработан\nРезультат:\n" + SearchingList.Count + "/" + count + "\n" + publishedtracks + " -уже опубликованных\n" + unsearchtracks + " -не найдено в поиске";
            string caption2 = "Внимание!";
            MessageBoxButtons buttons2 = MessageBoxButtons.OK;
            MessageBoxIcon iconsMB2 = MessageBoxIcon.Information;

            MessageBox.Show(message2, caption2, buttons2, iconsMB2);
            // MessageBox.Show("Список треков обработан.");
            resmes = 1;
            Invoke(new Action(() =>
            {
                //resmes = 1;
                // label6.Text = "Ищем в поиске треки";
                if (PB_Download.Value >= PB_Download.Maximum - 1)
                    PB_Download.Value = 0;
                PB_Download.Value += 1;
            }));
            return;
            //});
        }

        //Выбранный элемент перемещаем в лист бокс ВЛОЖКА
        public void IAmSelectedElement(int elementid = -1)
        {
            if (elementid == -1)
            {
                MessageBox.Show("В IAmSelectedElement get=-1");
                //elementid = listBox1.SelectedIndex();
            }
            if (addedcounter < 9)
            {
                SelectedTrackList.Add(SearchingList[elementid]);
                string lstboxelem = elementid + 1 + ") " + SearchingList[elementid].GetTitle();
                LstBox_AddedTracks.Items.Add(lstboxelem);
                label9.Text = "Вложка треков: " + LstBox_AddedTracks.Items.Count;

                addedcounter++;

            }

            return;
        }

        //[Вспомогательно] Создание/открытие или дозапись файла со списком добавленных на стену треков [Содержится в MAKEURLFROMLINES]
        public void AddedTracksFile(string tracks)
        {

            //если файл существует
            //if (System.IO.File.Exists(filepath_archive))
            //{
            //using (WebClient client = new WebClient())
            //{
            //    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            //    client.DownloadFile("ftp://rhiskey@ftp.drivehq.com/posted_tracks.dll", WebRequestMethods.Ftp.DownloadFile);
            //}
            int charCount = File.ReadAllText(filepath_archive).Length;
            //string[] strok = File.ReadAllLines(filepath_archive);
            //FileStream file1 = new FileStream(filepath_archive, FileMode.Open);
            //string dline = File.OpenRead(filepath_archive);
            //Если число строк в файле больше или равно 10000
            if (charCount >= number_of_strok)
            {
                //Нужно удалить начало файла
                File.WriteAllText(filepath_archive, String.Empty); //очистили файл
            }
            else
            {
                FileStream file1 = new FileStream(filepath_archive, FileMode.Append); //открытие файла на дозапись в конец файла
                StreamWriter writer = new StreamWriter(file1, Encoding.UTF8); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.Write(tracks); //записываем в файл (раньше было json)
                writer.Close();
            }
            //}
            //если его нет
            //else
            //{
            //    //Скачиваем новый файл с сервера в любом случае
            //    FileStream file1 = new FileStream(filepath_archive, FileMode.CreateNew); //создание нового файла
            //    StreamWriter writer = new StreamWriter(file1, Encoding.UTF8); //создаем «потоковый писатель» и связываем его с файловым потоком
            //    writer.Write(tracks); //записываем в файл (раньше было json)
            //    writer.Close();
            //}
        }

        //[ВСПОМОГАТЕЛЬНО] запрос поиска аудио [Содержится в MakeUrlFromLines]
        public string ConcatSearchReq(string url1, string url2, string url3)
        {
            var url = url1 + url2 + url3;
            return (url);
        }

        //[ВСПОМОГАТЕЛЬНО]Скачивание результата запроса поиска [Содержится в MakeUrlFromLines]
        public string JsonSearch(string url)
        {
            string json, response;
            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                webClient.QueryString.Add("format", "json");
                try
                {
                    response = webClient.DownloadString(url);
                }
                catch (Exception) {
                    MessageBox.Show("Слишком много поисковых запросов! Повтори позднее");
                    response = null;
                    Invoke(new Action(() =>
                {
                    PB_Download.Value = 0;
                }));
                }
                json = JsonConvert.SerializeObject(response);

            }
            // Audio.FromJson(json);
            return json;
        }

        //[ВСПОМОГАТЕЛЬНО] Перезапись, запись, создание файла  [Содержится в MakeUrlFromLines]
        public void FileWrite(string json)
        {
            //если файл существует
            if (System.IO.File.Exists(filepath))
            {
                string[] strok = File.ReadAllLines(filepath);
                File.WriteAllText(filepath, String.Empty); //очистили файл
                FileStream file1 = new FileStream(filepath, FileMode.Open); //создание нового файла
                StreamWriter writer = new StreamWriter(file1, Encoding.UTF8); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.Write(json); //записываем в файл (раньше было json)
                writer.Close();
            }
            //если его нет
            else
            {
                FileStream file1 = new FileStream(filepath, FileMode.CreateNew); //создание нового файла
                StreamWriter writer = new StreamWriter(file1, Encoding.UTF8); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.Write(json); //записываем в файл (раньше было json)
                writer.Close();
            }

        }

        //[ВСПОМОГАТЕЛЬНО] Получение перовго найденного ID трека из поиска [Содержится в MakeUrlFromLines]
        public string GetFullIdFromFile(string SearchingName)
        {
            //поиск совпадения по названию трека
            string path = filepath;
            string s = File.ReadAllText(path);//файл json ответа
            string subs2 = "0";

            //Поиск названия по алгоритму Левенштейна (сравнение расстояний между строками - примерный поиск)
            var charsToRemove = new string[] { ",", "\u0022", "\\", "//" }; //удаляем лишние символы и заменяем на пробелы или пустоту
            foreach (var c in charsToRemove)
            {
                s = s.Replace(c, string.Empty);
            }
            int diff = LevenshteinDistance(SearchingName, s); //Получение расстояния между строками исходной и результатов
            Console.WriteLine("diff= " + diff);
            //  int indname = s.IndexOf(SearchingName); //в точности не ищет
            //  Console.WriteLine(indname);
            Console.ReadLine();
            int errind = -1;
            int errind2 = -1;
            errind = s.IndexOf("error: audio_search"); //ошибка поиска может вылететь, проверка
            errind2 = s.IndexOf("no key"); //ошибка поиска может вылететь, проверка
            Console.WriteLine("err=" + errind);
            Console.ReadLine();
            //diff>35 чтобы ошибок не было, костыль
            if ((diff != -1) && (diff <= 1000) &&(diff>35)&& (diff != 0) && (errind == -1)&&(errind2==-1)) //проверка на пустоту и расстояние чтобы поиск был точным (расхождение символов)
            {
                string subsname = s.Remove(0, diff); //удалили все что до этого найденного совпадения
                Console.WriteLine("Удаление до совпадения= " + subsname);
                Console.ReadLine();

                if (s.IndexOf("content_id") != -1)//пока не дошли до индекса первого найденного слова content_id
                {
                    int ind = s.IndexOf("content_id"); //позиция content id
                    string subs = s.Remove(0, ind + 11); //сместились, удалили все что до цифр, включая content_id это 15 элементов с кракозябрами
                    Console.WriteLine("Айди+все что далее= " + subs);
                    Console.ReadLine();
                    int ind2 = subs.IndexOf("s:"); //нашли символ "\" после цифр
                    subs2 = subs.Substring(0, ind2); //вычли подстроку до символа "\" 
                    Console.WriteLine("Чистый айди= " + subs2);
                    Console.ReadLine();
                    //FullId = subs2;
                }

            }

            //Поиск первого найденного ID
            //if (s.IndexOf("content_id") != -1) //пока не дошли до первого найденного слова
            //{
            //    int ind = s.IndexOf("content_id"); //позиция content id
            //    string subs = s.Remove(0, ind + 15); //сместились, удалили все что до цифр, включая content_id это 15 элементов с кракозябрами
            //    int ind2 = subs.IndexOf("\\"); //нашли символ "\" после цифр
            //    subs2 = subs.Substring(0, ind2); //вычли подстроку до символа "\" 
            //                                     //FullId = subs2;
            //}

            return subs2;
        }


        //Поиск расстояния между похожими строками
        private int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) throw new ArgumentNullException("string1");
            if (string2 == null) throw new ArgumentNullException("string2");
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                                             m[i, j - 1] + 1),
                                             m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }

        //Очистка после УСПЕШНОЙ публикации
        private void ClearAll()
        {
            string filePath = photofilename;
            //downloaded = false; //фотка не скачана - скачать заново тип
             addedcounter = 0;
            if (PB_Download.Value >= PB_Download.Maximum-1)
                PB_Download.Value = 0;
            PB_Download.Value = 0;

            if (progressBar1.Value >= progressBar1.Maximum-1)
                progressBar1.Value = 0;

            progressBar1.Value = 0;
            //Добавляем трек в историю


            //File.Delete(filePath); //Удаление картинки как только добавили
            // (listBox1.Items);
            //Очистка списка найденных и вложки
            deleteclicked = false;
            for (int i = 0; i < listBox1.Items.Count; i++)
                listBox1.Items.RemoveAt(i);

            listBox1.Items.Clear();
            tracks_attached = false;
            //  SelectedTrackList.RemoveAt(LstBox_AddedTracks.SelectedIndex);
            // LstBox_AddedTracks.Items.RemoveAt(LstBox_AddedTracks.SelectedIndex);

            //Чистим массив списка поиска
            for (int i = 0; i < SearchingList.Count; i++)
                SearchingList.RemoveAt(i);

            SearchingList.Clear();
            //Чистим добавленные треки визуально

            //LstBox_AddedTracks.Items.Clear();
            for (int i = 0; i < LstBox_AddedTracks.Items.Count; i++)
                LstBox_AddedTracks.Items.RemoveAt(i);

            for (int i = 0; i < SelectedTrackList.Count; i++)
                SelectedTrackList.RemoveAt(i);

            SelectedTrackList.Clear();
            LstBox_AddedTracks.Items.Clear();

            pictureBox1.Image.Dispose();
            //    File.Delete(photofilename);
            //   pictureBox1.Image = null;


            textBox3.Text = null;
            //Надо очистить attachments
            for (int i = 0; i < attachments.Count; i++)
                attachments.RemoveAt(i);

            attachments.Clear();
            //attachments.RemoveAll();
            //attachments.Count
            //Очистить фото из attachments
            //pictureBox1.Dispose();

            TempImage(photofilename); //Удаление картинки как только добавили

            //Плсде публикации файл photofilename используется другим процессом?!
            //File.Delete(photofilename);

            //После публикации используется другим процессом, нужно где-то освободить использование файла
            // FileStream stream = new FileStream(photofilename, FileMode.CreateNew);
            // bmp.Save(stream, image.RawFormat);
            // stream.Close();

            //в группу залив
            //CHB_ToAudio.Checked = false;

            //listBox1.Items.Remove
            //Сброс поста после публикации
            downloaded = false;
            butflag = 0;
            flag = 0;
            resp_flag = 0;
            posted = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            RB_Manual.Enabled = true;
            RB_Auto.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false; //треки в аттачи
                                     //button3.Enabled = true;
                                     //Таймер выставить на текущее значение
            image_added = false; //сбросили кнопку //МОЖЕТ БАГАТЬ
                                 // PB_Download.Value = 0;
            threadfinisghedmusic = false;
            tracks_added = false;
        }

        //Опубликовать
        private void btPublish_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите опубликовать пост?";
            string caption = "Ждите завершения операции!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon iconsMB = MessageBoxIcon.Question;
            DialogResult result;
            if (PB_Download.Value >= PB_Download.Maximum - 1)
                PB_Download.Value = 0;
            PB_Download.Value += 1;

            result = MessageBox.Show(message, caption, buttons, iconsMB);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button6.Enabled = false;

                //PB_Download.Value += 1;
                if (posted == false)
                    AddTracksToAttachments(); //добавили в аттачи выбранные треки
                                              // AddPicture(); //добавить в аттачи выбранную фотку
               // PB_Download.Value += 1;                          //Добавим фото в аттачи

                if ((image_added == true) && (posted == false))
                {
                    if ((radioButton2.Checked == true) && (textBox3.TextLength > 0)) //Если выбрали загрузку по ссылке
                    {
                        AddPhotoToAttachFromUrl();
                        radioButton1.Enabled = false;
                        if (PB_Download.Value >= PB_Download.Maximum - 1)
                            PB_Download.Value = 0;
                        PB_Download.Value += 1;
                    }
                    else
                    {
                        AddPhotoToAttachFromPC();
                        radioButton2.Enabled = false;
                        if (PB_Download.Value >= PB_Download.Maximum - 1)
                            PB_Download.Value = 0;
                        PB_Download.Value += 1;
                    }
                }
                //BTN_AddImageToAttach.Click();

                //создаем новый поток
                // MessageBox.Show("Размещаю пост на стену...Ждите завершения операции!");
                label6.Text = "Размещаем пост на стену";
                //Загружаем файл AddedTracksFile на сервер
                //using (WebClient client = new WebClient())
                //{
                //    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                //    client.UploadFile(ftpAddress, WebRequestMethods.Ftp.UploadFile, filepath_archive);
                //}

                // if (posted == true)
                // LoadHistoryFileToServer();
                if (PB_Download.Value >= PB_Download.Maximum - 1)
                    PB_Download.Value = 0;
                PB_Download.Value += 1;

                //File.Delete(filepath_archive);
                if (CHB_ToAudio.Checked == true)
                    AddMusicToPublic();

                if (PB_Download.Value >= PB_Download.Maximum - 1)
                    PB_Download.Value = 0;
                PB_Download.Value += 1;
                PosterOnWall(attachments, flag);
                if (PB_Download.Value >= PB_Download.Maximum - 1)
                    PB_Download.Value = 0;
                PB_Download.Value += 5;
                //Добавляем ВСЕ найденные треки в группу, неважно что пользователь там навыбирал
                //AddMusicToPublic();
                //posted = true;
                label6.Text = "Готово!";
               // progressBar1.Value = 100;
                PB_Download.Value = 100;
                progressBar1.Value = 0;

            }
            if (result == System.Windows.Forms.DialogResult.No)
            {

            }

        }

        private void LoadHistoryFileToServer()
        {
            try
            {
                // Создаем объект FtpWebRequest - он указывает на файл, который будет создан
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress);
                // устанавливаем метод на загрузку файлов
                request.Method = WebRequestMethods.Ftp.UploadFile;
                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                // создаем поток для загрузки файла
                FileStream fs = new FileStream(filepath_archive, FileMode.Open);
                byte[] fileContents = new byte[fs.Length];
                fs.Read(fileContents, 0, fileContents.Length);
                fs.Close();
                request.ContentLength = fileContents.Length;

                // пишем считанный в массив байтов файл в выходной поток
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                // получаем ответ от сервера в виде объекта FtpWebResponse
                //       request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                // FtpWebResponse response = (FtpWebResponse)request.GetResponse();


                Console.WriteLine("Загрузка файлов завершена. Статус: {0}", response.StatusDescription);

                response.Close();
                requestStream.Close();// request.Close();
                Console.Read();
            }
            catch (Exception) {
                string message2 = "Загрузка файла истории на сервер не произошла";
                string caption2 = "Ошибка!";
                MessageBoxButtons buttons2 = MessageBoxButtons.RetryCancel;
                MessageBoxIcon iconsMB2 = MessageBoxIcon.Error;

                var result = MessageBox.Show(message2, caption2, buttons2, iconsMB2);
                if (result == DialogResult.Retry)
                {
                    // Создаем объект FtpWebRequest - он указывает на файл, который будет создан
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress);
                    // устанавливаем метод на загрузку файлов
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    // This example assumes the FTP site uses anonymous logon.
                    request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();

                    // создаем поток для загрузки файла
                    FileStream fs = new FileStream(filepath_archive, FileMode.Open);
                    byte[] fileContents = new byte[fs.Length];
                    fs.Read(fileContents, 0, fileContents.Length);
                    fs.Close();
                    request.ContentLength = fileContents.Length;

                    // пишем считанный в массив байтов файл в выходной поток
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();

                    // получаем ответ от сервера в виде объекта FtpWebResponse
                    //       request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    // FtpWebResponse response = (FtpWebResponse)request.GetResponse();


                    Console.WriteLine("Загрузка файлов завершена. Статус: {0}", response.StatusDescription);

                    response.Close();
                    requestStream.Close();// request.Close();
                    Console.Read();
                }
                // MessageBox.Show("Ошибка загрузки файла на сервер");
            }
        }

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
            label6.Text = "Авторизировались";
            var getWallUploadServer = api.Photo.GetWallUploadServer(groupid);
            string uploadurl = getWallUploadServer.UploadUrl;
            long? userid = getWallUploadServer.UserId;
            long? albumid = getWallUploadServer.AlbumId;

            //getWallUploadServer.

            // Загрузить фотографию.
            var wc = new WebClient();
            string responseImg = null;
            if (downloaded == false)
            {
                responseImg = Encoding.ASCII.GetString(wc.UploadFile(uploadurl, filename));
                responseImg.GetHashCode();
            }
            else
            {
                responseImg = Encoding.ASCII.GetString(wc.UploadFile(uploadurl, filename));
                responseImg.GetHashCode();
            }
            //ReadOnlyCollection<Photo> photolist = new ReadOnlyCollection <Photo>;
            //добавили стиль в хэштеги
            style = GetStylec();

            //сделать проверку на существование
            //if (style != null)
            //{
            //    style = style.Replace("/", "");
            //    style = style.Replace(" ", " #");
            //    string HashTags_style = HashTags + " " + style;
            //    var photolist = api.Photo.SaveWallPhoto(responseImg, ownerid3, groupid3, HashTags_style); //Сохранили фото на стену
            //}
            style = style.Replace("/", "");
            style = style.Replace(" ", " #");
            string HashTags_style = HashTags + " " + style;
            var photolist = api.Photo.SaveWallPhoto(responseImg, ownerid3, groupid3, HashTags_style); //Сохранили фото на стену
            return photolist;
        }

        //Пост на стену
        public string PosterOnWall(List<MediaAttachment> attachments, int flag)
        {
            var api = new VkApi();
            //api.Wall.Get(skipAuthorization=false);
            //Авторизация
            api.Authorize(new ApiAuthParams
            {
                AccessToken = Token
            });
            //Console.WriteLine(api.Token);
            var res = api.Groups.Get(new GroupsGetParams());
            //Console.WriteLine(res.TotalCount);
          //  progressBar1.Value = 80;
            label6.Text = "Авторизировались";
            label6.Text = "Треки/картинка добавлены на стену";
            //Отложенная запись добавить
            //Текущие дата/время хранятся в свойстве Now класса DateTime
            //flag показывает заполнен ли список вложений, 
            if (checkBox1.Checked == true) //отложка
            {    //нужна проверка на дату публикации, чтобы она прибавлялась на 5 минут вперед если отложка
                 //Читаем файл postpond.txt , проверяем нет ли там даты публикации, если нет, то публикуем, если есть - ошибка
                if (
                    ((MessageToAttach != null) && (flag == 2)) ||
                    ((flag == 2) && (MessageToAttach == null)) ||
                   ((flag == 0) && (MessageToAttach != null))
                    )
                {
                    try
                    {
                        var post = api.Wall.Post(new WallPostParams
                        {
                            Attachments = attachments,
                            //PublishDate=,
                            OwnerId = ownid,
                            //FromGroup = 1,
                            Message = MessageToAttach,
                            PublishDate = publication_date
                        });
                        LoadHistoryFileToServer();
                        error = "Пост опубликован";
                        string message2 = "Пост добавлен в отложенные записи!\nПубликация запланирована на " + publication_date;
                        string caption2 = "Информация";
                        MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                        MessageBoxIcon iconsMB2 = MessageBoxIcon.Information;

                        MessageBox.Show(message2, caption2, buttons2, iconsMB2);
                        // MessageBox.Show("Пост добавлен в отложенные записи");
                        if (chk_openbrowser.Checked == true)
                        {
                            //    ShowPublic OpenWeb = new ShowPublic(); //смотрим стену отложку
                            //    OpenWeb.ShowDialog();
                        }
                        //webBrowser1.Navigate("https://m.vk.com/hvmlabel?own=1#wall");
                        //SendKeys.Send("{F5}");
                        //min = min+5; //увеличили на 5 минуты
                        checkBox1.Checked = false; //сбросили выбор отложки
                       // progressBar1.Value = 100;
                        ClearAll();
                       // progressBar1.Value = 0;
                        posted = true;
                    }
                    catch (Exception)
                    {
                        string message2 = "На это время уже запланирована публикация!\nИзмените дату, удалите картинку и снова нажмите 'Отправить' !";
                        string caption2 = "Ошибка!";
                        MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                        MessageBoxIcon iconsMB2 = MessageBoxIcon.Error;

                        MessageBox.Show(message2, caption2, buttons2, iconsMB2);
                        //ClearAll();
                        // for (int i = 0; i < attachments.Count; i++)
                        //      attachments.RemoveAt(i);

                        //  attachments.Clear();
                    }

                }
                else
                {
                    error = "Заполните поле сообщение или добавьте вложения";
                    string message2 = "Заполните поле сообщения или добавьте вложения!";
                    string caption2 = "Ошибка!";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    MessageBoxIcon iconsMB2 = MessageBoxIcon.Error;

                    MessageBox.Show(message2, caption2, buttons2, iconsMB2);
                    // progressBar1.Value = 85;
                }
            }
            else
            {
                if (
                    ((MessageToAttach != null) && (flag == 2)) ||
                    ((flag == 2) && (MessageToAttach == null)) ||
                    ((flag == 0) && (MessageToAttach != null))
                    )
                {
                    try
                    {
                        var post = api.Wall.Post(new WallPostParams
                        {
                            Attachments = attachments,
                            //PublishDate=,
                            OwnerId = ownid,
                            //FromGroup = 1,
                            Message = MessageToAttach,
                            //PublishDate = publication_date
                        });
                        LoadHistoryFileToServer();
                        error = "Пост опубликован";
                        string message2 = "Пост опубликован!";
                        string caption2 = "Информация";
                        MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                        MessageBoxIcon iconsMB2 = MessageBoxIcon.Information;

                        MessageBox.Show(message2, caption2, buttons2, iconsMB2);
                        //MessageBox.Show("Пост опубликован");
                        if (chk_openbrowser.Checked == true)
                        {
                            //    ShowPublic OpenWeb = new ShowPublic(); //смотрим стену отложку
                            //    OpenWeb.ShowDialog();
                        }

                        ClearAll();
                        butflag = 0;
                        resp_flag = 0;
                        posted = true;

                        //Репостим
                        // Set the Step property to a value of 1 to represent each file being copied.
                        //progressBar1.Step = 1;
                        if (chk_repost.Checked == true)
                        {
                            var get = api.Wall.Get(new WallGetParams
                            {
                                OwnerId = ownid,
                                Count = 3,
                               // CaptchaKey=,
                              //  CaptchaSid=,
                            });

                            for (int i = 0; i < 2; i++)
                            {
                                string obj = "wall" + get.WallPosts[i].OwnerId.ToString() + "_" + get.WallPosts[i].Id.ToString();
                                try
                                {
                                   var repost= api.Wall.Repost(@obj, null, null, false);//captcha
                                    //progressBar1.PerformStep();
                                }
                                catch (Exception)
                                {
                                    var repost = api.Wall.Repost(@obj, null, null, false);//captcha
                                    MessageBox.Show("Ошибка репоста! " + repost.Success + " " + repost.RepostsCount);
                                }
                            }
                        }
                       // progressBar1.Value = 0;
                    }
                    catch (Exception)
                    {
                        string message2 = "Невозможно опубликовать пост!";
                        string caption2 = "Ошибка!";
                        MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                        MessageBoxIcon iconsMB2 = MessageBoxIcon.Error;
                        //  for (int i = 0; i < attachments.Count; i++)
                        //      attachments.RemoveAt(i);

                        //  attachments.Clear();
                        //  ClearAll();
                        MessageBox.Show(message2, caption2, buttons2, iconsMB2);
                    }

                }
                else
                {
                    error = "Заполните поле сообщение или добавьте вложения";
                    string message2 = "Заполните поле сообщения или добавьте вложения!";
                    string caption2 = "Ошибка!";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    MessageBoxIcon iconsMB2 = MessageBoxIcon.Error;

                    MessageBox.Show(message2, caption2, buttons2, iconsMB2);
                    // progressBar1.Value =;
                }
            }

            return (error);
        }

        //Отложенная запись  выбор даты-Конвертация
        public DateTime DatePick(string onlydate, string curTimeLong)
        {

            // 06.03.2014 14:10:00
            int day = int.Parse(onlydate.Split('.')[0]);
            int month = int.Parse(onlydate.Split('.')[1]);
            int year = int.Parse(onlydate.Split('.')[2]);

            int hour = int.Parse(curTimeLong.Split(':')[0]);
            min = int.Parse(curTimeLong.Split(':')[1]);

            if ((min % 5) != 0) min += 5 - (min % 5);
            if (min == 60)
            {
                hour++;
                min = 0;
            }

            DateTime data_time = new DateTime(year, month, day, hour, min, 0);
            return data_time;
        }

        // обработчик события Tick таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PB_Download.Value >= PB_Download.Maximum-1)
                PB_Download.Value = 0;

            if (progressBar1.Value >= progressBar1.Maximum-1)
                progressBar1.Value = 0;
            // if()
            //curDate = DateTime.Now.ToShortDateString();
            //style = GetStylec();
            if(valuesSet == true)
            {
                //button1.Enabled = true;
                repostToolStripMenuItem.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                repostToolStripMenuItem.Enabled = false;
            }

            if (System.IO.File.Exists(stylefilename))
            {
                style = GetStylec();
                //style.Replace(" ", "#");
                if (style != null)
                {
                    //style = style.Replace("/", "");
                    //style = style.Replace(" ", " #");
                    richTextBox1.Text = "Genre: " + style   /*+ GetStylec()*/ + "\nRelease: " + curDate ;
                }
            }
            else
                richTextBox1.Text = "Release: " + curDate + "\n#HighVolumeMusic #HVM @hvmlabel #top #edm #fresh #music #new #свежак #электронная #музыка #топ";

            if (PB_Download.Value == PB_Download.Maximum)
                PB_Download.Value = 0;
            //Обновление времени
            UpdatingTime();
            // dateTimePicker1.Value = new DateTime(Convert.ToInt32(year2), Convert.ToInt32(month2), Convert.ToInt32(day2), Convert.ToInt32(hour2), Convert.ToInt32(min2), Convert.ToInt32(sec2));
            proverkanullfile();
            //Переключатель авто/ручной РАБОТАЕТ ХУЕВО!
            if (resp_flag == 1)
            {
               // RB_Auto.Enabled = false;
               // RB_Manual.Enabled = false;
            }
            RadioButton btn = sender as RadioButton;
            if (btn != null && btn.Checked == true)
            {
                switch (btn.Name)
                {
                    case "RB_Auto":
                        {
                            // mode = false;
                            RB_Manual.Checked = false;
                            // LstBox_AddedTracks.Enabled = false;
                            // Btn_DeleteTrackFromSelectedList.Enabled = false;
                            mode = false;
                        }
                        break;
                    case "RB_Manual":
                        {
                            // mode = true;
                            RB_Auto.Checked = false;
                            mode = true;
                        }
                        break;

                }
                switch (btn.Name)
                {
                    case "radioButton1":
                        // textBox3.Enabled = false;
                        radioButton2.Checked = false;
                        // button2.Enabled = true;
                        break;
                    case "radioButton2":
                        // textBox3.Enabled = true;
                        radioButton1.Checked = false;
                        // button2.Enabled = true;

                        break;
                }
            }
            //Проверка на кнопки
            if ((radioButton1.Checked == true || radioButton2.Checked == true) && (resp_flag == 1) && (posted == false))
            {
                button2.Enabled = true;
            }

            //Получаем текущий поток
            // Thread t = Thread.CurrentThread;
            // var state=t.ThreadState;
            //Если авто или мануал выбрано и получили список треков из поиска, можем добавить в аттачи. Дописать как только поток закончится, тогда вкл
            if ( /*(posted == false) && */(threadfinisghedmusic == true) && ((RB_Auto.Checked == true) || (RB_Manual.Checked == true)) && (tracks_attached != true))
                button3.Enabled = true;
            else button3.Enabled = false;

            if ((LstBox_AddedTracks.Items == null) || (fileexist == false))
                button1.Enabled = false;
            else {
                button1.Enabled = true; }

            if (posted == true)//Разместили пост
            {

            }

            if (deleteclicked==true)
            {
                button3.Enabled = true;
            }

            if ((butflag == 1) && (resp_flag == 1)&&(tracks_added==true)) //нажали кнопку треки и сформировали список 
            {
                button6.Enabled = true; //Можем публиковать
                //button2.Enabled = true; //Можно добавить картинку
            }
            if ((butflag == 2) && (resp_flag == 2)) //нажали кнопку картинка и добавили картинку во вложения = МОЖНО ОПУБЛИКОВАТЬ
                button6.Enabled = true;

            //Получаем ссылку на фото из окна ввода каждые 500 мс
            photourl = textBox3.Text;

            if (checkBox1.Checked == true) //если отложка
            {
                dateTimePicker1.Visible = true;

               // dateTimePicker1.Value = new DateTime(Convert.ToInt32(year2), Convert.ToInt32(month2), Convert.ToInt32(day2), Convert.ToInt32(hour2), Convert.ToInt32(min2), Convert.ToInt32(sec2));
                var selected_date = dateTimePicker1.Value;
                //Текущие дата/время хранятся в свойстве Now класса DateTime
                string onlydate = selected_date.ToString("dd.MM.yyyy"); //Выводим дату, выводится номер месяца
                string curTimeLong = selected_date.ToLongTimeString();//Результат: 8:49:10
                publication_date = DatePick(onlydate, curTimeLong);
                label6.Text = String.Format("Будет опубликован: {0}", publication_date);

            }
            else
            {
                dateTimePicker1.Visible = false;

                label6.Text = String.Format("Будет опубликован сейчас");
                //publication_date = DateNow(onlydate, curTimeLong);
            }

            if (radioButton2.Checked == true) //Если выбрали загрузку по ссылке
            {
                textBox3.Enabled = true;
            //    radioButton1.Checked = false; //Нельзя с ПК загрузить
            //                                  //atts = DownloadImage();
            //   // button2.Enabled = false;                              //butflag = 2;
            }
            else
            {
            //    //button2.Enabled = true;
                textBox3.Enabled = false;
            //    radioButton1.Checked = true;
            //    //atts = AddPhotoOnWall();
                // butflag = 2;
            }

            //Если в списке LstBox_AddedTracks закончились элементы, выключить кнопку удалить из вложки
            if (LstBox_AddedTracks.Items.Count == 0)
                Btn_DeleteTrackFromSelectedList.Enabled = false;

            //если скачали файл и загрузили его в превью
            if (resp_flag == 2) 
            {
                BTN_DelImageFrom.Enabled = true;
            }
            else BTN_DelImageFrom.Enabled = false;
            //resp_flag = 2;
            //progressBar1.PerformStep();

        }

        //[IN WORK] Получить список записей на стене через api.Wall.Get(); и сравнить ID вложений или названия со списком поиска в MakeUrlFromSearch
        //Если такой трек уже был во вложениях на стене, не запрашивать поиск
        //"attachments": [{
        //"type": "photo",
        //"photo": {
        //"id":  ,
        //"album_id": -7,
        //"owner_id":  ,
        //"user_id": 100,

        //----------DEBUGGING---------------------

        //ДЛЯ КНОПКИ Загрузка списка треков
        //async Task  LoadListOfTracks()
        public void LoadListOfTracks()
        {
            DownloadHistoryFile();
            // await MakeUrlFromLines(filechartname);
            Invoke(new Action(() =>
            {
                label6.Text = "Ищем в поиске треки";
                if (PB_Download.Value >= PB_Download.Maximum - 1)
                    PB_Download.Value = 0;
                PB_Download.Value += 1;
            }));
            // await MakeUrlFromLines(filechartname);
            MakeUrlFromLines(filechartname);
            //Thread.Sleep(400);
            Invoke(new Action(() =>
            {
               // labelStatus.Text = "Остановлен";
                label6.Text = "Список треков обработан, найдены песни";
                button3.Enabled = true; //попытка обращения к элементу не в том потоке
                if (PB_Download.Value >= PB_Download.Maximum - 1)
                    PB_Download.Value = 0;
                PB_Download.Value += 1;
                // buttonStop.Enabled = false;
            }));
           // button3.Enabled = true; //попытка обращения к элементу не в том потоке
      //    label6.Text = "Список треков обработан, найдены песни";
            return;
        }

        //Немного потоков синхронизации
        //private void UpdateUI()
        //{
        //    var context = SynchronizationContext.Current;
        //    // Способ 1
        //    Task.Run(() =>
        //    {
        //        // Что-то делаем
        //        //...
        //        // Обновляем текстовое поле
        //        context.Send(obj => label6.Text = "Ищем в поиске треки", null);
        //        // илиftp://rhiskey@ftp.drivehq.com/posted_tracks.dll
        //        //this.Invoke(() => label6.Text = "Ищем в поиске треки");
        //    });
        //}

        private void DownloadHistoryFile()
        {
            //Скачиваем новый файл с сервера в любом случае
            // Get the object used to communicate with the server.
            try {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.EnableSsl = true; // если используется ssl
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                FileStream fs = new FileStream(filepath_archive, FileMode.Create);
                StreamReader reader = new StreamReader(responseStream);
                // Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine($"Download Complete, status {response.StatusDescription}");
                //Буфер для считываемых данных
                byte[] buffer = new byte[64];
                int size = 0;

                while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, size);

                }
                fs.Close();
                //if (File.Exists(filepath_archive) == false)
                //{

                //    using (StreamWriter sw = new StreamWriter(filepath_archive))
                //    {
                //        sw.WriteLine("Create");
                //    }
                //    MessageBox.Show("Создан!");

                //}


                // сохраняем файл в дисковой системе
                // создаем поток для сохранения файла
                //FileStream fs = new FileStream(filepath_archive, FileMode.Create);
                //Буфер для считываемых данных
                //byte[] buffer = new byte[64];
                //int size = 0;

                //while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //    fs.Write(buffer, 0, size);
                //}
                reader.Close();
                response.Close();
            } catch (Exception) {
                //error = "Заполните поле сообщение или добавьте вложения";
                string message2 = "Подключения к FTP с историей треков не установлено";
                string caption2 = "Ошибка!";
                MessageBoxButtons buttons2 = MessageBoxButtons.RetryCancel;
                MessageBoxIcon iconsMB2 = MessageBoxIcon.Error;
                var result= MessageBox.Show(message2, caption2, buttons2, iconsMB2);
                if (result == DialogResult.Retry)
                {
                    //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress);
                    //request.Method = WebRequestMethods.Ftp.DownloadFile;
                    //// This example assumes the FTP site uses anonymous logon.
                    //request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    //request.EnableSsl = true; // если используется ssl
                    //FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    //Stream responseStream = response.GetResponseStream();
                    //FileStream fs = new FileStream(filepath_archive, FileMode.Create);
                    //StreamReader reader = new StreamReader(responseStream);
                    //// Console.WriteLine(reader.ReadToEnd());

                    //Console.WriteLine($"Download Complete, status {response.StatusDescription}");
                    ////Буфер для считываемых данных
                    //byte[] buffer = new byte[64];
                    //int size = 0;
                    //while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                    //{
                    //    fs.Write(buffer, 0, size);
                    //}
                    //fs.Close();
                    //reader.Close();
                   // response.Close();
                

                    //if (File.Exists(filepath_archive) == false)
                    //{

                    //    using (StreamWriter sw = new StreamWriter(filepath_archive))
                    //    {
                    //        sw.WriteLine("Create");
                    //    }
                    //    MessageBox.Show("Создан!");

                    //}


                    // сохраняем файл в дисковой системе
                    // создаем поток для сохранения файла
                    //FileStream fs = new FileStream(filepath_archive, FileMode.Create);
                    //Буфер для считываемых данных
                    //byte[] buffer = new byte[64];
                    //int size = 0;

                    //while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                    //{
                    //    fs.Write(buffer, 0, size);
                    //}

                }
               // MessageBox.Show("Ошибка подключения к FTP с историей треков");
            }
            
        }

        //КНОПКА Треки
        private void button1_Click(object sender, EventArgs e)
            {
            PB_Download.Value = 0;
            //int count = System.IO.File.ReadAllLines(filechartname).Length;
            //string message = "Вы точно хотите найти указанные треки?" + " (" + count + ") штук";
            //string caption = "Обработка треков";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //MessageBoxIcon iconsMB = MessageBoxIcon.Question;
            //DialogResult result;
            //PB_Download.Value += 1;
            button1.Enabled = false;
            //создаем новый поток
            //result = MessageBox.Show(message, caption, buttons, iconsMB);
            //if ((result == System.Windows.Forms.DialogResult.Yes))
            //{
               
            //  fs.Close();
            PB_Download.Value+=1;

            //  var th = new Thread(LoadListOfTracks);
            //   th.IsBackground = true;
            //  th.Start();
            //  Thread.Sleep(1000);
            // Thread thread1 = new Thread(LoadListOfTracks);
            // Thread thread2 = new Thread(mythread2);
            // thread1.Start();
            // thread2.Start();
            //Удалили вложения
            //for (int i = 0; i < attachments.Count - 1; i++)
            //   attachments.RemoveAt(i);
            attachments.Clear();
            SearchingList.Clear();
            listBox1.Items.Clear();
            LstBox_AddedTracks.Items.Clear();
           // flagpost = 0;
            butflag = 1;
            posted = false;
               addedcounter = 0;
                GetStylec();
            if (PB_Download.Value >= PB_Download.Maximum - 1)
                PB_Download.Value = 0;
            PB_Download.Value += 1;
            //MakeUrl From Lines
            // Task t = LoadListOfTracksAsync();
            // t.Wait():
            // Initializes the variables to pass to the MessageBox.Show method.

            Thread myThread = new Thread(new ThreadStart(LoadListOfTracks)); //ошибка в listbox.add - метод в другом потоке
                myThread.Name = "Поток скачки LoadListOfTracks";
                myThread.Start(); // запускаем поток
                                  // if (myThread.ThreadState ==)
                                  //    th = true;
                                  // LoadListOfTracks(); //== MakeUrlFromLines(filechartname);
                                  // MakeUrlFromLines(filechartname);
                                  // resp_flag = 1;
            if (PB_Download.Value >= PB_Download.Maximum - 1)
                PB_Download.Value = 0;
            PB_Download.Value += 5;
            //Application.DoEvents();
            Thread.Sleep(1000);
            if (resmes == 1)
            {
                button1.Enabled = true;
                resmes = 0;
            }
           // }

        }

        //[DEBUG]КНОПКА Картинка
        private void button2_Click(object sender, EventArgs e)
        {
           // Thread myThread2 = new Thread(new ThreadStart(AddPicture)); //ошибка в listbox.add - метод в другом потоке
           // myThread2.Name = "Поток скачки AddPicture";
           // myThread2.Start();
            AddPicture();

            // radioButton2.Enabled = false;

           
        }

        //Косяк 
        public void OverritePicture()
        {
            //string filename2 = Path.GetFullPath(photofilename);
            string loadedimagefilepath= Path.GetFullPath(photofilename);
            // string imagefile;
            //Если фотка добавлена, и мы нажали X, обноваить
            if (resp_flag == 2)
            {
                try
                {
                    if(pictureBox1.Image!=null)
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }catch (Exception) { MessageBox.Show("Ошибка! Картинки и так нет!"); }
            }

            if (radioButton2.Checked == true&&pictureBox1.Image!=null) //Если выбрали загрузку по ссылке
            {
                pictureBox1.Image.Dispose();
              //  pictureBox1.Image = null;
             //  TempImage(loadedimagefilepath); //Удаление картинки как только добавили  //Не освобождает поток
            }
            else //Удаляем с ПК тот же файл?!
            {
                //TempImage(imagefile);
                TempImage(photofilename);
            }
            }

        public void AddPicture()
        {
           // Invoke(new Action(() =>
          //  {
                if ((radioButton2.Checked == true) && (textBox3.TextLength > 0)) //Если выбрали загрузку по ссылке
            {
                DownloadImage();
                // TempImage(photofilename);
                //textBox3.Enabled = true;
                //radioButton1.Checked = false; //Нельзя с ПК загрузить
                //Удалить старую, загрузить новую

                pictureBox1.Visible = true;
                //Превью
                // button2.Enabled = true;
                //AddPhotoToAttachFromUrl();
                resp_flag = 2;
                image_added = true;//МОЖЕТ БАГАТЬ
            }
            else //загружаем с ПК
            {
                if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                    return;
                Bitmap bit = new Bitmap(openFileDialog2.FileName);
                  pictureBox1.Image = bit;
                imagefile = openFileDialog2.FileName;
                pictureBox1.Visible = true;
                // string filePath = openFileDialog2.FileName;
                //Скачали и в потоке загрузили картинку в превью
                // using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Inheritable))
                //  {
                //      pictureBox1.LoadAsync(filePath);
                //pictureBox1.Image = System.Drawing.Image.FromStream(file);
                //  }
                resp_flag = 2; 
                image_added = true; //МОЖЕТ БАГАТЬ
            }
         //   }));
            //resp_flag = 2;
            //progressBar1.Value = 50;
          //  Invoke(new Action(() => //Обращение к элементу из потока
          //  {
                // labelStatus.Text = "Остановлен";
                label6.Text = "Картинка добавлена в список вложений";
          //  }));
           // label6.Text = "Картинка добавлена в список вложений";      
        }

        public void AddPhotoToAttachFromUrl()
        {
            label6.Text = "Отправляем запрос на загрузку сервер";
            string filename2 = Path.GetFullPath(photofilename);
            IReadOnlyCollection<Photo> photolist = SendOnServer(filename2); //отправляем на сервак, получаем ответ с картинкой
            label6.Text = "Картинка загружена, получен ответ от сервера";
            label6.Text = "Добавляем картинку во вложения";
            attachments.AddRange(photolist);
            pictureBox1.Visible = true;
            label4.Visible = true; //prewiev text
            flag = 2;
            button2.Enabled = false;
            //PB_Download.Value += 1;
            //radioButton2.Enabled = false;
        }

        public void AddPhotoToAttachFromPC()
        {
            //string imagefile = openFileDialog2.FileName;
            label6.Text = "Добавляем картинку во вложения";
            //отобразить но не добавлять
            attachments.AddRange(SendOnServer(imagefile));
            
            label4.Visible = true; //prewiev text
            flag = 2;
            button2.Enabled = false;
            //PB_Download.Value += 1;
            // radioButton2.Enabled = false;
        }

        //Создать временную картинку и удалить её после публикации поста
        public void TempImage(string photofilename)
        {
           // pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
         //  pictureBox1.Image.Dispose();
            //pictureBox1.Image.
            string filename2 = Path.GetFullPath(photofilename);
            //File.Delete(filename2); //Зачем удалять, можно просто заново качать?
            // System.Drawing.Image image = System.Drawing.Image.FromFile(imageFileName);

            //Плсде публикации файл photofilename используется другим процессом?!
            File.Delete(photofilename);

            //После публикации используется другим процессом, нужно где-то освободить использование файла
            FileStream stream = new FileStream(photofilename, FileMode.CreateNew);
                // bmp.Save(stream, image.RawFormat);
            stream.Close();

            // image.Dispose();
        }

        //Скачать фотку по ссылке 
        public void DownloadImage()
        {
            //Освободить использование картинки потоком

            //pictureBox1.Image.Dispose();
            //TempImage(photofilename);
            //Stream load;
            if (downloaded == true)
            {
             //  pictureBox1.Image.Dispose();

              //      if (File.Exists(photofilename))
                        //TempImage(photofilename);
               //     File.Delete(photofilename);
                // Bitmap bmp1 = new Bitmap(pictureBox1.Image);

                //            if (File.Exists(newphotoname))
                //                File.Delete(newphotoname); //Процесс не может получить доступ к дфайлу, так как используется другим процессом
                //else File.Create(newphotoname);
                //FileMode.
                //FileStream stream = new FileStream(photofilename, FileMode.Create);
                //    bmp1.Save(photofilename, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Dispose of the image files.
                //  pictureBox1.Image.Dispose();
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        if(pictureBox1.Image!=null)
                        pictureBox1.Image.Dispose();
                        webClient.DownloadFile(photourl, photofilename);
                        webClient.Dispose();
                        Bitmap bit2 = new Bitmap(photofilename);
                        pictureBox1.Image = bit2;

                    }
                    catch (Exception) {

                        string message = "Невозможно подключиться к серверу загрузки фото.\nПопробуйте добавить другую картинку";
                        string caption = "Ошибка!";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBoxIcon iconsMB = MessageBoxIcon.Error;

                        MessageBox.Show(message, caption, buttons, iconsMB); }
                }
                PB_Download.Value+=1;
              //  Bitmap bit2 = new Bitmap(photofilename);
             //  pictureBox1.Image = bit2;
 //               if (File.Exists(photofilename))
  //                  File.Delete(photofilename);
                // webClient.
            }
            //DownloadImage();

            //Если скачалась она, то обнуляем PB, удаляем старую photofilename, новую newohotoname переименовываем в имя старой, подкючаем к PB
            else
            {

          //      if (File.Exists(photofilename))
            //        File.Delete(photofilename); //Процесс не может получить доступ к дфайлу, так как используется другим процессом
            //    else File.Create(photofilename);

                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.DownloadFile(photourl, photofilename);
                        webClient.Dispose();

                        Bitmap bit = new Bitmap(photofilename);
                        pictureBox1.Image = bit;
                    }
                    catch (Exception) {
                        string message = "Невозможно подключиться к серверу загрузки фото.\nПопробуйте добавить другую картинку";
                        string caption = "Ошибка!";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBoxIcon iconsMB = MessageBoxIcon.Error;

                        MessageBox.Show(message, caption, buttons, iconsMB); } 
                }
                // webClient.Dispose();

                // catch (Exception) { MessageBox.Show("Невозможно подключиться к серверу загрузки фото."); }


                //  string filePath = photofilename;
                //Скачали и в потоке загрузили картинку в превью. При каждой скачке нужно освобождать и перезаписывать файл
                //   Bitmap bit = new Bitmap(filePath);
                //  pictureBox1.Image = bit;


                //using (var file = new FileStream(filePath, FileMode.Append))
                //{
                //    //pictureBox1.LoadAsync(file);
                //    Bitmap bit = new Bitmap(filePath);
                //    pictureBox1.Image = bit;
                //   // pictureBox1.Image = System.Drawing.Image.FromStream(filePath);
                //}
                // FileStream stream2 = new FileStream(newphotoname, FileMode.)
                //File.

                //Bitmap bit = new Bitmap(photofilename);
               // pictureBox1.Image = bit;
            }
            downloaded = true;
            Invoke(new Action(() =>
            {
                label6.Text = "Картинка скачана";
                if (PB_Download.Value >= PB_Download.Maximum - 1)
                    PB_Download.Value = 0;
                PB_Download.Value += 1;

            }));
       //     label6.Text = "Картинка скачана";
            return ;
        }

        //Добавить в аудио группы. Че-то тут не то, добавляет другое
        private void AddMusicToPublic()
        {
            progressBar1.Step = 11;
            var api = new VkApi();
            //SearchingList - тут храним экземпляр трэка
            //Автодобавление во вложку, нужно реализовать так же
            int maximum_tracks = 9;
            if (SearchingList.Count < 9)
            {
                maximum_tracks = SearchingList.Count;
            }
            //Авторизация
            api.Authorize(new ApiAuthParams
            {
                AccessToken = Token
            });

            for (int i = 0; i < maximum_tracks; i++)
            {
               var json=api.Audio.Add(SearchingList[i].GetMediaId(), SearchingList[i].GetOwnerId(), groupid);
                Console.WriteLine(json);
                Console.ReadLine();
                progressBar1.PerformStep();
            }
        }

        //Добавить во вложку
        private void button3_Click(object sender, EventArgs e)
        {

            if (RB_Auto.Checked == true)
            {
                mode = false;
            }
            else mode = true;

            if (mode == true && posted == false) //Ручной
            {
                LstBox_AddedTracks.Enabled = true;
                Btn_DeleteTrackFromSelectedList.Visible = true;

              //  if()
                Btn_DeleteTrackFromSelectedList.Enabled = true;
                
                int i = 0;
                foreach (Object obj in listBox1.SelectedItems)
                {
                   // if(i<9)
                    IAmSelectedElement(listBox1.SelectedIndices[i]);
                    //addedcounter++;
                    i++;
                    tracks_added = true;
                }
              //RB_Auto.Enabled = false;
                resp_flag = 1;
                //tracks_attached = true;
               // tracks_added = true;
               // flag = 2; //список заполнен
            }
            if (mode == false && posted == false) //АВТО
            {

                Btn_DeleteTrackFromSelectedList.Enabled = false;
                Btn_DeleteTrackFromSelectedList.Visible = false;
                LstBox_AddedTracks.Enabled = false;

                AutoAddTracksToAttachments();
               // tracks_attached = true;
                // tracks_attached = true;
                label6.Text = "Добавили треки в список вложений";
                    resp_flag = 1;
                    flag = 2;
                //RB_Manual.Enabled = false;
                //button3.Enabled = false;

                for (int i = 0; i < listBox1.Items.Count; i++)
                    listBox1.Items.RemoveAt(i);

                listBox1.Items.Clear();
                tracks_added = true;
              //  tracks_attached = true;
            }

            
            // RB_Manual.Enabled = false;
            //PB_Download.Value += 5;
        }

          //Все элементs перемещаем в лист бокс ВЛОЖКА
        public void IAmAutoAddedElement(int elementid = -1)
        {
            if (elementid == -1)
            {
                MessageBox.Show("В IAmAutoAddedElement get=-1");
                //elementid = listBox1.SelectedIndex();
            }
            //SelectedTrackList.Add(SearchingList[elementid]);
            LstBox_AddedTracks.Items.Add(SearchingList[elementid].GetTitle());
            return;
        }

        //Если в списке LstBox_AddedTracks закончились элементы, выключить кнопку удалить из вложки

        //Удалили из списка вложек
        private void Btn_DeleteTrackFromSelectedList_Click(object sender, EventArgs e)
        {
            //int i = 0;
            //foreach (Object obj in LstBox_AddedTracks.SelectedItems)
            //{
            //for (int i=0; i<)
            if (addedcounter > 0)
            {
                SelectedTrackList.RemoveAt(LstBox_AddedTracks.SelectedIndex);
                LstBox_AddedTracks.Items.RemoveAt(LstBox_AddedTracks.SelectedIndex);
                addedcounter--;
            }
            //    i++;
            //}
            deleteclicked = true;
        }

        //Ручное добавление треков
        public void AddTracksToAttachments()
        {
            int maximum_tracks = 9;
            if (SelectedTrackList.Count < 9)
            {
                maximum_tracks = SelectedTrackList.Count;
            }

            for (int i = 0; i < maximum_tracks; i++) //пока количество элементов в массиве меньше найденных треков
            {
                attachments.Add(
                  new Audio
                  {
                      OwnerId = SelectedTrackList[i].GetOwnerId(), //нужно запихнуть айди элемента из класса ввыбранных в Listbox1
                          Id = SelectedTrackList[i].GetMediaId(),
                      AccessKey = accesstoken,
                  });
               // flag = 2;
            }
            label6.Text = "Добавили треки в список вложений";
            resp_flag = 1;
            flag = 2;
        }

        //Авто добавление треков
        private void AutoAddTracksToAttachments()
        {
            int maximum_tracks = 9;
            if (SearchingList.Count < 9)
            {
                maximum_tracks = SearchingList.Count;
            }

            //Получение РЕАЛЬНЫх найденных названий из поиска и добавление в конечный список названий
            //var api = new VkApi();
            ////Авторизация
            //api.Authorize(new ApiAuthParams
            //{
            //    AccessToken = Token
            //});

            //Заполнить массив найденных ID и вывести инфу о треках

           // var ids=new string[10]; //размер массива

            for (int i = 0; i < maximum_tracks; i++)
            {
                string autoelem = i+1+ ") "+ SearchingList[i].GetTitle();
                LstBox_AddedTracks.Items.Add(autoelem);
                label9.Text = "Вложка треков: " + LstBox_AddedTracks.Items.Count;
                // ids[i] = SearchingList[i].GetFullId(); //заполнили массив
            }
            //var audioslist = api.Audio.GetById(ids).ToList(); //System.NullReferenceException: 'Ссылка на объект не указывает на экземпляр объекта.'

            //for (int i = 0; i < maximum_tracks; i++)
            //{
            //    LstBox_AddedTracks.Items.Add(audioslist[i].Title);
            //}

            for (int curobj = 0; curobj < maximum_tracks; curobj++)
            {

                attachments.Add(
                   new Audio
                   {
                       OwnerId = SearchingList[curobj].GetOwnerId(), //нужно запихнуть айди элемента из класса ввыбранных в Listbox1
                           Id = SearchingList[curobj].GetMediaId(),
                       AccessKey = accesstoken,
                   });
            }

            //label9.Text = "Вложка треков: " + LstBox_AddedTracks.Items.Count;
            // for (int i = 0; i < SearchingList.Count; i++)
            //     SearchingList.RemoveAt(i);
            // SearchingList.Clear();
            tracks_attached = true;
            //button3.Enabled = false;

            //listBox1.Items.Clear();
        }

        //---------Парсер Рекорд------
        private async void ParsingAsync()
        {
            //var parser = new HtmlParser();
            string site = "http://www.radiorecord.ru/radio/stations/?st=mt";
            var config = Configuration.Default.WithDefaultLoader().WithCss();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(site);
            // var document = parser.Parse("<ul><li>First item<li>Second item<li class='blue'>Third item!<li class='blue red'>Last item!</ul>");

            var pricesListItemsLinq = document.QuerySelectorAll("class.artist");
            //File.Create("Parse.html");
            // File.CreateText("Parse.html");

            Console.ReadLine();
        }

        //[DEBUG]Кнопка Parse 
        private void button5_Click(object sender, EventArgs e)
        {
            //run_python();
            //ParsingAsync();
            //Process.Start(nameofsoft);
        }

        //Запускаем код пайтон
        private void run_python()
        {
            string fileName = @"C:\sample_script.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Python27\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);
            Console.ReadLine();
        }

        private void UpdatingTime ()
        {
            //Обновление времени
             curDate = DateTime.Now.ToShortDateString();
            string curDate3 = DateTime.Now.ToString();
            //Значение по умолчанию для даты - сегодня сейчас
            // 06.03.2014 14:10:00
            int day2 = int.Parse(curDate.Split('.')[0]);
            int month2 = int.Parse(curDate.Split('.')[1]);
            int year2 = int.Parse(curDate.Split('.')[2]);
            string curTimeLong2 = DateTime.Now.ToLongTimeString();//Результат: 8:49:10
            int hour2 = int.Parse(curTimeLong2.Split(':')[0]);
            int min2 = int.Parse(curTimeLong2.Split(':')[1]);
            int sec2 = int.Parse(curTimeLong2.Split(':')[2]);

            dateTimePicker1.MinDate = new DateTime(Convert.ToInt32(year2), Convert.ToInt32(month2), Convert.ToInt32(day2), Convert.ToInt32(hour2), Convert.ToInt32(min2), Convert.ToInt32(sec2));
        }

        private void BTN_DelImageFrom_Click(object sender, EventArgs e)
        {
            OverritePicture();
        }

        private void BT_ManualParser_Click(object sender, EventArgs e)
        {
            var api = new VkApi();
            //api.Wall.Get(skipAuthorization=false);
            //Авторизация
            api.Authorize(new ApiAuthParams
            {
                Login = Login,
                Password = Password,
                AccessToken = Token
            });

        }

        private void TSMENU_About_Click(object sender, EventArgs e)
        {
            AboutBox1 abtbtn = new AboutBox1();
            abtbtn.Show();
            //MessageBox.Show("1)Кликаем на кнопку вверху Парсер->По жанрам" +
            //    "\n2)В открывшемся окне выбираем жанр и количество треков для поиска" +
            //    "\n3)Нажимаем единственную кнопку" +
            //    "\nЖдем... секунд 5-10, кнопка станет снова серой" +
            //    "\n4)В окне основной программы жмем кнопку Поиск треков" +
            //    "\nВ список ниже добавится первые 9 найденных треков" +
            //    "\n5)Выбираем режим добавления треков во вложения:"+
            //    "\nАвто - добавит все треки сразу во вложения;"+
            //    "\nРучной - позволит выделить нужные треки;" +
            //    "\\n6) Добавляем картинку с внешнего источника или с ПК, затем публикуем пост");
        }

        private void TSMENU_Parser_Click(object sender, EventArgs e)
        {
            //Process.Start(nameofsoft);
        }

        private void TSMENU_Oldparser_Click(object sender, EventArgs e)
        {
            Process.Start("BeatPort Parser_manual.exe");
        }

        private void измененияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этой версии:" +
            "\n*Добавлен выбор стилей"
                             );
        }

        private void CheckSettingsOnStart()
        {
            //if ownerid, access token = null
            //запускаем форму loginform.cs
        }

        private void TSMENU_Save_Click(object sender, EventArgs e)
        {
            PostPoned postForm = new PostPoned();
            postForm.Show();
            //Записать настройки (данные паблика, и приложения) в Settings.ini
        }

        private void TSMENU_Reset_Click(object sender, EventArgs e)
        {
            //Сбросить настройки - авторизироваться
        }

        private async Task StartParser()
        {
            string jsonfile = "todo.dll";
            string style = CB_Styles.SelectedItem.ToString();
            //string converstyletohastags = style.Replace("#", " ");
            bool done = true;
            // StyleNC.StyleName = style;
            // StyleNC.Count = trackscount;
            // string JSONresult = JsonConvert.SerializeObject(StyleNC);
            // string path = "stylencount.json";


            //using (var tw = new StreamWriter(path, true))
            //{
            //    tw.WriteLine(JSONresult.ToString());
            //    tw.Close();
            //}

            //Create file or JSOn with style and count of tracks
            //если файл существует
            if (System.IO.File.Exists(jsonfile))
            {
                string[] strok = File.ReadAllLines(jsonfile);
                File.WriteAllText(jsonfile, String.Empty); //очистили файл
                FileStream file1 = new FileStream(jsonfile, FileMode.Open); //создание нового файла
                StreamWriter writer = new StreamWriter(file1, Encoding.UTF8); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.WriteLine(style); //записываем в файл (раньше было json)
                writer.Write(trackscount + "\n");
                writer.Write(switcher);
                writer.Close();

                //using (var tw = new StreamWriter(path, true))
                //{
                //    tw.WriteLine(JSONresult.ToString());
                //    tw.Close();
                //}
            }
            //если его нет
            else
            {
                FileStream file1 = new FileStream(jsonfile, FileMode.CreateNew); //создание нового файла
                StreamWriter writer = new StreamWriter(file1, Encoding.UTF8); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.WriteLine(style); //записываем в файл (раньше было json)
                writer.Write(trackscount + "\n");
                writer.Write(switcher);
                //writer.
                writer.Close();
                //using (var tw = new StreamWriter(path, true))
                //{
                //    tw.WriteLine(JSONresult.ToString());
                //    tw.Close();
                //}
            }
            return;
        }

        private void CB_Styles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // StyleAndCount StyleNC = new StyleAndCount(); //вызов класса

            //Task stepone = StartParser();
            //Start BeatPort Parser
            //  int number = 5000;
            //  Task.Delay(number);


            string style = CB_Styles.SelectedItem.ToString();
            
            ScriptEngine engine = Python.CreateEngine();
            var pc = HostingHelpers.GetLanguageContext(engine) as PythonContext;
            var hooks = pc.SystemState.Get__dict__()["path_hooks"] as List;
            hooks.Clear();

            //string scriptPath = "C:\\Users\\Vladimir\\AppData\\Local\\Programs\\Python\\Python37\\Lib";
            //string dir = Path.GetDirectoryName(scriptPath);
            //ICollection<string> paths = engine.GetSearchPaths();

            //if (!String.IsNullOrWhiteSpace(dir))
            //{
            //    paths.Add(dir);
            //}
            //else
            //{
            //    paths.Add(Environment.CurrentDirectory);
            //}
            //engine.SetSearchPaths(paths);
            var searchPaths = engine.GetSearchPaths();
            //searchPaths.Add(@"C:\Python27\Lib");
            searchPaths.Add(@"C:\Users\Vladimir\AppData\Local\Programs\Python\Python37\Lib");
            searchPaths.Add(@"C:\Users\Vladimir\AppData\Local\Programs\Python\Python37\Lib\site - packages");
            searchPaths.Add(@"C:\Users\Vladimir\AppData\Local\Programs\Python\Python37\Lib\site - packages\bs4");
            searchPaths.Add(@"C:\Users\Vladimir\AppData\Local\Programs\Python\Python37\Lib\site - packages\future");
            searchPaths.Add(@"C:\Users\Vladimir\AppData\Local\Programs\Python\Python37\Lib\site - packages\request");
            engine.SetSearchPaths(searchPaths);
            ScriptScope scope = engine.CreateScope();
            IronPython.Hosting.Python.ImportModule(scope, "__future__");
            //IronPython.Hosting.Python.ImportModule(scope, "requests");
           // IronPython.Hosting.Python.ImportModule(scope, "io");
            IronPython.Hosting.Python.ImportModule(scope, "bs4");

            scope.SetVariable("stylename", style);
            scope.SetVariable("count", trackscount);
            scope.SetVariable("type", switcher);
            engine.ExecuteFile("projectCONSOLE_2.py", scope);

           // dynamic xNumber = scope.GetVariable("x");
           // dynamic zNumber = scope.GetVariable("z");
           // Console.WriteLine("Сумма {0} и {1} равна: {2}", xNumber, yNumber, zNumber);

            // //Create a new process object 
            // Process myProcess = new Process();

            // //Provide the start information for the process 
            // myProcess.StartInfo.FileName = nameofsoft;
            //// myProcess.StartInfo.Arguments = "mytestpython.py";
            // myProcess.StartInfo.UseShellExecute = false;
            // myProcess.StartInfo.RedirectStandardInput = true;
            // myProcess.StartInfo.RedirectStandardOutput = true;

            // StreamReader myStreamReader;
            // StreamWriter myStreamWriter;

            // //Invoke the process from current process 
            // myProcess.Start();

            // myStreamReader = myProcess.StandardOutput;

            // //Read the standard output of the spawned process. 
            //// string myString = myProcess.StandardOutput.ReadToEnd();
            // myProcess.BeginOutputReadLine();

            // Console.WriteLine(myString);

            // if (myString.Contains("argument_x"))
            // {
            //     myStreamWriter = myProcess.StandardInput;
            //     String argument = "argument_value";
            //     myStreamWriter.WriteLine(argument);
            //     myStreamWriter.Close();
            // }

            // myProcess.WaitForExit();
            //// myStreamWriter.Close();
            // myStreamReader.Close();
            // myProcess.Close();


            // Process.Start(nameofsoft);
            //Delete file of style and count tracks



            // style = GetStylec();
            // richTextBox1.Text = "Genre: #" + style   /*+ GetStylec()*/ + "\nRelease: " + curDate + "\n#HighVolumeMusic #HVM @hvmlabel #top #edm #fresh #music #new #свежак #электронная #музыка #топ";
        }

        private void BT_Repost_Click(object sender, EventArgs e)
        {
            var api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                Login = Login,
                Password = Password,
                AccessToken = Token
            });
            //Воспроизвести выделенный трек. Скачать его и по кнопке Play/Pause воспроизвести
            int i = 0;
            foreach (Object obj in listBox1.SelectedItems)
            {
               // SearchingList[i].GetFullId();
                //Download
                var ids = new string[] { SearchingList[i].GetFullId() }; //Получили все
                var link = api.Audio.GetById(ids).ToArray(); //Получили ссылки на скачку
                var mp3name = "audio";
                // 
                using (WebClient wc = new WebClient())
                {
                    //ЗАЩИТА ВК
                    wc.DownloadFileAsync(new System.Uri(link[i].Url.ToString()),
                    mp3name + i.ToString() + ".mp3");
                }
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                //player.SoundLocation = mp3name + i.ToString() + ".mp3";
                // WebClient.DownloadFileAsync(link[i].Url, mp3name+i.ToString()+".mp3"); //сделать скачку Url
                i++;
            }
            //   api.Audio.Get();
            //    WebClient.DownloadFileAsync(Uri address, string fileName);
            //var i = 0;
            //var attachu = get.WallPosts[i].Attachments;

            //if (attachu[i].Type == Audio)
            //    { download}
            //for (int i = 0; i < 2; i++)
            //{
            //    var typeofpost = get.WallPosts[i].PostType;
            //    //PostType postpone = new PostType();
            //    //postpone = "postpone";
            //    if (typeofpost == postpone)
            //    {
            //       // string obj = "wall" + get.WallPosts[i].OwnerId.ToString() + "_" + get.WallPosts[i].Id.ToString();
            //        try
            //        {
            //            var attachi = get.WallPosts[i].Attachments;
            //           var dateofotloz= get.WallPosts[i].Date;
            //            Console.WriteLine(dateofotloz);
            //            Console.ReadLine();
            //        }
            //        catch (Exception)
            //        {
            //            MessageBox.Show("Ошибка  "  );
            //        }
            //    }
            //}            
        }

        private void BT_PlayPause_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            var mp3name = "audio";

            var i=listBox1.SelectedIndex;
            player.SoundLocation = mp3name + i.ToString() + ".mp3";
            player.Play();
        }

        private void repostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Reposter reposterForm = new Reposter();

            // Show the settings form
            reposterForm.Show();
        }

        private void TSMENU_Settings_Click(object sender, EventArgs e)
        {

        }

        private void SaveSettToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            LoginForm loginForm = new LoginForm();

            // Show the settings form
            loginForm.Show();
        }

        private void ResetSettToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Сбрасывает до дефотных
            Properties.Settings.Default.Reset();
        }

        private void парсерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(nameofsoft);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            { chk_repost.Enabled = false; }
            else { chk_repost.Enabled = true;
                progressBar1.Enabled = false;
            }
        }

        private void tb_counter_Scroll(object sender, EventArgs e)
        {
            lb_counttracks.Text = tb_counter.Value.ToString();
            trackscount = tb_counter.Value;
        }

        private void RB_top100_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_top100.Checked == true)
                switcher = "top100";
            else switcher = "fresh";

        }

        private void RB_Tracks_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Tracks.Checked == true)
                switcher = "fresh";
            else switcher = "top100";
        }

        private void TSMENU_File_Click(object sender, EventArgs e)
        {

        }

        private void chk_repost_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PB_Download_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
