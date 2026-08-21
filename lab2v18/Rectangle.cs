namespace lab2v18;

public class Rectangle
{
    private double _width;
    private double _height;

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width
    {
        get => _width;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Ширина має бути додатною.");
            _width = value;
        }
    }

    public double Height
    {
        get => _height;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Висота має бути додатною.");
            _height = value;
        }
    }

    public double Area => _width * _height;

    public double Perimeter => 2 * (_width + _height);

    public double this[int index]
    {
        get => index switch
        {
            0 => _width,
            1 => _height,
            _ => throw new IndexOutOfRangeException("Індекс має бути 0 (ширина) або 1 (висота).")
        };
        set
        {
            switch (index)
            {
                case 0: Width = value; break;
                case 1: Height = value; break;
                default: throw new IndexOutOfRangeException("Індекс має бути 0 (ширина) або 1 (висота).");
            }
        }
    }

    public static Rectangle operator *(Rectangle rect, double factor)
    {
        if (factor <= 0)
            throw new ArgumentException("Коефіцієнт масштабування має бути додатним.");
        return new Rectangle(rect._width * factor, rect._height * factor);
    }

    public static Rectangle operator *(double factor, Rectangle rect) => rect * factor;

    public static bool operator ==(Rectangle a, Rectangle b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a._width == b._width && a._height == b._height;
    }

    public static bool operator !=(Rectangle a, Rectangle b) => !(a == b);

    public override bool Equals(object? obj) => obj is Rectangle other && this == other;

    public override int GetHashCode() => HashCode.Combine(_width, _height);

    public override string ToString() => $"Rectangle[{_width} x {_height}]";
}
