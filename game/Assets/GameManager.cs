using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject Door;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }



    void Start()
    {

    }

    void Update()
    {

    }

    public void canEnter(int score)
    {
        if(score == 5)
        {
            Door.SetActive(true);
            score -= 5;
        }
    }
}
