using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationGifScript : MonoBehaviour
{
    public Sprite[] animatedImages;
    public Image animateImageObj;
    void Update()
    {
       animateImageObj.sprite = animatedImages [(int)(Time.time * 10) % animatedImages.Length];
    }
}
