using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   

    [Header("Players")]
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


    private PlayerMovements _player1movements;
    private PlayerMovements _player2movements;
    private Ball _ball;
    private void Start()
    {
        _player1movements = PlayerOne.GetComponent<PlayerMovements>();
        _player2movements = PlayerTwo.GetComponent<PlayerMovements>();
        _ball =ball.GetComponent<Ball>();
    }



    public void PlayerOneScored()
    {
        _playerOneScore++;
        PlayerOneScore.text = _playerOneScore.ToString();
        _player2movements.Player2Life -= 10;
        _player2LifeSlider.value = _player2movements.Player2Life;
        RestartGame();
    }

    public void PlayerTwoScored()
    { 

        _playerTwoScore++;
        PlayerTwoScore.text = _playerTwoScore.ToString();
        _player1movements.Player1Life -= 10;
        _player1LifeSlider.value = _player1movements.Player1Life;
        RestartGame();
    }

    public void RestartGame()
    {
        _player1movements.ResetPlayer();
        _player2movements.ResetPlayer();
        _ball.RestBall();

    }
}
