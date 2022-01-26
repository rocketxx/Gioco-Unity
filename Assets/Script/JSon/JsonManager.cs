using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JsonManager : MonoBehaviour
{
    private Collector collector = new Collector();
    
    // Start is called before the first frame update
    void Awake()
    {
        TextAsset jsonAsset = Resources.Load("Loading") as TextAsset;
        Debug.Log(jsonAsset);
        collector = JsonUtility.FromJson<Collector>(jsonAsset.text);

    }

    // Update is called once per frame
    void Start()
    {
        foreach(Model model in collector.jsonList)
        {
            Debug.Log(model.id + " " + model.description);
            foreach(string element in model.lista)
            {
                Debug.Log(element);
            }
        }


        Model newModel = new Model();
        newModel.id = 5;
        newModel.description = "Description";
        newModel.lista = new string[1];
        newModel.lista[0] = "Hello";

        Collector coll = new Collector();
        coll.jsonList = new List<Model>();
        coll.jsonList.Add(newModel);


        //string jsonSaving = JsonUtility.ToJson(newModel);
        string jsonSaving = JsonUtility.ToJson(coll);
        Debug.Log(jsonSaving);
        string filePath = Path.Combine(Application.streamingAssetsPath, "Saving.json");
        File.WriteAllText(filePath, jsonSaving);
    }
}
