using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int gameOverSceneIndex = 3;

    private Animator anim;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GRASS"))
        {
            yaig();
        }
    }
    
    private void yaig()
    {
        AudioManager.Instance.Play("YAIG");
       rb.angularVelocity = 0;
       rb.velocity = Vector2.zero;
       rb.constraints = RigidbodyConstraints2D.FreezeAll;
       rb.isKinematic = true;
       rb.simulated = false;
       anim.SetTrigger("yaig");
    }
    
    private void RestartLevel()
    {
        Application.LoadLevel(gameOverSceneIndex);
    }

}
