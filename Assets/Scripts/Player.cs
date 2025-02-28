using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed; //moveSpeed 값을 정의하지 않아도 위에 SerializeField를 적으면 유니티에서 movespeed 입력하는 창이 뜬다
    // Update is called once per frame
    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f; //미사일이 나가는 시간 설정
    private float lastShotTime = 0f;
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime; 위아래로 캐릭터가 움직이는 코드

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if (Input.GetKey(KeyCode.LeftArrow)) {
        //     transform.position -=moveTo;
        // } else if (Input.GetKey(KeyCode.RightArrow)) {
        //     transform.position += moveTo;
        // } 양옆으로만 캐릭터가 움직이는 코드

        // Debug.Log (Input.mousePosition); 유니티 콘솔화면에서 마우스 좌표를 볼 수 있음

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);    //float Mathf.Clamp(float value, float min, float max)= x가 최솟값과 최댓값 사이로 적용되게 해줌
        transform.position = new Vector3(toX, transform.position.y, transform.position.z); //x값만 마우스 따라가고 y, z값은 현재 캐릭터 포지션으로 둠
         
        Shoot();
    }

    void Shoot() {
        if (Time.time - lastShotTime > shootInterval) {//Time.time: 게임이 시작된 이후로 현재까지 흐른 시간
        Instantiate(weapon, shootTransform.position, Quaternion.identity); // Instantiate라는 메소드 = (어떤 게임 오브젝트를 만들지, 어떤 위치에 만들지, 회전은 어떻게 할지) 정해주는 메소드 Queaternion.identity = 회전을 없애는 것
        lastShotTime = Time.time;
        }
    }
}
