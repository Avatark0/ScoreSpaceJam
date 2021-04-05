using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SpriteRenderer = default;

    private void OnEnable()
    {
        GetComponentInParent<Player>().cricket_boost_frames=true;
        GetComponentInParent<Player>().CricketBoostControl();
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

            GetComponentInParent<Player>().cricket_boost_frames=false;
            GetComponentInParent<Player>().CricketBoostControl();
            
            gameObject.SetActive(false);
        } 
    }

    public void ResetBoostTime()
    {
        Color fading = SpriteRenderer.color;
        fading.a = 1;
        SpriteRenderer.color = fading;
    }
}
