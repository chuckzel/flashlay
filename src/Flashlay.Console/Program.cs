using Flashlay.Core;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

Console.WriteLine("Hello, World!");

var cardSet = new CardSet
{
    Flashcards = [
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\snowflake.png"),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\horse.svg"),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\gingerbread.svg")
            .WithCustomCellStyle(c => c.Padding(40)),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\goose.svg"),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\bird.svg")
            .WithCustomCellStyle(c => c.Padding(20)),
    ],
    GridColumns = 1,
    GridRows = 2
};

var pdfGenerator = new FlashcardPdfGenerator();
pdfGenerator.GeneratePdf(cardSet).GeneratePdf(@"t:\My Drive\teaching\kindergarten\flashcards.pdf");
