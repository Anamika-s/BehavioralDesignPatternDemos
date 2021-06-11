using System;

namespace StrategyPattern
{
    // Step1: Creating Abstract Strategy

    public interface ICompression
    {
        void CompressFolder(string compressedArchiveFileName);
    }

    // Step2: Creating concrete Strategy

    // RarCompression
    public class RarCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is compressed using Rar approach: '" + compressedArchiveFileName
                 + ".rar' file is created");
        }
    }
    // ZipCompression
    public class ZipCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is compressed using zip approach: '" + compressedArchiveFileName
                 + ".zip' file is created");
        }
    }

    // Step3: Creating context

    public class CompressionContext
    {
        private ICompression Compression;

        public CompressionContext(ICompression Compression)
        {
            this.Compression = Compression;
        }
        public void SetStrategy(ICompression Compression)
        {
            this.Compression = Compression;
        }
        public void CreateArchive(string compressedArchiveFileName)
        {
            Compression.CompressFolder(compressedArchiveFileName);
        }
    }

    // Step4: Client


    class Program
    {
        static void Main(string[] args)
        {
            CompressionContext ctx = new CompressionContext(new ZipCompression());
            ctx.CreateArchive("DotNetDesignPattern");
            ctx.SetStrategy(new RarCompression());
            ctx.CreateArchive("DotNetDesignPattern");
            Console.Read();
        }
    }
}
