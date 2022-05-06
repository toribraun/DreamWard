using System;
using UnityEngine;

class LevelInfo
{
    static int nextId = 1;
    int Id;
    string LevelName;
    //GameObject LevelPicture;
    //GameObject LevelResult;
    public LevelInfo(string name)
    {
        Id = nextId;
        nextId++;
        LevelName = name;
    }
}
