﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string scene)
    {

        var spawnPos = new Vector3(Random.Range(-8, 8), 0, Random.Range(-8, 8));
        BoltNetwork.Instantiate(BoltPrefabs.Cube, spawnPos, Quaternion.identity);
    }

}
