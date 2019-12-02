using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleObject : MonoBehaviour
{
    Renderer m_Renderer;
    private bool isVisible;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
    }

    void OnBecameVisible()
    {
        isVisible = true;
    }

    void OnBecameInvisible()
    {
        isVisible = false;
    }

    public bool GetVisible()
    {
        return isVisible;
    }
}
