using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime; //Time 서로 다른 성능을 가진 PC에서 똑같은 위치만큼 이동
        if (transform.position.y < -10) {
            transform.position += new Vector3(0, 10 * 2f, 0 ); //10 * 2f 대신 20f 사용 가능
        }
    }
}