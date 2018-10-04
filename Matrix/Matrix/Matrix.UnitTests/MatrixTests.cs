using MatrixConsoleApplication;
using Xunit;

namespace MatrixUnitTests
{
     public class MatrixTests
    {
        [Theory]
        [InlineData("{ 1, 1 },{ 1, 1 }", "{ 2, 2 },{ 2, 2 }", "{ 3, 3 },{ 3, 3 }")]          
        public void Matrix_Add_Valid(string matrix1Str, string matrix2Str, string matrix3Str)
        {
            // arrange
            var matrix1 = new Matrix(InLineArrayParse.ParseArray(matrix1Str));
            var matrix2 = new Matrix(InLineArrayParse.ParseArray(matrix2Str));
            var matrix3 = new Matrix(InLineArrayParse.ParseArray(matrix3Str));

            // act
            Matrix matrix4 = matrix1 + matrix2;

            // assert            
            Assert.True(matrix3 == matrix4);

        }

        [Theory]
        [InlineData("{ 1, 1 },{ 1, 1 }", "{ 2, 2 },{ 2, 2 }", "{ -3, -3 },{ -3, -3 }")]                
        public void Matrix_Add_InValid(string matrix1Str, string matrix2Str, string matrix3Str)
        {
            var matrix1 = new Matrix(InLineArrayParse.ParseArray(matrix1Str));
            var matrix2 = new Matrix(InLineArrayParse.ParseArray(matrix2Str));
            var matrix3 = new Matrix(InLineArrayParse.ParseArray(matrix3Str));

            Matrix matrix4 = matrix1 + matrix2;            
            Assert.False(matrix3 == matrix4);
        }

        [Theory]
        [InlineData("{ 1, 1 },{ 1, 1 }", "{ 3, 3 },{ 2, 2 }", "{ 2, 2 },{ 1, 1 }")]       
        public void Matrix_Subtract_Valid(string matrix1Str, string matrix2Str, string matrix3Str)
        {
            var matrix1 = new Matrix(InLineArrayParse.ParseArray(matrix1Str));
            var matrix2 = new Matrix(InLineArrayParse.ParseArray(matrix2Str));
            var matrix3 = new Matrix(InLineArrayParse.ParseArray(matrix3Str));

            Matrix matrix4 = matrix2 - matrix1;            
            Assert.True(matrix3 == matrix4);
        }


        [Theory]
        [InlineData("{ 1, 1 },{ 1, 1 }", "{ 3, 3 },{ 2, 2 }", "{ 2, 2 },{ 1, 1 }")]
        public void Matrix_Subtract_InValid(string matrix1Str, string matrix2Str, string matrix3Str)
        {
            var matrix1 = new Matrix(InLineArrayParse.ParseArray(matrix1Str));
            var matrix2 = new Matrix(InLineArrayParse.ParseArray(matrix2Str));
            var matrix3 = new Matrix(InLineArrayParse.ParseArray(matrix3Str));

            Matrix matrix4 = matrix1 - matrix2;            
            Assert.False(matrix3 == matrix4);
        }

        [Theory]
        [InlineData("{ 5, 1, 6 },{ 0, 8, -2 }", "{ 2, 1 },{ 3, 2 },{ 4, 1 }", "{ 37, 13 },{ 16, 14 }")]
        public void Matrix_Multiply_Valid(string matrix1Str, string matrix2Str, string matrix3Str)
        {
            var matrix1 = new Matrix(InLineArrayParse.ParseArray(matrix1Str));
            var matrix2 = new Matrix(InLineArrayParse.ParseArray(matrix2Str));
            var matrix3 = new Matrix(InLineArrayParse.ParseArray(matrix3Str));

            Matrix matrix4 = matrix1 * matrix2;            
            Assert.True(matrix3 == matrix4);
        }

        [Theory]
        [InlineData("{ 5, 1, 6 },{ 0, 8, -2 }", "{ 2 },{ 3},{ 4 }", "{31},{11}")]
        public void Matrix_Multiply_InValid(string matrix1Str, string matrix2Str, string matrix3Str)
        {
            var matrix1 = new Matrix(InLineArrayParse.ParseArray(matrix1Str));
            var matrix2 = new Matrix(InLineArrayParse.ParseArray(matrix2Str));
            var matrix3 = new Matrix(InLineArrayParse.ParseArray(matrix3Str));

            Matrix matrix4 = matrix1 * matrix2;            
            Assert.True(matrix3 != matrix4);
        }
    }
}
