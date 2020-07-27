using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Script echo por  Andres GUanoluisa(NONE)
 domingo/01/Abril/2018
 Si desea añada mas funciones
 Tutor: Jasper Flick
     */
public class GraphF : MonoBehaviour {

    public Transform pointPrefab;

    [Range(10, 100)]
    public int resolution = 10;

    public GraphFunctionName function;

    Transform[] points;

    static GraphFunction[] functions = {
        SineFunction,Sine2DFunction ,MultiSineFunction,
        MultiSine2DFunction,Ripple,Circle,Cylinder,Spyral,
        WhobblyCylinder,ADN,VinstanheadU,TwistingCylinder,
        AlmostSphere,Sphere,Trevol,PulsingSphere,Torus,
        SplindleTorus,HornTorus,RingTorus,StarTorus
        };

    const float pi = Mathf.PI;
    
    static Vector3 SineFunction(float x,float z,float t) {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(pi * (x + t));
        p.z = z;
        return p;
    }

    static Vector3 Sine2DFunction(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(pi * (x + t));
        p.y += Mathf.Sin(pi * (z + t));
        p.y *= 0.5f;
        p.z = z;
        return p;
    }

    static Vector3 MultiSineFunction(float x,float z,float t) {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(pi * (x + t));
        p.y += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
        p.y *= 2f / 3f;
        p.z = z;
        return p;
    }

    static Vector3 MultiSine2DFunction(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = 4f * Mathf.Sin(pi * (x + z + t * 0.5f));
        p.y += Mathf.Sin(pi * (x + t));
        p.y += Mathf.Sin(2f * pi * (z + 2f * t)) / 2f;
        p.y *= 1f / 5.5f;
        p.z = z;
        return p;
    }
    //Ondulaciones Ripple
    static Vector3 Ripple(float x, float z, float t)
    {
        Vector3 p;
        float d = Mathf.Sqrt(x * x + z * z);

        p.x = x;
        p.y = Mathf.Sin(pi *(4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = z;
        return p;
    }

    //Cilindro
    static Vector3 Circle(float u,float v,float t)
    {
        Vector3 p;
        p.x = Mathf.Sin(pi * u);
        p.y = 0f;
        p.z = Mathf.Cos(pi * u);
        return p;
    }
    //-----------------------------------------------
    static Vector3 Cylinder(float u, float v, float t)
    {
        Vector3 p;
        p.x = Mathf.Sin(pi * u);
        p.y = v;
        p.z = Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Spyral(float u, float v, float t)
    {
        Vector3 p;
        float r = 1f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = u;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 WhobblyCylinder(float u, float v, float t)
    {
        Vector3 p;
        float r = 1f + Mathf.Sin(6f * pi * u + v + t) * 0.2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 ADN(float u, float v, float t)
    {
        Vector3 p;
        float r = 1f + Mathf.Sin(2f * pi * v + u + t);
        p.x = r * Mathf.Sin(pi * u); ;
        p.y = v;
        p.z = Mathf.Sin(pi * u); 
        return p;
    }

    static Vector3 VinstanheadU(float u, float v, float t)
    {
        Vector3 p;
        float r = 1f + Mathf.Sin(2f * pi * v + u + t) * 0.2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }


    static Vector3 TwistingCylinder(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Sin(pi * (6f * pi * u + v + t)) * 0.2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    //Sphere
    static Vector3 AlmostSphere(float u, float v, float t)
    {
        Vector3 p;
        float r = Mathf.Cos(pi * 0.5f * v + t);
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Sphere(float u, float v, float t)
    {
        Vector3 p;
        float r = Mathf.Cos(pi * 0.5f * v);
        p.x = r * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * 0.5f * v);
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Trevol(float u, float v, float t)
    {
        Vector3 p;
        float r = Mathf.Cos(pi * 0.5f * v + t * u);
        p.x = r * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * 0.5f * v);
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 PulsingSphere(float u, float v, float t)
    {
        Vector3 p;
        float r =0.8f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
        r += Mathf.Sin(pi * (4f * v + t)) * 0.1f;
        float s = r * Mathf.Cos(pi * 0.5f * v);

        p.x = s * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * 0.5f * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    //Torus
    static Vector3 Torus(float u, float v, float t)
    {
        Vector3 p;
        float s = Mathf.Cos(pi * 0.5f * v) + 0.5f;
        p.x = s * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * 0.5f * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 SplindleTorus(float u, float v, float t)
    {
        Vector3 p;
        float s = Mathf.Cos(pi * v) + 0.5f;
        p.x = s * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 HornTorus(float u, float v, float t)
    {
        Vector3 p;
        float r1 = 1f;
        float s = Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 RingTorus(float u, float v, float t)
    {
        Vector3 p;
        float r1 = 1f;
        float r2 = 0.5f;
        float s =r2 * Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = r2 * Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 StarTorus(float u, float v, float t)
    {
        Vector3 p;
        float r1 = 0.65f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
        float r2 = 0.2f + Mathf.Sin(pi * (4f * v + t)) * 0.05f;
        float s = r2 * Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = r2 * Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    //------------------------------------------------------------
    void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        points = new Transform[resolution * resolution];
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    void Update()
    {
        float t = Time.time;
        GraphFunction f = functions[(int)function];
        float step = 2f / resolution;

        for (int i = 0,z=0; z < points.Length; z++)
        {
            float v = (z + 0.5f) * step - 1f;
            for (int x = 0; x< resolution;x++ , i++) {
                float u = (x + 0.5f) * step - 1f;
                points[i].localPosition = f(u, v, t);
            }
        }
    }
}
