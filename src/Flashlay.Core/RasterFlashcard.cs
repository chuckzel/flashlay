using QuestPDF.Infrastructure;

namespace Flashlay.Core;

public class RasterFlashcard : Flashcard
{
    public required Image Image { get; init; }
}
