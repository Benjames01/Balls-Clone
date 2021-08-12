using UnityEngine;

public class BallReturn : MonoBehaviour
{  
    BallLauncher launcher;

    void Awake()
    {
       launcher = FindObjectOfType<BallLauncher>(); 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        launcher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
    }
}
