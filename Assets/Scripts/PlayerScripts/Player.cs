using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private UserInput _userInput;

    public Rigidbody2D GetRigidbody => _rigidbody2D;
}
