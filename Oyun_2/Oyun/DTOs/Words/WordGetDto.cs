namespace Oyun.DTOs.Words;
public class WordGetDto
{
    public int id { get; set; }
    public string Text { get; set; }
    public string LanguageCode { get; set; }
    public IEnumerable<string> BannedWords { get; set; }
}
