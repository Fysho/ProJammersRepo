using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityDisplay : MonoBehaviour
{
    public Text health;
    public Text attack;


    private Entity entity;

    void Start()
    {
        entity = gameObject.GetComponent<Entity>();
        attack.text = "" + entity.attack;
        health.text = "" + entity.health;
    }

    public void Refresh()
    {
        attack.text = "" + entity.attack;
        health.text = "" + entity.health;
    }


}
