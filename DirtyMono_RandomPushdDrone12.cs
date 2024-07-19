using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyMono_RandomPushdDrone12 : MonoBehaviour
{

    public ConnectArrayToServerTunnelingRsaMono m_rsaArrayConnection;

    public float m_frequenceChanged =0.5f;

    public int m_droneIndex = -1;

    public bool m_useRepeat = true;
    public float m_timeBetweenRepeat=1;

    private void Start()
    {
        if (m_useRepeat)
            InvokeRepeating("PushRandomInputToAllAsDrone20Gamepad", m_timeBetweenRepeat, m_timeBetweenRepeat);
    }

    public void PushRandomInputToAllAsDrone20Gamepad()
    {

        for (int i = 0; i< m_rsaArrayConnection.m_tunnels.Count; ++i) {

            int v =
                UnityEngine.Random.Range(0, 99) +
                UnityEngine.Random.Range(0, 99) * 100 +
                UnityEngine.Random.Range(0, 99) * 10000 +
                UnityEngine.Random.Range(0, 99) * 1000000;
            if (m_droneIndex<= 0) {

                v += (-m_droneIndex) * 100000000;
                v *= -1;
            }

            m_rsaArrayConnection.PushIntegerToIndex(i, v);            
            }
    }
}
