using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorEsqueleton : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform refPoint;
    private Animator anim;
    public float velocidad =4;
    public bool moverse = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = refPoint.position - transform.position ;

        if (moverse)
        {
            transform.Translate(direction.normalized * Time.deltaTime * velocidad, Space.World);
            anim.SetFloat("speed", 1f);

        }

    }
}
