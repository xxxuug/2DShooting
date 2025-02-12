using UnityEngine;

public class Poulpi : MonoBehaviour
{
    private int _hp = 100;
    private float _speed = 2.0f;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SHOT"))
        {
            Destroy(collision.gameObject);

            _hp -= 50;
            if (_hp <= 0)
            {
                GameManager.instance.Score(50);
                Destroy(gameObject);
            }
        }
    }
}
