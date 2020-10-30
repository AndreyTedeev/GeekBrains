using System.Drawing;
using System.Drawing.Drawing2D;

namespace AndreyTedeev.Asteroids.Data
{
    abstract class ImageObject : BaseObject
    {

        protected abstract Image Image { get; }

        protected static Image LoadImageAndResize(string fileName, int width, int height) {
            Image origin = Image.FromFile(fileName);
            return Resize(origin, width, height, true);
        }

        protected static Image Resize(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

            var newHeight = image.Height * newWidth / image.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead  
                newWidth = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }

            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return res;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, _bounds);
        }

    }
}
