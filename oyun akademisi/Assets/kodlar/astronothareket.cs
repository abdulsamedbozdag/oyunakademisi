using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class astronothareket : MonoBehaviour
{


    public float hiz = 1;
    public int taş_sayisi;
    public int buyuk_tas_sayisi;
    public bool indi_mi = false;
    public Animator benim_animator;
    float yatay;
    float dikey;
    public Text toplanan_tas_sayisi;
    public Text toplanan_buyuk_tas_sayisi;
    public GameObject oyunsonupaneli;
    public Text oyunsonu_tas_sayisi;
    public int saglik = 100;
    public Text saglik_text;
    public static bool oyunumuz_basladi_mi = false;
    public GameObject oyunbasipaneli;



    // Start is called before the first frame update
    void Start()
    {
        saglik_text.text = saglik.ToString();
        oyunumuz_basladi_mi = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
       void FixedUpdate()
       {
        if(oyunumuz_basladi_mi==false)
        {
            return;
        }

        yatay = Input.GetAxis("Horizontal");
        //Debug.Log(yatay);
        transform.position += new Vector3(yatay*hiz, 0, 0);




        dikey = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, dikey * hiz, 0);
        yondegistir();



          bool yuruyormuyuz = false;
          if (yatay!=0)

          {
            yuruyormuyuz = true;
          }

          if (yatay==0)

          {
            yuruyormuyuz = false;
          }
        benim_animator.SetBool("yuruyormu", yuruyormuyuz);




       }
    
       private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "stone")
        {   
            taş_sayisi++;
            toplanan_tas_sayisi.text = taş_sayisi.ToString();
            toplanan_tas_sayisi.text = "00" + toplanan_tas_sayisi.text;
            Debug.Log("taş toplandı");
            Destroy(collision.gameObject);
            
        }

        if (collision.tag == "buyuktas")
        {
            buyuk_tas_sayisi++;
            toplanan_buyuk_tas_sayisi.text = buyuk_tas_sayisi.ToString();
            toplanan_buyuk_tas_sayisi.text = "000" + toplanan_buyuk_tas_sayisi.text;
            Debug.Log("taş toplandı");
            Destroy(collision.gameObject);
            
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        { if(indi_mi==false)
            { 
              Debug.Log("astronot gezegene indi"); 
            }

           indi_mi = true;
        }

        if (collision.gameObject.tag == "spike") 
        
        {
            Debug.Log("ahhh!!!");
            saglik -= 20;
            saglik_text.text = saglik.ToString();
            if (saglik<=0)
            
            {
                
                Destroy(this.gameObject);
                oyunsonupaneli.SetActive(true);
                oyunsonu_tas_sayisi.text = taş_sayisi.ToString();
                oyunbasipaneli.SetActive(false);
            }

           
        }

    }
    void yondegistir()
    {
            if (yatay > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }


            else if (yatay < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (dikey > 0)

            {
                transform.localScale = new Vector3(1, 1, 1);

            }

            else if (dikey < 0)
            {
                transform.localScale = new Vector3(1, -1, 1);

            }
    }
    public void oyun_basladi()
    { 
        oyunumuz_basladi_mi = true;
        oyunbasipaneli.SetActive(false);
    }
    
    

}



