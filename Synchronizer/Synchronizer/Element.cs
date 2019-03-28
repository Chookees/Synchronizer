using System;

namespace Synchronizer
{
    public class Element
    {
        public string FileName { get; private set; }

        public string PathTo { get; private set; }

        public bool IsSource { get; private set; }

        public DateTime LastWriteTime { get; private set; }

        public Element(string fileName, string path, bool isSource, DateTime writeTime)
        {
            this.FileName = fileName;
            this.PathTo = path;
            this.IsSource = isSource;
            this.LastWriteTime = writeTime;
        }
    }
}
