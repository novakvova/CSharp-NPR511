using System.Text;

namespace WorkingOperator;

public class Matrix
{
    private readonly double[,] _data;

    public Matrix(int rows, int cols)
    {
        if (rows <= 0)
            throw new ArgumentOutOfRangeException(nameof(rows), "Кількість рядків має бути більшою за нуль.");
        if (cols <= 0)
            throw new ArgumentOutOfRangeException(nameof(cols), "Кількість стовпців має бути більшою за нуль.");

        _data = new double[rows, cols];
    }

    public int Rows => _data.GetLength(0);
    public int Cols => _data.GetLength(1);

    public double this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    public Matrix Transpose()
    {
        var result = new Matrix(Cols, Rows);
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                result[j, i] = _data[i, j];
        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
                sb.Append(_data[i, j]).Append(j < Cols - 1 ? "\t" : "");
            if (i < Rows - 1)
                sb.AppendLine();
        }
        return sb.ToString();
    }
}
