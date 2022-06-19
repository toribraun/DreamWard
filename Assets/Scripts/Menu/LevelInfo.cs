using System;
using UnityEngine;
using UnityEngine.UI;

class LevelInfo : MonoBehaviour
{
    [SerializeField]
    public int Id;
    [SerializeField]
    public string LevelName;
    [SerializeField]
    public string LevelText;
    [SerializeField]
    public Sprite LevelPicture;
    [SerializeField]
    public Sprite LevelLostPicture;
    [SerializeField]
    public Sprite LevelWonPicture1;
    [SerializeField]
    public Sprite LevelWonPicture2;
    [SerializeField]
    public Sprite LevelWonPicture3;
    [SerializeField]
    public int threshold2;
    [SerializeField]
    public int threshold3;
}
