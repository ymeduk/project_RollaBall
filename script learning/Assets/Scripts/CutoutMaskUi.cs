using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoutMaskUi : Image
{ 
    public override Material materialForRendering
    {
        get 
        {
            Material material = new Material(base.materialForRendering);
            material.SetInt("_stencilComp", (int)CompareFunction.NotEqual);
            return material;
        }
    }
}
