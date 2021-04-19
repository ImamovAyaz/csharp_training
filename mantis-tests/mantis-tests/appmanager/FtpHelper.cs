using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;


namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;
        public FtpHelper(ApplicationManager manager) : base(manager) //Конструктор, который принимает на вход перменную типа
                                                                     //ApplicationManager и передаёт ему менеджер, который там будет заполнен 
        {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }
        public void BackupFile(String path) //необходимо для временного скрытия существущего конфигурационного файла
        {
            String backUpPath = path + ".bak";
            if (client.FileExists(backUpPath))
            {
                return;
            }
            else
            {
                client.Rename(path, backUpPath);
            }
        }
        public void RestoreBackupFile(String path) //метод для восстановления конфигурационного файла из резервной копии
        {
            String backUpPath = path + ".bak";
            if (! client.FileExists(backUpPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(backUpPath, path);
        }
        public void Upload(String path, Stream localFile) //Загружаем локальный файл вместо конфига
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            using (Stream ftpStream = client.OpenWrite(path))
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localFile.Read(buffer, 0, buffer.Length); //сколько байт было прочитано на самом деле
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count); //записываем из буффера, с .. 0, count штук
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }

        }
    }
}
