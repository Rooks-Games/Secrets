using Scripts.Player;
using UnityEngine;

namespace Map
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject GameOver;
        [SerializeField] private GameObject GameWon;
        [SerializeField] private PlayerController player;
        private int loyal;
        private int notloyal;

        public void SetLoyal(int isloyal)
        {
            if (isloyal==1)
            {
                loyal++;
                if (loyal==11)
                {
                    GameWon.SetActive(true);
                    player.GameEnded = true;
                }
            }
            else if (isloyal==-1)
            {
                notloyal++;
                if (notloyal==3)
                {
                    GameOver.SetActive(true);
                    player.GameEnded = true;
                }
            }
        }
    }
}