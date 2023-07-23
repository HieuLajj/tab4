using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum StateGame
{
    AWAIT,
    AWAITLOAD,
    PLAY,
    WIN,
    AWAITNEW
}
public enum DiffirentEnum
{
    EASY,
    MEDIUM,
    HARD
}

public enum ShopEnum
{
    SKIN,
    TRAILS,
    TOUCH
}
public enum ButtonEnum
{
    ACTIVE,
    PRICE,
    NOT
}
public class Controller : Singleton<Controller>
{
    public float timer;
    public Transform test;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    
    public UIManager manager;

    public ParticleSystem WinPS;
    public List<IListenerBlock> ListenerBlock = new List<IListenerBlock>();
    public int amountNumberBlock = 0;
    public int checkloadBlock = 0;
    private StateGame stateGame = StateGame.AWAIT;
    public GameObject Boom;

    public DiffirentEnum DiffirentGame = DiffirentEnum.EASY;
    private float touchStartTime;
    float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;
    [SerializeField]
    float zoomModifierSpeed = 0.1f;
    public int AmountCoin, AmountCoinX2;
    public List<ButtonChangeSkin> SkinMaterial = new List<ButtonChangeSkin>();
    public List<ButtonChangeTap> TapMaterial = new List<ButtonChangeTap>();
    public List<ButtonChangeTrails> TrailMaterial = new List<ButtonChangeTrails>();

    Vector2 firstTouchPrevPos, secondTouchPrevPos;
    public int IndexSkin;
    public Transform TempPreForParent;
    private int indexTrail;
    public int IndexTrail
    {
        set
        {
            indexTrail = value;
            PlayerPrefs.SetInt("TrailIndex", indexTrail);
        }
        get
        {
            return indexTrail;
        }
    }


    public string TrailsObjectTarget;
    private int indexTap;
    public int IndexTap
    {
        set {
            indexTap = value;
            PlayerPrefs.SetInt("TapIndex", indexTap);
        }
        get
        {
            return indexTap;
        }
    }
    public string TagNameTag;
    public StateGame gameState
    {
        get
        {
            return stateGame;
        }
        set
        {
            stateGame = value;
            if(value == StateGame.WIN)
            {
                if (UIManager.Instance.UIBoom.activeInHierarchy)
                {
                    UIManager.Instance.UIBoom.GetComponent<Button>().interactable = false;
                }
                WhenWin();
            }else if(value == StateGame.PLAY)
            {
               
                if (!UIManager.Instance.FunctionsButtons.activeInHierarchy)
                {
                   
                    UIManager.Instance.FunctionsButtons.SetActive(true);
                }
                //if (!UIManager.Instance.UIBoom.activeInHierarchy)
                //{
                //    UIManager.Instance.UIBoom.SetActive(true);
                //}
                BoomBtn boomBtn = UIManager.Instance.UIBoom.GetComponent<BoomBtn>();
                if(!boomBtn.isCountdownActive)
                {
                    //UIManager.Instance.UIBoom.GetComponent<Button>().interactable = true;
                    boomBtn.HienUIBoom();
                }
                
            }
            else if(value == StateGame.AWAITLOAD)
            {
                UIManager.Instance.UIBoom.GetComponent<Button>().interactable = false;
            }else if (value == StateGame.AWAIT)
            {
               
            }
        }
    }

    private int coinPlayer;
    public int CoinPlayer{
        set{
            if(coinPlayer!=value){
                PlayerPrefs.SetInt("Coin", value);
            }
            coinPlayer = value;
            UIManager.Instance.CoinTextPlayer.text = Utiliti.SetCoinsText(coinPlayer);

            //if(UIManager.Instance.CoinTextPlayer2.gameObject.activeInHierarchy){
                UIManager.Instance.CoinTextPlayer2.text = Utiliti.SetCoinsText(coinPlayer);
            //}
            //cap nhap tien bom
            UIManager.Instance.UIBoom.GetComponent<BoomBtn>().UpdateView();
        }
        get{
            return coinPlayer;
        }
    }
    public readonly Dictionary<DiffirentEnum, int> constantsDiffical = new Dictionary<DiffirentEnum, int>()
    {
        { DiffirentEnum.EASY, 10 },
        { DiffirentEnum.MEDIUM, 20 },
        { DiffirentEnum.HARD, 369 }
    };
    public readonly Dictionary<ShopEnum, int> constantsShop = new Dictionary<ShopEnum, int>()
    {
        { ShopEnum.SKIN, 0 },
        { ShopEnum.TRAILS, 50 },
        { ShopEnum.TOUCH, 100 }
    };

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
       IndexSkin = PlayerPrefs.GetInt("SkinIndex");
       CoinPlayer = PlayerPrefs.GetInt("Coin");
    }
    private void Update()
    {
        //if(stateGame == StateGame.AWAITLOAD) {
        //    awaitload();
        //}
        if (gameState == StateGame.PLAY)
        {
            userInteraction();
        }
    }
    public void Checkawaitload()
    {
        checkloadBlock++;
        if(checkloadBlock >= amountNumberBlock) {
            //kiem tra xem
            if(gameState == StateGame.AWAITLOAD)
            {
                gameState = StateGame.PLAY;
            }
        }
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveGame();
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveGame();
        }
    }
    public void SaveGame()
    {
        int i = 0;
        int[] arraytest = new int[ListenerBlock.Count];
        // kiem tra xem mang co toan -1 hay khong
        bool checkminus1 = false;
        foreach (var item in ListenerBlock)
        {
            arraytest[i] = item.IType();
            if (arraytest[i] != -1 && !checkminus1)
            {
                checkminus1 = true;
            }
            i++;
        }
        if (checkminus1)
        {
            LevelManager.Instance.SaveGame(arraytest);
        }
        else
        {
            LevelManager.Instance.ClearDataSaveGame();
        }
    }

    public void ChangSkin(int index)
    {
        //luu skin
        PlayerPrefs.SetInt("SkinIndex", index);
        IndexSkin = index;
        foreach(var item in ListenerBlock)
        {
            item.ISkin(LevelManager.Instance.skindata.GetSkinData(index));
        }
    }
    
    public void userInteraction()
    {

        if (Input.GetMouseButton(0))
        {
          timer += Time.deltaTime;
          if (timer > 0.5f)
          {
              manager.SwipeScreen();
          }
        }
        if (Input.GetMouseButtonUp(0))
        {
          if (timer <= 0.5f)
          {

                   screenPosition = Input.mousePosition;
                   Ray ray = Camera.main.ScreenPointToRay(screenPosition);
                    LevelManager.Instance.LimitMoveInt--;

                  if (Physics.Raycast(ray, out RaycastHit hitData, Mathf.Infinity, 1 << 6))
                  {
                      Block block = hitData.collider.GetComponent<Block>();
                      block.checkRayInput();
                  }

          }
          timer = 0;
        }


        // if (Input.touchCount == 2)
        // {
        //     ZoomInOut();
        // }
        // else
        // {
        //     if (Input.touchCount > 0)
        //     {
        //     // Debug.Log("Hoko");   
        //         Touch touch = Input.GetTouch(0);
               
        //         if (touch.phase == TouchPhase.Began)
        //         {
        //             touchStartTime = Time.time;
                    
        //         }   
        //         else if (touch.phase == TouchPhase.Moved)
        //         {
        //             float touchhaiTime = Time.time;
        //             float touchDurationMove = touchhaiTime - touchStartTime;
        //             if (touchDurationMove > 0.15)
        //             {
        //                 manager.SwipeScreen();
        //             }
                    
        //         }
        //         else if (touch.phase == TouchPhase.Ended)
        //         {
        //             float touchEndTime = Time.time;
        //             float touchDuration = touchEndTime - touchStartTime;
        //            // Debug.Log(Time.deltaTime+"?"+touchDuration );
        //             if (touchDuration < 0.5f)
        //             {
        //                // Debug.Log("HAHAHA");
        //                 EffectTouch(touch.position);
        //                 TouchClickBlock();
        //             }
        //         }
        //     }
        // }

    }

    public void EffectTouch(Vector3 position)
    {
        TapPooling.Instance.CreateTap(position);
    }
    public void TouchClickBlock()
    {
        screenPosition = Input.GetTouch(0).position;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hitData, Mathf.Infinity, 1 << 6))
        {
            if (LevelManager.Instance.LimitMoveInt <= 0)
            {
                UIManager.Instance.SelectAddMoveUI.gameObject.SetActive(true);
                return;
            }
            Block block = hitData.collider.GetComponent<Block>();
            block.checkRayInput();
            LevelManager.Instance.LimitMoveInt--;

            //tao hieu ung dung
            if(SettingControll.Instance.VibratorCheck == 1)
            {
               Vibrator.Vibrate(100);
            }

            if (LevelManager.Instance.LimitMoveInt <= 0 && Controller.Instance.gameState == StateGame.PLAY)
            {
                UIManager.Instance.SelectAddMoveUI.gameObject.SetActive(true);
            }
        }
    }
    public void ZoomInOut()
    {      
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

            touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
            touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

            zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

            if (touchesPrevPosDifference > touchesCurPosDifference)
            {
                Camera.main.fieldOfView += zoomModifier;
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 30, 60);
            }
            
            if (touchesPrevPosDifference < touchesCurPosDifference)
            {
                Camera.main.fieldOfView -= zoomModifier;
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 30, 60);
            }
               
            //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 2f, 10f);
    }

    private void WhenWin()
    {
        LevelManager.Instance.ClearDataSaveGame();
        WinPS.gameObject.SetActive(true);
        if (!WinPS.isPlaying)
        {
           WinPS.Play();
           MusicController.Instance.PlayClip(MusicController.Instance.ConfettiClip);
        }
        Invoke("AwaitNext",2.0f);
    }
    public void AwaitNext()
    {
        UIManager.Instance.CompleteLevelUI.SetActive(true);
    }

    void OnGUI()
    {
        //if (GUI.Button(new Rect(250, 10, 150, 100), "RanDom Gift"))
        //{
        //    GameObject g = LevelManager.Instance.GetRandomGift();
        //    if (g != null)
        //    {
        //        Block block = g.GetComponent<Block>();
        //        block.StatusBlock = StatusBlock.Gift;
        //    }
        //}
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
           PlayerPrefs.DeleteAll();
        }
    }

    public void IdentifyDifficult(int Level)
    {
     
        if (Level<= Controller.Instance.constantsDiffical[DiffirentEnum.EASY])
        {
            LevelProgess.Instance.gameObject.SetActive(false);
        }
        else if (Level <= Controller.Instance.constantsDiffical[DiffirentEnum.EASY]  + Controller.Instance.constantsDiffical[DiffirentEnum.MEDIUM])
        {
            LevelProgess.Instance.gameObject.SetActive(true);
        }
        else 
        {
            LevelProgess.Instance.gameObject.SetActive(true);
        }
    }

    public void AddSkinMaterialMemory(ButtonChangeSkin g)
    {
        if (!SkinMaterial.Contains(g))
        {
            SkinMaterial.Add(g);
        }
    }

    public ButtonChangeSkin SelectRandomSkin()
    {
        if (SkinMaterial.Count <= 0) { return null; }
        int random = Random.Range(0, SkinMaterial.Count - 1);
        return SkinMaterial[random];
    }

    public void RemoveSkinMaterialMemory(ButtonChangeSkin g)
    {
        if (SkinMaterial.Contains(g))
        {
            SkinMaterial.Remove(g);
        }
    }

    public void AddTapMaterialMemory(ButtonChangeTap g)
    {
        if (!TapMaterial.Contains(g))
        {
            TapMaterial.Add(g);
        }
    }
    public ButtonChangeTap SelectRandomTap()
    {
        if (TapMaterial.Count <= 0) { return null; }
        int random = Random.Range(0, TapMaterial.Count - 1);
        return TapMaterial[random];
    }
    public void RemoveTapMaterialMemory(ButtonChangeTap g)
    {
        if (TapMaterial.Contains(g))
        {
            TapMaterial.Remove(g);
        }
    }


    public void AddTrailMaterialMemory(ButtonChangeTrails g)
    {
        if (!TrailMaterial.Contains(g))
        {
            TrailMaterial.Add(g);
        }
    }

    public ButtonChangeTrails SelectRandomTrail()
    {
        if (TrailMaterial.Count <= 0) { return null; }
        int random = Random.Range(0, TrailMaterial.Count - 1);
        return TrailMaterial[random];
    }

    public void RemoveTrailMaterialMemory(ButtonChangeTrails g)
    {
        if (TrailMaterial.Contains(g))
        {
            TrailMaterial.Remove(g);
        }
    }
}
