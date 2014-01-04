using System.Collections.Generic;
using System.Text;

namespace TextSources.TestUtilities.Stubs
{
    public class TextSourceStub : ITextSource
    {
        public string Author
        {
            get { return "Stub Author"; }
        }

        public int ChapterCount
        {
            get { return 3; }
        }

        public string Title
        {
            get { return "Stub Title"; }
        }

        public List<Chapter> Chapters
        {
            get
            {
                var chapters = new List<Chapter>();
                chapters.Add(ChapterOne);
                chapters.Add(ChapterTwo);
                chapters.Add(ChapterThree);
                return chapters;
            }
        }

        private Chapter ChapterOne
        {
            get
            {
                var chapter = new Chapter(ChapterOneText);
                return chapter;
            }
        }

        private Chapter ChapterTwo
        {
            get
            {
                var chapter = new Chapter(ChapterTwoText);
                return chapter;
            }
        }

        private Chapter ChapterThree
        {
            get
            {
                var chapter = new Chapter(ChapterThreeText);
                return chapter;
            }
        }

        private string ChapterOneText
        {
            get
            {
                var sb = new StringBuilder();

                sb.Append("One ");
                sb.Append("two ");
                sb.Append("three ");
                sb.Append("four, ");
                sb.Append("five ");
                sb.Append("six ");
                sb.Append("seven ");
                sb.Append("eight ");
                sb.Append("nine ");
                sb.Append("ten. ");

                sb.Append("Eleven ");
                sb.Append("twelve ");
                sb.Append("thirteen ");
                sb.Append("fourteen, ");
                sb.Append("fifteen ");
                sb.Append("sixteen ");
                sb.Append("seventeen ");
                sb.Append("eighteen ");
                sb.Append("nineteen ");
                sb.Append("twenty. ");

                sb.Append("Twenty-one ");
                sb.Append("twenty-two ");
                sb.Append("twenty-three ");
                sb.Append("twenty-four, ");
                sb.Append("twenty-five ");
                sb.Append("twenty-six ");
                sb.Append("twenty-seven ");
                sb.Append("twenty-eight ");
                sb.Append("twenty-nine ");
                sb.Append("thirty. ");

                sb.Append("Thirty-one ");
                sb.Append("thirty-two ");
                sb.Append("thirty-three ");
                sb.Append("thirty-four, ");
                sb.Append("thirty-five ");
                sb.Append("thirty-six ");
                sb.Append("thirty-seven ");
                sb.Append("thirty-eight ");
                sb.Append("thirty-nine ");
                sb.Append("forty. ");

                sb.Append("Forty-one ");
                sb.Append("forty-two ");
                sb.Append("forty-three ");
                sb.Append("forty-four, ");
                sb.Append("forty-five ");
                sb.Append("forty-six ");
                sb.Append("forty-seven ");
                sb.Append("forty-eight ");
                sb.Append("forty-nine ");
                sb.Append("fifty. ");

                sb.Append("Fifty-one ");
                sb.Append("fifty-two ");
                sb.Append("fifty-three ");
                sb.Append("fifty-four ");
                sb.Append("(fifty-five ");
                sb.Append("fifty-six ");
                sb.Append("fifty-seven ");
                sb.Append("fifty-eight) ");
                sb.Append("fifty-nine ");
                sb.Append("sixty. ");

                return sb.ToString();
            }
        }

        private string ChapterTwoText
        {
            get
            {
                var sb = new StringBuilder();

                sb.Append("Chapter2One ");
                sb.Append("two ");
                sb.Append("three ");
                sb.Append("four, ");
                sb.Append("five ");
                sb.Append("six ");
                sb.Append("seven ");
                sb.Append("eight ");
                sb.Append("nine ");
                sb.Append("ten. ");

                sb.Append("Eleven ");
                sb.Append("twelve ");
                sb.Append("thirteen ");
                sb.Append("fourteen, ");
                sb.Append("fifteen ");
                sb.Append("sixteen ");
                sb.Append("seventeen ");
                sb.Append("eighteen ");
                sb.Append("nineteen ");
                sb.Append("twenty. ");

                sb.Append("Twenty-one ");
                sb.Append("twenty-two ");
                sb.Append("twenty-three ");
                sb.Append("twenty-four, ");
                sb.Append("twenty-five ");
                sb.Append("twenty-six ");
                sb.Append("twenty-seven ");
                sb.Append("twenty-eight ");
                sb.Append("twenty-nine ");
                sb.Append("thirty. ");

                sb.Append("Thirty-one ");
                sb.Append("thirty-two ");
                sb.Append("thirty-three ");
                sb.Append("thirty-four, ");
                sb.Append("thirty-five ");
                sb.Append("thirty-six ");
                sb.Append("thirty-seven ");
                sb.Append("thirty-eight ");
                sb.Append("thirty-nine ");
                sb.Append("forty. ");

                sb.Append("Forty-one ");
                sb.Append("forty-two ");
                sb.Append("forty-three ");
                sb.Append("forty-four, ");
                sb.Append("forty-five ");
                sb.Append("forty-six ");
                sb.Append("forty-seven ");
                sb.Append("forty-eight ");
                sb.Append("forty-nine ");
                sb.Append("fifty. ");

                sb.Append("Fifty-one ");
                sb.Append("fifty-two ");
                sb.Append("fifty-three ");
                sb.Append("fifty-four ");
                sb.Append("(fifty-five ");
                sb.Append("fifty-six ");
                sb.Append("fifty-seven ");
                sb.Append("fifty-eight) ");
                sb.Append("fifty-nine ");
                sb.Append("sixty. ");

                return sb.ToString();
            }
        }

        private string ChapterThreeText
        {
            get
            {
                var sb = new StringBuilder();

                sb.Append("Chapter3One ");
                sb.Append("two ");
                sb.Append("three ");
                sb.Append("four, ");
                sb.Append("five ");
                sb.Append("six ");
                sb.Append("seven ");
                sb.Append("eight ");
                sb.Append("nine ");
                sb.Append("ten. ");

                sb.Append("Eleven ");
                sb.Append("twelve ");
                sb.Append("thirteen ");
                sb.Append("fourteen, ");
                sb.Append("fifteen ");
                sb.Append("sixteen ");
                sb.Append("seventeen ");
                sb.Append("eighteen ");
                sb.Append("nineteen ");
                sb.Append("twenty. ");

                sb.Append("Twenty-one ");
                sb.Append("twenty-two ");
                sb.Append("twenty-three ");
                sb.Append("twenty-four, ");
                sb.Append("twenty-five ");
                sb.Append("twenty-six ");
                sb.Append("twenty-seven ");
                sb.Append("twenty-eight ");
                sb.Append("twenty-nine ");
                sb.Append("thirty. ");

                sb.Append("Thirty-one ");
                sb.Append("thirty-two ");
                sb.Append("thirty-three ");
                sb.Append("thirty-four, ");
                sb.Append("thirty-five ");
                sb.Append("thirty-six ");
                sb.Append("thirty-seven ");
                sb.Append("thirty-eight ");
                sb.Append("thirty-nine ");
                sb.Append("forty. ");

                sb.Append("Forty-one ");
                sb.Append("forty-two ");
                sb.Append("forty-three ");
                sb.Append("forty-four, ");
                sb.Append("forty-five ");
                sb.Append("forty-six ");
                sb.Append("forty-seven ");
                sb.Append("forty-eight ");
                sb.Append("forty-nine ");
                sb.Append("fifty. ");

                sb.Append("Fifty-one ");
                sb.Append("fifty-two ");
                sb.Append("fifty-three ");
                sb.Append("fifty-four ");
                sb.Append("(fifty-five ");
                sb.Append("fifty-six ");
                sb.Append("fifty-seven ");
                sb.Append("fifty-eight) ");
                sb.Append("fifty-nine ");
                sb.Append("sixty. ");

                return sb.ToString();
            }
        }
    }
}