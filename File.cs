

namespace HW6.Delegates
{
    public class FileDetector
    {
        public event EventHandler<FileArgs>? FileFound;
        public event Action StoppedDetection;

        public string _path;
        public bool _stopDetection;

        public FileDetector(string pathDirectory)
        {
            _path = pathDirectory;
            _stopDetection = false;
        }

        public void Detect()
        {
            var files = new DirectoryInfo(_path).EnumerateFiles();

            foreach (var file in files)
            {
                if (_stopDetection)
                {
                    StoppedDetection?.Invoke();
                    break;
                }

                FileFound?.Invoke(this, new FileArgs(file.Name, file.Length));
            }

            _stopDetection = false;
        }

        
        public FileInfo? GetMaxLenthFile()
        {
            var files = new DirectoryInfo(_path).EnumerateFiles();
            return files.GetMax(x => x.Length);
        }


    }
    public class FileArgs
    {
        public string Name { get; private set; }

        public long Length { get; private set; }

        public FileArgs(string name, long length)
        {
            Name = name;
            Length = length;
        }
    }
}
