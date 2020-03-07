using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.XPath;
using Akavache.Sqlite3.Internal;
using PropertyChanged;

namespace OnlineStep.Services
{
    public static class Gamification
    {
        public static int xp = 0;
        public static int userLevel = 1;

        // Logic for 1 chapter
        public static int maxScore;
        public static int highestScore = 0;
        public static double highestScoreProcentage;
        public static int currentChapterScore;

        //Private variables
        private static double _minUnlockScore = 0.5; 


        public static int Xp
        {
            get => xp;
            set
            {
                xp += value;
                Debug.WriteLine("New XP: "+xp);
            }
        }

        public static int UserLevel
        {
            get => userLevel;
            set
            {
                userLevel += value;
                Debug.WriteLine("New unlockedLevels: " + userLevel);
            }
        }

        public static void AddPageResult (bool rightAnswer)
        {
            if (rightAnswer)
            {
                currentChapterScore += 1;
            }
            Debug.WriteLine("CurrentChapterScore: " + currentChapterScore);
        }

        public static void AddChapterResult()
        {
            Debug.WriteLine("currentChapterScore: " + currentChapterScore);
            Debug.WriteLine("highestScore: " + highestScore);
            if (currentChapterScore > highestScore)
            {
                
                double scoreInProcent = Math.Round(1.0 /maxScore * currentChapterScore,2);
                Debug.WriteLine("scoreInProcent: " + scoreInProcent);
                if (scoreInProcent > _minUnlockScore)
                {
                    Debug.WriteLine("Chapter Unlocked");
                    if (scoreInProcent > highestScoreProcentage)
                    {
                        Debug.WriteLine("Old highscore for chapter: " + highestScoreProcentage);
                        Debug.WriteLine("New highscore for chapter: " + scoreInProcent);
                        highestScoreProcentage = scoreInProcent;
                    }
                }
            }
        }

    }
}
