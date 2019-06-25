using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine("Proteins =" +string.Join(", ", protein));
            Console.WriteLine("Carbs =" +string.Join(", ", carbs));
            Console.WriteLine("Fats =" +string.Join(", ", fat));
            Console.WriteLine("Diet plan =" +string.Join(", ", dietPlans));
            Console.WriteLine(result);

        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int dietPlanLength = dietPlans.Length;
            int[] answer = new int[dietPlanLength];

            int calorieLength = protein.Length;     
            int[] calorie=new int[calorieLength]; 
       
            for(int i=0;i<calorieLength;i++)
            {
                calorie[i]=(protein[i]*5)+(carbs[i]*5)+(fat[i]*9);
            }
        
            for (int i = 0; i < dietPlanLength; i++)
            {
                int stringLength = dietPlans[i].Length;
                
                if (stringLength == 0)
                {
                    answer[i] = 0;
                }
                else if (stringLength == 1)
                {
                    char stringCharacter = char.Parse(dietPlans[i]);
                    answer[i] = getIndex(stringCharacter, protein, carbs, fat, calorie);
                }
                else
                {
                    int MinMaxIndex, MinMaxIndexPosition;
                    int[] repatedArrayPosition = new int[50];

                    char[] stringCharacter = dietPlans[i].ToCharArray();
                    MinMaxIndex = getIndex(stringCharacter[0], protein, carbs, fat, calorie);

                    repatedArrayPosition = getPosition(MinMaxIndex, stringCharacter[0], protein, carbs, fat, calorie);

                        bool Upper = Char.IsUpper(stringCharacter[0]);
                        int position = 1;
                       
                            while (position < stringCharacter.Length)
                            {
                                if (Upper == true)
                                {
                                    stringCharacter[position] = char.ToUpper(stringCharacter[position]);
                                }
                                else
                                {
                                    stringCharacter[position] = char.ToLower(stringCharacter[position]);
                                }
                    
                                MinMaxIndexPosition = CheckRepeatedPosition(repatedArrayPosition, stringCharacter[position], protein, carbs, fat, calorie);
                                if (MinMaxIndexPosition == -1)
                                {
                                    answer[i] = repatedArrayPosition[1];
                                }
                                else
                                {
                                    answer[i] = MinMaxIndexPosition;
                                    break;
                                }
                                position++;
                            }
                    }
            }

      return answer;
     throw new NotImplementedException();
 }


 public static int getIndex(char check, int[] protein, int[] carbs, int[] fat,int[] calorie)
 {
            int maxValue, minValue, maxIndex, minIndex;
            switch (check)
            {
                case 'C':
                    maxValue = carbs.Max();
                    return maxIndex = carbs.ToList().IndexOf(maxValue);

                case 'c':
                    minValue = carbs.Min();
                    return minIndex = carbs.ToList().IndexOf(minValue);

                case 'P':
                    maxValue = protein.Max();
                    return maxIndex = protein.ToList().IndexOf(maxValue);

                case 'p':
                    minValue = protein.Min();
                    return minIndex = protein.ToList().IndexOf(minValue);

                case 'F':
                    maxValue = fat.Max();
                    return maxIndex = fat.ToList().IndexOf(maxValue);

                case 'f':
                    minValue = fat.Min();
                    return minIndex = fat.ToList().IndexOf(minValue);

                case 'T':
                    maxValue = calorie.Max();
                    return maxIndex = calorie.ToList().IndexOf(maxValue);

                case 't':
                    minValue = calorie.Min();
                    return minIndex = calorie.ToList().IndexOf(minValue);
            }
            return 0;
        }


        public static int[] getPosition(int index,char check, int[] protein, int[] carbs, int[] fat, int[] calorie)
        {
            int[] repeatElementPosition = new int[50];
        
            switch (check)
            {
                case 'C':
                        return repeatElementPosition= getArray(index,carbs);
                case 'c':
                        return repeatElementPosition = getArray(index, carbs);
                case 'P':
                        return repeatElementPosition = getArray(index, protein);
                case 'p':
                        return repeatElementPosition = getArray(index, protein);
                case 'F':
                        return repeatElementPosition = getArray(index, fat);
                case 'f':
                        return repeatElementPosition = getArray(index, fat);
                case 'T':
                        return repeatElementPosition = getArray(index, calorie);
                case 't':
                        return repeatElementPosition = getArray(index, calorie);
            }
            return repeatElementPosition;
        }

        public static int[] getArray(int index, int[] type)
       {
           int count = 0, temp;
           int[] repeatElementPosition = new int[50];
           int z = 1;

            temp = type[index];
            for (int i = 0; i < type.Length; i++)
            {
                if (temp == type[i])
                {
                    repeatElementPosition[z] = i;
                    z++;
                    count++;
                }
            }
            repeatElementPosition[0] = count;
            return repeatElementPosition;
        }


        public static int CheckRepeatedPosition(int[] index, char check, int[] protein, int[] carbs, int[] fat, int[] calorie)
        {
            int min = 0, max = 1;
            int position;
            switch (check)
            {
                case 'C':
                         position=getElement(index,carbs,max);
                         return position;
                case 'c':
                        position=getElement(index,carbs,min);
                         return position;
                case 'P':
                         position = getElement(index, protein, max);
                         return position;
                case 'p':
                         position = getElement(index, protein, min);
                         return position;
                case 'F':
                         position = getElement(index, fat, max);
                         return position;
                case 'f':
                         position = getElement(index, fat, min);
                         return position;
                case 'T':
                         position = getElement(index, calorie, max);
                         return position;
                case 't':
                         position = getElement(index, calorie, min);
                         return position;
            }    
            return -1;
        }

        public static int getElement(int[] index, int[] type, int MinMax)
        {
            int count = 0, position;
       
            position = type[index[1]];

            for (int i = 0; i < index[0]; i++)
            {
                if (position == type[index[i + 1]])
                {
                    count++;
                }
            }

            if (count == index[0])
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < index[0]; i++)
                {
                    if (MinMax == 1)
                    {
                        if (position < type[index[i + 1]])
                        {
                            position = type[index[i + 1]];
                        }
                    }
                    else
                    {
                        if (position > type[index[i + 1]])
                        {
                            position = type[index[i + 1]];
                        }
                    }
                }
                position = type.ToList().IndexOf(position);
                return position;
            }
                  
        }      

    }
}
