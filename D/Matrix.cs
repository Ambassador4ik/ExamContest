using System;

internal class Matrix
{
    private int[,] matrix;

    public Matrix(int[,] matrix)
    {
        this.matrix = matrix;
    }

    public void FillMatrix(string fillType)
    {
        if (fillType != "right to left" && fillType != "left to right")
        {
            throw new ArgumentException("Incorrect input");
        }
        // Fill the matrix with odd numbers starting from 1
        int number = 1;
        for (int row = 0; row < this.matrix.GetLength(0); row++)
        {
            for (int col = 0; col < this.matrix.GetLength(1); col++)
            {
                this.matrix[row, col] = number;
                number += 2;
            }
        }
        if (fillType == "right to left")
            FlipMatrix(ref matrix);
    }

    private static void FlipMatrix(ref int[,] m)
    {
        // Flip the matrix vertically
        // Only change rows
        for (int row = 0; row < m.GetLength(0); row++)
        {
            for (int col = 0; col < m.GetLength(1) / 2; col++)
            {
                (m[row, col], m[row, m.GetLength(1) - 1 - col]) = (m[row, m.GetLength(1) - 1 - col], m[row, col]);
            }
        }
    }

    public override string ToString()
    {
        string result = string.Empty;
        for (int row = 0; row < this.matrix.GetLength(0); row++)
        {
            for (int col = 0; col < this.matrix.GetLength(1); col++)
            {
                result += this.matrix[row, col] + " ";
            }
            result = result.TrimEnd();
            result += Environment.NewLine;
        }
        result = result.TrimEnd();
        return result;
    }
}