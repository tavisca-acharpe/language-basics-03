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
        
            //int  minValue, minIndex;
            
            int n = dietPlans.Length;
            int[] answer = new int[n];

            int cLen = protein.Length;     
            int[] calorie=new int[cLen]; 
       
            for(int i=0;i<cLen;i++)
            {
                calorie[i]=(protein[i]*5)+(carbs[i]*5)+(fat[i]*9);
            }
        
            for (int i = 0; i < n; i++)
            {
                int len = dietPlans[i].Length;
                
                //For Single Character 'p'
                if (len == 1)
                {
                    char check = char.Parse(dietPlans[i]);
                    answer[i] = getIndex(check, protein, carbs, fat, calorie);
                }

                if (len == 2)
                {
                       int ans1;
                       int[] rep = new int[50];
                       int rep1; 

                       char[] check = dietPlans[i].ToCharArray();
                       ans1 = getIndex(check[0], protein, carbs, fat, calorie);

                       rep = CheckRepeated(ans1, check[0], protein,carbs, fat, calorie);
                     
                        if(rep[0]==1)
                       {
                            answer[i]=ans1;
                       }
                       else
                       {
                           bool U = Char.IsUpper(check[0]);
                           if (U == true)
                           {
                               check[1] = char.ToUpper(check[1]);
                               rep1 = CheckRepeatedPos(rep, check[1], protein, carbs, fat, calorie);
                               if (rep1 == -1)
                               {
                                   answer[i] = rep[1];
                               }
                               else
                               {
                                   answer[i] = rep1;
                               }
 
                           }
                           else
                           {
                               check[1] = char.ToLower(check[1]);
                               rep1 = CheckRepeatedPos(rep, check[1], protein, carbs, fat, calorie);
                               if (rep1 == -1)
                               {
                                   answer[i] = rep[1];
                               }
                               else
                               {
                                   answer[i] = rep1;
                               }
                           }
                            
                       }

                }
                if (len == 3)
                {
                    int ans1;
                    int[] rep = new int[50];
                    int rep1;

                    char[] check = dietPlans[i].ToCharArray();
                    ans1 = getIndex(check[0], protein, carbs, fat, calorie);

                    rep = CheckRepeated(ans1, check[0], protein, carbs, fat, calorie);

                    if (rep[0] == 1)
                    {
                        answer[i] = ans1;
                    }
                    else
                    {
                        bool U = Char.IsUpper(check[0]);
                        if (U == true)
                        {
                            check[1] = char.ToUpper(check[1]);
                            rep1 = CheckRepeatedPos(rep, check[1], protein, carbs, fat, calorie);
                            if (rep1 == -1)
                            {
                                int t;
                                check[2]=char.ToUpper(check[2]);
                                t=CheckRepeatedPos(rep, check[2], protein, carbs, fat, calorie);
                                if (t == -1)

                                {
                                    answer[i] = rep[1];
                                }
                                else
                                {
                                    answer[i] = t;
                                }
                            }
                            else
                            {
                                answer[i] = rep1;
                            }

                        }
                        else
                        {
                            check[1] = char.ToLower(check[1]);
                            rep1 = CheckRepeatedPos(rep, check[1], protein, carbs, fat, calorie);
                            if (rep1 == -1)
                            {
                                int t;
                                check[2] = char.ToLower(check[2]);
                                t = CheckRepeatedPos(rep, check[2], protein, carbs, fat, calorie);
                                if (t == -1)
                                {
                                    answer[i] = rep[1];
                                }
                                else
                                {
                                    answer[i] = t;
                                }
                            }
                            else
                            {
                                answer[i] = rep1;
                            }
                        }

                    }

                }
                if (len == 4)
                {
                    int ans1;
                    int[] rep = new int[50];
                    int rep1;

                    char[] check = dietPlans[i].ToCharArray();
                    ans1 = getIndex(check[0], protein, carbs, fat, calorie);

                    rep = CheckRepeated(ans1, check[0], protein, carbs, fat, calorie);

                    if (rep[0] == 1)
                    {
                        answer[i] = ans1;
                    }
                    else
                    {
                        bool U = Char.IsUpper(check[0]);
                        if (U == true)
                        {
                            check[1] = char.ToUpper(check[1]);
                            rep1 = CheckRepeatedPos(rep, check[1], protein, carbs, fat, calorie);
                            if (rep1 == -1)
                            {
                                int t;
                                check[2] = char.ToUpper(check[2]);
                                t = CheckRepeatedPos(rep, check[2], protein, carbs, fat, calorie);
                                if (t == -1)
                                {
                                    int l;
                                    check[3] = char.ToUpper(check[3]);
                                    l = CheckRepeatedPos(rep, check[3], protein, carbs, fat, calorie);
                                    if (l == -1)
                                    {
                                        answer[i] = rep[1];
                                    }
                                    else
                                    {
                                        answer[i] = l;
                                    }

                                }
                                else
                                {
                                    answer[i] = t;
                                }
                            }
                            else
                            {
                                answer[i] = rep1;
                            }

                        }
                        else
                        {
                            check[1] = char.ToLower(check[1]);
                            rep1 = CheckRepeatedPos(rep, check[1], protein, carbs, fat, calorie);
                            if (rep1 == -1)
                            {
                                int t;
                                check[2] = char.ToLower(check[2]);
                                t = CheckRepeatedPos(rep, check[2], protein, carbs, fat, calorie);
                                if (t == -1)
                                {
                                    int l;
                                    check[3] = char.ToLower(check[3]);
                                    l = CheckRepeatedPos(rep, check[3], protein, carbs, fat, calorie);
                                    if (l == -1)
                                    {
                                        answer[i] = rep[1];
                                    }
                                    else
                                    {
                                        answer[i] = l;
                                    }

                                }
                                else
                                {
                                    answer[i] = t;
                                }
                            }
                            else
                            {
                                answer[i] = rep1;
                            }
                        }

                    }


                }

            }

            return answer;
            throw new NotImplementedException();
        }

        public static int getIndex(char check, int[] protein, int[] carbs, int[] fat,int[] calorie)
        {

            int maxValue, minValue;
            int ans=0;
            switch (check)
            {
                case 'C':
                    maxValue = carbs.Max();
                    ans = carbs.ToList().IndexOf(maxValue);
                    break;

                case 'c':
                    minValue = carbs.Min();
                    ans = carbs.ToList().IndexOf(minValue);
                    break;

                case 'P':
                    maxValue = protein.Max();
                    ans = protein.ToList().IndexOf(maxValue);
                    break;

                case 'p':
                    minValue = protein.Min();
                    ans = protein.ToList().IndexOf(minValue);
                    break;

                case 'F':
                    maxValue = fat.Max();
                    ans = fat.ToList().IndexOf(maxValue);
                    break;

                case 'f':
                    minValue = fat.Min();
                    ans = fat.ToList().IndexOf(minValue);
                    break;

                case 'T':
                    maxValue = calorie.Max();
                    ans = calorie.ToList().IndexOf(maxValue);
                    break;

                case 't':
                    minValue = calorie.Min();
                    ans = calorie.ToList().IndexOf(minValue);
                    break;
            }
            return ans;  
        }


        public static int[] CheckRepeated(int index,char check, int[] protein, int[] carbs, int[] fat, int[] calorie)
        {
            int count=0,temp;
            int[] rep = new int[50];
            int z = 1;

            switch (check)
            {
                case 'C':    
                        temp=carbs[index];
                        for (int i = 0; i < carbs.Length; i++)
                        {
                            if (temp == carbs[i])
                            {
                                rep[z] = i;
                                z++;
                                count++;
                            }
                        }
                        rep[0] = count;
               break;

                case 'c':
                       temp=carbs[index];
                        for (int i = 0; i < carbs.Length; i++)
                        {
                            if (temp == carbs[i])
                            {
                                rep[z] = i;
                                count++;
                                z++;
                            }
                        }
                        rep[0] = count;

               break;

                case 'P':
                        temp=protein[index];
                        for (int i = 0; i < protein.Length; i++)
                        {
                            if (temp == protein[i])
                            {
                                rep[z] = i;
                                z++;
                                count++;
                            }
                        }
                        rep[0] = count;

                break;

                case 'p':
                        temp=protein[index];
                        for (int i = 0; i < protein.Length; i++)
                        {
                            if (temp == protein[i])
                            {
                                rep[z] = i;
                                z++;
                                count++;
                            }
                        }
                        rep[0] = count;

                break;

                case 'F':
                        temp=fat[index];
                        for (int i = 0; i < fat.Length; i++)
                        {
                            if (temp == fat[i])
                            {
                                rep[z] = i;
                                count++;
                                z++;
                            }
                        }
                        rep[0] = count;
                
                break;

                case 'f':
                        temp=fat[index];
                        for (int i = 0; i < fat.Length; i++)
                        {
                            if (temp == fat[i])
                            {
                                rep[z] = i;
                                z++;
                                count++;
                            }
                        }
                        rep[0] = count;
                

                break;

                case 'T':
                        temp=calorie[index];
                        for (int i = 0; i < calorie.Length; i++)
                        {
                            if (temp == calorie[i])
                            {
                                rep[z] = i;
                                z++;
                                count++;
                            }
                        }
                        rep[0] = count;
                break;

                case 't':
                        temp=calorie[index];
                        for (int i = 0; i < calorie.Length; i++)
                        {
                            if (temp == calorie[i])
                            {
                                rep[z] = i;
                                z++;
                                count++;
                            }
                        }
                        rep[0] = count;
                 
                break;
            }
            return rep;
        }



        public static int CheckRepeatedPos(int[] index, char check, int[] protein, int[] carbs, int[] fat, int[] calorie)
        {
            int count = 0, temp;
            
            switch (check)
            {
                case 'C':
                    temp = carbs[index[1]];
                    
                    for (int i = 0; i < index[0]; i++)
                    {
                        if (temp == carbs[index[i+1]])
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
                            if (temp< carbs[index[i + 1]])
                            {
                                temp = carbs[index[i + 1]];  
                            }
                        }
                        temp = carbs.ToList().IndexOf(temp);
                        return temp;
                    }
                   
                case 'c':
                             temp = carbs[index[1]];
                    
                            for (int i = 0; i < index[0]; i++)
                            {
                                if (temp == carbs[index[i+1]])
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
                                Console.WriteLine("ind " + index[0]);
                                for (int i = 0; i < index[0]; i++)
                                {
                                    
                                    if (temp> carbs[index[i + 1]])
                                    {
                                        temp = carbs[index[i + 1]]; 
 
                                    }
                                }
                                temp = carbs.ToList().IndexOf(temp);
                                return temp;
                            }

                case 'P':
                   
                     temp = protein[index[1]];
                    
                    for (int i = 0; i < index[0]; i++)
                    {
                        if (temp == protein[index[i+1]])
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
                            if (temp< protein[index[i + 1]])
                            {
                                temp = protein[index[i + 1]];  
                            }
                        }
                        temp = protein.ToList().IndexOf(temp);
                        return temp;
                    }

                case 'p':
                     temp = protein[index[1]];
                    
                    for (int i = 0; i < index[0]; i++)
                    {
                        if (temp == protein[index[i+1]])
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
                            if (temp> protein[index[i + 1]])
                            {
                                temp = protein[index[i + 1]];  
                            }
                        }
                        temp = protein.ToList().IndexOf(temp);
                        return temp;
                    }

                case 'F':
                   temp = fat[index[1]];
                    
                    for (int i = 0; i < index[0]; i++)
                    {
                        if (temp == fat[index[i+1]])
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
                            if (temp< fat[index[i + 1]])
                            {
                                temp = fat[index[i + 1]];  
                            }
                        }
                        temp = fat.ToList().IndexOf(temp);
                        return temp;
                    }

                case 'f':
                   temp = fat[index[1]];
                    for (int i = 0; i < index[0]; i++)
                    {
                        if (temp == fat[index[i+1]])
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
                            if (temp> fat[index[i + 1]])
                            {
                                temp = fat[index[i + 1]];  
                            }
                        }
                        temp = fat.ToList().IndexOf(temp);
                        return temp;
                    }

           
                case 'T':
                          temp = calorie[index[1]];
                    
                    for (int i = 0; i < index[0]; i++)
                    {
                        if (temp == calorie[index[i+1]])
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
                            if (temp< calorie[index[i + 1]])
                            {
                                temp = calorie[index[i + 1]];  
                            }
                        }
                        temp = calorie.ToList().IndexOf(temp);
                        return temp;
                    }

            

                case 't':
                         temp = calorie[index[1]];
                    
                    for (int i = 0; i < index[0]; i++)
                    {
                        if (temp == calorie[index[i+1]])
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
                            if (temp> calorie[index[i + 1]])
                            {
                                temp = calorie[index[i + 1]];  
                            }
                        }
                        temp = calorie.ToList().IndexOf(temp);
                        return temp;
                    }
                   
            }
            return -1;
        }

    }
}
