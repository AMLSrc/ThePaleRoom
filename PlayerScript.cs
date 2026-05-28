using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public List<IconInfo> IconsRaw;
    public List<Area> AllAreas;

    private GameObject Test;
    private GameObject Pitcher;
    private GameObject Tag;
    private GameObject Drunk;
    private GameObject Window;

    private List<string> TList = new List<string>();
    private string[] Items = new string [6];
    
    private int N = 0;  //number of text segments
    private int M;      //stops intext
    private int I = 0;  //checks inventory
    private int C;      //used for checking your inventory;
    private int CI;     //Compare I and C
    private int CI2;    //Compare again

    private Vector3 Active = new Vector3(0, -4, 0);
    private Vector3 Inactive = new Vector3(0, -7, 0);
    private Vector3 ActiveArea = new Vector3(0, 1, 0);
    private Vector3 InactiveArea = new Vector3(0, 11, 0);

    private GameObject PlayerUIItems;
    private GameObject PlayerUIText;
    private GameObject StartRoom;
    private GameObject BlueRoom;
    private GameObject PaleRoom;
    private GameObject RedRoom;

    private GameObject TextTime;
    private SpriteRenderer TTSR;
    public TextMeshPro PlayerText;
    public List<SpriteRenderer> Inventory;

    public GameObject Slot1;
    public SpriteRenderer Item1;
    public GameObject Slot2;
    public SpriteRenderer Item2;
    public GameObject Slot3;
    public SpriteRenderer Item3;
    public GameObject Slot4;
    public SpriteRenderer Item4;
    public GameObject Slot5;
    public SpriteRenderer Item5;
    public GameObject Slot6;
    public SpriteRenderer Item6;

    public SpriteRenderer CupObject;
    public SpriteRenderer SkeletonObject;
    public SpriteRenderer DoorObject;
    public SpriteRenderer GuyObject;
    public SpriteRenderer LeftWindow;
    public SpriteRenderer RightWindow;

    public bool InText = false;
    public bool HasItem;
    public bool HasItem2;
    public bool HaveR = false;
    public bool HaveL = false;
    public bool HaveE = false;
    public bool HaveP = false;
    public bool Discard = false;
    public bool OpenWindowL = false;
    public bool OpenWindowR = false;
    public bool MegaCheck = false;
    public bool End = false;

    public string Dialogue;
    public GameObject CurrentArea;
    public string AreaReference = "StartRoom";
    public string Check;
    public string Check2;
    public string Remove = "";
    
    public Sprite TestItem;
    public Sprite PitcherIcon;

    public Sprite Cup;
    public Sprite CupFilled;
    public Sprite Skeleton;
    public Sprite SkeletonComplete;
    public Sprite Guy;
    public Sprite GuyComplete;
    public Sprite WindowC;
    public Sprite WindowO;
    public Sprite Exit;
    public Sprite YouCanExit;
    
    void Start()
    {

        PlayerUIItems = GameObject.FindWithTag("UIItems");
        PlayerUIText = GameObject.FindWithTag("UIText");

        BlueRoom = GameObject.FindWithTag("BlueRoom");
        PaleRoom = GameObject.FindWithTag("PaleRoom");
        RedRoom = GameObject.FindWithTag("RedRoom");
        StartRoom = GameObject.FindWithTag("StartRoom");
        
        CurrentArea = GameObject.Find(AreaReference);

        Test = GameObject.FindWithTag("Test");
        TextTime = GameObject.FindWithTag("Fade");
        TTSR = GameObject.FindWithTag("Fade").GetComponent<SpriteRenderer>();
        
        Pitcher = GameObject.FindWithTag("Pitcher");
        Tag = GameObject.FindWithTag("TableTag");
        Drunk = GameObject.FindWithTag("Drunk");
        Window = GameObject.FindWithTag("Window");

        
        Items[0] = "";
        Items[1] = "";
        Items[2] = "";
        Items[3] = "";
        Items[4] = "";
        Items[5] = "";
        
        Slot1 = GameObject.FindWithTag("Item1");
        Item1 = GameObject.FindWithTag("Item1").GetComponent<SpriteRenderer>();
        Slot2 = GameObject.FindWithTag("Item2");
        Item2 = GameObject.FindWithTag("Item2").GetComponent<SpriteRenderer>();
        Slot3 = GameObject.FindWithTag("Item3");
        Item3 = GameObject.FindWithTag("Item3").GetComponent<SpriteRenderer>();
        Slot4 = GameObject.FindWithTag("Item4");
        Item4 = GameObject.FindWithTag("Item4").GetComponent<SpriteRenderer>();
        Slot5 = GameObject.FindWithTag("Item5");
        Item5 = GameObject.FindWithTag("Item6").GetComponent<SpriteRenderer>();
        Slot6 = GameObject.FindWithTag("Item6");
        Item6 = GameObject.FindWithTag("Item6").GetComponent<SpriteRenderer>();

        CupObject = GameObject.FindWithTag("Cup").GetComponent<SpriteRenderer>();
        SkeletonObject = GameObject.FindWithTag("Skeleton").GetComponent<SpriteRenderer>();
        GuyObject = GameObject.FindWithTag("Guy").GetComponent<SpriteRenderer>();
        DoorObject = GameObject.FindWithTag("WinDoor").GetComponent<SpriteRenderer>();
        LeftWindow = GameObject.FindWithTag("LWindow").GetComponent<SpriteRenderer>();
        RightWindow = GameObject.FindWithTag("RWindow").GetComponent<SpriteRenderer>();
        
        GameObject[] invs = GameObject.FindGameObjectsWithTag("MenuColor");
        foreach (GameObject go in invs)
        {
            Inventory.Add(go.GetComponent<SpriteRenderer>());
        }
        
        

    }

    void Update()
    {

        foreach (SpriteRenderer sr in Inventory)
        {
            
            //sr.color = new Color(0.19215686274509805f, 0.30196078431372547f, 0.4745098039215686f);
            
        }

        if (InText == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                N++;
                Dialogue = TList[N];
                PlayerText.text = Dialogue;

            }

            if (N >= M - 1)
            {
                
                TTSR.color = new Color(0, 0, 0, 0);
                PlayerText.text = "";
                TList.Clear();
                N = 0;

                PlayerUIText.transform.position = Inactive;
                PlayerUIItems.transform.position = Active;
                InText = false;

                if (End == true)
                {

                    SceneManager.LoadScene("End");

                }

                if (Remove != "")
                {

                    Debug.Log(I);

                    if (I == 0)
                    {
                        
                        I = I + 1;
                        
                        Item1.sprite = GetIcon(Remove);
                        Item1.color = new Color(1, 1, 1, 1);
                        Items[I] = Remove;
                        Remove = "";

                        //if (C == I && Discard == true) EmptyInv = true;

                    }
                    else if (I == 1)
                    {
                        
                        I = I + 1;
                        
                        Item2.sprite = GetIcon(Remove);
                        Item2.color = new Color(1, 1, 1, 1);
                        Items[I] = Remove;
                        Remove = "";

                    }
                    else if (I == 2)
                    {
                        
                        I = I + 1;
                        
                        Item3.sprite = GetIcon(Remove);
                        Item3.color = new Color(1, 1, 1, 1);
                        Items[I] = Remove;
                        Remove = "";

                    }
                    else if (I == 3)
                    {
                        
                        I = I + 1;
                        
                        Item4.sprite = GetIcon(Remove);
                        Item4.color = new Color(1, 1, 1, 1);
                        Items[I] = Remove;
                        Remove = "";

                    }
                    else if (I == 4)
                    {
                        
                        I = I + 1;
                        
                        Item5.sprite = GetIcon(Remove);
                        Item5.color = new Color(1, 1, 1, 1);
                        Items[I] = Remove;
                        Remove = "";

                    }
                    else if (I == 5)
                    {
                        
                        I = I + 1;
                        
                        Item6.sprite = GetIcon(Remove);
                        Item6.color = new Color(1, 1, 1, 1);
                        Items[I] = Remove;
                        Remove = "";

                    }
                    
                    Destroy(GameObject.FindWithTag(Remove));

                    // Debug.Log(Items[0]);
                    // Debug.Log(Items[1]);
                    // Debug.Log(Items[2]);
                    // Debug.Log(Items[3]);
                    // Debug.Log(Items[4]);
                    // Debug.Log(Items[5]);

                }

            }

        }
        
        // if (EmptyInv == true)
        // {
        //
        //     Item1.color = new Color(0, 0, 0, 0);
        //     Items[C] = "";
        //
        // }

        if (Input.GetMouseButtonDown(0) && InText == false)
        {

            Ray PlayerClick = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(PlayerClick, Mathf.Infinity);
            
            Debug.Log(hit.transform.tag);

            /*if (hit.transform.tag == "Test")
            {
                
                TList.Add("Nice text idiot");
                TList.Add("Bet it doesn't even work as intended");
                TList.Add("Dumbass");
                
                TextManager();

            }
            
            if (hit.transform.tag == "Test2")
            {
                
                TList.Add("Ok, wait");
                TList.Add("This might actually work");

                TextManager();

            }
            
            if (hit.transform.tag == "Test3")
            {
                
                TList.Add("I'm taking this");
                Remove = "Test3";

                TextManager();

            }*/

            if (hit.transform.tag == "BlueDoor")
            {

                BlueRoom.transform.position = ActiveArea;
                CurrentArea.transform.position = InactiveArea;
                CurrentArea = BlueRoom;

            }
            
            if (hit.transform.tag == "PaleDoor")
            {

                PaleRoom.transform.position = ActiveArea;
                CurrentArea.transform.position = InactiveArea;
                CurrentArea = PaleRoom;
                

            }
            
            if (hit.transform.tag == "RedDoor")
            {

                RedRoom.transform.position = ActiveArea;
                CurrentArea.transform.position = InactiveArea;
                CurrentArea = RedRoom;
                

            }

            if (hit.transform.tag == "Return" && CurrentArea != StartRoom)
            {
                
                StartRoom.transform.position = ActiveArea;
                CurrentArea.transform.position = InactiveArea;
                CurrentArea = StartRoom;
                
            }

            if (hit.transform.tag == "Pitcher")
            {
                
                TList.Add("...");
                TList.Add("It's almost empty");
                TList.Add("...");
                
                if (HaveP == false)
                {
                    
                    Remove = "Pitcher";
                    HaveP = true;

                }  

                TextManager();

            }
            
            if (hit.transform.tag == "TableTag")
            {
                
                TList.Add("It says:");
                TList.Add("\"Monsieur Waiter! I am feeling quite parched!\"");

                Check = "Pitcher";
                
                DoYouHave();

                if (HasItem == true)
                {
                    
                    TList.Add("...");
                    CupObject.sprite = CupFilled;
                    LeftWindow.sprite = WindowO;
                    OpenWindowL = true;

                    HasItem = false;
                    Discard = true;

                }
                
                TextManager();

            }
            
            if (hit.transform.tag == "Drunk")
            {
                
                TList.Add("He's just asleep");

                TextManager();

            }
            
            if (hit.transform.tag == "LWindow" && OpenWindowL == true)
            {
                
                TList.Add("It feels warm...");
                TList.Add("It feels... soft");
                TList.Add("It feels...");
                TList.Add("Boney");

                if (HaveL == false)
                {
                    
                    Remove = "LeftArm";
                    HaveL = true;

                }                
                TextManager();

            }
            
            if (hit.transform.tag == "LWindow" && OpenWindowL == false)
            {
                
                TList.Add("...");
                TList.Add("It's locked");

                TextManager();

            }

            if (hit.transform.tag == "RWindow" && OpenWindowR == true)
            {
                
                TList.Add("...");
                TList.Add("It's wet");

                if (HaveR == false)
                {
                    
                    Remove = "RightArm";
                    HaveR = true;

                }

                TextManager();

            }
            
            if (hit.transform.tag == "RWindow" && OpenWindowR == false)
            {
                
                TList.Add("...");
                TList.Add("It's locked");

                TextManager();

            }
            
            if (hit.transform.tag == "Window")
            {
                
                TList.Add("...");
                TList.Add("...?");
                TList.Add("Is this just painted on?");

                TextManager();

            }

            if (hit.transform.tag == "Eye")
            {
                
                TList.Add("Weird");
                
                if (HaveE == false)
                {
                    
                    Remove = "Eye";
                    HaveE = true;

                }
                
                TextManager();

            }

            if (hit.transform.tag == "Skeleton")
            {
                
                TList.Add("...");
                TList.Add("Looks like you could use a hand");
                TList.Add("...");
                TList.Add("Or two");
                
                Check = "LeftArm";
                Check2 = "RightArm";
                
                DoYouHave();

                if (HaveR == true && HaveL == true)
                {

                    SkeletonObject.sprite = SkeletonComplete;
                    DoorObject.sprite = YouCanExit;
                    MegaCheck = true;

                    TList.Add("...");
                    TList.Add("There");
                    
                    HasItem = false;
                    Discard = true;

                }
                
                TextManager();
                
            }

            if (hit.transform.tag == "Guy")
            {
                
                TList.Add("He's taking his duties seriously");
                TList.Add("...");
                TList.Add("He might be missing something though...");

                Check = "Eye";
                
                DoYouHave();

                if (HasItem == true)
                {

                    GuyObject.sprite = GuyComplete;
                    
                    TList.Add("There we go");
                    TList.Add("...");
                    TList.Add("...?");
                    
                    RightWindow.sprite = WindowO;
                    OpenWindowR = true;

                }
                
                TextManager();

            }

            if (hit.transform.tag == "WinDoor" && MegaCheck == true)
            {
                
                TList.Add("It's over");
                TList.Add("...");
                TList.Add("Thanks");

                End = true;
                
                TextManager();

            }
            else if (hit.transform.tag == "WinDoor" && MegaCheck == false)
            {
                
                TList.Add("Hmm...");
                
                TextManager();

            }


        }
        
    }
    
    void TextManager()
    {
            
        InText = true;
        PlayerUIText.transform.position = Active;
        PlayerUIItems.transform.position = Inactive;
        TTSR.color = new Color(0, 0, 0, 0.4f);

        M = TList.Count + 1;
        Dialogue = TList[N];
        PlayerText.text = Dialogue;

        // int safety = 99999;
        //
        // while (N < M && safety < 0)
        // {
        //     
        //     safety--;
        //     
        // }
            
    }

    void DoYouHave()
    {

        for (int C = 0; C < 6; C++) //ask what to use instead of count,
        {

            if (Items[C] == Check)
            {

                CI = C;
                HasItem = true;

            }
            
            if (Items[C] == Check2)
            {

                CI2 = C;
                HasItem2 = true;

            }

        }

    }

    public Sprite GetIcon(string nam)
    {
        foreach (IconInfo i in IconsRaw)
        {
            if (nam == i.Name) return i.S;
        }

        return null;
    }
    
}

[System.Serializable]
public class IconInfo
{
    public string Name;
    public Sprite S;
}

[System.Serializable]
public class Area
{
    public string Name;
    public GameObject A;
}