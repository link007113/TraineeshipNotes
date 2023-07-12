using CursusCase.Shared.Exceptions;
using CursusCase.Shared.Helpers;
using System.Reflection;

namespace CursusCase.Shared.Tests.Helpers
{
    [TestClass]
    public class CursusImporterTests
    {
        [DataTestMethod]
        [DataRow("CursusCase.Shared.Tests.TestFiles.goedvoorbeeld1.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.goedvoorbeeld2.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.goedvoorbeeld3.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.goedvoorbeeld4.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.goedvoorbeeld5.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.goedvoorbeeld6.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.goedvoorbeeld7.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.goedvoorbeeld8.txt")]
        public void Import_WhenValidFile_ReturnFilledList(string filepath)
        {
            // Arrange

            CursusImporter sut = new CursusImporter();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string stringResult;
            string testFilePath = EmbeddedResourceUnpacker(filepath);

            // Act
            List<Models.CourseInstance> result = sut.Import(testFilePath);

            // Assert

            Assert.IsTrue(result.Count() > 0);
            File.Delete(testFilePath);
        }

        [DataTestMethod]
        [DataRow("CursusCase.Shared.Tests.TestFiles.fout1.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.fout2.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.fout3.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.fout4.txt")]
        [DataRow("CursusCase.Shared.Tests.TestFiles.fout5.txt")]
        public void Import_WhenInvalidFile_ThroughMissingMembers_ReturnInException(string filepath)
        {
            // Arrange

            CursusImporter sut = new CursusImporter();
            string testFilePath = EmbeddedResourceUnpacker(filepath);

            // Act
            void act()
            {
                List<Models.CourseInstance> result = sut.Import(testFilePath);
            }

            // Assert

            Assert.ThrowsException<ImportException>(act);
            File.Delete(testFilePath);
        }

        private static string EmbeddedResourceUnpacker(string filepath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string stringResult;
            string testFilePath = Path.GetTempFileName();
            using (Stream stream = assembly.GetManifestResourceStream(filepath))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    stringResult = reader.ReadToEnd();
                }

                File.WriteAllText(testFilePath, stringResult);
            }

            return testFilePath;
        }
    }
}