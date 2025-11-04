using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Flashlay.Core;

public class CardSet
{
    public List<Flashcard> Flashcards { get; init; } = [];
    public required Action<TableColumnsDefinitionDescriptor> ColumnsDefinition { get; init; }
    public required Func<IContainer, IContainer> CellStyle { get; init; }

    // todo: ability to combine relative/absolute rows/columns
    public static CardSet RelativeGrid(List<Flashcard> flashcards, int gridColumns, int gridRows, float contentHeight)
    {
        return new CardSet
        {
            Flashcards = flashcards,
            ColumnsDefinition = columns =>
            {
                for (int i = 0; i < gridColumns; i++)
                {
                    columns.RelativeColumn();
                }
            },
            CellStyle = container => container.Height(contentHeight / gridRows)
        };
    }

    public static CardSet AbsoluteGrid(List<Flashcard> flashcards, float cellWidth, float cellHeight, float contentWidth)
    {
        return new CardSet
        {
            Flashcards = flashcards,
            ColumnsDefinition = columns =>
            {
                for (int i = 0; i < Math.Floor(contentWidth / cellWidth); i++)
                {
                    columns.ConstantColumn(cellWidth);
                }
            },
            CellStyle = container => container.Height(cellHeight)
        };
    }
}