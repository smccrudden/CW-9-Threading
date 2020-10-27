/* Author:Seth McCrudden
* Last date modified: 74-Oct-2020
* File name: FindPiThread.cs
* Description: Contains dart functions.
*/

using System;

namespace Project
{
    class FindPiThread
    {
        private int numOfDarts;
        public int dartsInCircle { get; private set;}
        private Random rnd;

        public FindPiThread(int totalDarts)
        {
            numOfDarts = totalDarts;
            dartsInCircle = 0;
            rnd = new Random();
        }

        public void throwDarts()
        {
            for (int i = 0; i < numOfDarts; i++)
            {
                double x = rnd.NextDouble();
                double y = rnd.NextDouble();

                if ((x * x) + (y * y) <= 1)
                {
                    dartsInCircle++;
                }
            }
        }
    }
}
