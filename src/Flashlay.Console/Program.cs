using Flashlay.Core;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

Console.WriteLine("Hello, World!");

List<Func<Flashcard>> fcards = [
    () => Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\acorn.svg"),
    () => Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\sky.jpg"),
    () => Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\forest.jpg"),
    () => Flashcard.FromRasterFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\grass.png"),
    () => Flashcard.FromSvgFile(@"t:\My Drive\teaching\kindergarten\flashcard pictures\mushroom.svg"),
];


var flashCards = CardSet.AbsoluteGrid([
        fcards[0]().WithCustomCellStyle(c => c.Padding(20)),
        fcards[1]().WithCustomCellStyle(c => c.Padding(20)),
        fcards[2]().WithCustomCellStyle(c => c.Padding(20)),
        fcards[3]().WithCustomCellStyle(c => c.Padding(20)),
        fcards[4]().WithCustomCellStyle(c => c.Padding(20)),
    ],
    cellWidth: PageSizes.A4.Width,
    cellHeight: PageSizes.A4.Height / 2 - 20,
    contentWidth: PageSizes.A4.Width 
);

var cubeCards = CardSet.AbsoluteGrid([
        fcards[0]().WithCustomCellStyle(c => c.Padding(8)),
        fcards[1]().WithCustomCellStyle(c => c.Padding(8)),
        fcards[2]().WithCustomCellStyle(c => c.Padding(8)),
        fcards[3]().WithCustomCellStyle(c => c.Padding(8)),
        fcards[4]().WithCustomCellStyle(c => c.Padding(8)),
    ],
    //cube
    cellWidth: 80f.ToPoints(Unit.Millimetre),
    cellHeight: 80f.ToPoints(Unit.Millimetre),
    contentWidth: PageSizes.A4.Width - 40
);

var fishCards = CardSet.AbsoluteGrid([
        fcards[0]().WithCustomCellStyle(c => c.Padding(4)),
        fcards[1]().WithCustomCellStyle(c => c.Padding(4)),
        fcards[2]().WithCustomCellStyle(c => c.Padding(4)),
        fcards[3]().WithCustomCellStyle(c => c.Padding(4)),
        fcards[4]().WithCustomCellStyle(c => c.Padding(4)),
    ],
    //fishing
    cellWidth: 40f.ToPoints(Unit.Millimetre),
    cellHeight: 40f.ToPoints(Unit.Millimetre),
    contentWidth: PageSizes.A4.Width - 40
);

var cardCollection = new CardCollection(
    cardSets: [flashCards, fishCards, cubeCards],
    pageSetup: page =>
    {
        page.Size(PageSizes.A4);
        float margin = 15f.ToPoints(Unit.Millimetre);
        //float margin = 0;
        //page.Margin(margin);
        page.MarginVertical(20);
    }
);

var pdfGenerator = new FlashcardPdfGenerator();
var pdf = pdfGenerator.GeneratePdf(cardCollection);
pdfGenerator.GeneratePdf(cardCollection).GeneratePdf(@"t:\My Drive\teaching\kindergarten\flashcards.pdf");
pdf.ShowInCompanion();
