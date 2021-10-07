using UnityEngine;

public class UnscaledChild : MonoBehaviour
{
    [SerializeField] private Vector3 baseScale;
    private void OnEnable()
    {
        if (transform.parent == null) return;
        Vector3 scaleTmp = baseScale;
        scaleTmp.x /= transform.parent.localScale.x;
        scaleTmp.y /= transform.parent.localScale.y;
        scaleTmp.y /= transform.parent.localScale.z;
        transform.localScale = scaleTmp;
    }
}
