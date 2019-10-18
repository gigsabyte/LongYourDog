using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateNoise : MonoBehaviour
{

    Renderer rend;

    private Texture2D noiseTex;

    Vector2 size;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        size = new Vector2(transform.localScale.x, transform.localScale.z);

        noiseTex = generateNoise(size, 0, 0);
        rend.sharedMaterial.SetTexture("_MainTexture", noiseTex);
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time;
        t = t / 10;
        noiseTex = generateNoise(size, t, t);
        noiseTex.Apply();
        rend.sharedMaterial.mainTexture = noiseTex;
        //rend.sharedMaterial.SetTexture("_MainTexture", noiseTex);
    }

    Texture2D generateNoise(Vector2 size, float timex, float timey, float seed = 0)
    {
        Texture2D noise = new Texture2D((int)size.x, (int)size.y);

        Color[] pixels = new Color[(int)size.x * (int)size.y];

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                float sample = Mathf.PerlinNoise(x + timex, y + timey);
                pixels[y * (int)size.x + x] = new Color(sample, sample, sample);
            }
        }

        noise.SetPixels(pixels);
        noise.Apply();

        return noise;
    }
}
