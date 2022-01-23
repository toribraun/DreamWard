using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirefliesLeftScore : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] fireflyLampsOn;
    
    private void Start()
    {
        // fireflyLampsOn = GetComponent<GameObject>();
        // fireflyLampsOn = GetComponentsInChildren<GameObject>();
        foreach (var lamp in fireflyLampsOn)
        {
            lamp.SetActive(false);
        }
    }
    
    public void UpdateFirefliesLeftScore(int fireflyNumber)
    {
        fireflyLampsOn[fireflyNumber].SetActive(true);
    }
}