using Flashlay.Core;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

Console.WriteLine("Hello, World!");

var cardSet = CardSet.AbsoluteGrid([
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\snowflake.png"),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\horse.svg"),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\gingerbread.svg")
            .WithCustomCellStyle(c => c.Padding(20)),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\goose.svg"),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\bird.svg")
            .WithCustomCellStyle(c => c.Padding(10)),
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\spider-7425947_1280.png"),
    ],
    cellWidth: 80f.ToPoints(Unit.Millimetre),
    cellHeight: 80f.ToPoints(Unit.Millimetre),
    contentWidth: PageSizes.A4.Width
);

var pdfGenerator = new FlashcardPdfGenerator();
//pdfGenerator.GeneratePdf(cardSet).ShowInCompanion();
pdfGenerator.GeneratePdf(cardSet).GeneratePdf(@"t:\My Drive\teaching\kindergarten\flashcards.pdf");
