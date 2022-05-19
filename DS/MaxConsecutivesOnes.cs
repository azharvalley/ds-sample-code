using System.Linq;

namespace DS
{
    class MaxConsecutivesOnes
    {
        public int[] numbers;

        public int FindMaxConsecutiveOnes(int[] numbers)
        {
            int count = 0;
            int[] totalConsecutiveOnes = new int[5];
            int k = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 1)
                {
                    totalConsecutiveOnes[k] = ++count;
                }
                else
                {
                    k++;
                    count = 0;
                }
            }

            //Get max number in array
            return totalConsecutiveOnes.Max();
        }
    }
}
