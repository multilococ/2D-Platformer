using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteFliper : MonoBehaviour 
{
    [SerializeField] private UserInput _userInput;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _userInput.Turned += Flip;
    }

    private void OnDisable()
    {
        _userInput.Turned -= Flip;
    }

    private void Flip(float turn) 
    {
       _spriteRenderer.flipX = turn < 0;      
    }
}
