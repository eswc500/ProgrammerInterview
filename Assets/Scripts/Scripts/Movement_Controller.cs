using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    [Header("Movement Base")]
    public float speed_movement = 4f;

    private GameObject char_obj;
    public Rigidbody2D char_rigidbody;
    public Animator char_anima_main;
    Vector2 move;

    [Space(30)]
    [Header("Animations Cloth")]
    [Header("Animations Cloth Up")]
    public Animator char_anima_up;

    [Space(10)]
    [Header("Animations Cloth Mid")]
    public Animator char_anima_mid;

    [Space(10)]
    [Header("Animations Cloth Down")]
    public Animator char_anima_down;


    private void Start()
    {
        char_obj = GameObject.FindGameObjectWithTag("Player");

        char_rigidbody = char_obj.GetComponent<Rigidbody2D>();
        char_anima_main = char_obj.GetComponent<Animator>();
    }


    private void Update()
    {
        if(char_obj)
        {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");

            char_anima_main.SetFloat("Horizontal", move.x);
            char_anima_main.SetFloat("Vertical", move.y);
            char_anima_main.SetFloat("Speed", move.sqrMagnitude);

            if(char_anima_up)
            {
                char_anima_up.SetFloat("Horizontal", move.x);
                char_anima_up.SetFloat("Vertical", move.y);
                char_anima_up.SetFloat("Speed", move.sqrMagnitude);
            }

            if (char_anima_mid)
            {
                char_anima_mid.SetFloat("Horizontal", move.x);
                char_anima_mid.SetFloat("Vertical", move.y);
                char_anima_mid.SetFloat("Speed", move.sqrMagnitude);

            }

            if (char_anima_down)
            {
                char_anima_down.SetFloat("Horizontal", move.x);
                char_anima_down.SetFloat("Vertical", move.y);
                char_anima_down.SetFloat("Speed", move.sqrMagnitude);
            }

        }        
    }

    public void Anima_send(Animator anima)
    {
        anima.SetFloat("Horizontal", move.x);
        anima.SetFloat("Vertical", move.y);
        anima.SetFloat("Speed", move.sqrMagnitude);
    }


    private void FixedUpdate()
    {
        if (char_obj)
        char_rigidbody.MovePosition(char_rigidbody.position + move * speed_movement * Time.fixedDeltaTime);
    }
}
