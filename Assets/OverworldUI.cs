using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldUI : MonoBehaviour
{
    public Text _coinCountText;
    public Text _buttonText;
    private int _coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin()
    {
        _coinCount = _coinCount + 1;
        _coinCountText.text = "" + _coinCount;
    }
}
