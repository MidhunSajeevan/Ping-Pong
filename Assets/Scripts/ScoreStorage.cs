using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreStorage : MonoBehaviour
{
    private static ScoreStorage instance;
    private GameManager gameManager;
    private int PlayerOneScore;
    private int PlayerTwoScore;

    private TextMeshProUGUI player1ScoreText;
    private TextMeshProUGUI player2ScoreText;

    private GameObject canvas;
    public static ScoreStorage Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreStorage>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("ScoreStorageSingleton");
                    instance = singletonObject.AddComponent<ScoreStorage>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    // Add your score-related variables and methods here

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  
    }
    private void Update()
    {
        if(canvas == null && SceneManager.GetActiveScene().buildIndex == 2)
        {
            canvas = GameObject.Find("ScoreCanvas");
            player1ScoreText = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            player2ScoreText = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            PlayerOneScore = gameManager.Player1Score;
            PlayerTwoScore = gameManager.Player2Score;

            player1ScoreText.text = PlayerOneScore.ToString();
            player2ScoreText.text = PlayerTwoScore.ToString();
        }
    }
  
    
}
