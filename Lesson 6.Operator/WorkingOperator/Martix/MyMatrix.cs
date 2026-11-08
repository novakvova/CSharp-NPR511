using System.Text;

public class MyMatrix
{
    //readonly - значить, що створити зміннну можна пристворені
    //або у конструкторі
    private readonly double[,] _data;

    public MyMatrix(int rows, int cols)
    {
        if (rows <= 0)
            throw new ArgumentOutOfRangeException(nameof(rows), "Кількість рядків має бути більшою за нуль.");
        if (cols <= 0)
            throw new ArgumentOutOfRangeException(nameof(cols), "Кількість стовпців має бути більшою за нуль.");

        _data = new double[rows, cols];
    }

    //public int Rows => _data.GetLength(0); //Розмір по рядках
    public int Rows
    {
        get { return _data.GetLength(0); }
    } //Розмір по рядках
    public int Cols => _data.GetLength(1); //Розмір по стовпчиках

    public double this[int row, int col]
    {
        get => _data[row, col];
        //set => _data[row, col] = value;
        set
        {
            _data[row, col] = value;
        }
    }

    public MyMatrix Transpose()
    {
        var result = new MyMatrix(Cols, Rows);
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                result[j, i] = _data[i, j];
        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        //Побудова String, але розумного
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
