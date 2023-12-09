using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float _speed = 70f;
    void Update()
    {
        transform.Rotate(transform.up, _speed * Time.deltaTime, 0);
    }
}
