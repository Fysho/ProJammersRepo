using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerater : MonoBehaviour
{

    public class MapElement {
        public int column;
        public int layer;
        public bool isParent = false;
        public int parent = -1;
        public GameObject gameObject;

        public MapElement(GameObject go, int col, int lay)
        {
            gameObject = go;
            column = col;
            layer = lay;
        }
    }


    public GameObject[] artThings;
    public GameObject[] mapLines;

    public GameObject EntityContainer;
    public  int _columns = 10;
    public float _columnWidth = 3f;
    public float _xStart = -6;
    public float _midY = 0.0f;
    public float _yGap = 1.4f;
    public float _xrand = 1.0f;
    public float _yrand = 1.0f;
    public int _maxLayersPerColumn = 5;
    public int _layersBeforeMin = 4;
    private List<List<MapElement>> MapElements;

    System.Random _random;
    void Start()
    {
        MapElements = new List<List<MapElement>>();

        _random = new System.Random();
        int previousLayers = 0;

        for(int column = 0; column < _columns;  column++)
        {
            List<MapElement> columnElements = new List<MapElement>(); ;
            int layersThisColumn = 0;
            if(column == 0)
            {
                layersThisColumn = 1;
            }
            else if(column == 1)
            {
                layersThisColumn = 2;
            }
            else
            {
                if(previousLayers < _layersBeforeMin)
                {
                    layersThisColumn = previousLayers + (int)(_random.NextDouble() * 3);
                }
                else
                {
                    layersThisColumn = previousLayers + (int)(_random.NextDouble() * 5) - 2;
                }
                if (layersThisColumn > _maxLayersPerColumn) layersThisColumn = _maxLayersPerColumn;
            }

            for(int layer = 0; layer < layersThisColumn; layer++)
            {
                float xrand = (float) _random.NextDouble() * _xrand;
                float yrand = (float)_random.NextDouble() * _yrand;

                float gap = _yGap;
                float firstY = (layersThisColumn - 1) * (gap * 0.5f);
                float thisY = firstY - layer * gap;
                int card = (int) (_random.NextDouble() * artThings.Length);
                GameObject newThing = GameObject.Instantiate(artThings[card]);
                newThing.transform.position = new Vector3(_xStart + column * _columnWidth + xrand, thisY + yrand, 0);
                MapElement mapElement = new MapElement(newThing, column, layer);
                columnElements.Add(mapElement);
            }

            MapElements.Add(columnElements);
            previousLayers = layersThisColumn;
        }

        for(int col = MapElements.Count - 1; col >= 1; col--)
        {
            List<MapElement> column = MapElements[col];
            List<MapElement> priorColumn = MapElements[col-1];

            foreach (MapElement mapElement in column)
            {
                foreach(MapElement lastElements in priorColumn)
                {
                    if(lastElements.isParent == false)
                    {
                        mapElement.parent = lastElements.layer;
                        lastElements.isParent = true;
                        DrawLine(mapElement, lastElements);
                        break;
                    }
                }
            }
        }


    }

    void DrawLine(MapElement m1, MapElement m2)
    {
        float lineJump = 0.2f;

        Vector3 pos1 = m1.gameObject.transform.position;
        Vector3 pos2 = m2.gameObject.transform.position;
        Vector3 direction = pos2 - pos1;
        float distance = direction.magnitude;
        direction = direction.normalized;
        float runningDistance = 0;
        Vector3 currentPoint = pos1;

        runningDistance += lineJump * 2;
        currentPoint += lineJump * direction * 2;

        while (runningDistance < distance - lineJump * 3)
        {
            runningDistance += lineJump;
            currentPoint += lineJump * direction;

            int line = (int)(_random.NextDouble() * mapLines.Length);
            GameObject newThing = GameObject.Instantiate(mapLines[line]);
            newThing.transform.position = currentPoint;

        }
    }

    void Update()
    {
        
    }
}
