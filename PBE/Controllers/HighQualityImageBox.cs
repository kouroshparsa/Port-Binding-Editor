using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Cyotek.Windows.Forms;

namespace PBE.Controllers
{
    class HighQualityImageBox: ImageBox
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Optional: use if you want to customize background
            base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Image == null)
            {
                base.OnPaint(e);
                return;
            }

            // Set high-quality rendering options
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            base.OnPaint(e); // Let ImageBox handle actual drawing and transformation
        }
    }
}
