using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CrossControl : MonoBehaviour
{
    [Header("West")]
    public bool westStraight;
    public bool westRight;
    [Header("East")]
    public bool eastStraight;
    public bool eastLeft;
    [Header("South")]
    public bool southRight;
    public bool southLeft;
    [Header("Pedestrians")]
    public bool southWest;
    public bool southEast;
    public bool eastSouth;
    public bool eastNorth;

    [Header("Time")]
    public int sysSec = 0;
    public int seconds;
    private int m_seconds;

    [Header("Reading")]
    public bool read = false;
    public static bool automaticRead = false;
    public static bool automaticControl = false;
    public string path;
    public static string fileName;

    [Header("Lists")]
    public List<string> spawnCodes;
    public List<Spawner> carSpawns;
    public List<PedestrianSpawning> pedestrianSpawns;


    [Header("Car Spawners")]
    public GameObject carSpawnWS1;
    public GameObject carSpawnWS2;
    public GameObject carSpawnWR;
    public GameObject carSpawnES1;
    public GameObject carSpawnES2;
    public GameObject carSpawnEL;
    public GameObject carSpawnSR;
    public GameObject carSpawnSL2;
    public GameObject carSpawnSL1;

    private Spawner carScriptWS1;
    private Spawner carScriptWS2;
    private Spawner carScriptWR;
    private Spawner carScriptES1;
    private Spawner carScriptES2;
    private Spawner carScriptEL;
    private Spawner carScriptSR;
    private Spawner carScriptSL2;
    private Spawner carScriptSL1;

    [Header("Pedestrian Spawners")]

    public GameObject signSW;
    public GameObject signSE;
    public GameObject signES;
    public GameObject signEN;

    private PedestrianSpawning SW;
    private PedestrianSpawning SE;
    private PedestrianSpawning ES;
    private PedestrianSpawning EN;

    [Header("Counters")]

    public GameObject counterWS1;
    public GameObject counterWS2;
    public GameObject counterWR;
    public GameObject counterES1;
    public GameObject counterES2;
    public GameObject counterEL;
    public GameObject counterSR;
    public GameObject counterSL2;
    public GameObject counterSL1;

    private Counter WS1;
    private Counter WS2;
    private Counter WR;
    private Counter ES1;
    private Counter ES2;
    private Counter EL;
    private Counter SR;
    private Counter SL2;
    private Counter SL1;


    private int state;
    private bool busWS2;
    private bool busES2;
    private bool backdoor;
    private bool flag;
    private bool readSpawns;

    public void Start()
    {

    state = 0;
    backdoor = false;
    path = Application.dataPath + "/" + fileName + ".txt";

    spawnCodes = new List<string> { "000", "000", "000", "000", "000", "000", "000", "000", "000", "0", "0", "0", "0" };

        carScriptWS1 = carSpawnWS1.GetComponent<Spawner>();
        carScriptWS2 = carSpawnWS2.GetComponent<Spawner>();
        carScriptWR = carSpawnWR.GetComponent<Spawner>();
        carScriptES1 = carSpawnES1.GetComponent<Spawner>();
        carScriptES2 = carSpawnES2.GetComponent<Spawner>();
        carScriptEL = carSpawnEL.GetComponent<Spawner>();
        carScriptSR = carSpawnSR.GetComponent<Spawner>();
        carScriptSL2 = carSpawnSL2.GetComponent<Spawner>();
        carScriptSL1 = carSpawnSL1.GetComponent<Spawner>();

        WS1 = counterWS1.GetComponent<Counter>();
        WS2 = counterWS2.GetComponent<Counter>();
        WR = counterWR.GetComponent<Counter>();
        ES1 = counterES1.GetComponent<Counter>();
        ES2 = counterES2.GetComponent<Counter>();
        EL = counterEL.GetComponent<Counter>();
        SR = counterSR.GetComponent<Counter>();
        SL2 = counterSL2.GetComponent<Counter>();
        SL1 = counterSL1.GetComponent<Counter>();

        SW = signSW.GetComponent<PedestrianSpawning>();
        SE = signSE.GetComponent<PedestrianSpawning>();
        ES = signES.GetComponent<PedestrianSpawning>();
        EN = signEN.GetComponent<PedestrianSpawning>();
    }
    void Update()
    {
        AutomaticCrossControl(automaticControl);

        sysSec = System.DateTime.Now.Second;
        seconds = GetDigit(sysSec);
        if (automaticRead)
        {
            if (seconds != m_seconds && (seconds == 1 || seconds == 6))
            {
                read = true;
                m_seconds = seconds;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (read)
        {
            ReadFile();
            if (spawnCodes[0] != "0")
            {
                carScriptWS1.StartReading();
            }
            if (spawnCodes[1] != "0")
            {
                carScriptWS2.StartReading();
            }
            if (spawnCodes[2] != "0")
            {
                carScriptWR.StartReading();
            }
            if (spawnCodes[3] != "0")
            {
                carScriptES1.StartReading();
            }
            if (spawnCodes[4] != "0")
            {
                carScriptES2.StartReading();
            }
            if (spawnCodes[5] != "0")
            {
                carScriptEL.StartReading();
            }
            if (spawnCodes[6] != "0")
            {
                carScriptSR.StartReading();
            }
            if (spawnCodes[7] != "0")
            {
                carScriptSL2.StartReading();
            }
            if (spawnCodes[8] != "0")
            {
                carScriptSL1.StartReading();
            }
            if (spawnCodes[9] != "0")
            {
                SW.StartReading();
            }
            if (spawnCodes[10] != "0")
            {
                SE.StartReading();
            }
            if (spawnCodes[11] != "0")
            {
                ES.StartReading();
            }
            if (spawnCodes[12] != "0")
            {
                EN.StartReading();
            }

            read = false;

        }

    }

    void ReadFile()
    {
        using(StreamReader sr = new StreamReader(path))
        {
            for (int i = 0; i < 13; i++)
            {
                spawnCodes[i] = sr.ReadLine();
            }
        }
    }

    public int GetDigit(int seconds)
    {
        string temp = seconds.ToString();
        int[] array = new int[temp.Length];
        for (int i = 0; i< array.Length; i++)
        {
            array[i] = (int)(temp[i] - '0');
        }
        return array[array.Length-1];
    }

    void AutomaticCrossControl(bool isOn)
    {       
        if (WS2.busesCount > 0)
        {
            busWS2 = true;
        }
        else
        {
            busWS2 = false;
        }
        if (ES1.busesCount > 0)
        {
            busES2 = true;
        }
        else
        {
            busES2 = false;
        }

        
        
        if (isOn)
        {
            switch (state)
            {
                case 0:
                    westStraight = false;
                    westRight = false;
                    eastStraight = false;
                    eastLeft = false;
                    southRight = false;
                    southLeft = false;
                    southWest = false;
                    southEast = false;
                    eastSouth = false;
                    eastNorth = false;

                    if (WS1.carsCount > 0 || WS2.carsCount > 0 || ES1.carsCount > 0 || ES2.carsCount > 0 || busES2 || busWS2 || SW.pedestrianCount > 0 || SE.pedestrianCount > 0)
                    {
                        backdoor = true;
                        state = 1;
                    }
                    else if(SR.carsCount > 0 || EL.carsCount > 0)
                    {
                        backdoor = true;
                        state = 2;
                    }
                    else if (SL1.carsCount > 0 || SL2.carsCount > 0 || EN.pedestrianCount > 0 || ES.pedestrianCount > 0)
                    {
                        backdoor = true;
                        state = 3;
                    }
                    break;
                case 1:
                    if (flag == false)
                    {
                        StartCoroutine(StartTimer(45f));
                        flag = true;
                    }
                    if ((WS1.carsCount == 0 && WS2.carsCount == 0 && !busWS2 && WR.carsCount == 0) || backdoor)
                    {
                        backdoor = false;
                        StopAllCoroutines();

                        eastNorth = false;
                        if (WS1.carsCount == 0 && WS2.carsCount == 0 && !busWS2)
                        {
                            westStraight = false;
                        }
                        if (WR.carsCount == 0)
                        {
                            westRight = false;
                        }
                        if (WS1.carsCount > 0 || WS2.carsCount > 0 || ES1.carsCount > 0 || ES2.carsCount > 0 || busES2 || busWS2 || SW.pedestrianCount > 0 || SE.pedestrianCount > 0)
                        {
                            westStraight = true;
                            westRight = true;
                            eastStraight = true;
                            southWest = true;
                            southEast = true;
                            Debug.Log(state);
                            state = 2;
                            flag = false;
                        }
                        else
                        {
                            Debug.Log(state);
                            state = 2;
                            flag = false;

                            westStraight = false;
                            westRight = false;
                        }
                    }
                    break;
                case 2:
                    if (flag == false)
                    {
                        StartCoroutine(StartTimer(45f));
                        flag = true;
                    }
                    if ((WS1.carsCount == 0 && WS2.carsCount == 0 && ES1.carsCount == 0 && ES2.carsCount == 0 && !busES2 && !busWS2 && SW.pedestrianCount == 0 && SE.pedestrianCount == 0) || backdoor)
                    {
                        backdoor = false;
                        StopAllCoroutines();
                        westStraight = false;
                        westRight = false;
                        if (ES1.carsCount == 0 && ES2.carsCount == 0 && !busES2)
                        {
                            eastStraight = false;
                        }
                        southWest = false;
                        southEast = false;

                        if(busES2 || busWS2)
                        {
                            eastStraight = false;
                            state = 0;
                            break;
                        }

                        if (ES1.carsCount > 0 || ES2.carsCount > 0 || EL.carsCount > 0 || busES2 || SR.carsCount > 0)
                        {
                            eastStraight = true;
                            eastLeft = true;
                            southRight = true;
                            Debug.Log(state);
                            state = 3;
                            flag = false;
                        }
                        else
                        {
                            eastStraight = false;
                            Debug.Log(state);
                            state = 3;
                            flag = false;
                        }
                    }                  
                    
                    break;
                case 3:
                    if (flag == false)
                    {
                        StartCoroutine(StartTimer(45f));
                        flag = true;
                    }
                    if ((ES1.carsCount == 0 && ES2.carsCount == 0 && EL.carsCount == 0 && !busES2 && SR.carsCount == 0) || backdoor)
                    {
                        backdoor = false;
                        StopAllCoroutines();

                        eastStraight = false;
                        eastLeft = false;
                        southRight = false;

                        if (busES2 || busWS2)
                        {
                            state = 0;
                            break;
                        }

                        if (SL1.carsCount > 0 || SL2.carsCount > 0 || ES.pedestrianCount > 0 || EN.pedestrianCount > 0)
                        {
                            southLeft = true;
                            westRight = true;
                            eastNorth = true;
                            eastSouth = true;
                            Debug.Log(state);
                            state = 4;
                            flag = false;
                        }
                        else
                        {
                            Debug.Log(state);
                            state = 4;
                            flag = false;
                        }
                    }
                    break;
                case 4:
                    if (flag == false)
                    {
                        StartCoroutine(StartTimer(45f));
                        flag = true;
                    }
                    if ((SL1.carsCount == 0 && SL2.carsCount == 0 && ES.pedestrianCount == 0 && EN.pedestrianCount == 0) || backdoor)
                    {
                        backdoor = false;
                        StopAllCoroutines();

                        southLeft = false;
                        eastSouth = false;
                        if(EN.pedestrianCount == 0)
                        {
                            eastNorth = false;
                        }
                        if(WR.carsCount == 0)
                        {
                            westRight = false;
                        }

                        if (busES2 || busWS2)
                        {
                            eastNorth = false;
                            westRight = false;
                            state = 0;
                            break;
                        }

                        if (WS1.carsCount > 0 || WS2.carsCount > 0 || busWS2 || WR.carsCount > 0)
                        {
                            westStraight = true;
                            westRight = true;
                            eastNorth = true;
                            Debug.Log(state);
                            state = 5;
                            flag = false;
                        }
                        else
                        {
                            eastNorth = false;
                            westRight = false;
                            Debug.Log(state);
                            state = 5;
                            flag = false;
                        }
                    }
                    break;
                case 5:
                    if (flag == false)
                    {
                        StartCoroutine(StartTimer(45f));
                        flag = true;
                    }
                    if ((WS1.carsCount == 0 && WS2.carsCount == 0 && WS2.busesCount == 0) || backdoor)
                    {
                        backdoor = false;
                        StopAllCoroutines();

                        Debug.Log(state);
                        state = 0;
                        flag = false;
                    }
                    break;
            }

        }
    }
    IEnumerator StartTimer(float period)
    {
        yield return new WaitForSeconds(period);
        backdoor = true;        
    }
}