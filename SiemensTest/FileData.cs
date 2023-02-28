namespace SiemensTest
{
    internal class FileData
    {
        public string Fname { get; set; }
        public string Extension { get; set; }

        public FileData()
        {
        }
        public FileData(FileInfo file)
        {
            Fname = Path.GetFileNameWithoutExtension(file.Name);
            Extension = file.Extension;
        }
    }
}
