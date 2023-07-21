using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailparticleElement : MonoBehaviour
{
    new public ParticleSystem particleSystem;
    public int id = -1;

    private void Awake()
    {
        particleSystem = transform.GetComponent<ParticleSystem>();
    }

    public void Setup(Sprite sprite, int Id)
    {
        if (sprite == null) return;
        if(Id== id)
        {
            return;
        }
        else
        {
            id = Id;
        }
        var mainModule = particleSystem.main;
        var startColor = mainModule.startColor;
        Color randomColor = Random.ColorHSV();
        
        particleSystem.textureSheetAnimation.SetSprite(0, sprite);
        if (sprite.name == "trail_cicle(Clone)")
        {
            mainModule.startSize = new ParticleSystem.MinMaxCurve(0.5f, 1f);
        }else if(sprite.name == "trail_dot(Clone)")
        {
            mainModule.startSize = new ParticleSystem.MinMaxCurve(1f, 2f);
            mainModule.startColor = Color.white;
            return;
        }else if(sprite.name == "trail_heart(Clone)")
        {       
            mainModule.startSize = new ParticleSystem.MinMaxCurve(0.75f, 1.5f);
            startColor.mode = ParticleSystemGradientMode.RandomColor;
            startColor.gradient = new Gradient()
            {
                colorKeys = new GradientColorKey[] { new GradientColorKey(randomColor, 0f) },
                alphaKeys = new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f) }
            };
         
            mainModule.startColor = startColor;        
            return;
        }else if(sprite.name == "trail_snowflakes(Clone)")
        {
            mainModule.startSize = new ParticleSystem.MinMaxCurve(0.5f, 1f);
        }
        else
        {
            mainModule.startSize = new ParticleSystem.MinMaxCurve(1f, 2f);
        }
        
        startColor.mode = ParticleSystemGradientMode.RandomColor;
        startColor.gradient = new Gradient()
        {
            colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(Color.red, 0f),
                new GradientColorKey(Color.yellow, 0.2f),
                new GradientColorKey(Color.green, 0.4f),
                new GradientColorKey(Color.blue, 0.6f),
                new GradientColorKey(Color.magenta, 0.8f),
                new GradientColorKey(Color.magenta, 1f)
            },

            alphaKeys = new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f) }
        };

        mainModule.startColor = startColor;
    }
}
