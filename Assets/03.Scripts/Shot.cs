using UnityEngine;

public class Shot : MonoBehaviour
{
    private float _speed = 10.0f;
    Transform shotTransform;

   void Start()
    {
        shotTransform = GetComponent<Transform>();
        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
        shotTransform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}
