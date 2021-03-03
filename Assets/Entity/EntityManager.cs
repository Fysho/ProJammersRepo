using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance;

    private List<Entity> _friendlyEntities;
    private List<Entity> _enemyEntities;

    public GameObject[] _friendlyEntityList;
    public GameObject[] _enemyEntityList;
    private List<EntitySlot> _entitySlots;

    private class EntitySlot
    {
        public int xpos;
        public int ypos;
        public bool taken;

        public EntitySlot(int x, int y)
        {
            Debug.Log("new struct");
            xpos = x;
            ypos = y;
            taken = false;
        }

        public void SetTaken(bool isTaken)
        {
            taken = isTaken;
        }
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            Debug.Log("NEW  INSTANCE");
            _friendlyEntities = new List<Entity>();
            _enemyEntities = new List<Entity>();
            _entitySlots = new List<EntitySlot>();
            _entitySlots.Add(new EntitySlot(100, 800));
            _entitySlots.Add(new EntitySlot(100, 700));
            _entitySlots.Add(new EntitySlot(100, 600));
            _entitySlots.Add(new EntitySlot(100, 500));
            _entitySlots.Add(new EntitySlot(100, 400));

            DontDestroyOnLoad(gameObject);        //Should this be here?
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        //foreach(EntitySlot slot in _entitySlots)
        //{
        //    Debug.Log(slot.taken);
        //}
    }

    public void SpawnFriendly(string entityType)
    {
        GameObject entityObject = null;
        Entity newEntity = null;
        if (entityType == "Rat")
        {
            entityObject = Instantiate(_friendlyEntityList[0]);
            newEntity = entityObject.GetComponent<RatEntity>();
        }
        else if (entityType == "Spider")
        {
            entityObject = Instantiate(_friendlyEntityList[1]);
            newEntity = entityObject.GetComponent<SpiderEntity>();
        }
        else if (entityType == "Wolf")
        {
            entityObject = Instantiate(_friendlyEntityList[2]);
            newEntity = entityObject.GetComponent<WolfEntity>();
        }
        if (entityObject == null || newEntity == null)
        {
            Debug.LogError("Problem creating entity: ");
            if(entityObject == null) Debug.LogError("entityObject is null");
            if(newEntity == null) Debug.LogError("newEntity is null");

        }
        entityObject.transform.SetParent(GameObject.Find("EntityParent").transform);
        _friendlyEntities.Add(newEntity);
        PlaceEntity(newEntity);
    }

    void PlaceEntity(Entity entity)
    {
        foreach(EntitySlot slot in _entitySlots)
        {
            
            Debug.Log(slot.taken);
            if (!slot.taken)
            {
                entity.transform.position = new Vector3(slot.xpos, slot.ypos, 0);
                slot.SetTaken(true);
                break;
            }
        }
       
    }
    
    //or BuffType
    //Race = rat, wolf etc
    //Type = dark, fire, ice etc
    //public void BuffRace(string race, int attack, int health)
    //{
    //    foreach(Entity entity in _friendlyEntities)
    //    {
    //        if(entity.race == race)
    //        {
    //            entity.buff(attack, health);
    //            entity.update();
    //        }
    //    }
    //}


}
