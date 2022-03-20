using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	[RequireComponent(typeof(Renderer))]

	public class Outline : MonoBehaviour
	{
		public Renderer Renderer { get; private set; }
		public SpriteRenderer SpriteRenderer { get; private set; }
		public SkinnedMeshRenderer SkinnedMeshRenderer { get; private set; }
		public MeshFilter MeshFilter { get; private set; }
		public GameObject PressEbuttonUI;
		public GameObject DialogueBoxUIPopUp;
		bool oneKeyIsPressedDown = false;
		bool PopupActive = false;
		bool CanActivatePopUp = false;
		float timeRemaining = 1;

		public int color;
		public bool eraseRenderer;

		private void Awake()
		{
			Renderer = GetComponent<Renderer>();
			SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
			SpriteRenderer = GetComponent<SpriteRenderer>();
			MeshFilter = GetComponent<MeshFilter>();
			timeRemaining = 1;
		}

		void Update()
		{


			
			if(Input.GetButtonDown("Interact"))
			{
				oneKeyIsPressedDown = true;
			}
			else
			{
				oneKeyIsPressedDown = false;
			}
			

			if((CanActivatePopUp == true) && (oneKeyIsPressedDown == true))
			{
				PressEbuttonUI.SetActive(false);
				DialogueBoxUIPopUp.SetActive(true);
				PopupActive = true;
			}


			if(PopupActive == true) 
			{
				timeRemaining -= Time.deltaTime; 
				if((oneKeyIsPressedDown == true) && (timeRemaining <= 0))
				{
					DialogueBoxUIPopUp.SetActive(false);
					PopupActive = false;
					Destroy(this.gameObject); 
				}
			}



		}

		void OnEnable()
		{
			OutlineEffect.Instance?.AddOutline(this);
		}

		void OnDisable()
		{
			OutlineEffect.Instance?.RemoveOutline(this);
		}

		private bool visible;
		private void OnBecameVisible()
		{
			visible = true;
		}
		private void OnBecameInvisible()
		{
			visible = false;
		}
		public bool IsVisible => visible;

		private Material[] _SharedMaterials;
		public Material[] SharedMaterials
		{
			get
			{
				if (_SharedMaterials == null)
					_SharedMaterials = Renderer.sharedMaterials;

				return _SharedMaterials;
			}
		}

		
		public void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.tag == "Player")  
			{
				PressEbuttonUI.SetActive(true); 
				CanActivatePopUp = true;
			}

		}

		public void OnTriggerExit(Collider other)
		{
			if(other.gameObject.tag == "Player")  
			{
				PressEbuttonUI.SetActive(false);
				CanActivatePopUp = false;
				DialogueBoxUIPopUp.SetActive(false);
			}  
		}




	}

