using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onVirusExe;
    
    public static GameManager Instance {get; private set;}

    public void VirusExe(){
        onVirusExe.Invoke();
    }
}
