using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private bool IsPlayer1ScoreWall;
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            if (IsPlayer1ScoreWall)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerTwoScored();
            }else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerOneScored();
            }
               

        }
    }
}
