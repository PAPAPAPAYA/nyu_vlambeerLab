using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int spawnerCount = 1;
    public int globalFloorCount = 0;
    static public GameManager me;
    public List<Transform> floorList = new List<Transform>();
    public List<GameObject> wallList = new List<GameObject>();
    public Vector3 totalV3;
    public Vector3 center;

    public bool wallGenerated = false;

    public GameObject w;
    // Start is called before the first frame update
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        //print(spawnerCount);
        //print(globalFloorCount);
        //print(center);
        if (Input.GetKeyDown(KeyCode.R)){
            Restart();
        }

        if (floorList.Count < 501){
            totalV3 = new Vector3(0,0,0);
            foreach (Transform a in floorList){
                        totalV3 += a.position;
                        center = totalV3/floorList.Count;
                    }
        }

        foreach(Transform a in floorList){
            //print(a.GetComponent<Renderer>().isVisible);
            if (!a.GetComponent<Renderer>().isVisible){
                camMoveScript.me.camHeight += 0.04f;
            }
        }
        //if (wallList.Count > 0){
            foreach(GameObject a in wallList){
                        //print(a.GetComponent<Renderer>().isVisible);
                        if (!a.GetComponent<Renderer>().isVisible){
                            camMoveScript.me.camHeight += 0.03f;
                        }
                    }
        //}
        

        if (floorList.Count == 501){
            foreach(Transform a in floorList){
                Ray wallTest00 = new Ray(new Vector3(a.position.x - 5, a.position.y + 2.5f, a.position.z - 5),-transform.up); // bottom left
                Ray wallTest01 = new Ray(new Vector3(a.position.x, a.position.y + 2.5f, a.position.z - 5),-transform.up); // down
                Ray wallTest02 = new Ray(new Vector3(a.position.x + 5, a.position.y + 2.5f, a.position.z -5),-transform.up); // bottom right
                Ray wallTest10 = new Ray(new Vector3(a.position.x - 5, a.position.y + 2.5f, a.position.z),-transform.up); // left
                Ray wallTest12 = new Ray(new Vector3(a.position.x + 5, a.position.y + 2.5f, a.position.z),-transform.up); // right
                Ray wallTest20 = new Ray(new Vector3(a.position.x - 5, a.position.y + 2.5f, a.position.z + 5),-transform.up); // up left
                Ray wallTest21 = new Ray(new Vector3(a.position.x, a.position.y + 2.5f, a.position.z + 5),-transform.up); // up
                Ray wallTest22 = new Ray(new Vector3(a.position.x + 5, a.position.y + 2.5f, a.position.z + 5),-transform.up); // up right

                RaycastHit t00 = new RaycastHit();
                RaycastHit t01 = new RaycastHit();
                RaycastHit t02 = new RaycastHit();
                RaycastHit t10 = new RaycastHit();
                RaycastHit t12 = new RaycastHit();
                RaycastHit t20 = new RaycastHit();
                RaycastHit t21 = new RaycastHit();
                RaycastHit t22 = new RaycastHit();

                float rayDist = 5f;

                Debug.DrawRay(wallTest00.origin,wallTest00.direction * rayDist, Color.red);
                Debug.DrawRay(wallTest01.origin,wallTest00.direction * rayDist, Color.red);
                Debug.DrawRay(wallTest02.origin,wallTest00.direction * rayDist, Color.red);
                Debug.DrawRay(wallTest10.origin,wallTest00.direction * rayDist, Color.red);
                Debug.DrawRay(wallTest12.origin,wallTest00.direction * rayDist, Color.red);
                Debug.DrawRay(wallTest20.origin,wallTest00.direction * rayDist, Color.red);
                Debug.DrawRay(wallTest21.origin,wallTest00.direction * rayDist, Color.red);
                Debug.DrawRay(wallTest22.origin,wallTest00.direction * rayDist, Color.red);

                if (!Physics.Raycast(wallTest00, out t00, rayDist) && !a.gameObject.GetComponent<floorScript>().wallChecked00){
                    
                    wallList.Add(Instantiate(w,wallTest00.origin,a.transform.rotation));
                    a.gameObject.GetComponent<floorScript>().wallChecked00 = true;
                    //wallList.Add(wallTest00.origin);
                //     foreach (Vector3 b in wallList){
                //         if (b == wallTest00.origin){
                //             //print("nothing here");
                //             wallList.Remove(wallTest00.origin);
                //       }
                //    }
                }
                if (!Physics.Raycast(wallTest01, out t01, rayDist) && !a.gameObject.GetComponent<floorScript>().wallChecked01){
                    wallList.Add(Instantiate(w,wallTest01.origin,a.transform.rotation));
                    a.gameObject.GetComponent<floorScript>().wallChecked01 = true;
                    // foreach (Vector3 b in wallList){
                    //     if (b != wallTest01.origin){
                    //         wallList.Add(wallTest01.origin);
                    //    }
                    // }
                }
                if (!Physics.Raycast(wallTest02, out t02, rayDist) && !a.gameObject.GetComponent<floorScript>().wallChecked02){
                    wallList.Add(Instantiate(w,wallTest02.origin,a.transform.rotation));
                    a.gameObject.GetComponent<floorScript>().wallChecked02 = true;
                    //foreach (GameObject b in wallList){
                        //if (b.transform.position != wallTest02.origin){
                            //Instantiate(w,wallTest02.origin,a.transform.rotation);
                            //print("nothing here");
                            //wallList.Add(wallTest02.origin);
                        //}
                    //}
                }
                if (!Physics.Raycast(wallTest10, out t10, rayDist) && !a.gameObject.GetComponent<floorScript>().wallChecked10){
                    wallList.Add(Instantiate(w,wallTest10.origin,a.transform.rotation));
                    a.gameObject.GetComponent<floorScript>().wallChecked10 = true;
                   // foreach (GameObject b in wallList){
                        //if (b.transform.position != wallTest10.origin){
                            //Instantiate(w,wallTest10.origin,a.transform.rotation);
                            //print("nothing here");
                            //wallList.Add(wallTest10.origin);
                        //}
                   // }
                }
                if (!Physics.Raycast(wallTest12, out t12, rayDist) && !a.gameObject.GetComponent<floorScript>().wallChecked12){
                    wallList.Add(Instantiate(w,wallTest12.origin,a.transform.rotation));
                    a.gameObject.GetComponent<floorScript>().wallChecked12 = true;
                   // foreach (GameObject b in wallList){
                      //  if (b.transform.position != wallTest12.origin){
                            //Instantiate(w,wallTest12.origin,a.transform.rotation);
                            // print("nothing here");
                            // wallList.Add(wallTest12.origin);
                      //  }
                  //  }
                }
                if (!Physics.Raycast(wallTest20, out t20, rayDist) && !a.gameObject.GetComponent<floorScript>().wallChecked20){
                    wallList.Add(Instantiate(w,wallTest20.origin,a.transform.rotation));
                    a.gameObject.GetComponent<floorScript>().wallChecked20 = true;
                   // foreach (GameObject b in wallList){
                        //if (b.transform.position != wallTest20.origin){
                            //Instantiate(w,wallTest20.origin,a.transform.rotation);
                            // print("nothing here");
                            // wallList.Add(wallTest20.origin);
                       // }
                    //}
                    
                }
                if (!Physics.Raycast(wallTest21, out t21, rayDist) && !a.gameObject.GetComponent<floorScript>().wallChecked21){
                    wallList.Add(Instantiate(w,wallTest21.origin,a.transform.rotation));
                    a.gameObject.GetComponent<floorScript>().wallChecked21 = true;
                   // foreach (GameObject b in wallList){
                       // if (b.transform.position != wallTest21.origin){
                            //Instantiate(w,wallTest21.origin,a.transform.rotation);
                            // print("nothing here");
                            // wallList.Add(wallTest21.origin);
                       // }
                   // }
                }
                if (!Physics.Raycast(wallTest22, out t22, rayDist) && !a.gameObject.GetComponent<floorScript>().wallChecked22){
                    wallList.Add(Instantiate(w,wallTest22.origin,a.transform.rotation));
                    a.gameObject.GetComponent<floorScript>().wallChecked22 = true;
                    //foreach (GameObject b in wallList){
                        //if (b.transform.position != wallTest22.origin){
                            //Instantiate(w,wallTest22.origin,a.transform.rotation);
                            // print("nothing here");
                            // wallList.Add(wallTest22.origin);
                       // }
                    //}
                }
                
                // foreach(GameObject c in wallList){
                    
                //     Instantiate(c);
                //     wallGenerated = true;
                // }
            }
            //MakeWall();
            //wallGenerated = true;
        }
    }

    public void Restart(){
        SceneManager.LoadScene(0);
        globalFloorCount = 0;
        spawnerCount = 1;
        wallGenerated = false;
    }

    // void MakeWall(){
    //     for(int i = 0; i < wallList.Count; i ++){
    //                 for(int j = 0; j < wallList.Count; j ++){
    //                     if (wallList[i] != wallList[j]){
    //                         print("instantiate");
    //                         //Instantiate(w,wallList[i],gameObject.transform.rotation);
    //                     }
    //                 }
    //             }
    // }
}
