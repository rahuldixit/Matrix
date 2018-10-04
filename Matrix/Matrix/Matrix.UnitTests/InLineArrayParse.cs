using System;
using System.Collections.Generic;

namespace MatrixUnitTests
{
    public static class InLineArrayParse
    {
        public static int[,] ParseArray(string values)
        {
            var intList = new List<List<int>>();
            var items = values.Split("},{");
            int x = items.Length;
            int y = -1;
            foreach (var item in items)
            {
                var subitems = item.Replace("{", "").Replace("}", "").Split(",");
                var newY = subitems.Length;
                if (y != -1 && newY != y)
                {
                    throw new IndexOutOfRangeException($"{y} is not the same as {newY}");
                }
                y = newY;
                var subItemsArray = new List<int>();
                foreach (var subitem in subitems)
                {
                    subItemsArray.Add(int.Parse(subitem.Trim()));
                }
                intList.Add(subItemsArray);
            }
            var result = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    result[i, j] = intList[i][j];
                }
            }
            return result;

        }
    }
}
