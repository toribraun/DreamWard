using UnityEngine;

public class WebSpider : MonoBehaviour
{
    private WebString web;
    private Spider spider;
    
    [HideInInspector]
    public SpidersLevel LevelManager;
    
    [SerializeField]
    private DestroyablePlatform platform;
    [SerializeField]
    private float minScale;
    [SerializeField]
    private float maxScale;
    [SerializeField]
    private float movingSpeed;
    [SerializeField]
    private float fallingSpeed;

    private bool shouldGoDown;
    
    private void Start()
    {
        web = GetComponentInChildren<WebString>();
        spider = GetComponentInChildren<Spider>();
        shouldGoDown = web.transform.localScale.y > minScale;
    }

    private void Update()
    {
        if (!platform.isFalling)
        {
            if (shouldGoDown)
            {
                web.transform.localScale = Vector3.MoveTowards(
                    web.transform.localScale, 
                    web.transform.localScale - web.transform.up, movingSpeed * Time.deltaTime);
                web.transform.localPosition = Vector3.MoveTowards(
                    web.transform.localPosition, 
                    web.transform.localPosition + web.transform.up, movingSpeed / 2 * Time.deltaTime);
                spider.transform.localPosition = Vector3.MoveTowards(
                    spider.transform.localPosition, 
                    spider.transform.localPosition + spider.transform.up, movingSpeed * Time.deltaTime);
                if (web.transform.localScale.y <= minScale)
                    shouldGoDown = false;
            }
            else
            {
                web.transform.localScale = Vector3.MoveTowards(
                    web.transform.localScale, 
                    web.transform.localScale + web.transform.up, movingSpeed * Time.deltaTime);
                web.transform.localPosition = Vector3.MoveTowards(
                    web.transform.localPosition, 
                    web.transform.localPosition - web.transform.up, movingSpeed / 2 * Time.deltaTime);
                spider.transform.localPosition = Vector3.MoveTowards(
                    spider.transform.localPosition, 
                    spider.transform.localPosition - spider.transform.up, movingSpeed * Time.deltaTime);
                if (web.transform.localScale.y >= maxScale)
                    shouldGoDown = true;
            }
        }
        else
        {
            
            web.transform.localScale = Vector3.zero;
            spider.transform.localPosition = Vector3.MoveTowards(
                spider.transform.localPosition, 
                spider.transform.localPosition - spider.transform.up, fallingSpeed * Time.deltaTime);
            
            if (!spider.IsDead)
            {
                spider.IsDead = true;
                LevelManager.SpidersLeftCount -= 1;
                if (LevelManager.SpidersLeftCount <= 0)
                {
                    LevelManager.Win();
                }
            }
        }
        
        
    }
}