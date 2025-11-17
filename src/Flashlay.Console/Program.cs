using Flashlay.Core;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

Console.WriteLine("Hello, World!");

var flashCards = CardSet.AbsoluteGrid([
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\king.jpg")
            .WithCustomCellStyle(c => c.Padding(20)),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\knight.svg")
            .WithCustomCellStyle(c => c.Padding(20)),
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\dwarf.jpg")
            .WithCustomCellStyle(c => c.Padding(20)),
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\bone.png")
            .WithCustomCellStyle(c => c.Padding(40)),
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\cone.jpg"),
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\megaphone.png")
            .WithCustomCellStyle(c => c.Padding(40))
    ],
    cellWidth: PageSizes.A4.Width,
    cellHeight: PageSizes.A4.Height / 2 - 20,
    contentWidth: PageSizes.A4.Width
);

var cubeCards = CardSet.AbsoluteGrid([
        //Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\cloak.svg"),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\lantern.svg")
            .WithCustomCellStyle(c => c.Padding(-30)),
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\bread.png")
            .WithCustomCellStyle(c => c.Padding(4)),
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\cake.png")
            .WithCustomCellStyle(c => c.Padding(4)),
        Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\donkey.svg")
            .WithCustomCellStyle(c => c.Padding(3)),
        Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\chestnut.jpg")
            .WithCustomCellStyle(c => c.Padding(4)),
    ],
    //cube
    cellWidth: 80f.ToPoints(Unit.Millimetre),
    cellHeight: 80f.ToPoints(Unit.Millimetre),
    //fishing
    //cellWidth: 40f.ToPoints(Unit.Millimetre),
    //cellHeight: 40f.ToPoints(Unit.Millimetre),
    contentWidth: PageSizes.A4.Width - 40
);

var cardCollection = new CardCollection(
    cardSets: [flashCards, cubeCards],
    pageSetup: page =>
    {
        page.Size(PageSizes.A4);
        //float margin = 15f.ToPoints(Unit.Millimetre);
        float margin = 0;
        page.Margin(margin);
    }
);

var pdfGenerator = new FlashcardPdfGenerator();
pdfGenerator.GeneratePdf(cardCollection).ShowInCompanion();
//pdfGenerator.GeneratePdf(cardCollection).GeneratePdf(@"t:\My Drive\teaching\kindergarten\flashcards.pdf");
