// C# 
using System;
using System.Timers;
using System.Diagnostics;
using System.Threading;

int glb1 = 0;
long glb2 = 0;
int glb3 = 0;
void Rec1(int[] n, long l) // kaštai | kartai
{
    if (l < 10) { return; }//c1,c2 | 1, 1
    glb1++;

    Rec1(n, l / 10);//        T(n/10) | 1
    Rec1(n, l / 10);//        T(n/10) | 1
    Rec1(n, l / 10);//        T(n/10) | 1
    Rec1(n, l / 10);//        T(n/10) | 1 
    glb1 = glb1 + 4;

    glb1++;
    
}

void Rec2(int[] n, int l)
{
    if (l < 6) { return; }//c1,c2 | 1, 1
    glb2++;

    Rec2(n, l / 5);//        T(n/5) | 1
    Rec2(n, l / 6);//        T(n/6) | 1
    glb2 = glb2 + 2;

    glb2++;
    for (int i = 0; i < l; i++)//   c3 | 1
    {//                             c4,c5 | n + n
        for (int j = 0; j < l; j++)// c6 | 1    
        {//                         c7,c8 | n + n
            glb2++;
        }
    }
}
void Rec3(int[] n, int l) // kaštai | kartai
{
    if (l < 9) { return; }// c1,c2  | 1,1
    glb3++;

    Rec3(n, l - 9);//       T(n-9)
    Rec3(n, l - 2);//       T(n-2)
    glb3 = glb3 + 2;        // c7 | 1

    for (int i = 0; i < l; i++)// c3,c4,c5   | 1, n, n
        glb3++;//                 c6         | n
}


// Driver code
void Main()
{


    Stopwatch stopwatch = Stopwatch.StartNew();
    // Start the timer
    long ArraySize1 = 1000000000000000;
    //Rec1(new int[100000000], ArraySize1);
    stopwatch.Stop();
    Console.WriteLine("Array size {0}", ArraySize1);
    Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
    Console.WriteLine(glb1);
    

    stopwatch.Restart();
    int ArraySize2 = 50000;
    //Rec2(new int[100000], ArraySize2);
    stopwatch.Stop();
    Console.WriteLine("Array size {0}", ArraySize2 );
    Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
    Console.WriteLine(glb2);
    
    stopwatch.Restart();
     Rec3(new int[1000000], 150);
    stopwatch.Stop();
    Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
    Console.WriteLine(glb3);
}

Main();


