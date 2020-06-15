using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineWalker : MonoBehaviour {

    public BezierSpline spline;

    public SplineWalkelMode mode;

    private bool goingForward = true;


    public float duration;
    private float progress;

    public bool lookForwark;

    private void Update()
    {
        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                if (mode==SplineWalkelMode.Once)
                {
                    progress = 1f;
                }else if(mode==SplineWalkelMode.Loop){
                    progress -= 1f;
                }else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
                
            }
        }
        else
        {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = false;
            }
        }

        
        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;
        if (lookForwark)
        {
            transform.LookAt(position + spline.GetPoint(progress));
        }
    }
}
