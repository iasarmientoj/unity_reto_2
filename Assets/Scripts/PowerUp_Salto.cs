using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Salto : MonoBehaviour
{
    public float fuerzaSalto;
    public float tiempoSalto;
    private float fuerzaOriginal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterController2D playerController = FindObjectOfType<CharacterController2D>();
            fuerzaOriginal = playerController.m_JumpForce;
            playerController.m_JumpForce = fuerzaSalto;

            //eliminar "de mentiras"
            //GetComponent<Renderer>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;

            Invoke(nameof(ResetSalto), tiempoSalto);
        }
    }

    public void ResetSalto()
    {
        CharacterController2D playerController = FindObjectOfType<CharacterController2D>();
        playerController.m_JumpForce = fuerzaOriginal;

        //Destroy(gameObject);
    }
}
