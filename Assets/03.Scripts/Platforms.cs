using UnityEngine;

public class Platforms : MonoBehaviour
{
    float _speed = 2.0f;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
