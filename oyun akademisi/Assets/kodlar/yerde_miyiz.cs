using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerde_miyiz : MonoBehaviour
{
    public LayerMask layer;
    public bool yerdemiyiz; //alt tresiz oluşturdum
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (astronothareket.oyunumuz_basladi_mi == false) ;
        {
            return;
        }
        RaycastHit2D carpis = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, layer);

        if (carpis.collider != null)
        {
            //ışın bir yere çarptıysa----> yerdeyiz
            yerdemiyiz = true;
        }

        else
        {
            //ışın bir yere çarpmadıysa---> havadayız
            yerdemiyiz = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && yerdemiyiz==true)
        {
            rb.velocity += new Vector2(0, 13f);
        }
    }

}
