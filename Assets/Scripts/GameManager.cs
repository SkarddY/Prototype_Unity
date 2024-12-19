using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onLogIn;
    
    public static GameManager Instance {get; private set;}

   public void LogIn(){
        onLogIn.Invoke();
    }
}
