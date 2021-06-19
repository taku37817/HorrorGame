using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F
{
    public class textActiv : MonoBehaviour
    {
        public GameObject ac;

        public void trueActiv()
        {
            ac.SetActive(true);
        }
        public void falseActive()
        {
            ac.SetActive(false);
        }
    }
}