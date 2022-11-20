using System;
using System.Collections.Generic;

var length = 8;
var table = new string[length, length];
var ans = 1;
Init();
Available(0);

//初始化棋桌
void Init()
{
    for (var x = 0; x < length; x++)
    {
        for (var y = 0; y < length; y++)
        {
            table[x, y] = ".";
        }
    }
}

void Available(int row)
{
    //尋找可放置的位置
    var list = new List<int>();
    for (var y = 0; y < length; y++)
    {
        if (Check(row, y))
        {
            list.Add(y);
        }
    }

    if (row != length - 1) //若不是最後一層
    {
        foreach (var y in list)
        {
            table[row, y] = "Q";
            Available(row + 1);
            table[row, y] = ".";
        }
    }
    else if (row == length - 1 && list.Count > 0) //若為最後一層，且有可放置的位置
    {
        table[row, list[0]] = "Q";
        Print();
        table[row, list[0]] = ".";
    }
}

bool Check(int posX, int posY)
{
    var check = true;

    //檢查上下
    for (var x = 0; x < length; x++)
    {
        if (table[x, posY] != ".")
            check = false;
    }

    var num = 1;

    //檢查右下
    while (posX + num < length && posY + num < length)
    {
        if (table[posX + num, posY + num] != ".")
            check = false;
        num++;
    }

    //檢查左下
    num = 1;
    while (posX + num < length && posY - num >= 0)
    {
        if (table[posX + num, posY - num] != ".")
            check = false;
        num++;
    }

    //檢查左上
    num = 1;
    while (posX - num >= 0 && posY - num >= 0)
    {
        if (table[posX - num, posY - num] != ".")
            check = false;
        num++;
    }

    //檢查右上
    num = 1;
    while (posX - num >= 0 && posY + num < length)
    {
        if (table[posX - num, posY + num] != ".")
            check = false;
        num++;
    }

    return check;
}


void Print()
{
    Console.WriteLine($"Solution {ans}");
    Console.WriteLine();

    for (var x = 0; x < length; x++)
    {
        for (var y = 0; y < length; y++)
        {
            Console.Write(table[x, y]);
        }
        Console.WriteLine();
    }

    Console.WriteLine();
    ans++;
}
