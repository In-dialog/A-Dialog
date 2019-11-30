#pragma strict

// FakeTriangulator v2.0 - http://unitycoder.com/blog

// adds 1 vertice to the middle, all connect to that
private var points:int;
private var triangles:int[];
private var vertices:Vector3[];


function Start () 
{
	points = 13;
	vertices = new Vector3[points];
	triangles = new int[points*3];
	
	// build loop
	
	// central point
	vertices[0] = Vector3(0,0,0);

	// vertices around
	var angle:float = 0;
	for (var i:int=1;i<points;i++)
	{
		var x = Mathf.Sin(angle);
		var y = Mathf.Cos(angle);
		angle += 2*Mathf.PI/points-1;
		var r = Random.Range(1,20);
		vertices[i] = Vector3(x*r,y*r,0);
	}

	// triangle list
	i = -1;
	for (var n:int=0;n<triangles.length-1;n+=3)
	{
		i++;
		triangles[n] = 0;
		if (i>=points-1)
		{
			triangles[n+1] = 1;
			print ("hit:"+i);
		}else{
			triangles[n+1] = i+1;
		}
		triangles[n+2] = i;
	}

	print (">"+triangles[triangles.length-3]);
	print (">"+triangles[triangles.length-2]);
	print (">"+triangles[triangles.length-1]);

	// add mesh
	var mesh : Mesh = GetComponent(MeshFilter).mesh;

	mesh.vertices = vertices;
    mesh.triangles = triangles;
    mesh.RecalculateNormals();
    mesh.RecalculateBounds();

}
