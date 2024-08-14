using System.Collections;
using UnityEngine;
namespace Game
{
    public class CrystalScore : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private AudioSource _audioSource;

        private void Awake(){
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collider2D){
            if(collider2D.tag == "Ball"){
                StartCoroutine(DestroyAfterTime());

                _audioSource.Play();

                GameManager.Instance.AddScore( 10f);
            }
            if(collider2D.tag == "BoostBall"){
                StartCoroutine(DestroyAfterTime());

                _audioSource.Play();

                GameManager.Instance.AddScore( 20f);
            }
        }

        private IEnumerator DestroyAfterTime(){
            _spriteRenderer.enabled = false;
            

            yield return new WaitForSeconds(1f);

            Destroy(gameObject);
        }
    }
}
