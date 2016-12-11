using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mp3Player
{
    class MusicPlayer
    {
        //Importowanie biblioteki umożliwiającej odtwarzanie plików *.mp3
        [DllImport("winmm.dll")]
        //zmienne lokalne
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);
        private StringBuilder returnData = new StringBuilder(128);
        //zmienne globalne
        public bool isPlaying = false;
        public bool repeat = false;
        public bool shuffle = false;
        public int maxSongLength = 0;
        public int currentSongIndex = -1;
        //Wczytanie pliku do otworzenia
        public void Load(string plik)
        {
            //Ustawiamy polecenie nadajemy naszemu pliku nazwę MP3
            string command = "open \"" + plik + "\" type MPEGVideo alias MP3";
            //Przesylamy polecenie do biblioteki za pomocą msiSendString
            mciSendString(command, null, 0, 0);
        }
        //Uruchomienie pliku
        public void Start()
        {
            //Ustawiamy polecenie odtworzenia pliku z alliasem MP3, który ustawiamy powyżej
            string command = "play MP3";
            //Przeysylamy polecenie
            mciSendString(command, null, 0, 0);
            maxSongLength = GetSongLenght();
        }
        //Zatrzymanie pliku
        public void Stop()
        {
            //Ustawiamy polecenie na zatrzymanie odtwarzania pliku
            string command = "stop MP3";
            //przeyslamy je
            mciSendString(command, null, 0, 0);   
        }
        //Zamkniecie otowrzonego pliku
        public void Close()
        {
            //Ustawiamy polecenie na zamkniecie obslugi pliku
            string command = "close MP3";
            //przesylamy je
            mciSendString(command, null, 0, 0);
        }
        //Pobranie dlugosci piosenki
        public int GetSongLenght()
        {
            string command = "status MP3 length";
            mciSendString(command, returnData, returnData.Capacity, 0);
            return int.Parse(returnData.ToString());
        }
        //Metoda do rozbudowy programu, mozna usunąć
        public int GetCurentMilisecond()
        {
            string command = "status MP3 position";
            mciSendString(command, returnData,returnData.Capacity, 0);
            return int.Parse(returnData.ToString());
        }
        //Ustawienie dzwieku
        public bool SetVolume(int volume)
        {
            try
            {
                volume = (100 - volume) * 10;
                string command = "setaudio MP3 volume to " + volume.ToString();
                mciSendString(command, null, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Ustawienie bassu
        public bool SetBass(int bass)
        {
            try
            {
                bass = (100 - bass) * 10;
                string command = "setaudio MP3 bass to " + bass.ToString();
                mciSendString(command, null, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Ustawienie sopranu
        public bool SetTreble(int treble)
        {
            try
            {
                treble = (100 - treble) * 10;
                string command = "setaudio MP3 treble to " + treble.ToString();
                mciSendString(command, null, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Zmiana pozycji piosenki, przewijanie, cofanie itp.
        public bool SetPosition(int miliseconds)
        {
            try
            {
                string command = "play MP3 from " + miliseconds.ToString();
                mciSendString(command, null, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
