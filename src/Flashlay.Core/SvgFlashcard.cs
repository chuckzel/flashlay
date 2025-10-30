using QuestPDF.Infrastructure;

namespace Flashlay.Core;

public class SvgFlashcard : Flashcard
{
    public required SvgImage Image { get; init; }
}