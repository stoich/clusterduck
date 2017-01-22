using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
 public class CrateText : MonoBehaviour {
     public float delay = 0f;
     public Text textBox;
     public Animator animator;
 
     // Use this for initialization
     void Start () {
         Destroy (gameObject, animator.GetCurrentAnimatorStateInfo(0).length + delay); 
     }

     public void Setup(Vector3 position, string text) {
     	transform.position = position;
     	textBox.text = text;
     }
 }
