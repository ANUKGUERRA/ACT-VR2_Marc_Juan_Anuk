using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public static Puntuacion Instance { get; private set; }
    private int goal = 5;
    private int intentos = 20;
    private int score = 0;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(this);
            return;
        }

        Instance = this;
    }

    private void OnEnable()
    {
        TargetLogic.OnTargetHit += AddPoint;
    }

    private void OnDisable()
    {
        TargetLogic.OnTargetHit -= AddPoint;
    }

    private void AddPoint()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}