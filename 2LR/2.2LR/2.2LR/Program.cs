using System;
using System.IO;
using System.Threading.Tasks;

namespace _2LR
{
    class Program
    {
        struct Student
        {
            public string Name;
            public int SchoolNumber;
            public int Scores;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк для считывания");
            int N = Convert.ToInt32(Console.ReadLine());
            Student[] list = Readfile(N);
            //ReadFile2(N);
            OutArray(N, list);
            Solution(N, list);

        }
        static Student[] Readfile(int n)
        {
            Student[] list = new Student[n];
            int counter = 0;
            string path = @"C:\Users\User\source\repos\PI\2LR\StudentList.txt";
            using StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (counter == n) break;
                //Console.WriteLine(line);
                string[] words = line.Split(new char[] { ';' });
                for (int i = 0; i < words.Length; i++)
                {
                    if (i == 0) { list[counter].Name = words[i]; }
                    if (i == 1) { list[counter].SchoolNumber = int.Parse(words[i]); }
                    if (i == 2) { list[counter].Scores = int.Parse(words[i]); }
                }
                //Console.WriteLine(list[counter].Name);
                //Console.WriteLine(list[counter].SchoolNumber);
                //Console.WriteLine(list[counter].Scores);
                counter++;
            }
            return list;
        }
        static void OutArray(int n, Student[] list)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Ученик {0} школы номер {1} набрал {2} балл(ов)", list[i].Name, list[i].SchoolNumber, list[i].Scores);
            }
        }
        static void Solution(int n, Student[] list)
        {
            int kolschool = 1;
            double max = 0;
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                if (i != (n - 1))
                {
                    if (list[i].SchoolNumber != list[i + 1].SchoolNumber)
                        kolschool++;
                }
            }
            //Console.WriteLine(kolschool);
            double[] MidlleScore = new double[kolschool];
            int[] kolstudent = new int[kolschool];
            for (int j = 0; j < MidlleScore.Length; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (list[i].SchoolNumber == j + 1)
                    {
                        kolstudent[j]++;
                        MidlleScore[j] += list[i].Scores;
                    }
                }
                MidlleScore[j] = MidlleScore[j] / kolstudent[j];
                if (MidlleScore[j] > max)
                    max = MidlleScore[j];
                Console.WriteLine("Школа №{0} имеет средний балл {1}", j + 1, MidlleScore[j]);
            }
            for (int i = 0; i < MidlleScore.Length; i++)
            {
                if (MidlleScore[i] == max)
                    res++;
            }
            OutResult(res, max, MidlleScore);
            //Console.WriteLine(max);
        }
        static void OutResult(int res, double max, double[] MidlleScore)
        {
            if (res == 1)
            {
                for (int i = 0; i < MidlleScore.Length; i++)
                {
                    if (MidlleScore[i] == max)
                    {
                        Console.WriteLine("Самый высокий балл = {0} у школы №{1}", max, i + 1);
                        break;
                    }
                }
            }
            else
                for (int i = 0; i < MidlleScore.Length; i++)
                {
                    if (MidlleScore[i] == max)
                        Console.WriteLine("Самый высокий балл = {0} у школы №{1}", max, i + 1);
                }
        }
        /*static void ReadFile2(int n)
        {
            int count = 0;
            string path = @"C:\Users\User\source\repos\PI\2LR\StudentList.txt";
            int[,] School = new int[100,2];
            int[] Scores = new int[100];
            using StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (count == n) break;
                //Console.WriteLine(line);
                string[] words = line.Split(new char[] { ';' });
                /*for (int i = 0; i < words.Length; i++)
                {
                    if (i == 0) { list[counter].Name = words[i]; }
                    if (i == 1) { list[counter].SchoolNumber = int.Parse(words[i]); }
                    if (i == 2) { list[counter].Scores = int.Parse(words[i]); }
                    for(int j=0;j<School.Length;j++)
                        for(int c=0;c<School.Length;c++)
                        {
                            if(i==1&int.Parse(words[i])==j+1)
                            {
                                School[j,0] = int.Parse(words[i]);
                                School[j, 1] += int.Parse(words[i]);
                            }
                        }
                }
                for(int c=0;c<words.Length;c++)
                        for(int i=0;i<100;i++)
                        {
                            if (c == 1)
                                if(int.Parse(words[c]) == i + 1)
                                    School[i, 0] = int.Parse(words[c]);
                            if (c == 2)
                                School[i, 1] += int.Parse(words[c]);
                        }
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 2; j++)
                        Console.Write($"{School[i, j]} \t");
                    Console.WriteLine();
                }
                    
                        
                count++;
            }
        }*/

    }

}
