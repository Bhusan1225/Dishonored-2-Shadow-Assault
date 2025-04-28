using UnityEngine;
using UnityEngine.VFX;

public class VFXForceBounds : MonoBehaviour
{
    public VisualEffect vfx;

    void Start()
    {
        if (vfx == null)
            vfx = GetComponent<VisualEffect>();

        // Disable automatic bounds
        //vfx.visualEffectAsset.SetDefaultBounds(new Bounds(Vector3.zero, Vector3.one * 10000f));
    }
}

