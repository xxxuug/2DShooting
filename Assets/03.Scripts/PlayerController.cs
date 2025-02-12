using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject Shot;
    public Canvas canvas;

    Transform _transform;
    //Rigidbody2D rb2d;
    float _speed = 0.08f;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        //rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, y, 0);
        _transform.position += movement.normalized * _speed;
        //rb2d.linearVelocity = new Vector2(x, y) * _speed;
        //_transform.Translate(new Vector3(x, y, 0));
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var shot = Instantiate<GameObject>(Shot);
            shot.transform.position = _transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ENEMY"))
        {
            canvas.enabled = true;
            Destroy(gameObject);
        }
    }
}
