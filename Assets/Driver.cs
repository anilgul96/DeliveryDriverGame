using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f; //sonuna float kısaltması f koyuyoruz.
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 0.5f;
    [SerializeField] float boostSpeed = 30f;
    //[SerializeField] unity ekranında sağ tarafta değişkenlere müdahele etmemizi sağlayan bir metod.
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other) // herhangi bir şeye çarpınca hızım düşsün
    {
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp") // üstünden geçince hız artsın.
        {
            Debug.Log("SpeedUp etkin");
            moveSpeed = boostSpeed;
        }
        if (other.tag == "SlowSpeed") // üstünden geçince hız düşsün.
        {
            Debug.Log("SlowSpeed etkin!");
            moveSpeed = slowSpeed;
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis("Horizontal"): Yatayda ok tuşlarından gelen veriye göre hareket etmemizi sağlıyor.
        //Input.GetAxis("Vertical"): Düşeyde ok tuşlarından gelen veriye göre hareket etmemizi sağlıyor.
        //Time.deltaTime():Her bilgisayarın hızı farklıdır. Doalyısıyla frameler her PC'de farklı sürelerde hareket edebilir. Bunu ortadan kaldırmak için bu metodu kullanıyoruz.
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; //sağ ve sol ok tuşlarıyla dönderiyoruz. dönüş hızını steerSpeed değişkeni ile belirledik. steerAmount ile dönüş hareketini klavyeden alıyoruz.
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // yukarı aşağı ok tuşlarıyla hareketi yapıyoruz. moveSpeed ile hareketin hızını belirliyoruz.
        transform.Rotate(0, 0, -steerAmount); // negatif yaptık, rotasyon doğru olsun  diye.
        transform.Translate(0, moveAmount, 0);
    }
}
