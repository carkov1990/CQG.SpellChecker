using System;
using System.Linq;
using System.Text;
using CQG.SpellChecker.Models;

namespace CQG.SpellChecker.Utils
{
    /// <summary>
    /// Класс утилиты для получения редакционного расстояния по алгоритму Левенштейна
    /// </summary>
    public class LevenshteinDistance
    {
        /// <summary>
        /// Метод вычисления редакционного предписания.
        /// Реализация алгоритма взята с https://ru.wikibooks.org/wiki/%D0%A0%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D0%B8_%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2/%D0%A0%D0%B5%D0%B4%D0%B0%D0%BA%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D0%BE%D0%B5_%D0%BF%D1%80%D0%B5%D0%B4%D0%BF%D0%B8%D1%81%D0%B0%D0%BD%D0%B8%D0%B5
        /// Цена операции замены повышена на 2, так как замена это 2 действия - удаления и вставка. 
        /// </summary>
        /// <param name="S1">Слово 1.</param>
        /// <param name="S2">Слово 2.</param>
        public static Prescription Calculate(String S1, String S2) {
            int m = S1.Length, n = S2.Length;
            int[,] D = new int[m + 1,n + 1];
            char[,] P = new char[m + 1,n + 1];

            // Базовые значения
            for (int p = 0; p <= m; p++) {
                D[p,0] = p;
                P[p,0] = 'D';
            }
            for (int o = 0; o <= n; o++) {
                D[0,o] = o;
                P[0,o] = 'I';
            }

            for (int i = 1; i <= m; i++)
            for (int j = 1; j <= n; j++) {
                int cost = (S1[i - 1] != S2[j - 1]) ? 2 : 0;
                if(D[i,j - 1] < D[i - 1,j] && D[i,j - 1] < D[i - 1,j - 1] + cost) {
                    //Вставка
                    D[i,j] = D[i,j - 1] + 1;
                    P[i,j] = 'I';
                }
                else if(D[i - 1,j] < D[i - 1,j - 1] + cost) {
                    //Удаление
                    D[i,j] = D[i - 1,j] + 1;
                    P[i,j] = 'D';
                }
                else {
                    //Замена или отсутствие операции
                    D[i,j] = D[i - 1,j - 1] + cost;
                    P[i,j] = (cost == 2) ? 'R' : 'M';
                }
            }

            //Восстановление предписания
            StringBuilder route = new StringBuilder("");
            int l = m, t = n;
            do {
                char c = P[l,t];
                route.Append(c);
                if(c == 'R' || c == 'M') {
                    l --;
                    t --;
                }
                else if(c == 'D') {
                    l --;
                }
                else {
                    t --;
                }
            } while((l != 0) || (t != 0));
            return new Prescription(D[m,n], new string(route.ToString().Reverse().ToArray()));
        }
    }
}