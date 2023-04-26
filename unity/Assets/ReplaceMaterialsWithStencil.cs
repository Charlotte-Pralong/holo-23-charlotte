using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ReplaceMaterialsWithStencil : MonoBehaviour
{
    public int stencilReference = 1;


    void OnEnable()
    {
        var shader = Shader.Find("Graphics Tools/Standard");

        var renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            var materials = renderers[i].materials; // will create a copy of all materials

            for (int j = 0; j < materials.Length; j++)
            {
                var material = materials[j];
                material.shader = shader;
                material.SetFloat("_EnableStencil", 1);
                material.SetInt("_StencilReference", Mathf.RoundToInt(stencilReference));
                material.SetInt("_StencilComparison", (int)CompareFunction.Equal);
                material.SetInt("_StencilOperation", (int)StencilOp.Keep);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
