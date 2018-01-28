using UnityEngine;
using System.Collections;

public class Rote : MonoBehaviour {
	private int nowSelectCubeID;
	public int max;
	private int[] indexArray= {1,1,1};
	public GameObject cubHome;
	private string cubeKey = "cube{0}_{1}_{2}";
    bool isrotating;
    public AudioClip[] audioClip;
    public GameObject camera;
	private enum ROTATE_DRICATION_ENUM {
		V_FORNT,
		V_BREAK,
		V_RIGHT,
		V_LEFT,
		H_RIGHT,
		H_LEFT

	};
	private ROTATE_DRICATION_ENUM rotaeDrication = ROTATE_DRICATION_ENUM.H_RIGHT;

	// Use this for initialization
	void Start () {
		StartCoroutine(checkTouch());
	}

	IEnumerator  checkTouch(){
		while(true){

			if (Input.GetMouseButtonDown(0)){
				// Input.mousePosition
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(ray,out hit,100,1 << LayerMask.NameToLayer("myCube"))){
					cube myCube = hit.collider.GetComponent<cube>();
					nowSelectCubeID= myCube.idx;
					indexArray[0] = myCube.idx;
					indexArray[1] = myCube.idy;
					indexArray[2] = myCube.idz;
					Debug.Log("id:"+myCube.idx+","+myCube.idy+","+myCube.idz);
				}
			}
			yield return null;
		}
	}
	// Update is called once per frame
	void Update () {

	}

	private void moveToCubHome(){
		int chIndex = this.transform.childCount;
		Transform[] childeArray = new Transform[chIndex ];
		for(int i = 0 ; i < chIndex;i++){
			childeArray[i] = this.transform.GetChild(i);
		}

		foreach(Transform tmp in 	childeArray){
			Debug.Log(cubHome.name);
			tmp.transform.parent = cubHome.transform;
		}
		this.transform.rotation = Quaternion.identity;
	}
	//水平順時變換名稱
	private void horizontalMoveLeftChangename(cube cubeID,GameObject tmpGame){
		string cubeObjectName = "";
		if(cubeID.idx >= max && cubeID.idy < max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                ++cubeID.idy,cubeID.idz);
			
		}else if(cubeID.idx < max && cubeID.idy < max){
			cubeObjectName =  string.Format(cubeKey,++cubeID.idx,
			                                cubeID.idy,cubeID.idz);
			Debug.Log(cubeObjectName);
		}else if(cubeID.idx ==max && cubeID.idy ==max){
			cubeObjectName =  string.Format(cubeKey,--cubeID.idx,
			                                cubeID.idy,cubeID.idz);
		}else if(cubeID.idx < max && cubeID.idy ==max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                --cubeID.idy,cubeID.idz);
		}
		tmpGame.name = cubeObjectName;
	}

	//水平逆時變換名稱
	private void horizontalMoveRightChangename(cube cubeID,GameObject tmpGame){
		string cubeObjectName = "";
		if(cubeID.idx == max && cubeID.idy < max){
			cubeObjectName =  string.Format(cubeKey,--cubeID.idx,
			                                cubeID.idy,cubeID.idz);
			Debug.Log("cubeID.idx == max"+cubeObjectName);
		}else if(cubeID.idx < max && cubeID.idy < max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                ++cubeID.idy,cubeID.idz);
			//Debug.Log(cubeObjectName);
		}else if(cubeID.idx ==max && cubeID.idy ==max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                --cubeID.idy,cubeID.idz);
		}else if(cubeID.idx < max && cubeID.idy ==max){
			cubeObjectName =  string.Format(cubeKey,++cubeID.idx,
			                                cubeID.idy,cubeID.idz);		
		}
		tmpGame.name = cubeObjectName;
	}

	//垂直右時變換名稱
	private void  verticaMoveRightChangename(cube cubeID,GameObject tmpGame){
		string cubeObjectName = "";
		if(cubeID.idx < max && cubeID.idz < max){
			cubeObjectName =  string.Format(cubeKey,++cubeID.idx,
			                                cubeID.idy,cubeID.idz);
			Debug.Log("cubeID.idx == max"+cubeObjectName);
		}else if(cubeID.idx == max && cubeID.idz < max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                cubeID.idy,++cubeID.idz);
		
		}else if(cubeID.idx == max && cubeID.idz == max){
			cubeObjectName =  string.Format(cubeKey,--cubeID.idx,
			                                cubeID.idy,cubeID.idz);

		}else if(cubeID.idx < max && cubeID.idz == max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                cubeID.idy,--cubeID.idz);
			Debug.Log("cubeID.idx <= max"+cubeObjectName);
		}
		tmpGame.name = cubeObjectName;
	}


	//垂直右時變換名稱
	private void  verticaMoveLeftChangename(cube cubeID,GameObject tmpGame){
		string cubeObjectName = "";
		if(cubeID.idx < max && cubeID.idz < max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                cubeID.idy,++cubeID.idz);
			Debug.Log("cubeID.idx == max"+cubeObjectName);
		}else if(cubeID.idz == max && cubeID.idx < max){
			cubeObjectName =  string.Format(cubeKey,++cubeID.idx,
			                                cubeID.idy,cubeID.idz);
			
		}else if(cubeID.idx == max && cubeID.idz == max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                cubeID.idy,--cubeID.idz);
			
		}else if(cubeID.idx ==max && cubeID.idz < max){
			cubeObjectName =  string.Format(cubeKey,--cubeID.idx,
			                                cubeID.idy,cubeID.idz);
			Debug.Log("cubeID.idx <= max"+cubeObjectName);
		}
		tmpGame.name = cubeObjectName;
	}


	private void  verticaMoveBreakChangename(cube cubeID,GameObject tmpGame){
		string cubeObjectName = "";
		if(cubeID.idy < max && cubeID.idz < max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                ++cubeID.idy,cubeID.idz);
			Debug.Log("cubeID.idx == max"+cubeObjectName);
		}else if(cubeID.idy == max && cubeID.idz < max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                cubeID.idy,++cubeID.idz);
			Debug.Log("cubeID.idx == max"+cubeObjectName);
		}else if(cubeID.idy == max && cubeID.idz == max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                --cubeID.idy,cubeID.idz);
		}else if(cubeID.idy <max && cubeID.idz == max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                cubeID.idy,--cubeID.idz);
		}
		tmpGame.name = cubeObjectName;
	}


	private void  verticaMoveFORNTChangename(cube cubeID,GameObject tmpGame){
		string cubeObjectName = "";
		if(cubeID.idy < max && cubeID.idz < max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                cubeID.idy,++cubeID.idz);

		}else if(cubeID.idy < max && cubeID.idz == max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                ++cubeID.idy,cubeID.idz);

		}else if(cubeID.idy == max && cubeID.idz == max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                cubeID.idy,--cubeID.idz);
		}else if(cubeID.idy ==max && cubeID.idz < max){
			cubeObjectName =  string.Format(cubeKey,cubeID.idx,
			                                --cubeID.idy,cubeID.idz);
		}
		tmpGame.name = cubeObjectName;
	}

	private void horizontalMoveToPoint(){
		int x = indexArray[0];
		int y = indexArray[1];
		int z = indexArray[2];
		GameObject[] tmpGames = new GameObject[4];
		int index = 0;
		for(int i = 1;i <=max;i++){
			for(int j = 1;j <=max;j++){
				string cubeObjectName =  string.Format(cubeKey,i,j,z);
				GameObject tmpGame =  GameObject.Find(cubeObjectName);
				Debug.Log(cubeObjectName);
				tmpGame.transform.parent = this.transform;
				tmpGames[index] = tmpGame;
				index++;
			}			
		}

		foreach (GameObject tmpGame in tmpGames){
			cube cubeID = tmpGame.GetComponent<cube>();
			if(rotaeDrication == ROTATE_DRICATION_ENUM.H_RIGHT){
				//逆時鐘
				horizontalMoveRightChangename(cubeID,tmpGame);
			}else{
				//順順時
				horizontalMoveLeftChangename( cubeID, tmpGame);
			}		

		}

	}

	private void verticaFBlMoveToPoint(){
		int x = indexArray[0];
		int y = indexArray[1];
		int z = indexArray[2];
		int index = 0;
		GameObject[] tmpGames = new GameObject[4];
		for(int i = 1;i <=max;i++){
			for(int j = 1;j <=max;j++){
				string cubeObjectName =  string.Format(cubeKey,x,i,j);
				GameObject tmpGame =  GameObject.Find(cubeObjectName);
				tmpGames[index] = tmpGame;
				index++;
				Debug.Log(cubeObjectName);
				tmpGame.transform.parent = this.transform;
			}			
		}
		foreach (GameObject tmpGame in tmpGames){
			cube cubeID = tmpGame.GetComponent<cube>();
			if(rotaeDrication == ROTATE_DRICATION_ENUM.V_BREAK){
				//向後轉
				Debug.Log("V_BREAK");
				verticaMoveBreakChangename(cubeID,tmpGame);
			}else{
				//向前轉
				Debug.Log("FORNT");
				verticaMoveFORNTChangename( cubeID, tmpGame);
			}		
			
		}
	}

	private void verticaRLlMoveToPoint(){
		int x = indexArray[0];
		int y = indexArray[1];
		int z = indexArray[2];
		GameObject[] tmpGames = new GameObject[4];
		int index = 0;

		for(int i = 1;i <=max;i++){
			for(int j = 1;j <=max;j++){
				string cubeObjectName =  string.Format(cubeKey,i,y,j);
				GameObject tmpGame =  GameObject.Find(cubeObjectName);
				tmpGames[index] = tmpGame;
				index++;
				Debug.Log(cubeObjectName);
				tmpGame.transform.parent = this.transform;
			}			
		}

		foreach (GameObject tmpGame in tmpGames){
			cube cubeID = tmpGame.GetComponent<cube>();
			if(rotaeDrication == ROTATE_DRICATION_ENUM.V_RIGHT){
				//逆時鐘
				verticaMoveRightChangename(cubeID,tmpGame);
			}else{
				//順順時
				verticaMoveLeftChangename( cubeID, tmpGame);
			}		
			
		}


	}



	private  IEnumerator  horizontalRotate(){
		horizontalMoveToPoint();
		float value = 0;
        isrotating = true;
        while ((value+= 90 * Time.deltaTime) <=90f){

			if(rotaeDrication == ROTATE_DRICATION_ENUM.H_RIGHT){
				this.transform.Rotate(Vector3.up * -90 * Time.deltaTime );						
			}else{
				this.transform.Rotate(Vector3.up   * 90 * Time.deltaTime  );
			}
			yield return null;
		}
        if (rotaeDrication == ROTATE_DRICATION_ENUM.H_RIGHT)
        {
            this.transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x), Mathf.Floor(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));
        }

        else
        {
            this.transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x), Mathf.Ceil(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));
        }

        moveToCubHome();
        isrotating = false;
    }

	private IEnumerator verticalRLRotate(){
		verticaRLlMoveToPoint();
		float value = 0;
        isrotating = true;
        while ((value+= 90 * Time.deltaTime) <=90f){
			if(rotaeDrication == ROTATE_DRICATION_ENUM.V_RIGHT){
				this.transform.Rotate(this.transform.TransformDirection(Vector3.forward) * 90* Time.deltaTime );
                Debug.Log("NICE");						
			}else{
				this.transform.Rotate(this.transform.TransformDirection(Vector3.forward) * -90 * Time.deltaTime);				
			}
			yield return null;
		}
        if (rotaeDrication == ROTATE_DRICATION_ENUM.V_RIGHT)
        {
            //this.transform.eulerAngles = new Vector3(Mathf.Ceil(transform.eulerAngles.x), Mathf.Round(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));
        }
        else
        {
            //this.transform.eulerAngles = new Vector3(Mathf.Ceil(transform.eulerAngles.x), Mathf.Round(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));
        }
        moveToCubHome();
        isrotating = false;
        //transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x), Mathf.Round(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));
    }

	private IEnumerator verticaFBRotate(){
		verticaFBlMoveToPoint();
		float value = 0;
        isrotating = true;
		while((value+= 90 * Time.deltaTime) <=90f){
			if(rotaeDrication == ROTATE_DRICATION_ENUM.V_FORNT){
				this.transform.Rotate(this.transform.TransformDirection(Vector3.right) * -90* Time.deltaTime );										
			}else{
				this.transform.Rotate(this.transform.TransformDirection(Vector3.right) * 90 * Time.deltaTime);										
			}
			yield return null;
		}
        
       // this.transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x), Mathf.Round(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));
        moveToCubHome();
        isrotating = false;
        //transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x), Mathf.Round(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));
	}

	void OnGUI() {
		//GUI.Label(new Rect(200, 10,100, 30),"請點選方塊!");
		if (GUI.Button(new Rect(10, 10,100, 30), "A a.c.w.") && isrotating == false && GameManager.Instance.isShooting == false){
			rotaeDrication = ROTATE_DRICATION_ENUM.H_RIGHT;
		    StartCoroutine(horizontalRotate());
            camera.GetComponent<AudioSource>().clip = audioClip[Random.Range(0, audioClip.Length)];
            camera.GetComponent<AudioSource>().Play();

       }

		if (GUI.Button(new Rect(10, 50,100, 30), "A c.w.") && isrotating == false && GameManager.Instance.isShooting == false)
        {
			rotaeDrication = ROTATE_DRICATION_ENUM.H_LEFT;
			StartCoroutine(horizontalRotate());
            camera.GetComponent<AudioSource>().clip = audioClip[Random.Range(0, audioClip.Length)];
            camera.GetComponent<AudioSource>().Play();

        }

        if (GUI.Button(new Rect(10, 90,100, 30), "B a.c.w.") && isrotating == false && GameManager.Instance.isShooting == false)
        {
			rotaeDrication = ROTATE_DRICATION_ENUM.V_RIGHT;
			StartCoroutine(verticalRLRotate());
            camera.GetComponent<AudioSource>().clip = audioClip[Random.Range(0, audioClip.Length)];
            camera.GetComponent<AudioSource>().Play();

        }

        if (GUI.Button(new Rect(10, 130,100, 30), "B c.w.") && isrotating == false && GameManager.Instance.isShooting == false)
        {
			rotaeDrication = ROTATE_DRICATION_ENUM.V_LEFT;
			StartCoroutine(verticalRLRotate());
            camera.GetComponent<AudioSource>().clip = audioClip[Random.Range(0, audioClip.Length)];
            camera.GetComponent<AudioSource>().Play();

        }

        if (GUI.Button(new Rect(10, 170,100, 30), "C a.c.w.") && isrotating == false && GameManager.Instance.isShooting == false)
        {
			rotaeDrication = ROTATE_DRICATION_ENUM.V_FORNT;
			StartCoroutine(verticaFBRotate());
            camera.GetComponent<AudioSource>().clip = audioClip[Random.Range(0, audioClip.Length)];
            camera.GetComponent<AudioSource>().Play();

        }
        if (GUI.Button(new Rect(10, 210,100, 30), "C c.w.") && isrotating == false && GameManager.Instance.isShooting == false)
        {
			rotaeDrication = ROTATE_DRICATION_ENUM.V_BREAK;
			StartCoroutine(verticaFBRotate());
            camera.GetComponent<AudioSource>().clip = audioClip[Random.Range(0, audioClip.Length)];
            camera.GetComponent<AudioSource>().Play();

        }

    }

}
