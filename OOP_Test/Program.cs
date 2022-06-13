namespace OOP_Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            //points to calculate & length of the requerd array
            int point1 = 0;
            int point2 = 6;
            int length = 3;
            NewMatrix newMatrix = new NewMatrix(point1, point2, length);
            //Write down resulted matrix
            Console.WriteLine(newMatrix);
            //Calculate answer
            int answer = newMatrix.Calculate();
            //If condition is not broken then print answer else print Error!
            if (answer != int.MinValue)
                Console.WriteLine(answer);
            else
                Console.WriteLine("Error!");
        }
        //Matrix class to inherit of
        public class Matrix
        {
            //private fields 
            int length;
            int[,] matrix;
            //method to read matrix from the outside
            public int[,] Matr
            {
                get { return matrix; }
            }
            //method to read matrix length from the outside
            public int Length
            {
                get { return length; }
            }   
            //constructor which recives length & builds our matrix
            public Matrix( int length)
            {
                this.length = length;
                matrix = new int[length, length];
                //use function to fill matrix up to prevent clutter of constructor
                FillMatrix();
            }
            //matrix-filling function
            void FillMatrix()
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
        }
        //new class which inherits base class
        public class NewMatrix : Matrix
        {
            //requerd points
            int point1,point2;
            //constructor of this class
            //using keyword base to acsess base class constructor and assemble matrix properly
            public NewMatrix(int point1, int point2, int length)
                : base(length)
            {
                this.point1 = point1;
                this.point2 = point2;

            }
            //calculate function to solve task
            public int Calculate()
            {
                int max = int.MinValue;
                for (int i = 0; i < Length; i++)
                {
                    int sum = 0;
                    for(int j = 0; j < Length; j++)
                    {
                        sum += Matr[i, j];
                    }
                    //if sum is not within requerd points then return predetermined value
                    if (sum < point1 || sum > point2)
                    {
                        sum = int.MinValue;
                        return sum;
                    }
                    //find max sum
                    if (sum > max)
                    {
                        max = sum;
                    }
                }
                return max;
            }
            //proper formated output
            public override string ToString()
            {
                string output = "";
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        output = output + Matr[i, j] + " ";
                    }
                    output = output + "\n";
                }
                return output;
            }
        }
    }
}