using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationGifScript : MonoBehaviour
{
    public Sprite[] animatedImages;
    public Image animateImageObj;
    public int speedFPS;
    public bool looping = true;
    public int posActual;
    void Update()
    {
        if (looping)
        {
            posActual = (int)(Time.time * speedFPS) % animatedImages.Length;
            animateImageObj.sprite = animatedImages[posActual];
        }

        if (looping == false && posActual != animatedImages.Length - 1)
        {
            posActual = (int)(Time.time * speedFPS) % animatedImages.Length;
            animateImageObj.sprite = animatedImages[posActual];
        }

        if (looping == false && posActual == animatedImages.Length - 1)
        {
            posActual = animatedImages.Length - 1;
            animateImageObj.sprite = animatedImages[posActual];
            if (posActual == animatedImages.Length - 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
