using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    int equipo;
    public GameObject magicHat, pointer;
    public PlayerMovement move;
    public bool fireball = false;
    void Start()
    {
        equipo = 0;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && move.magic == true)
        {
            equipo++;
            if (equipo > 1) equipo = 0;
        }
        switch (equipo)
        {
            case 0:
                magicHat.gameObject.SetActive(false);
                pointer.gameObject.SetActive(false);
                move.velocidad = 12;
                fireball = false;
                break;
            case 1:
                magicHat.gameObject.SetActive(true);
                pointer.gameObject.SetActive(true);
                move.velocidad = 12;
                fireball = true;
                break;

        }
    }

    private void FixedUpdate()
    {
        
    }

    public void cambiarEquipo()
    {
        equipo++;
        if (equipo > 1) equipo = 0;
    }
    
}
/*public enum Equipo
    {
        Barehands,
        WithBow
    }*/