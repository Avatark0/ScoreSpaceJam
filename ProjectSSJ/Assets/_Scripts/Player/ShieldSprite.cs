using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SpriteRenderer = default;

    private void OnEnable()
    {
        GetComponentInParent<Player>().shieldDamageFrames=true;
    }

    private void Update()
    {
        Color fading = SpriteRenderer.color;
        fading.a -= fading.a * Time.deltaTime;
        SpriteRenderer.color = fading;
        if(fading.a<0.1f)
        {
            fading.a = 1;
            SpriteRenderer.color = fading;
            GetComponentInParent<Player>().shieldDamageFrames=false;
            gameObject.SetActive(false);
        } 
    }
}
