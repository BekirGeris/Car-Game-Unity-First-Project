using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArabaScript : MonoBehaviour
{
    public float carVelocity = 15;
    public Text puanTest;
    public Text zamanText;
    public Text finishText;
    float horizontal;
    Rigidbody2D rigidBody2D;
    int puan;
    Vector3 fark;
    public GameObject kamera;
    float zaman;
    int sayac;
    bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        fark = kamera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        carKontrol();
        puanTest.text = puan + "";
        kamera.transform.position = new Vector3(fark.x + transform.position.x, kamera.transform.position.y, kamera.transform.position.z);
        zamanYazdır();
        oyunBittimi();
    }

    void carKontrol()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigidBody2D.AddForce(new Vector3(horizontal * carVelocity, 0, 0 - horizontal * (carVelocity / 2)));
        Debug.Log(puan);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Coin")
        {
            puan++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            flag = false;
        }
    }

    void zamanYazdır(){
        zaman += Time.deltaTime;
        if (zaman > 1 && zaman < 15)
        {
            sayac++;
            zaman = 0;
        }
        zamanText.text = sayac + "";
    }

    void oyunBittimi() 
    {
        if (sayac == 15)
        {
            finishText.gameObject.SetActive(true);
            flag = false;
            SceneManager.LoadScene(0);
        }

        if (sayac < 15 && flag == false)
        {
            finishText.text = "You Win";
            finishText.gameObject.SetActive(true);
            if (sayac == 15)
            {
                SceneManager.LoadScene(0);
            }
            
        }

    }

}
