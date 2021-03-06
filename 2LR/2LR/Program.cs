﻿using System;
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
            Console.WriteLine("Выберите способ А(1) В(2)");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice==1)
            {
                Student[] list = Readfile(N);
                OutArray(N, list);
                Solution(N, list);
            }
            if(choice==2)
            {
                double[,] School = ReadFile2(N);
                Out(School);
                Solution2(School);
            }
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
                string[] words = line.Split(new char[] { ';' });
                for (int i = 0; i < words.Length; i++)
                {
                    if (i == 0) { list[counter].Name = words[i]; }
                    if (i == 1) { list[counter].SchoolNumber = int.Parse(words[i]); }
                    if (i == 2) { list[counter].Scores = int.Parse(words[i]); }
                }
                counter++;
            }
            return list;
        }
        static void OutArray(int n, Student[] list)
        {
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("Ученик {0} школы номер {1} набрал {2} балл(ов)", list[i].Name, list[i].SchoolNumber, list[i].Scores);
            }
        }
        static void Solution(int n, Student[] list)
        {
            int kolschool = 1;
            double max = 0;
            int res = 0;
            for(int i=0;i<n;i++)
            {
                if (i != (n-1))
                    if (list[i].SchoolNumber != list[i + 1].SchoolNumber)
                        kolschool++;
            }
            double[] MidlleScore = new double[kolschool];
            int[] kolstudent = new int[kolschool];
            for(int j = 0; j < MidlleScore.Length; j++)
            {
                for(int i = 0; i < n; i++)
                {
                    if(list[i].SchoolNumber==j+1)
                    {
                        kolstudent[j]++;
                        MidlleScore[j] += list[i].Scores;
                    }
                }
                MidlleScore[j]=MidlleScore[j]/kolstudent[j];
                if (MidlleScore[j] > max)
                    max = MidlleScore[j];
                Console.WriteLine("Школа №{0} имеет балл {1}", j+1, MidlleScore[j]);
            }
            for(int i=0;i<MidlleScore.Length;i++)
            {
                if (MidlleScore[i] == max)
                    res++;
            }
            OutResult(res,max,MidlleScore);
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
        static double[,] ReadFile2(int n)
        {
            int counter = 0;
            string path = @"C:\Users\User\source\repos\PI\2LR\StudentList.txt";
            using StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            double[,] mas = new double[100, 4];
            while ((line = sr.ReadLine()) != null)
            {
                if (counter == n) break;
                string[] words = line.Split(new char[] { ';' });
                for(int j=0;j<100;j++)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (i == 1)
                            if (j == int.Parse(words[i])-1)
                            {
                                mas[j,0] = int.Parse(words[i]);
                                mas[j, 2] += int.Parse(words[i+1]);
                                mas[j, 1]++;
                            }
                    }
                }
                for(int i=0;i<100;i++)
                {
                    mas[i, 3] = mas[i, 2] / mas[i, 1];
                }
                counter++;
            }
            return mas;
        }
        static void Solution2(double [,] mas)
        {
            double max = -1;
            for(int i=0;i<100;i++)
                if (mas[i, 3] > max)
                    max = mas[i, 3];
            for(int i=0;i<100;i++)
            {
                if (mas[i, 3] == max)
                    Console.WriteLine("Самый высокий средний балл ({0}) у школы {1}", mas[i,3], mas[i, 0]);
            }
        }
        static void Out(double [,] mas)
        {
            for (int i = 0; i < 100; i++)
            {
                if (mas[i, 0] == 0)
                    break;
                for (int j = 0; j < 4; j++)
                    Console.Write($"{mas[i, j]} \t");
                Console.WriteLine();
            }
        }
    }  
}
