using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public int a;
#if TEST_DEF
	public bool aa;
#endif
	public int b;
#if TEST_DEF
	public byte bb = 100;
#endif
	public int c;
}
