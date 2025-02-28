using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -6;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
}
