using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class Effect : MonoBehaviour
{

    private PostProcessVolume v;
    private Bloom b;
    private Vignette vg;
    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings(out b);
        v.profile.TryGetSettings(out vg);
        //Test();
    }

    [ContextMenu("test")]
    private void Test()
    {
        b.intensity.value = 0.1f;
        vg.intensity.value = 0.5f;
    }

}
