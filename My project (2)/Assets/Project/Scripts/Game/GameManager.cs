using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private List<PlayerCharacter> characterList = new List<PlayerCharacter>();
    [SerializeField] private int numbOfPlayer = 2;

    [SerializeField] List<PlayerCharacter> prefabsCharacters = new List<PlayerCharacter>();

    public MapGeneration map = null;

    GameObject parentTeamOne;
    GameObject parentTeamTwo;
    public enum Team
    {
        TeamOne,
        TeamTwo
    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartParty();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartParty()
    {
        CreateMap();
        GeneratePlayer();
    }

    private void GeneratePlayer()
    {
        parentTeamOne = new GameObject("TeamOne");
        parentTeamTwo = new GameObject("TeamTwo");

        for (int i = 0; i < numbOfPlayer; i++)
        {
            int rand = Random.Range(0, numbOfPlayer);
            characterList.Add(Instantiate(prefabsCharacters[rand]));
            if (i % 2 == 0)
            {
                characterList[characterList.Count - 1].transform.SetParent(parentTeamOne.transform);
                characterList[characterList.Count - 1].team = Team.TeamOne;
            }
            else
            {
                characterList[characterList.Count - 1].transform.SetParent(parentTeamTwo.transform);
                characterList[characterList.Count - 1].team = Team.TeamTwo;
            }
        }
    }

    private void CreateMap()
    {
        map = Instantiate(map);
    }
}
