using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Backpack _backpack;

    private Animator _characterAnimator;
    private Animator _backpackAnimator;

    private void Start()
    {
        _characterAnimator = _character.GetComponent<Animator>();
        _backpackAnimator = _backpack.GetComponent<Animator>();
    }

    public void PlayRocketJumpAnimation()
    {
        _characterAnimator.SetBool("isGrounded", false);
        _backpackAnimator.Play("OnAnimation");
        _characterAnimator.Play("JumpAnimation");
    }

    public void PlayRunAnimation() 
    {
        _characterAnimator.SetBool("isGrounded", true);
    }
}
