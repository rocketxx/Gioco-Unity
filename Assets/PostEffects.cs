using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
public class PostEffects : MonoBehaviour
{
    public ParticleSystem pSystem;

    private PostProcessVolume v;
    private Bloom b;
    private Vignette vg;
    private void Start()
    {
        //pSystem.Play();
        v = GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings(out b);
        v.profile.TryGetSettings(out vg);
    }

    [ContextMenu("Test")]
    private void Test()
    {
        b.intensity.value = 0.1f;
        vg.intensity.value = 0.5f;
    }
}
