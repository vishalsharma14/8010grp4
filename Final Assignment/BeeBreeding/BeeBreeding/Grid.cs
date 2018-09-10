/** BeeBreeding - FinalAssignment - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeBreeding
{
    class Hex
    {
        public int x;
        public int y;
        public int z;

        public Hex(int a, int b, int c)
        {
            x = a;
            y = b;
            z = c;
        }
    }

    class Grid
    {

        private readonly Hex[] CUBE_DIRECTIONS = new Hex[] {
            new Hex(1, -1, 0),
            new Hex(1, 0, -1),
            new Hex(0, 1, -1),
            new Hex(-1, 1, 0),
            new Hex(-1, 0, 1),
            new Hex(0, -1, 1)
        };

        private List<Hex> Results = new List<Hex>();

        public Hex HexAdd(Hex a, Hex b)
        {
            return new Hex(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public Hex HexScale(Hex a, int k)
        {
            return new Hex(a.x * k, a.y * k, a.z * k);
        }

        public Hex HexNeighbour(Hex a, int direction)
        {
            return HexAdd(a, CUBE_DIRECTIONS[direction]);
        }

        // Reference: https://www.redblobgames.com/grids/hexagons/#rings
        public List<Hex> HexRing(Hex center, int radius)
        {
            List<Hex> results = new List<Hex>();
            Hex cube = HexAdd(center, HexScale(CUBE_DIRECTIONS[4], radius));
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < radius; j++)
                {
                    results.Add(cube);
                    cube = HexNeighbour(cube, i);
                }
            }
            return results;
        }

        public int FindHex(List<Hex> hexList, Hex cube)
        {
            for (int i = 0; i < hexList.Count; i++)
            {
                if (hexList[i].x == cube.x && hexList[i].y == cube.y && hexList[i].z == cube.z)
                {
                    return i;
                }
            }
            return -1;
        }

        public List<Hex> GetRing(Hex center, int radius, Hex lastHex)
        {
            List<Hex> ring = HexRing(center, radius);
            Hex firstHex = new Hex(lastHex.x - 1, lastHex.y, lastHex.z + 1);
            int index = FindHex(ring, firstHex);
            if (index == -1)
            {
                return ring;
            }
            List<Hex> tempRing = new List<Hex>();
            for (int j = index; j < ring.Count; j++)
            {
                tempRing.Add(ring[j]);
            }

            for (int k = 0; k < index; k++)
            {
                tempRing.Add(ring[k]);
            }
            return tempRing;

        }

        // Reference: https://www.redblobgames.com/grids/hexagons/#rings-spiral
        public List<Hex> CubeSpiral(Hex center, int radius)
        {
            List<Hex> results = new List<Hex>();
            results.Add(center);
            Hex lastHex = new Hex(0, 0, 0);
            for (int k = 1; k <= radius; k++)
            {
                List<Hex> ring = GetRing(center, k, lastHex);
                lastHex = ring[ring.Count - 1];
                results.AddRange(ring);
            }
            return results;
        }

        // Reference: https://www.reddit.com/r/math/comments/2b52up/what_is_the_equation_for_the_number_of_hexagons/
        private int FindRadius(int number)
        {
            double count = 0;
            double i=1;
            while(true)
            {
                count = (3 * Math.Pow(i, 2) - 3 * i + 1); // 3n*n - 3n + 1  -> No. of hexagons in a grid with radius n
                i++;
                if (count > number)
                    return Convert.ToInt32(i);
            }
        }

        // Populates Grid List based on the maximum input number
        private List<Hex> GetGridList(int maxNum)
        {
            if(Results.Count < maxNum)
            {
                int radius = FindRadius((maxNum));
                Results = CubeSpiral(new Hex(0, 0, 0), radius);
            }
            return Results;
            
        }

        // Reference: https://www.redblobgames.com/grids/hexagons/#line-drawing
        public int FindDistance(int firstNum, int secondNum)
        {
            int maxNum = new int[] { firstNum, secondNum }.Max();
            List<Hex> results = GetGridList(maxNum);
            Hex firstHex = results[firstNum - 1];
            Hex secondHex = results[secondNum - 1];
            int distance =  new int[] {Math.Abs(firstHex.x - secondHex.x),
               Math.Abs(firstHex.y - secondHex.y),
               Math.Abs(firstHex.z - secondHex.z) }.Max();
            return distance;
        }

    }
}
