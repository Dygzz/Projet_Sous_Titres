﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LecteurVideo
{
    class Posting 
    {
        public string chemin;
        public List<Subtitle> sub;
        public Posting(TextBlock T, string Chemin)
        {
            chemin = Chemin;
            sub = StockSubtitle();
            Task t = Affichage(sub, T);
        }

        public List<Subtitle> StockSubtitle()
        {
            List<Subtitle> subi = new List<Subtitle>();
            string[] time = new string[2];
            string[] sepatator = new string[] { "-->" };
            string sub = "";
            using (StreamReader Ligne = new StreamReader(chemin))
            {
                Regex test = new Regex("-->");
                Regex test2 = new Regex("^[0-9]{1,}$");
                string ligne;
                while ((ligne = Ligne.ReadLine()) != null)
                {
                    if (test2.Match(ligne).Success)
                    {
                    }

                    else if (test.Match(ligne).Success)
                    {
                        time = ligne.Split(sepatator, 2, StringSplitOptions.None);
                    }
                    else
                    {
                        if (ligne.Length != 0)
                            sub += ligne + "\n";
                        else
                        {
                            subi.Add(new Subtitle(sub, (int)TimeSpan.Parse(time[0]).TotalMilliseconds , (int)TimeSpan.Parse(time[1]).TotalMilliseconds));
                            sub = "";
                        }

                    }
                }
            }
            return subi;
        }

        public async Task Affichage(List<Subtitle> subti, TextBlock T)
        {
            await Task.Delay(subti[0].timeStart);
            T.Text = subti[0].subt;
            await Task.Delay(subti[0].timeEnd - subti[0].timeStart);
            T.Text = "";
            for (int i = 1; i < sub.Count; i++)
            {
                await Task.Delay(subti[i].timeStart - subti[i - 1].timeEnd);
                T.Text = subti[i].subt;
                await Task.Delay(subti[i].timeEnd - subti[i].timeStart);
                T.Text = "";
            }
        }
    }
}