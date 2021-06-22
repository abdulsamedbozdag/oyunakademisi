using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasfırlatma : MonoBehaviour
{

    public Rigidbody2D tas_rb2D;
    bool eğerclikced = false;
    public Rigidbody2D bağlantınoktası;
    public float en_buyuk_uzaklık;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eğerclikced==true)
        { 
          //tas_rb2D.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          Vector2 mouse_konumu = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          if(Vector2.Distance(mouse_konumu,bağlantınoktası.position)>en_buyuk_uzaklık)
            {
                tas_rb2D.position = bağlantınoktası.position + (mouse_konumu - bağlantınoktası.position).normalized * en_buyuk_uzaklık;
            }
          else
            {
                tas_rb2D.position = mouse_konumu;
            }

        }

    }
    private void OnMouseDown()
    {
        eğerclikced = true;
        tas_rb2D.isKinematic = true;
    }
    private void OnMouseUp()
    {
        eğerclikced = false;
        tas_rb2D.isKinematic = false;
        Firlat();
    }
    void Firlat()
    {
        Destroy(GetComponent<SpringJoint2D>(), 0.05f);
    }
       
}
