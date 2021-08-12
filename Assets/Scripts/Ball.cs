using UnityEngine;

public class Ball : MonoBehaviour
{

    new Rigidbody2D rigidbody2D;

    [SerializeField]
    float moveSpeed = 10f;

    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * moveSpeed;
    }
}
