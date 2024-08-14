using UnityEngine;
namespace Game
{
    public class BoostBall : MonoBehaviour
    {
        public float Score {get; set;} 

        private void OnCollisionEnter2D(Collision2D collision2D){
            if(collision2D.gameObject.tag == "Basket"){
                collision2D.gameObject.GetComponent<Basket>().GiveBoostScore(Score);

                Destroy(gameObject);
            }
        }
    }
}
