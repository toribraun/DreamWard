using UnityEngine;

public class WebSpider : MonoBehaviour
{
    private GameObject web;
    private GameObject spider;
    
    [SerializeField]
    private DestroyablePlatform platform;
    [SerializeField]
    private float maxScale;
    [SerializeField]
    private float minScale;
    [SerializeField]
    private float scaleChange;

    private Vector3 _scaleChange;

    private bool shouldGoDown;
    
    private void Start()
    {
        web = GameObject.Find("String").gameObject;
        spider = GameObject.Find("Spider").gameObject;
        _scaleChange = new Vector3(0.0f, scaleChange, 0.0f);
        shouldGoDown = web.transform.localScale.y > minScale;
    }

    private void Update()
    {
        if (!platform.isFalling)
        {
            if (shouldGoDown)
            {
                web.transform.localScale -= _scaleChange;
                web.transform.localPosition += _scaleChange / 2;
                spider.transform.localPosition += _scaleChange;
                if (web.transform.localScale.y <= minScale)
                    shouldGoDown = false;
            }
            else
            {
                web.transform.localScale += _scaleChange;
                web.transform.localPosition -= _scaleChange / 2;
                spider.transform.localPosition -= _scaleChange;
                if (web.transform.localScale.y >= maxScale)
                    shouldGoDown = true;
            }
        }
        else
        {
            web.transform.localScale = Vector3.zero;
            spider.transform.localPosition += new Vector3(0.0f, -0.1f, 0.0f);
        }
    }
}