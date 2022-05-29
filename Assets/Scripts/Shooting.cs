using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject pointer, launchPoint, projectilePrefab, castProjectile;
    public bool casting = false, cursorVisible = false;
    public float arrowSpeed = 30.0f;
    public float shotCoolDown = 1; 
    private float shotTime;
    private Vector3 target;
    public Animator Player;
    public CharacterControl charControl;


    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3
            (Input.mousePosition.x, Input.mousePosition.y, transform.position.z)); //Almacena la posicion del mouse
        pointer.transform.position = new Vector2(target.x, target.y);   //Pone el apuntador en la posicion del mouse cambiandolo a un vector 2d
        Vector3 difference = target - launchPoint.transform.position;   //Crea un vector entre la posicion del mouse y el personaje
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;  //Calcula el angulo usando la tangente inversa
        if (charControl.fireball)                                       //Esto es para cuando tenia diferentes proyectiles
        {
            if (Input.GetMouseButton(0))
            {
                Player.SetBool("Casting", true);                //Muestra la bolita de fuego cargando
                castProjectile.gameObject.SetActive(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                float distance = difference.magnitude;          //La distancia es igual a la magnitud del vector diferencia
                Vector2 direction = difference / distance;      //Vector unitario en la direccion del cursor
                direction.Normalize();
                if (Time.time > shotTime + shotCoolDown)        //Agrega un tiempo de espera al disparo
                {
                    shotArrow(direction, rotationZ);            //Funcion para disparar
                    shotTime = Time.time;                       //Almacena el tiempo de disparo
                }
            }
        }
    }

    void shotArrow(Vector2 direction, float rotationZ)
    {
        GameObject arrow = Instantiate(projectilePrefab) as GameObject;     //Carga el prefab del proyectil
        arrow.transform.position = launchPoint.transform.position;          //Establece el punto de donde sale el proyectil, es decir, el jugador
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); //Apunta el proyectil en la direccion del objetivo
        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;    //Dispara el proyectil
        Player.SetBool("Casting", false);                                   //Termina el estado de preparacion de disparo y su animacion
        castProjectile.gameObject.SetActive(false);
    }
}
