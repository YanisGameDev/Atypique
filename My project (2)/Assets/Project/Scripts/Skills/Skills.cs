using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cette class me permet de centraliser toutes les compétences.
/// Ces dernières sont appeler dans les classes enfant de PlayerCharacter.
/// </summary>
public class Skills
{
    //Le dictionary me permet de trouver facilement une compétence via son nom.
    private Dictionary<string, GameObject> d_Skills = new Dictionary<string, GameObject>();

    /// <summary>
    /// Dans le constructeur je recherche toutes les préfabs de compétences se trouvant le dossier "Resources" et de les ajouter a mon Dictionary.
    /// </summary>
    public Skills()
    {
        List<GameObject> vfxPrefabsList = new List<GameObject>();
        vfxPrefabsList.AddRange(Resources.LoadAll<GameObject>("Skills"));

        for (int i = 0; i < vfxPrefabsList.Count; i++)
        {
            d_Skills.Add(vfxPrefabsList[i].name, vfxPrefabsList[i]);
            Debug.Log(vfxPrefabsList[i].name + " has been added in dictionary.");
        }
    }

    public GameObject Shield()
    {
        return d_Skills["ShieldEffect"];
    }

    public GameObject MortalStrike()
    {
        return d_Skills["SlashEffect"];
    }

    public GameObject FireBolt()
    {
        return d_Skills["FireBolt"];
    }
}
