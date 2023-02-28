using System.Runtime.CompilerServices;

namespace SiemensTest
{
    internal class DirData
    {
        public string Name { get; set; }
        public List<FileData> Files { get; set; }
        public List<DirData> Subdirectories { get; set; }

        public DirData() { }

        public DirData(DirectoryInfo direct) {
            Name = direct.Name;
            Files = new List<FileData>();
            foreach (FileInfo f in direct.GetFiles())
            {
                Files.Add(new FileData(f));
            }
            Subdirectories = new List<DirData>();
            foreach (DirectoryInfo d in direct.GetDirectories())
            {
                Subdirectories.Add(new DirData(d));
            }
        }

        public void printoutExtensions()
        {
            List<String> list = new List<String>();

            addExtensions(this, list);
            foreach (DirData d in Subdirectories)
            {
                addExtensions(d, list);
            }

            list = list.Distinct().ToList();
            if (list.Count != 0) {
                foreach (string l in list)
                {
                    Console.Write(l + " ");
                }
            }
            else {
                Console.Write("There are no files with extensions.");
            }
            
        }
        private void addExtensions(DirData dir, List<String> list)
        {
            foreach (FileData i in dir.Files)
            {
                list.Add(i.Extension);
            }
        }
    }
}
