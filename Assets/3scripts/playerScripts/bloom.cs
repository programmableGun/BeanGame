using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloom : MonoBehaviour
{
    public Image imageBloom;
    public float bloomToggleRate;
    public void DoBloom(bool val) {
        if (!val) {
            imageBloom.rectTransform.localScale = Vector3.Lerp(new Vector3(1.25f, 2f, 1f), new Vector3(1f, 1f, 1f), bloomToggleRate);
        }
        else
        {

            imageBloom.rectTransform.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(1.25f, 2f, 1f), bloomToggleRate);
        }
    }

}
