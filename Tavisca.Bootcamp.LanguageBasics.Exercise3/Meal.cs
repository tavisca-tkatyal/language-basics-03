using System;
using System.Linq;

using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class GetMeal
    {
         public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] indexesOfSelectedItem = new int[dietPlans.Length];
            int[] calories = new int[fat.Length];
            for(int i = 0;i < fat.Length;i++)
            {
                calories[i] = 5 * protein[i] + 5 * carbs[i] + 9 * fat[i]; 
            } 
            for(int i = 0;i < dietPlans.Length ;i++)
            {
                String dietPlanOfIndividual = dietPlans[i];
                if(dietPlanOfIndividual.Length == 0)
                {
                    continue;
                }
                List<int> FinalList = new List<int>();
                List<int> TempList = new List<int>();
                for(int j=0; j < dietPlanOfIndividual.Length;j++)
                {
                     if(dietPlanOfIndividual[j] == 'P')
                    {
                         TempList = getMax(FinalList,protein);
                    }
                     else if(dietPlanOfIndividual[j] == 'p')
                    {
                        TempList = getMin(FinalList,protein);
                    }
                    else if(dietPlanOfIndividual[j] == 'C')
                    {
                        TempList = getMax(FinalList,carbs);
                    }
                    else if(dietPlanOfIndividual[j] == 'c')
                    {
                        TempList = getMin(FinalList,carbs);
                    }
                    else if(dietPlanOfIndividual[j] == 'F')
                    {
                        TempList = getMax(FinalList,fat);
                    }
                    else if(dietPlanOfIndividual[j] == 'f')
                    {
                       TempList = getMin(FinalList,fat);
                    }
                    else if(dietPlanOfIndividual[j] == 'T')
                    {
                        TempList = getMax(FinalList,calories);
                    }
                    else if(dietPlanOfIndividual[j] == 't')
                    {
                        TempList = getMin(FinalList,calories);
                    }
                    if(FinalList.Count == 0)
                    {
                        FinalList=TempList;
                    }
                    else if(FinalList.Count != 0)
                    {
                        FinalList = FinalList.Intersect(TempList).ToList();
                    }
                }
                int minimum=Int32.MaxValue;
                foreach(var x in FinalList)
                {
                    minimum=Math.Min(minimum,x);
                }
                indexesOfSelectedItem[i]=minimum;
            }
            return indexesOfSelectedItem;
            throw new NotImplementedException();
        }
        public static List<int> getMax(List <int> FinalList,int[] gramsPresentInMenuItem)
        {
            int maximum=Int32.MinValue;
            int index=0;
            List<int> TempList=new List<int>();
            for(int i=0;i<gramsPresentInMenuItem.Length;i++)
            {
               if(gramsPresentInMenuItem[i]>maximum)
               {
                   if(FinalList.Count == 0)
                    {
                        maximum = gramsPresentInMenuItem[i];
                        index = i;
                    }
                   else{
                       if(FinalList.Contains(i)==true)
                       {
                           maximum=gramsPresentInMenuItem[i];
                        index=i;
                       }
                   }
               }  
            }
            TempList.Add(index);
            for(int i=0;i<gramsPresentInMenuItem.Length;i++)
            {
                if(maximum==gramsPresentInMenuItem[i] && i!=index)
                {
                    if(FinalList.Count==0)
                    {
                        TempList.Add(i);
                    }
                   else{
                       if(FinalList.Contains(i)==true)
                       {
                           TempList.Add(i);
                       }

                   }
                }
            }
            return TempList;
        }
        public static List<int> getMin(List<int> FinalList,int[] gramsPresentInMenuItem)
            {
                int minimum=Int32.MaxValue;
            int index=0;
            List<int> TempList=new List<int>();
            for(int i=0;i<gramsPresentInMenuItem.Length;i++)
            {
               if(gramsPresentInMenuItem[i]<minimum)
               {
                   if(FinalList.Count==0)
                    {
                        minimum=gramsPresentInMenuItem[i];
                        index=i;
                    }
                   else{
                       if(FinalList.Contains(i)==true)
                       {
                           minimum=gramsPresentInMenuItem[i];
                           index=i;
                       }

                   }
               }
            }
            TempList.Add(index);
            for(int i=0;i<gramsPresentInMenuItem.Length;i++)
            {
                if(minimum==gramsPresentInMenuItem[i] && i!=index)
                {
                    if(FinalList.Count==0)
                    {
                        TempList.Add(i);
                    }
                   else{
                       if(FinalList.Contains(i)==true)
                       {
                           TempList.Add(i);
                       }

                   }
                }
            }
            return TempList;
        }
    }  
}
