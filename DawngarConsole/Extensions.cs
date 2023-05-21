namespace DawngarConsole;

public static class Extensions
{
    public static bool IsSectionBlank(this Image<Rgba32> img, RectangleF rect)
    {
        int x = (int)rect.X;
        int y = (int)rect.Y;
        int width = (int)rect.Width;
        int height = (int)rect.Height;
        for (int row = y; row < y + height; row++)
        {
            for (int col = x; col < x + width; col++)
            {
                if(!img[col, row].IsTransparentOrBlank()) 
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool AreTheSame(this Image<Rgba32> img, RectangleF rec1, RectangleF rec2)
    {
        if(rec1.Width != rec2.Width || rec1.Height != rec2.Height) 
        {
            throw new InvalidOperationException("Rectangles must have identical width and height");
        }
        int width = (int)rec1.Width;
        int height = (int)rec1.Height;
        Rgba32[] rec1Pixels = new Rgba32[(int)rec1.Width * (int)rec1.Height];         
        int rec1X = (int)rec1.X;
        int rec1Y = (int)rec1.Y;
        int idx = 0;
        for (int row = rec1Y; row < rec1Y + height; row++)
        {
            for (int col = rec1X; col < rec1X + width; col++)
            {
                rec1Pixels[idx++] = img[col, row];
            }
        }
        //Reset cursor
        idx = 0;
        Rgba32[] rec2Pixels  = new Rgba32[(int)rec2.Width * (int)rec2.Height];
        int rec2X = (int)rec2.X;
        int rec2Y = (int)rec2.Y;
        for (int row = rec2Y; row < rec2Y + height; row++)
        {
            for (int col = rec2X; col < rec2X + width; col++)
            {
                rec2Pixels[idx++] = img[col, row];
            }
        }
        for(int i = 0; i < idx; i++) 
        {
            if(rec1Pixels[i] != rec2Pixels[i]) 
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsTheSame(this Image<Rgba32> img, RectangleF rect, int offset)
    {
        int x = (int)rect.X;
        int y = (int)rect.Y;
        int width = (int)rect.Width;
        int height = (int)rect.Height;
        for (int row = y; row < y + height; row++)
        {
            for (int col = x; col < x + width; col++)
            {
                Rgba32 pixel1 = img[col, row];
                Rgba32 pixel2 = img[col + offset, row];
                if(!pixel1.Equals(pixel2)) {
                    return false;
                }

            }
        }
        return true;
    }

    public static bool IsTransparentOrBlank(this Rgba32 pixel) 
        => pixel.A == 0 || pixel.R == 0 && pixel.G == 0 && pixel.B == 0;
}
