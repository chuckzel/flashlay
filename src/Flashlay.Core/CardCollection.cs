using QuestPDF.Fluent;

namespace Flashlay.Core;

public class CardCollection
{
    public IEnumerable<CardSet> CardSets { get; init; } = [];
    public Action<PageDescriptor> PageSetup { get; init; }
    public CardCollection(IEnumerable<CardSet> cardSets, Action<PageDescriptor> pageSetup)
    {
        CardSets = cardSets;
        PageSetup = pageSetup;
    }
}