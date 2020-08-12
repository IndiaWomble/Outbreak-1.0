using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outbreak;

public class EnemyAI : MonoBehaviour
{
    public Transform targetpos_wall;
    public Transform targetpos_player;
    public GameObject enemyobj,ren;
    public Transform targetpos_wall2;
    public GameObject boss_obj;
     GameObject[] rightenemy;
    int x, y, z, x1, y1, z1;
    int[] arr;
    int[] arr2;
    Vector3 spawnpos;
    int[] arr3;
    float spawnenemiesX;
    float spawnenemiesY = 0.6f;
    float temp_pos = 0;
    float spawnenemiesZ = -4;
    float[] space_between_enemies_witheachother1;
    Vector3[] enemy_destination_pos;
    int temp;
    int rand;
    //  float[] space_between_enemies_witheachother;
    /// </summary>

    GameObject[] enemies;
    int totalnumberof_enemies = 6;

    Vector3 targetwall;
    
    GameManager gameManager;

    void Start()
    {  arr3=new int[] { -3,8,-15};
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        GameManager.GameStartEvent += GameManager_GameStartEvent;
    }

    private void GameManager_GameStartEvent()
    {

        rightenemy = new GameObject[3];
        space_between_enemies_witheachother1 = new float[6] { targetpos_wall.position.x - 2, targetpos_wall.position.x + 2, targetpos_wall.position.x - 4, targetpos_wall.position.x + 4, targetpos_wall.position.x - 6, targetpos_wall.position.x + 6 };
        enemy_destination_pos = new Vector3[3];

        InvokeRepeating("nextspawn_crtine", 18, 18);
        // space_between_enemies_witheachother =  6, 6f, 7f, 7f, 8f ;

        targetwall = targetpos_wall.position;
     
        enemies = new GameObject[20];
        StartCoroutine("spawn_enemies");
    }

    private void OnDisable()
    {
        GameManager.GameStartEvent -= GameManager_GameStartEvent;
    }
    void detect_playerpos()
    {

        enemy_destination_pos[0] = new Vector3(targetpos_player.position.x - 3.7f, targetpos_player.position.y, targetpos_player.position.z + 1);
        enemy_destination_pos[1] = new Vector3(targetpos_player.position.x + 3, targetpos_player.position.y, targetpos_player.position.z - 1);
      //  enemy_destination_pos[2] = new Vector3(targetpos_player.position.x - 2, targetpos_player.position.y, targetpos_player.position.z + 2.5f);

    }


    void hardcoded_value()
    {
        int hard = Random.Range(0, 3);

        if (hard == 0)
        {
            x = 1;
            y = 3;
            x1 = 2;
            y1 = 5;
            z = 4;
            z1 = 0;
        }
        if (hard == 1)
        {
            x = 2;
            y = 1;
            x1 = 4;
            y1 = 0;
            z = 3;
            z1 = 5;
        }
        if (hard == 2)
        {
            x = 5;
            y = 2;
            x1 = 3;
            y1 = 1;
            z = 0;
            z1 = 4;
        }

    }
    IEnumerator spawn_enemies()
    {

        hardcoded_value();

        for(int le=0;le<2;le++)
        {


            spawnenemiesX = boss_obj.transform.position.x;

            spawnpos = new Vector3(spawnenemiesX, -15, boss_obj.transform.position.z + 25);
            rightenemy[le] = Instantiate(enemyobj, spawnpos, Quaternion.identity) as GameObject;

            yield return new WaitForSeconds(2f);
        }

        arr = new int[3] { x, y, z };
        arr2 = new int[3] { x1, y1, z1 };


      
        Debug.LogError(arr2);
        rand = Random.Range(0, 4);


        if (rand == 0)
        {
            temp = 0;
        }
        else if (rand == 1)

        {
            temp = 1;
        }
        else if (rand == 2)
        {
            temp = 2;
        }
        else
        {
            temp = 3;
        }


        for (int a = 0; a < totalnumberof_enemies; a++)
        {

            spawnenemiesX = boss_obj.transform.position.x;

            spawnpos = new Vector3(spawnenemiesX, -15, boss_obj.transform.position.z + 25);
            enemies[a] = Instantiate(enemyobj, spawnpos, Quaternion.identity) as GameObject;



            yield return new WaitForSeconds(2f);

        }
    }





    void enemies_move_rigtwall()
    {


        for (int i = 0; i < 2; i++)
        {
           
         
            if (rightenemy[i] != null)
            {

         

                if (Vector2.Distance(rightenemy[i].transform.position,targetpos_wall2.transform.position) > 2f)
                {
                    rightenemy[i].GetComponent<EnemyAnimController>().PlayRun();
                    Vector3 targetdirection = targetpos_wall2.position - rightenemy[i].transform.position;
                    Vector3 newrotation = Vector3.RotateTowards(rightenemy[i].transform.forward, targetdirection, 0.3f, 0);
                    rightenemy[i].transform.rotation = Quaternion.LookRotation(newrotation);
                    rightenemy[i].transform.position = Vector3.MoveTowards(rightenemy[i].transform.position, targetpos_wall2.position- new Vector3(-2, 0, arr3[i]), 0.2f);

                }
                else
                {
                    //Enemies animation for hitting player should be started fom here.

                    rightenemy[i].GetComponent<EnemyAnimController>().PlayAttack();


                }
            }
        }
    }










    void enemies_move_toward_player()
    {

        int tmp = -1;
        for (int i = 0; i < 2; i++)
        {
            int tempp = 0;
            tempp = arr[i];


            if (enemies[tempp] != null)
            {

                tmp++;
               
                if (Vector3.Distance(enemies[tempp].transform.position, targetpos_player.transform.position) > 4f)
                {
                    enemies[tempp].GetComponent<EnemyAnimController>().PlayRun();
                    Debug.Log("illl");
                    Vector3 targetdirection = targetpos_player.position - enemies[tempp].transform.position;
                    Vector3 newrotation = Vector3.RotateTowards(enemies[tempp].transform.forward, targetdirection, 0.3f, 0);
                    enemies[tempp].transform.rotation = Quaternion.LookRotation(newrotation);
                    enemies[tempp].transform.position = Vector3.MoveTowards(enemies[tempp].transform.position, enemy_destination_pos[tmp], 0.2f);

                }
                else
                {
                    //Enemies animation for hitting player should be started fom here.

                    enemies[tempp].GetComponent<EnemyAnimController>().PlayAttack();


                }
            }
        }
    }

    void enemies_move_toward_wall()
    {
        int a = -1;
        int l;
        for (int i = 3; i < totalnumberof_enemies; i++)
        {

       

            int tempp = arr2[i - 3];
            if (enemies[tempp] != null)
            {
                a++;

              //  Debug.Log(targetwall);
                temp_pos = space_between_enemies_witheachother1[temp + a];
                targetwall = new Vector3(targetpos_wall.position.x, -15, targetpos_wall.position.z); 
                if (Vector2.Distance(enemies[tempp].transform.position, targetwall) > 5f)
                {

                    Vector3 targetdirection = targetwall - enemies[tempp].transform.position;
                    Vector3 newrotation = Vector3.RotateTowards(enemies[tempp].transform.forward, targetdirection, 0.3f, 0);
                    enemies[tempp].transform.rotation = Quaternion.LookRotation(newrotation);
                    enemies[tempp].transform.position = Vector3.MoveTowards(enemies[tempp].transform.position, targetwall-new Vector3(-2,0,arr3[i-3]), 0.2f);

                }
                else
                {
                    enemies[tempp].GetComponent<EnemyAnimController>().PlayAttack();

                    Debug.Log("enemies on the wall, destroying wall animation should be run from here ");
                }



            }
        }
    }

    void nextspawn_crtine()
    {

        StartCoroutine("Next_spawn");
    }

    IEnumerator Next_spawn()

    {

        for (int a = 0; a < 6; a++)
        {
            if (enemies[a] == null)
            {
                spawnenemiesX = boss_obj.transform.position.x;

                spawnpos = new Vector3(spawnenemiesX, -15, boss_obj.transform.position.z + 25);
                enemies[a] = Instantiate(enemyobj, spawnpos, Quaternion.identity) as GameObject;
               yield return new WaitForSeconds(2f);
            }
        }



        for (int E = 0; E < 2; E++)
        {
            if (rightenemy[E] == null)
            {
                spawnenemiesX = boss_obj.transform.position.x;

                spawnpos = new Vector3(spawnenemiesX, -15, boss_obj.transform.position.z + 25);
                rightenemy[E] = Instantiate(enemyobj, spawnpos, Quaternion.identity) as GameObject;
                yield return new WaitForSeconds(2f);
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        if (gameManager.CurrentState != GameState.Running)
            return;

        enemies_move_rigtwall();
        enemies_move_toward_player();
        enemies_move_toward_wall();
        detect_playerpos();
    }
}