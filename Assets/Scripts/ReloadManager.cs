using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReloadManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _ammoText;

    // Start is called before the first frame update
    public void UpdateAmmo(int count){
        _ammoText.text += count;
    }
}
