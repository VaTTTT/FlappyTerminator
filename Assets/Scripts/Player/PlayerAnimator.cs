using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Backpack _backpack;

    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private Animator _backpackAnimator;

    public void PlayRocketJumpAnimation()
    {
        _characterAnimator.SetBool(Params.IsGrounded, false);
        _backpackAnimator.Play(Params.OnAnimation);
        _characterAnimator.Play(Params.JumpAnimation);
    }

    public void PlayRunAnimation() 
    {
        _characterAnimator.SetBool(Params.IsGrounded, true);
    }

    public static class Params
    {
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        public static readonly int OnAnimation = Animator.StringToHash(nameof(OnAnimation));
        public static readonly int JumpAnimation = Animator.StringToHash(nameof(JumpAnimation));
    }
}
