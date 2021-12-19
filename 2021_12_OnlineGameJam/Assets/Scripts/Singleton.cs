using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType
{ 
    Normal, Easy, SuperEasy
}

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public GameType GameType;
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                var gameObject = new GameObject("Singleton");
                instance = gameObject.AddComponent<Singleton>();
                DontDestroyOnLoad(gameObject);
            }
            return instance;
        }
    }
}
