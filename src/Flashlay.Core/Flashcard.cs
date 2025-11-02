using QuestPDF.Infrastructure;

namespace Flashlay.Core;

public abstract class Flashcard
{
    public Func<IContainer, IContainer> CustomCellStyle { get; private set; } = container => container;
    public Flashcard WithCustomCellStyle(Func<IContainer, IContainer> cellStyleFunc)
    {
        CustomCellStyle = cellStyleFunc;
        return this;
    }

    public static RasterFlashcard FromRasterStream(Stream imageStream) =>
        new() { Image = Image.FromStream(imageStream) };
    public static RasterFlashcard FromRasterBytes(byte[] imageBytes) =>
        new() { Image = Image.FromBinaryData(imageBytes) };
    public static RasterFlashcard FromRasterFile(string imagePath) =>
        new() { Image = Image.FromFile(imagePath) };


    public static SvgFlashcard FromSvgString(string svgContent) =>
        new() { Image = SvgImage.FromText(svgContent) };
    public static SvgFlashcard FromSvgFile(string imagePath) =>
        new() { Image = SvgImage.FromFile(imagePath) };
}