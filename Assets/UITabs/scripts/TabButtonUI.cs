using UnityEngine ;
using UnityEngine.UI ;
using TMPro;

public class TabButtonUI : MonoBehaviour {
    public Button uiButton ;
    public Image uiImage ;
    public Image DifficleImage;
    public Sprite[] spriteImage;
    public Sprite[] spriteImageDifficle;
    public LayoutElement uiLayoutElement ;
    private RectTransform reactTransform;
    public TextMeshProUGUI textDifficle;
    private Vector2 preRT;
    private void Awake()
    {
        reactTransform = GetComponent<RectTransform>();
        preRT = new Vector2(reactTransform.sizeDelta.x, 110);
    }
    public void Active()
   {
        uiImage.sprite = spriteImage[0];
      
        reactTransform.sizeDelta = new Vector2(preRT.x+35, preRT.y+20);
        DifficleImage.sprite = spriteImageDifficle[0];
        if (textDifficle != null)
        {
            textDifficle.color = new Color(60 / 255f, 198 / 255f, 182 / 255f);
        }
    }
    public void DisActive()
    {
        uiImage.sprite = spriteImage[1];
       
        reactTransform.sizeDelta = preRT;
        DifficleImage.sprite = spriteImageDifficle[1];
        if (textDifficle != null)
        {
            textDifficle.color = Color.white;
        }
    }
}
