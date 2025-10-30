using Flashlay.Core;
using QuestPDF.Helpers;

Console.WriteLine("Hello, World!");

var cardSet = new CardSet
{
    Flashcards = [
        Flashcard.FromRasterBytes(Placeholders.Image(100, 100)),
        Flashcard.FromRasterBytes(Placeholders.Image(400, 600)),
        Flashcard.FromRasterBytes(Placeholders.Image(600, 400)),
        Flashcard.FromRasterBytes(Placeholders.Image(100, 800)),
        Flashcard.FromRasterBytes(Placeholders.Image(10, 2)),
        Flashcard.FromRasterBytes(Placeholders.Image(1, 20)),
    ],
    GridColumns = 2,
    GridRows = 3
};

var pdfGenerator = new FlashcardPdfGenerator();
pdfGenerator.GeneratePdf(cardSet);
