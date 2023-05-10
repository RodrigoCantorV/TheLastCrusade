using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePJ : Character
{
    public override void Dash()
    {
        print("dash activado");
    }

    public override void LeftAtack()
    {
        print("ataque izquierdo");
    }

    public override void RightAtack()
    {
        print("ataque derecho");
    }

    public override void SuperPower()
    {

        print("superPoder de distancia");
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
