using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScript : MonoBehaviour
{
 [SerializeField]
    private Color colorField = Color.red;

    [SerializeField]
    private GameObject targetObject;
    
    private static int staticVariable = 100;
    
    private void Start()
    {
        AnotherMethod();
        CustomMethodWithParameters(42, "Unity");

        StartCoroutine(CustomCoroutine());
    }

    private void Update()
    {
        CustomUpdateMethod();
    }

    private void AnotherMethod()
    {
    }

    private void CustomUpdateMethod()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    private void CustomMethodWithParameters(int number, string text)
    {
    }

    private void OnDestroy()
    {
        CustomEvent?.Invoke();
    }
    
    private interface IDoNothing
    {
        void InterfaceMethod();
    }
    
    private class DoNothingImplementation : IDoNothing
    {
        public void InterfaceMethod()
        {
        }
    }
    
    private delegate void CustomDelegate();
    
    private event CustomDelegate CustomEvent;

    private void Awake()
    {
        IDoNothing doNothingImplementation = new DoNothingImplementation();
        doNothingImplementation.InterfaceMethod();
        
        CustomDelegate customDelegate = () => CustomMethodWithParameters(42, "Unity");
        CustomEvent += customDelegate;
    }
    
    private System.Collections.IEnumerator CustomCoroutine()
    {
        yield return new WaitForSeconds(2f);
    }
    
    public static void StaticMethod()
    {
    }

    public static int StaticProperty
    {
        get
        {
            return staticVariable;
        }
        set
        {
            staticVariable = value;
        }
    }
    
}
