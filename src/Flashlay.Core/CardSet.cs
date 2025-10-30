namespace Flashlay.Core;

public class CardSet
{
    public List<Flashcard> Flashcards { get; set; } = [];
    public int GridColumns { get; set; }
    public int GridRows { get; set; }
}