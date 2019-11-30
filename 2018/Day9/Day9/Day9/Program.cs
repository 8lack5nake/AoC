using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class NineNode
    {
        public NineNode(long value, NineNode ccw, NineNode cw)
        {
            Value = value;
            CCW = ccw ?? this;
            CW = cw ?? this;

            CW.CCW = this;
            CCW.CW = this;
        }
        public long Value { get; set; }
        public NineNode CW { get; set; }
        public NineNode CCW { get; set; }
    }

    class MarbleGame
    {
        static void Main(string[] args)
        {
            MarbleGame game = new MarbleGame();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");
            foreach (string line in lines)
            {
                double ergebnis = game.getBetterHighscore(line);
                Console.WriteLine("{0}: high score is {1}", line, ergebnis);
            }
            
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public double getHighscore(string info)
        {
            double result = 0;
            string[] infos = info.Split(' ');
            
            int players = int.Parse(infos[0]);
            int[] playerCount = new int[players + 1];
            int lastMarbleWorth = int.Parse(infos[6]);    //Part 2 = 3527845091
            long longLastMarble = lastMarbleWorth;

            //PartOne(players, longLastMarble);

            List<List<int>> playGround = new  List<List<int>>();
            int actualPlayer = 0;
            int actualMarble = 0;
            int actualPosition = 0;
            int lastPlayer = 0;
            //Initialbefüllung, damit wir mit der Spieleranzahl hochzählen können.

            for (int i = 0; i < players + 1; i++)
            {   
                List<int> sammlung = new List<int>();
                playGround.Add(sammlung);
            }

            playGround[actualPlayer].Add(actualMarble);
            lastPlayer = actualPlayer;
            actualPosition++;
            actualPlayer++;
            actualMarble++;

            while (actualMarble <= lastMarbleWorth)
            {
                bool added = false;
                //Setzen der Murmeln der Vorgänger
                playGround[actualPlayer] = new List<int>(playGround[lastPlayer]);

                playGround[actualPlayer].Insert(actualPosition, actualMarble);

                //for (int i = 0; i <= playGround[lastPlayer].Count(); i++)
                //{
                //    if (i == actualPosition)
                //    {
                //        playGround[actualPlayer].Add(actualMarble);
                //        added = true;
                //    }
                //    else
                //    {
                //        if (added == true)
                //        {
                //            playGround[actualPlayer].Add(playGround[lastPlayer][i - 1]);
                //        }
                //        else
                //        {
                //            playGround[actualPlayer].Add(playGround[lastPlayer][i]);
                //        }
                //    }

                //}



                actualMarble++;

                if (actualMarble % 23 == 0)
                {
                    int valueToRemove = 0;
                    int countingPlayer = 0;
                    int removePosition = 0;

                    if (actualPlayer == players)
                    {
                        countingPlayer = 1;
                    }
                    else
                    {
                        countingPlayer = actualPlayer + 1;
                    }

                    playerCount[countingPlayer] += actualMarble;

                    if (actualPosition - 7 < 0 )
                    {
                        removePosition = playGround[actualPlayer].Count() - (Math.Abs(actualPosition - 7));
                        valueToRemove = playGround[actualPlayer][removePosition];
                        actualPosition = removePosition;
                    }
                    else
                    {
                        removePosition = actualPosition - 7;
                        valueToRemove = playGround[actualPlayer][removePosition];
                        actualPosition = actualPosition - 7;
                    }


                        playerCount[countingPlayer] += valueToRemove;
                    

                    //Copy to next element
                        playGround[countingPlayer] = new List<int>(playGround[actualPlayer]);
                        playGround[countingPlayer].RemoveAt(removePosition);

                    //for (int i = 0; i < playGround[actualPlayer].Count(); i++)
                    //{
                    //    if (playGround[actualPlayer][i] == valueToRemove)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        playGround[countingPlayer].Add(playGround[actualPlayer][i]);
                    //    }

                    //}

                    actualPlayer = countingPlayer;
                    actualMarble++;
                }

                if ( actualPosition+2 > playGround[actualPlayer].Count())
                {
                    actualPosition = 1;
                }
                else
                {
                    actualPosition += 2;
                }

                if (actualPlayer == 1)
                {
                    playGround[lastPlayer].Clear();
                }

                lastPlayer = actualPlayer;
                if (actualPlayer == players)
                {
                    actualPlayer = 1;
                    for (int i = 0; i < players ; i++)
                    {
                        playGround[i].Clear();
                    }
                    
                }
                else
                {
                    actualPlayer++;
                }

               
            }

            for (int i = 0; i < playerCount.Length; i++ )
            {
                if  (playerCount[i] > result)
                {
                    result = playerCount[i];
                }
            }

                return result;
        }
        public double getBetterHighscore(string info)
        {
            double result = 0;
            string[] infos = info.Split(' ');

            int players = int.Parse(infos[0]);
            int[] playerCount = new int[players + 1];
            int lastMarbleWorth = int.Parse(infos[6]) * 100;    //Part 2 = 3527845091
            long longLastMarble = lastMarbleWorth;

            //PartOne(players, longLastMarble);

            List<int> playGround = new List<int>();
            int actualPlayer = 0;
            int actualMarble = 0;
            int actualPosition = 0;
            int lastPlayer = 0;
            //Initialbefüllung, damit wir mit der Spieleranzahl hochzählen können.

            //for (int i = 0; i < players + 1; i++)
            //{
            //    List<int> sammlung = new List<int>();
            //    playGround.Add(sammlung);
            //}

            playGround.Add(actualMarble);
            lastPlayer = actualPlayer;
            actualPosition++;
            actualPlayer++;
            actualMarble++;

            while (actualMarble <= lastMarbleWorth)
            {
                bool added = false;
                //Setzen der Murmeln der Vorgänger
                //playGround[actualPlayer] = new List<int>(playGround[lastPlayer]);

                playGround.Insert(actualPosition, actualMarble);

                //for (int i = 0; i <= playGround[lastPlayer].Count(); i++)
                //{
                //    if (i == actualPosition)
                //    {
                //        playGround[actualPlayer].Add(actualMarble);
                //        added = true;
                //    }
                //    else
                //    {
                //        if (added == true)
                //        {
                //            playGround[actualPlayer].Add(playGround[lastPlayer][i - 1]);
                //        }
                //        else
                //        {
                //            playGround[actualPlayer].Add(playGround[lastPlayer][i]);
                //        }
                //    }

                //}



                actualMarble++;

                if (actualMarble % 23 == 0)
                {
                    int valueToRemove = 0;
                    int countingPlayer = 0;
                    int removePosition = 0;

                    if (actualPlayer == players)
                    {
                        countingPlayer = 1;
                    }
                    else
                    {
                        countingPlayer = actualPlayer + 1;
                    }

                    playerCount[countingPlayer] += actualMarble;

                    if (actualPosition - 7 < 0)
                    {
                        removePosition = playGround.Count() - (Math.Abs(actualPosition - 7));
                        valueToRemove = playGround[removePosition];
                        actualPosition = removePosition;
                    }
                    else
                    {
                        removePosition = actualPosition - 7;
                        valueToRemove = playGround[removePosition];
                        actualPosition = actualPosition - 7;
                    }


                    playerCount[countingPlayer] += valueToRemove;


                    //Copy to next element
                    playGround.RemoveAt(removePosition);

                    //for (int i = 0; i < playGround[actualPlayer].Count(); i++)
                    //{
                    //    if (playGround[actualPlayer][i] == valueToRemove)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        playGround[countingPlayer].Add(playGround[actualPlayer][i]);
                    //    }

                    //}

                    actualPlayer = countingPlayer;
                    actualMarble++;
                }

                if (actualPosition + 2 > playGround.Count())
                {
                    actualPosition = 1;
                }
                else
                {
                    actualPosition += 2;
                }

                //if (actualPlayer == 1)
                //{
                //    playGround[lastPlayer].Clear();
                //}

                lastPlayer = actualPlayer;
                if (actualPlayer == players)
                {
                    actualPlayer = 1;
                    //for (int i = 0; i < players; i++)
                    //{
                    //    playGround[i].Clear();
                    //}

                }
                else
                {
                    actualPlayer++;
                }


            }

            for (int i = 0; i < playerCount.Length; i++)
            {
                if (playerCount[i] > result)
                {
                    result = playerCount[i];
                }
            }

            return result;
        }

        public void PartOne(int elfCount, long marbleMaxIdx)
        {
            var solution = String.Empty;
            NineNode iter = new NineNode(0, null, null);
            List<long> players = Enumerable.Range(0, elfCount).Select(x => (long)0).ToList();
            var playerIdx = 0;
            //16458525
            for (var i = 1; i <= marbleMaxIdx; i++)
            {
                if ((i % 23) == 0)
                {
                    for (var j = 0; j < 7; j++)
                    {
                        iter = iter.CCW;
                    }

                    var toRemove = iter;
                    iter = toRemove.CW;

                    iter.CCW = toRemove.CCW;
                    toRemove.CCW.CW = iter;

                    players[playerIdx] += toRemove.Value + i;
                }
                else
                {
                    var one = iter.CW;
                    var two = one.CW;

                    iter = new NineNode(i, one, two);
                }
                playerIdx += 1;
                if (playerIdx == elfCount)
                    playerIdx = 0;
            }
            solution = players.Max().ToString();
            //System.Windows.Forms.Clipboard.SetText(solution.ToString());
            Console.WriteLine("Day Nine: " + solution);
        }
    }
}
