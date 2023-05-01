using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceduralGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelModule_Start;
    [SerializeField] private Transform levelModule_1;

    public List<Transform> easySlowBucket;
    public List<Transform> easyMediumBucket;
    public List<Transform> easyFastBucket;
    public List<Transform> hardSlowBucket;
    public List<Transform> hardMediumBucket;
    public List<Transform> hardFastBucket;

    Vector3 lastEndPosition;

    [Header("Generation rules variables")]
    float playTime;
    public int playerLength;
    public float f;
    PCMovement pCMovement;
    public float playerSpeed;

    
    
    public enum RulesStates
    {
        First_Thirty,
        Second_Thirty,
        Third_Thirty,
        Fourth_Thirty,
        Fifth_Thirty,
        Sixth_Thirty,
        Last_Thirty
    }

    public RulesStates currentRulesState;

        
    private void Awake()
    {
        lastEndPosition = levelModule_Start.Find("EndPoint").position;

        InvokeRepeating("SpawnCounter", 1f, 1f);
        pCMovement = FindObjectOfType<PCMovement>(); //Reference the PCMovement script
       
    }

    private void Start()
    {        
        currentRulesState = RulesStates.First_Thirty;
                
    }

    private void Update()
    {
        playTime = Time.timeSinceLevelLoad; //set the time to start counting when the scene loads
        //Debug.Log("Time in the scene:" + playTime);
        
        
    }

    void SpawnModule()
    {
        Transform newModuleGenerated = SpawnModule(lastEndPosition);
        lastEndPosition = newModuleGenerated.Find("EndPoint").position;
    }

    Transform ChooseModuleToSpawn()
    {
        playerLength = pCMovement.playerCharacterBalls.Count; //Assign playerLength the number of items in the player character balls list
        //Debug.Log("The balls in the scene:" + playerLength);

        
        //Debug.Log("Speed is:" + playerSpeed);

        Transform chosenModule = null;

        /*if(Time.time < 10f)
        {
            chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
        }
        else if (Time.time >= 10f)
        {
            chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
        }*/

        switch (currentRulesState)
        {
            case RulesStates.First_Thirty:

                f = Random.value;

                playerSpeed = 5f;

                
                if (playerLength <= 5)
                {                    
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength >5 && playerLength <= 10 && f > 0.3) //70% chance
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 5 && playerLength <= 10 && f <= 0.3) //30% chance
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 10 && f<= 0.3) //30% chance
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && f> 0.3 && f <= 0.6) //30% chance
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 10 && f> 0.6 && f <= 0.9) //30% chance
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 10 && f >= 0.9) //10% chance
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }
                

                if (playTime >= 30f)
                {
                    if (currentRulesState != RulesStates.Second_Thirty)
                    {
                        currentRulesState = RulesStates.Second_Thirty;
                    }
                }

                break;

            case RulesStates.Second_Thirty:

                f = Random.value;

                playerSpeed = 7f;

                if (playerLength <= 10 && f > 0.4) //60% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength <= 10 && f>0.1 && f <= 0.4) //30% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength <= 10 && f <= 0.1) //10% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f > 0.5) //50% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.2 && f <= 0.5) //30% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f <= 0.2) //20% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f > 0.9) //10% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.7 && f <= 0.9) //20% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f > 0.4 && f <= 0.7) //30% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f > 0.1 && f <= 0.4) //30% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength >30 && f > 0.7) //30% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 30 && f>0.5 && f <= 0.7) //20% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 30 && f>0.1 && f <= 0.5) //40% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 30 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }

                if (playTime >= 60f)
                {
                    if (currentRulesState != RulesStates.Third_Thirty)
                    {
                        currentRulesState = RulesStates.Third_Thirty;
                    }
                }

                break;

            case RulesStates.Third_Thirty:

                f = Random.value;

                playerSpeed = 9f;

                if (playerLength <= 10) //100% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <=20 && f > 0.4) //60% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.3 && f <= 0.4) //10% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.2 && f <= 0.3) //10% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f >0.1 && f <= 0.2) //10% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f > 0.8) //20% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.7 && f <= 0.8) //10% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.5 && f <= 0.7) //20% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.3 && f <= 0.5) //20% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f >0.1 && f <= 0.3) //20% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }
                else if (playerLength > 30 && f > 0.7) //30% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 30 && f>0.4 && f <= 0.7) //30% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 30 && f <= 0.4) //40% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }


                if (playTime >= 90f)
                {
                    if (currentRulesState != RulesStates.Fourth_Thirty)
                    {
                        currentRulesState = RulesStates.Fourth_Thirty;
                    }
                }

                break;

            case RulesStates.Fourth_Thirty:

                f = Random.value;

                playerSpeed = 12f;

                if (playerLength <= 10 && f > 0.2) //80% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength <= 10 && f>0.1 && f <= 0.2) //10% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength <= 10 && f <= 0.1) //10% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f > 0.6) //40% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.4 && f <= 0.6) //20% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.2 && f <= 0.4) //20% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f <= 0.2) //20% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 &&  f > 0.8) //20% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.7 && f <= 0.8) //10% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.5 && f <= 0.7) //20% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.3 && f <= 0.5) //20% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.1 && f <= 0.3) //20% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }
                else if (playerLength > 30 && f > 0.9) //10% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 30 && f>0.7 && f <= 0.9) //20% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 30 && f<=0.7) //70% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }

                if (playTime >= 120f)
                {
                    if (currentRulesState != RulesStates.Fifth_Thirty)
                    {
                        currentRulesState = RulesStates.Fifth_Thirty;
                    }
                }

                break;

            case RulesStates.Fifth_Thirty:

                f = Random.value;

                playerSpeed = 14f;

                if (playerLength <= 10 && f >0.3) //70% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength <= 10 && f>0.1 && f <= 0.3) //20% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength <= 10 && f <= 0.1) //10% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f > 0.6) //40% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.4 && f <= 0.6) //20% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.1 && f <= 0.4) //30% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f > 0.8) //20% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f > 0.4 && f <= 0.8) //40% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.1 && f <= 0.4) //30% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }
                else if (playerLength > 30 && f > 0.7) //30% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 30 && f> 0.4 && f <= 0.7) //30% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 30 && f <= 0.4) //40% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }

                if (playTime >= 150f)
                {
                    if (currentRulesState != RulesStates.Sixth_Thirty)
                    {
                        currentRulesState = RulesStates.Sixth_Thirty;
                    }
                }

                break;

            case RulesStates.Sixth_Thirty:

                f = Random.value;

                playerSpeed = 16f;

                if (playerLength <= 10 && f > 0.4) //60% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength <= 10 && f>0.1 && f <= 0.4) //30% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength <= 10 && f <= 0.1) //10% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f > 0.6) //40% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.4 && f <= 0.6) //20% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.1 && f <= 0.4) //30% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f > 0.9) //10% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.7 && f <= 0.9) //20% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.4 && f <= 0.7) //30% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.1 && f <= 0.4) //30% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }
                else if (playerLength > 30 && f > 0.9) //10% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 30 && f>0.5 && f <= 0.9) //40% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 30 && f <= 0.5) //50% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }


                if (playTime >= 180f)
                {
                    if (currentRulesState != RulesStates.Last_Thirty)
                    {
                        currentRulesState = RulesStates.Last_Thirty;
                    }
                }

                break;

            case RulesStates.Last_Thirty:

                f = Random.value;

                playerSpeed = 18f;

                if (playerLength <= 10 && f > 0.7) //30% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength <= 10 && f>0.4 && f <= 0.7) //30% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength <= 10 && f>0.2 && f <= 0.4) //20% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength <= 10 && f <= 0.2) //20% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f > 0.8) //20% chance 
                {
                    chosenModule = easySlowBucket[Random.Range(0, easySlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.6 && f <= 0.8) //20% chance 
                {
                    chosenModule = easyMediumBucket[Random.Range(0, easyMediumBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.3 && f <= 0.6) //30% chance 
                {
                    chosenModule = easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f>0.2 && f <= 0.3) //10% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 10 && playerLength <= 20 && f <= 0.2) //20% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f > 0.8) //20% chance 
                {
                    chosenModule =easyFastBucket[Random.Range(0, easyFastBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.4 && f <= 0.8) //40% chance 
                {
                    chosenModule = hardSlowBucket[Random.Range(0, hardSlowBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f>0.1 && f <= 0.4) //30% chance 
                {
                    chosenModule = hardMediumBucket[Random.Range(0, hardMediumBucket.Count)];
                }
                else if (playerLength > 20 && playerLength <= 30 && f <= 0.1) //10% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }
                else if (playerLength > 30) //100% chance 
                {
                    chosenModule = hardFastBucket[Random.Range(0, hardFastBucket.Count)];
                }


                break;
        } 


        return chosenModule;
    }

    private Transform SpawnModule(Vector3 spawnPosition)
    {
        Transform pickedModule = ChooseModuleToSpawn();
        Transform levelModule = Instantiate(pickedModule,spawnPosition, Quaternion.identity);

                
        return levelModule;
                
    }

    void SpawnCounter()
    {       
        SpawnModule();
    }

    
        
}
