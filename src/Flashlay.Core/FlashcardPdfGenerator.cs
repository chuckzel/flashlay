using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Flashlay.Core;

public class FlashcardPdfGenerator
{
    public void GeneratePdf(CardSet cardSet)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                float cellHeight = PageSizes.A4.Height / cardSet.GridRows;
                page.Content().AlignCenter().AlignMiddle().Table(table =>
                {
                    IContainer CellStyle(IContainer container)
                    {
                        return container
                            .Height(cellHeight)
                            .Border(1, Colors.Grey.Lighten5)
                            .AlignMiddle()
                            .AlignCenter();
                    }

                    table.ColumnsDefinition(columns =>
                    {
                        for (int i = 0; i < cardSet.GridColumns; i++)
                        {
                            columns.RelativeColumn();
                        }
                    });

                    for (int i = 0; i < cardSet.Flashcards.Count; i++)
                    {
                        var currFlashcard = (RasterFlashcard)cardSet.Flashcards[i];
                        table.Cell().Element(CellStyle)
                            .Image(currFlashcard.Image)
                            .FitArea();
                    }
                });
            });
        }).ShowInCompanion();
    }
}
