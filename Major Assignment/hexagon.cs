using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
    Grid grid = new Grid();
    List<Hex> hexList = grid.CubeSpiral(new Hex(0, 0, 0), 5);
    for(int i=0; i<hexList.Count; i++) 
    {
      Console.WriteLine (hexList[i].y);
      Console.WriteLine (hexList[i].x);
      Console.WriteLine (hexList[i].z);
      Console.WriteLine (hexList.Count);
    }
    Console.WriteLine (hexList[29].x-hexList[18].x);
    Console.WriteLine (hexList[29].y-hexList[18].y);
    Console.WriteLine (hexList[29].z-hexList[18].z);
  }
}


class Hex {
  public int x;
  public int y;
  public int z;

  public Hex(int a, int b, int c) {
    x = a;
    y = b;
    z = c;
  }
}

class Grid {

  private readonly Hex[] CUBE_DIRECTIONS = new Hex[] {
    new Hex(1, -1, 0),
    new Hex(1, 0, -1),
    new Hex(0, 1, -1),
    new Hex(-1, 1, 0),
    new Hex(-1, 0, 1),
    new Hex(0, -1, 1)
  };
  
  public Hex HexAdd(Hex a, Hex b) {
    return new Hex(a.x + b.x, a.y + b.y, a.z + b.z);
  }

  public Hex HexScale(Hex a, int k) {
    return new Hex(a.x * k, a.y * k, a.z * k);
  }

  public Hex HexNeighbour(Hex a, int direction) {
    return HexAdd(a, CUBE_DIRECTIONS[direction]);
  }

  public List<Hex> HexRing(Hex center, int radius) {
    List<Hex> results = new List<Hex>();
    Hex cube = HexAdd(center, HexScale(CUBE_DIRECTIONS[4], radius));
    for(int i=0; i<6; i++) {
      for(int j=0; j<radius; j++) {
        results.Add(cube);
        cube = HexNeighbour(cube, i);
      }
    }
    return results;
  }

  public int FindHex(List<Hex> hexList, Hex cube) 
  {
    for(int i=0; i<hexList.Count; i++) 
    {
      if(hexList[i].x == cube.x && hexList[i].y == cube.y && hexList[i].z == cube.z)
      {
        return i;
      }
    }
    return -1;
  }

  public List<Hex> GetRing(Hex center, int radius, Hex lastHex)
  {
    List<Hex> ring = HexRing(center, radius);
    Console.WriteLine ("HEREEE");
    Hex firstHex = new Hex(lastHex.x - 1, lastHex.y, lastHex.z + 1);
    int index = FindHex(ring, firstHex);
    Console.WriteLine ("INDEX");
    Console.WriteLine (index);
    if(index == -1) 
    {
      return ring;
    }
    List<Hex> tempRing = new List<Hex>();
    for(int j=index; j<ring.Count; j++) 
    {
      tempRing.Add(ring[j]);
    }

    for(int k=0; k<index; k++) 
    {
      tempRing.Add(ring[k]);
    }
    return tempRing;

  }

  public List<Hex> CubeSpiral(Hex center, int radius) 
  {
    List<Hex> results = new List<Hex>();
    results.Add(center);
    Hex lastHex = new Hex(0, 0, 0);
    for(int k=1; k<=radius; k++)
    {
      List<Hex> ring = GetRing(center, k, lastHex);
      Console.WriteLine (ring.Count);
      lastHex = ring[ring.Count - 1];
      Console.WriteLine (lastHex.y);
      Console.WriteLine (lastHex.x);
      Console.WriteLine (lastHex.z);
      Console.WriteLine (" LAST HEXXX");
      results.AddRange(ring);
    }
    return results;
  }

}