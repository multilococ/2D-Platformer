using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;

    private Animator _animator;

    private readonly string MoveSpeed = nameof(MoveSpeed);
    private readonly string Jump = nameof(Jump);
    private readonly string Horizontal = nameof(Horizontal);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_jumper.IsGrounded == true)
            _animator.SetFloat(MoveSpeed, Mathf.Abs(Input.GetAxisRaw(Horizontal)));
        
        if(_jumper.IsGrounded == false)
            _animator.SetBool(Jump,true);
        else
            _animator.SetBool(Jump,false);
    }
}
