using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers Instance { get { Init(); return _instance; } }
    private static Managers _instance;
    
    private ObjectManager _object = new ObjectManager();
    private GameManager _gameManager = new GameManager();
    
    public static ObjectManager Object { get { return Instance._object; } }
    public static GameManager GameManager { get { return Instance._gameManager;} }

    private static void Init()
    {
        if (_instance == null)
        {
            GameObject gameObject = GameObject.Find("Managers");
            if (gameObject == null)
            {
                gameObject = new GameObject("Managers");
                gameObject.AddComponent<Managers>();
                
            }

            DontDestroyOnLoad(gameObject);
            _instance = gameObject.GetComponent<Managers>();
        }
    }
}