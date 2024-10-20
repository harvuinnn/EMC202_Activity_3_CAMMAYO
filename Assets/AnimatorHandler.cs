using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    private Animator playerAnim;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.SetBool("Attack", true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerAnim.SetBool("Attack", false);
        }
    }
}
