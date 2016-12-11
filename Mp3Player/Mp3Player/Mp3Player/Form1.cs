using Mp3Player.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mp3Player
{
    public partial class Form1 : Form
    {
        struct ListaPlikow
        {
            public string[] nazwa;
            public string[] zrodlo;
        }

        //Inicjonowanie zmiennych globalnych
        ListaPlikow p1;
        Bitmap CollapseArrowBitmap = Mp3Player.Properties.Resources.CollapseArrow;
        Bitmap ExpandArrowBitmap = Mp3Player.Properties.Resources.ExpandArrow;
        Bitmap RepeatBitmap = Mp3Player.Properties.Resources.Repeat;
        Bitmap DontRepeatBitmap = Mp3Player.Properties.Resources.DontRepeat;
        Bitmap ShuffleBitmap = Mp3Player.Properties.Resources.Shuffle;
        int time = 0;
        // inicjujemy instancje klasy MusicPlayer konstruktorem domyslnym obejmującą operacje na pliku audio
        MusicPlayer player = new MusicPlayer();
        public Form1()
        {
            InitializeComponent();
            
            //Zmieniamy wartości początkowe poszczególnych elementów programu
            p1.nazwa = new string[2000];
            p1.zrodlo = new string[2000];

            pb_PlayBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_STStart.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_STEnd.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_OpenFile.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_SavePlaylist.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_LoadPlaylist.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Delete.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Hide.Image = ExpandArrowBitmap;
            pb_Hide.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Repeat.Image = DontRepeatBitmap;
            pb_Repeat.SizeMode = PictureBoxSizeMode.StretchImage;
            //uruchamiamy timer odpowiedzalny za scrollowanie górnego tekstu (nazwy pliku obecnie odtwarzanego)
            timerScroll.Start();
        }
        //----------------------------------METODY OBSŁUGI PRZYCISKÓW----------------------------------
        //Mechanika obsługi przycisku play - logika obsługi błędu, obsługa możliwych błędów podczas próby 
        //odtworzenia utworu.
        private void btn_Play_Click(object sender, EventArgs e)
        {
            if(listaPlikow.Items.Count != 0 && listaPlikow.SelectedIndex != -1)
            {
                if(!player.isPlaying)
                {
                    pb_PlayBtn.Image = Mp3Player.Properties.Resources.Pause;
                    if (listaPlikow.SelectedIndex == player.currentSongIndex)
                    {
                        try
                        {
                            StartSong();
                            timer1.Start();
                            player.isPlaying = true;
                        }
                        catch
                        {
                            TryPlayNextSong();
                        }
                        
                    }
                    else
                    {
                        player.currentSongIndex = listaPlikow.SelectedIndex;
                        try
                        {
                            NextSongSetup();
                            StartSong();
                            trackBar1.Maximum = player.maxSongLength / 1000;
                            lb_curSongName.Text = p1.nazwa[player.currentSongIndex];
                            timer1.Start();
                            player.isPlaying = true;
                            pb_PlayBtn.Image = Mp3Player.Properties.Resources.Pause;
                        }
                        catch
                        {
                            TryPlayNextSong();
                        }
                    }
                }
                else if(player.isPlaying && listaPlikow.SelectedIndex != player.currentSongIndex)
                {
                    player.currentSongIndex = listaPlikow.SelectedIndex;
                    try
                    {
                        NextSongSetup();
                        StartSong();
                        trackBar1.Maximum = player.maxSongLength / 1000;
                        lb_curSongName.Text = p1.nazwa[player.currentSongIndex];
                        timer1.Start();
                        player.isPlaying = true;
                        pb_PlayBtn.Image = Mp3Player.Properties.Resources.Pause;
                    }
                    catch
                    {
                        TryPlayNextSong();
                    }
                }
                else
                {
                    pb_PlayBtn.Image = Mp3Player.Properties.Resources.Play;
                    player.Stop();
                    timer1.Stop();
                    player.isPlaying = false;
                }

            }
        }
        //Mechanika przycisku cofającego utwór na początek odtwarzania
        private void pb_STStart_Click(object sender, EventArgs e)
        {
            if (player.isPlaying)
            {
                if(time < 2 && listaPlikow.Items.Count > 1)
                {
                    player.currentSongIndex -= 2;
                    TryPlayNextSong();
                }
                else
                {
                    time = 0;
                    player.SetPosition(time);
                }
            }
        }
        //Mechanika przycisku przewijającego utwór
        private void pb_STEnd_Click(object sender, EventArgs e)
        {
            TryPlayNextSong();
        }
        //Wczytywanie plików do ListBox'a "listaPlikow"
        private void btn_listaPlikow_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Algorytm dodawnia plików to listBoxa oraz zais w pamięci scieżek do plików oraz ich nazw, system indeksowania
                //potrzebny do wyboru odtwarzania zadanego utworu.
                int i = listaPlikow.Items.Count;
                foreach (var plik in openFileDialog1.SafeFileNames)
                {
                    p1.nazwa[listaPlikow.Items.Count] = plik;
                    listaPlikow.Items.Add(plik);
                }
                foreach (var plik in openFileDialog1.FileNames)
                {
                    p1.zrodlo[i] = plik;
                    i++;
                }
            }
        }
        //Zapisywanie playlisty do pliku txt
        private void pb_SavePlaylist_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Playlists";
            saveFileDialog1.InitialDirectory = path;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!File.Exists(saveFileDialog1.FileName))
                {
                    for (int i = 0; i < listaPlikow.Items.Count; i++)
                    {
                        File.AppendAllText(saveFileDialog1.FileName, p1.nazwa[i] + Environment.NewLine);
                        File.AppendAllText(saveFileDialog1.FileName, p1.zrodlo[i] + Environment.NewLine);
                    }
                }
            }
        }
        //Wczytywanie playlisty z pliku txt
        private void pb_LoadPlaylist_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Playlists";
            openFileDialog2.InitialDirectory = path;
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFileDialog2.FileName);
                string line;
                int i = 0;
                int j = 0;
                listaPlikow.Items.Clear();
                while ((line = file.ReadLine()) != null)
                {
                    if (i % 2 == 0)
                    {
                        p1.nazwa[j] = line;
                        listaPlikow.Items.Add(p1.nazwa[j]);
                    }
                    else
                    {
                        p1.zrodlo[j] = line;
                        j++;
                    }
                    i++;
                }
                file.Close();
            }
        }
        //----------------------------------KONIEC METOD OBSŁUGI PRZYCISKÓW----------------------------------
        //----------------------------------FUNKCJE LOGICZNE W PROGRAMIE----------------------------------
        //Funkcja "próbująca" odtworzyć kolejny utwór z listy, w razie błędu - obsługa. Zawarta logika
        //możliwości odtworzenia kolejnejnego utworu
        private void TryPlayNextSong()
        {
            if (player.currentSongIndex + 1 < listaPlikow.Items.Count)
            {
                if (player.repeat)
                {
                    player.SetPosition(0);
                    time = 0;
                }
                else if (player.currentSongIndex + 1 < listaPlikow.Items.Count)
                {
                    Random rnd = new Random();
                    if (player.shuffle)
                        player.currentSongIndex = rnd.Next(0, listaPlikow.Items.Count);
                    else
                        player.currentSongIndex++;
                    do
                    {
                        try
                        {
                            NextSongSetup();
                            listaPlikow.SelectedIndex = player.currentSongIndex;
                            StartSong();
                            timer1.Start();
                            break;
                        }
                        catch
                        {
                            if (player.currentSongIndex + 1 < listaPlikow.Items.Count)
                            {
                                if (player.shuffle)
                                {
                                    player.currentSongIndex = rnd.Next(0, listaPlikow.Items.Count);
                                }
                                else
                                    player.currentSongIndex++;
                            }
                            else
                                break;
                        }
                    } while (player.currentSongIndex + 1 < listaPlikow.Items.Count);

                }
                else
                {
                    timer1.Stop();
                    time = 0;
                    MessageBox.Show("Koniec listy odtwarzania!");
                }
            }
        }
        //Ustawianie wartosci kolejnej piosenki
        private void NextSongSetup()
        {
            player.Close();
            player.Load(p1.zrodlo[player.currentSongIndex]);
            lb_SongEnd.Text = timeSet(player.GetSongLenght());
            trackBar1.Maximum = player.GetSongLenght()/1000;
            lb_curSongName.Text = p1.nazwa[player.currentSongIndex];
            time = 0;
        }
        //Obsługa timeru odpowiedzialnego za uakutalnianie wartosci trackbara pokazujacego obecny stan piosenki,
        //piosenka zmienia sie podczas gdy wartosc zmiennej "time" przekroczy wartosc maxSongLenght pobieranego
        //przy starcie piosenki player.Start()
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > player.maxSongLength / 1000)
            {
                if(player.repeat)
                {
                    trackBar1.Value = 0;
                    time = 0;
                    player.SetPosition(time * 1000);
                }
                else
                    TryPlayNextSong();
            }
            else if (trackBar1.Value < player.maxSongLength)
            {
                lb_SongCur.Text = timeSet(time * 1000);
                trackBar1.Value = time;
            }
            else
            {
                MessageBox.Show("Błąd suwaka");
            }
            time++;
        }
        //Logika zmiany trackbar'u w celu zmiany obecnego stanu piosenki (przewijanie piosenki bądź cofanie), akutalizacja
        //zmiennej globalnej time, ktora jest kluczowa w metodzie timer1_Tick.
        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (player.isPlaying)
            {
                time = trackBar1.Value;
                player.SetPosition(time * 1000);
            }
        }
        //----------------------------------KONIEC FUNKCJI LOGICZNYCH----------------------------------
        //----------------------------------METODY POMOCNICZE----------------------------------
        //Ustawienie formatowania czasu MM:SS
        private string timeSet(int miliseconds)
        {
            int sec = miliseconds / 1000;
            int min=0;
            string text;
            if(sec >= 60)
            {
                min = sec/60;
                sec = sec - (min * 60);
            }
            if(sec < 10)
                text = min.ToString() + ":0" + sec.ToString();
            else
                text = min.ToString() + ":" + sec.ToString();
            return text;
        }
        //ustawianie dzwieku basu i sopranu w jednnej metodzie
        private void StartSong()
        {
            player.Start();
            player.SetBass(vsb_Bass.Value);
            player.SetTreble(vsb_Treble.Value);
            player.SetVolume(vsb_Volume.Value);
        }
        //----------------------------------KONIEC METOD POMOCNICZYCH----------------------------------
        //----------------------------------METODY DRUGORZĘDNE----------------------------------
        //logika zmiany ikonki przycisku "play" przy zmianie zaznaczenia w listaPlikow
        private void listaPlikow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listaPlikow.SelectedIndex != player.currentSongIndex)
                pb_PlayBtn.Image = Mp3Player.Properties.Resources.Play;
            else if (player.isPlaying)
                pb_PlayBtn.Image = Mp3Player.Properties.Resources.Pause;
        }
        //Logika scrollowanego napisu utworu
        private void timerScroll_Tick(object sender, EventArgs e)
        {
            if(lb_curSongName.Text != "" && lb_curSongName.Text.Length > 25)
            {
                lb_curSongName.Text = lb_curSongName.Text.Substring(1, lb_curSongName.Text.Length - 1) + lb_curSongName.Text.Substring(0, 1);
            }     
        }
        //Rozszerzanie i zmniejszanie okna odtwarzacza
        private void pb_Hide_Click(object sender, EventArgs e)
        {
            if (pb_Hide.Image == ExpandArrowBitmap)
            {
                pb_Hide.Image = CollapseArrowBitmap;
                pb_Delete.Show();
                this.Height += 230;
            }
            else
            {
                pb_Hide.Image = ExpandArrowBitmap;
                pb_Delete.Hide();
                this.Height -= 230;
            }
        }
        //ustawianie dzwieku basu i sopranu
        private void vsb_Bass_ValueChanged(object sender, EventArgs e)
        {
            if (!(player.SetBass(vsb_Bass.Value)))
                MessageBox.Show("error");
        }
        private void vsb_Volume_ValueChanged(object sender, EventArgs e)
        {
            if (!(player.SetVolume(vsb_Volume.Value)))
                MessageBox.Show("error");
        }
        private void vsb_T_ValueChanged(object sender, EventArgs e)
        {
            if (!(player.SetTreble(vsb_Treble.Value)))
                MessageBox.Show("error");
        }
        //zmiana trybu odtwarzania (zapetlanie, ciaglosc, losowosc)
        private void pb_Repeat_Click(object sender, EventArgs e)
        {
            if(pb_Repeat.Image == RepeatBitmap)
            {
                pb_Repeat.Image = DontRepeatBitmap;
                player.repeat = false;
            }
            else if(pb_Repeat.Image == DontRepeatBitmap)
            {
                pb_Repeat.Image = ShuffleBitmap;
                player.shuffle = true;
            }
            else if(pb_Repeat.Image == ShuffleBitmap)
            {
                pb_Repeat.Image = RepeatBitmap;
                player.repeat = true;
                player.shuffle = false;
            }
        }
        //Kasowanie jednego utworu za pomoca klawisza delete
        //Kasowanie calej playlisty
        private void pb_Delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy chcesz usunąć całą playliste?", "Zapytanie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                listaPlikow.Items.Clear();
            }
            else
            {
            }
        }
        //----------------------------------KONIEC METOD DRUGORZĘDNYCH----------------------------------
    }
}
