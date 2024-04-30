using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float count = 4;
    public  int GameCount = 1;
    int scoreDecrement =100;

    public UnityAction OnGameOver;
    public UnityAction OnAnyPlayerDead;

    [Header("Players")]
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] GameObject PlayerOne;
    [SerializeField] GameObject PlayerTwo;
    private int _playerOneScore;
    private int _playerTwoScore;

  

    [Header("Ball")]
    [SerializeField] GameObject ball;

    [Header("UI Updates")]
    [SerializeField] TextMeshProUGUI PlayerOneScore;
    [SerializeField] TextMeshProUGUI PlayerTwoScore;
    [SerializeField] Slider _player1LifeSlider;
    [SerializeField] Slider _player2LifeSlider;
    [SerializeField] TextMeshProUGUI _CountDownText;
    [SerializeField] TextMeshProUGUI helthTextPlayer1;
    [SerializeField] TextMeshProUGUI HelthTextPlayer2;
    [SerializeField] TextMeshProUGUI roundText;
  


    private PlayerMovements _player1movements;
    private PlayerMovements _player2movements;
    private Ball _ball;


    public int Player1Score
    {
        get { return _playerOneScore; }

    }
    public int Player2Score
    {
        get { return _playerTwoScore; }
    }
    private void Start()
    {
       
        _player1movements = PlayerOne.GetComponent<PlayerMovements>();
        _player2movements = PlayerTwo.GetComponent<PlayerMovements>();
        _ball =ball.GetComponent<Ball>();
        HelthTextPlayer2.text = _player2movements.Player2Life.ToString();
        helthTextPlayer1.text = _player1movements.Player1Life.ToString();

        OnAnyPlayerDead += OnAnyPlayerIsDead;
        OnGameOver += GameOver;


        roundText.text = "Round " + GameCount.ToString();
        StartCoroutine(CountDown(count));

    }



    public void PlayerOneScored()
    {
        _particleSystem.Play();
        _playerOneScore++;
        PlayerOneScore.text = _playerOneScore.ToString();
        _player2movements.Player2Life -= scoreDecrement;

        UpdatePlayerHealth();


        if ( _player2movements.Player2Life <= 0)
            OnAnyPlayerDead.Invoke();
        else
            StartCoroutine(CountDown(count));
       
      
    }

    public void PlayerTwoScored()
    {
        _particleSystem.Play();
        _playerTwoScore++;
        PlayerTwoScore.text = _playerTwoScore.ToString();
        _player1movements.Player1Life -= scoreDecrement;
      
        UpdatePlayerHealth();

        if (_player1movements.Player1Life <= 0)
            OnAnyPlayerDead.Invoke();
        else
            StartCoroutine(CountDown(2));
       
    }

    public void UpdatePlayerHealth()
    {
        _player1LifeSlider.value = _player1movements.Player1Life;
        helthTextPlayer1.text = _player1movements.Player1Life.ToString();

        _player2LifeSlider.value = _player2movements.Player2Life;
        HelthTextPlayer2.text = _player2movements.Player2Life.ToString();
    }
    public void RestartGame()
    {
        _player1movements.ResetPlayer();
        _player2movements.ResetPlayer();
        _ball.RestBall();

    }

    public IEnumerator CountDown(float count)
    {
        float timer = count;

        while (timer >= -1f)
        {
            if (timer <= 0)
                _CountDownText.text = "Start";
            else
                _CountDownText.text = Mathf.CeilToInt(timer).ToString();

            // Decrease the timer
            timer -= Time.deltaTime;

            // Wait for the next frame
            yield return null;

            
        }
  
        _CountDownText.enabled = false;
        roundText.enabled = false;
        RestartGame();
    }

    public void OnAnyPlayerIsDead()
    {
        GameCount++;
        if(GameCount == 4)
        {
            OnGameOver.Invoke();
            Debug.Log("Game Over");
           
        }
        else
        {
            _player1movements.Player1Life = 100;
            _player2movements.Player2Life = 100;
            UpdatePlayerHealth();
            _CountDownText.enabled = true;
            roundText.enabled=true;
            StartCoroutine(CountDown(count));
            Debug.Log(GameCount.ToString() + " Round");

            roundText.text = "Round " + GameCount.ToString();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
