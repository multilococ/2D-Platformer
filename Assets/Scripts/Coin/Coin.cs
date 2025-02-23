using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private SpriteRenderer _coinSprite;
    
    [SerializeField] private float _showDelay = 10f;

    private WaitForSeconds _delayTime;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_showDelay);
    }

    public void Take()
    {
        _coinSprite.enabled = false;
        _circleCollider.enabled = false;
        StartCoroutine(ShowCoinWithDelay());
    }

    private IEnumerator ShowCoinWithDelay()
    {
        yield return _delayTime;

        _circleCollider.enabled = true;
        _coinSprite.enabled = true;
    }
}
