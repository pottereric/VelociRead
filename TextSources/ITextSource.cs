using System;
namespace TextSources
{
    public interface ITextSource
    {
        string Author { get; }
        int ChapterCount { get; }
        System.Collections.Generic.List<Chapter> Chapters { get; }
        string Title { get; }
    }
}
