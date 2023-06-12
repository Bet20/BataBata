using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelEffectHandler : MonoBehaviour
{
    public Material pixel_mat;
    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, dest, pixel_mat);    
    }
}
