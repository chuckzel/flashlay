using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Flashlay.Core;

public class FlashcardPdfGenerator
{
    public FlashcardPdfGenerator(LicenseType licenseType = LicenseType.Community)
    {
        QuestPDF.Settings.License = licenseType;
    }

    public IDocument GeneratePdf(CardCollection cardCollection)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                cardCollection.PageSetup(page);

                page.Content().AlignCenter().Column(col =>
                {
                    foreach (var cardSet in cardCollection.CardSets)
                    {
                        col.Item().Table(table =>
                        {
                            static IContainer CellStyle(IContainer container)
                            {
                                return container
                                    .Border(1, Colors.Grey.Lighten5)
                                    .AlignMiddle()
                                    .AlignCenter();
                            }

                            table.ColumnsDefinition(cardSet.ColumnsDefinition);

                            for (int i = 0; i < cardSet.Flashcards.Count; i++)
                            {
                                var currFlashcard = cardSet.Flashcards[i];
                                var cell = table.Cell()
                                    .Element(CellStyle)
                                    .Element(cardSet.CellStyle)
                                    .Element(currFlashcard.CustomCellStyle)
                                    .AlignMiddle()
                                    .AlignCenter();

                                switch (currFlashcard)
                                {
                                    case RasterFlashcard rasterFlashcard:
                                        cell.Image(rasterFlashcard.Image).FitArea();
                                        break;
                                    case SvgFlashcard svgFlashcard:
                                        cell.Svg(svgFlashcard.Image).FitArea();
                                        break;
                                }
                            }
                        });
                    }
                    
                });
            });
        });
    }
}
