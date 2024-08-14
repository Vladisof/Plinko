using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private BasketType _basketType;

    private AudioSource _audioSource;

    public enum BasketType{
        x5,
        mx2,
        x3,
        mx5
    };

    private void Awake(){
        _audioSource = GetComponent<AudioSource>();
    }

    public void GiveScore(float score){
        _audioSource.Play();

        switch(_basketType){
            case BasketType.x5:
                GameManager.Instance.AddScore(score * 5f);
                break;

            case BasketType.mx2:
                GameManager.Instance.AddScore(score * -2f);
                break;

            case BasketType.x3:
                GameManager.Instance.AddScore(score * 3f);
                break;
            
            case BasketType.mx5:
                GameManager.Instance.AddScore(score * -5f);
                break;
        } 
    }
    public void GiveBoostScore(float score){
        _audioSource.Play();

        switch(_basketType){
            case BasketType.x5:
                GameManager.Instance.AddScore(score * 10f);
                break;

            case BasketType.mx2:
                GameManager.Instance.AddScore(score * -4f);
                break;

            case BasketType.x3:
                GameManager.Instance.AddScore(score * 6f);
                break;
            
            case BasketType.mx5:
                GameManager.Instance.AddScore(score * -10f);
                break;
        } 
    }
}
