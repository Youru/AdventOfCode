using AdventOfCode2024.Day09;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day09
{
    public class Day09Test
    {
        private readonly string _basePath = "Day09/Input";
        private readonly Resolve _resolve;

        public Day09Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_File_System_Checksum()
        {
            string documentText = """
                2333133121414131402
                """;
            long fileSystemChecksum = _resolve.GetFileSystemChecksum(documentText);

            fileSystemChecksum.Should().Be(1928);
        }
        [Fact]
        public void Get_File_System_Checksum_For_Complete_File()
        {
            string documentText = """
                2333133121414131402
                """;
            long fileSystemChecksum = _resolve.GetFileSystemChecksumForCompleteFile(documentText);

            fileSystemChecksum.Should().Be(1928);
        }
        [Fact]
        public void Get_File_System_Checksum_From_Input()
        {
            string document = FileHelper.GetContent(_basePath, "Input1.txt");
            long fileSystemChecksum = _resolve.GetFileSystemChecksum(document);

            fileSystemChecksum.Should().Be(6360094256423);
        }
        //[Fact]
        public void Get_File_System_Checksum_For_Complete_File_From_Input()
        {
            string document = FileHelper.GetContent(_basePath, "Input1.txt");
            long fileSystemChecksum = _resolve.GetFileSystemChecksumForCompleteFile(document);

            fileSystemChecksum.Should().Be(6379677752410);
        }
    }
}