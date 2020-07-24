using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupGame : MonoBehaviour
{
    public int score;
    public Text ScoreText;
    private bool isColliding=false;
    private string objetivo = "Objetivo Alcanzado en : ";
    private Animator m_Animator;
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (isColliding == false)
        { 
            ReachObjetive();
        }
       

    }

    private void ReachObjetive()
    {
       score++;
       ScoreText.text =objetivo + Time.realtimeSinceStartup.ToString();
       isColliding = true;
       m_Animator.SetTrigger("goOut");

    }
  
    void fixUpdate()
    {

    }


   
}
