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

    public IDocument GeneratePdf(CardSet cardSet)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.MarginBottom(20); //todo - make configurable
                float cellHeight = PageSizes.A4.Height / cardSet.GridRows - 20;
                page.Content().AlignCenter().Table(table =>
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
                        var currFlashcard = cardSet.Flashcards[i];
                        var cell = table.Cell().Element(CellStyle).Element(currFlashcard.CustomCellStyle);
                        
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
            });
        });
    }
}
