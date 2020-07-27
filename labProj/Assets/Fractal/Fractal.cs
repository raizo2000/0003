using UnityEngine;
using System.Collections;


public class Fractal : MonoBehaviour {

	public Mesh mesh;
	public Material material;
	public int maxDepth;
	public float childScale;

	private int depth;
    private Material[,] materials;

    public Mesh[] meshes; //esta amiga ayuda a aplicar el rango
    public float spawProbability;

    //movimiento
    public float maxRotationSpeed;
    private float RotationSpeed;
    public float maxTwist;//twist

    //hijos
    private static Vector3[] childDirections = {
        Vector3.up,Vector3.right,Vector3.left
        ,Vector3.forward,Vector3.back
    };

    private static Quaternion[] childOrientations =
    {
        Quaternion.identity,
        Quaternion.Euler(0f,0f,-90f),
        Quaternion.Euler(0f,0f,90f),
        Quaternion.Euler(90f,0f,0f),
        Quaternion.Euler(-90f,0f,0f)

    };

    private void InitializaMaterials()
    {
        materials = new Material[maxDepth + 1,2];
        for (int i = 0; i <= maxDepth; i++)
        {
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i,0] = new Material(material);
            materials[i,0].color = Color.Lerp(Color.white, Color.yellow,t);
            materials[i, 1] = new Material(material);
            materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
        }
        materials[maxDepth, 0].color = Color.magenta;
        materials[maxDepth, 1].color = Color.red;
    }

    private void Start() {
        RotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);

        //color
        if (materials == null)
        {
            InitializaMaterials();
        }
        //--------------------------
		gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0,meshes.Length)];
		gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0, 2)];
        
        
		if (depth < maxDepth) {
            StartCoroutine(CreateChildren());
        }
	}

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childDirections.Length; i++)
        {
            if (Random.value < spawProbability) {
                yield return new WaitForSeconds(0.5f);
                new GameObject("Fractal Child").AddComponent<Fractal>().
                    Initialize(this, i);
            }
            
        }
    }

    private void Initialize(Fractal parent, int childIndex) {
        meshes = parent.meshes;
        materials = parent.materials;
        maxDepth = parent.maxDepth;
        //rotacion twist y %

        maxRotationSpeed = parent.maxRotationSpeed;
        spawProbability = parent.spawProbability;
        maxTwist = parent.maxTwist;

        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
	}

    public void Update()
    {
        transform.Rotate(0f, RotationSpeed * Time.deltaTime, 0);
    }
}