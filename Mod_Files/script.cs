using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Security.Permissions;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.Events;

namespace furrymod {
//if not jimmyl or prussian doge D O N O T M O D I F Y
public class BombCollar : MonoBehaviour
{
	void Awake()
	{
		this.Limb = gameObject.GetComponent < LimbBehaviour > ();
		this.Person = this.Limb.Person;
		StartCoroutine(Dropdown());
		//public PersonBehaviour Person;
		//public float PainLevel;
	}
	IEnumerator Dropdown() {
      while (true) {
        yield
        return new WaitForSeconds(1.0f);
        timer--;
		//ModAPI.Notify("nice");
        //pinger.Brightness = 1;
        //audioSource.PlayOneShot(beepclip, 0.7F);
        //beep
        //pinger.Brightness = 0;
		
        if (timer == 0 && this.Limb.IsConsideredAlive) {
          UnityEngine.Object.Destroy(gameObject.transform.parent.gameObject);
        }
        yield
        return null;
      }
    }
	void Update()
	{
		this.PainLevel = this.Person.PainLevel;
		if ( this.PainLevel > 0.8f || !Limb.IsConsideredAlive || Limb.IsDismembered)
		{
			 ModAPI.Notify("error: Instance.timer is undefined.");
			timer = timerdefault;
		}
	}
	//time in seconds
	[SkipSerialisation]
	public float timerdefault = 200f;//180f;
	public float timer = 200f;//180f;
	[SkipSerialisation]
	public float PainLevel;
	[SkipSerialisation]
	public LimbBehaviour Limb;
	[SkipSerialisation]
	public PersonBehaviour Person;
}
public class EmpExplode : MonoBehaviour 
{
	void OnEMPHit()
	{
		ExplosionCreator.CreateFragmentationExplosion(
            32, 
            transform.position, 
            4, 
            7, 
            true, 
            false, 
            0.5f);
	}
}
public class EffectRemoval : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(Dropdown());
	}
	void checkforcomponents()
	{
		/*List<string> blacklist = new List<string>();blacklist.Add("ImmortalityPoison");blacklist.Add("ImmPoison");
		Component[] components = gameObject.GetComponents(typeof(PoisonSpreadBehaviour));
foreach(Component poison in components) {
    if(blacklist.Contains(poison.GetType().ToString()))
	{
		ModAPI.Notify("hi yes you used a blacklisted syringe on this npc");
		UnityEngine.Object.Destroy(gameObject.transform.parent.gameObject);
	}*/
}
	IEnumerator Dropdown() {
      while (true) {
        yield
        return new WaitForSeconds(1.0f);
        checkforcomponents();
        yield
        return null;
      }
    }
}
public class Mod {
    public static void Main() {
      ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Fox Fursona", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "Some Furry with a fox fursona. Kill at all cost.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			//load the skin texture
			var skin = ModAPI.LoadTexture("skin.png");
			//gets the person component
			var person = Instance.GetComponent<PersonBehaviour>();
			//set textures
            person.SetBodyTextures(skin, null, null, 1);
			//add BombCollar to the head
			////Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			//reserving for the worst of the worst
			//create some object
			var childObject = new GameObject("what");
			//parent it to bodys lowerbody
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                     childObject.transform.position = Instance.transform.position;
					 //offset
                     childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObject.transform.localScale = new Vector3(1f, 1f);
					 //give our created object a sprite renderer
                     var childSprite = childObject.AddComponent < SpriteRenderer > ();
					 //give the spriterenderer a sprite
                     childSprite.sprite = ModAPI.LoadSprite("fuckthem.png");
					 //make it show up on top
                     childSprite.sortingLayerName = "Top";
					 //below is basically the same thing for but for the ears n stuff
					 	var childObjectF = new GameObject("what");
                     childObjectF.transform.SetParent(Instance.transform.Find("Head"));
                     childObjectF.transform.position = Instance.transform.position;
                     childObjectF.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObjectF.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
                     childSpriteF.sprite = ModAPI.LoadSprite("fur.png");
                     childSpriteF.sortingLayerName = "Top";
							  }
						  }
					   );
					   ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Chinese Goop Fursona", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "what. please burn it." + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "im pretty sure this is cum", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			//load the skin texture
			var skin = ModAPI.LoadTexture("chinesegoop.png");
			//gets the person component
			var person = Instance.GetComponent<PersonBehaviour>();
			//set textures
            person.SetBodyTextures(skin, null, null, 1);
			//add BombCollar to the head
			////Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			//reserving for the worst of the worst
			//create some object
			var childObject = new GameObject("what");
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			//parent it to bodys lowerbody
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                     childObject.transform.position = Instance.transform.position;
					 //offset
                     childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObject.transform.localScale = new Vector3(1f, 1f);
					 //give our created object a sprite renderer
                     var childSprite = childObject.AddComponent < SpriteRenderer > ();
					 //give the spriterenderer a sprite
                     childSprite.sprite = ModAPI.LoadSprite("tail_goop.png");
					 //make it show up on top
                     childSprite.sortingLayerName = "Top";
					 //below is basically the same thing for but for the ears n stuff
					 	var childObjectF = new GameObject("what");
                     childObjectF.transform.SetParent(Instance.transform.Find("Head"));
                     childObjectF.transform.position = Instance.transform.position;
                     childObjectF.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObjectF.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
                     childSpriteF.sprite = ModAPI.LoadSprite("chinesegoopwhitefur.png");
                     childSpriteF.sortingLayerName = "Top";
							  }
						  }
					   );
					   ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Wolf Fursuiter (Black and white)", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "MoonLight. jesus christ this one is annoying", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			//load the skin texture
			var skin = ModAPI.LoadTexture("moonlight.png");
			//gets the person component
			var person = Instance.GetComponent<PersonBehaviour>();
			//set textures
            person.SetBodyTextures(skin, null, null, 1);
			//add BombCollar to the head
			//Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			//reserving for the worst of the worst
			//create some object
			var childObject = new GameObject("what");
			//parent it to bodys lowerbody
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                     childObject.transform.position = Instance.transform.position;
					 //offset
                     childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObject.transform.localScale = new Vector3(1f, 1f);
					 //give our created object a sprite renderer
                     var childSprite = childObject.AddComponent < SpriteRenderer > ();
					 //give the spriterenderer a sprite
                     childSprite.sprite = ModAPI.LoadSprite("white_tail.png");
					 //make it show up on top
                     childSprite.sortingLayerName = "Top";
					 //below is basically the same thing for but for the ears n stuff
					 	var childObjectF = new GameObject("what");
                     childObjectF.transform.SetParent(Instance.transform.Find("Head"));
                     childObjectF.transform.position = Instance.transform.position;
                     childObjectF.transform.localPosition = new Vector3(0.056f, 0.044f);
                     childObjectF.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
                     childSpriteF.sprite = ModAPI.LoadSprite("mn_fur.png");
                     childSpriteF.sortingLayerName = "Top";
							  }
						  }
					   );
					   ModAPI.Register(
					   new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Shark Fursona", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "Im gonna be honest,i totally botched this sprite.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			//load the skin texture
			var skin = ModAPI.LoadTexture("shark.png");
			//gets the person component
			var person = Instance.GetComponent<PersonBehaviour>();
			//set textures
            person.SetBodyTextures(skin, null, null, 1);
			//add BombCollar to the head
			//Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			//reserving for the worst of the worst
			//create some object
			//you forgot to make the tail sprite you absolute fucking jackass --from jimmyl to jimmyl
			/*var childObject = new GameObject("Tail"); 
			//parent it to bodys lowerbody
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                     childObject.transform.position = Instance.transform.position;
					 //offset
                     childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObject.transform.localScale = new Vector3(1f, 1f);
					 //give our created object a sprite renderer
                     var childSprite = childObject.AddComponent < SpriteRenderer > ();
					 //give the spriterenderer a sprite
                     childSprite.sprite = ModAPI.LoadSprite("white_tail.png");
					 //make it show up on top
                     childSprite.sortingLayerName = "Top";*/
					 //below is basically the same thing for but for the ears n stuff
					 
					 	var childObjectF = new GameObject("Accesories");
                     childObjectF.transform.SetParent(Instance.transform.Find("Head"));
                     childObjectF.transform.position = Instance.transform.position;
                     childObjectF.transform.localPosition = new Vector3(0f, 0.2f);
                     childObjectF.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
                     childSpriteF.sprite = ModAPI.LoadSprite("shark_fur.png");
                     childSpriteF.sortingLayerName = "Top";
					 
					 var childObjectG = new GameObject("Fin");
                     childObjectG.transform.SetParent(Instance.transform.Find("Body").Find("MiddleBody"));
                     childObjectG.transform.position = Instance.transform.position;
                     childObjectG.transform.localPosition = new Vector3(-0.185f,0f);
                     childObjectG.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteG = childObjectG.AddComponent < SpriteRenderer > ();
                     childSpriteG.sprite = ModAPI.LoadSprite("sharkfin_middle.png");
					 childSpriteG.sortingOrder = Instance.transform.Find("Body").Find("MiddleBody").gameObject.GetComponent < SpriteRenderer > ().sortingOrder+1;
                     //childSpriteG.sortingLayerName = "Top";
							  }
						  }
					   );
					   ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Protodegen", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "Some Furry with a fox fursona. Kill at all cost. EMP bombs could work but well,nah.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("protoview.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			//load the skin texture
			var skin = ModAPI.LoadTexture("skin.png");
			//gets the person component
			var person = Instance.GetComponent<PersonBehaviour>();
			//set textures
            person.SetBodyTextures(skin, null, null, 1);
			//add BombCollar to the head
			////Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EmpExplode));
			//create some object
			var childObject = new GameObject("what");
			//parent it to bodys lowerbody
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                     childObject.transform.position = Instance.transform.position;
					 //offset
                     childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObject.transform.localScale = new Vector3(1f, 1f);
					 //give our created object a sprite renderer
                     var childSprite = childObject.AddComponent < SpriteRenderer > ();
					 //give the spriterenderer a sprite
                     childSprite.sprite = ModAPI.LoadSprite("fuckthem.png");
					 //make it show up on top
                     childSprite.sortingLayerName = "Top";
					 //below is basically the same thing for but for the ears n stuff
					 	var childObjectF = new GameObject("what");
                     childObjectF.transform.SetParent(Instance.transform.Find("Head"));
                     childObjectF.transform.position = Instance.transform.position;
                     childObjectF.transform.localPosition = new Vector3(0.15f, 0.043f);
                     childObjectF.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
                     childSpriteF.sprite = ModAPI.LoadSprite("protohat.png");
                     childSpriteF.sortingLayerName = "Top";
							  }
						  }
					   );
					   ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Reviewer Protodegen", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "Mono. Bomb Collar enabled.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("revview.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			//load the skin texture
			var skin = ModAPI.LoadTexture("reviewerproto.png");
			//gets the person component
			var person = Instance.GetComponent<PersonBehaviour>();
			//set textures
            person.SetBodyTextures(skin, null, null, 1);
			//add BombCollar to the head
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EmpExplode));
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			//create some object
			var childObject = new GameObject("what");
			//parent it to bodys lowerbody
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                     childObject.transform.position = Instance.transform.position;
					 //offset
                     childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObject.transform.localScale = new Vector3(1f, 1f);
					 //give our created object a sprite renderer
                     var childSprite = childObject.AddComponent < SpriteRenderer > ();
					 //give the spriterenderer a sprite
                     childSprite.sprite = ModAPI.LoadSprite("reviewtail.png");
					 //make it show up on top
                     childSprite.sortingLayerName = "Top";
					 //below is basically the same thing for but for the ears n stuff
					 	var childObjectF = new GameObject("what");
                     childObjectF.transform.SetParent(Instance.transform.Find("Head"));
                     childObjectF.transform.position = Instance.transform.position;
                     childObjectF.transform.localPosition = new Vector3(0.13f, 0.057225f); // THIS IS THE OFFSET YOU RETARD DONT FORGET
                     childObjectF.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
                     childSpriteF.sprite = ModAPI.LoadSprite("revieweredegen.png",2f);
                     childSpriteF.sortingLayerName = "Top";
							  }
						  }
					   );
					   ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Dr. K-ringe", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "This man is filled with hardcore cringe", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("labt.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			//load the skin texture
			var skin = ModAPI.LoadTexture("chineselab.png");
			//gets the person component
			var person = Instance.GetComponent<PersonBehaviour>();
			//set textures
            person.SetBodyTextures(skin, null, null, 1);
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			//add BombCollar to the head
			//Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			//create some object
			var childObject = new GameObject("what");
			//parent it to bodys lowerbody
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                     childObject.transform.position = Instance.transform.position;
					 //offset
                     childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObject.transform.localScale = new Vector3(1f, 1f);
					 //give our created object a sprite renderer
                     var childSprite = childObject.AddComponent < SpriteRenderer > ();
					 //give the spriterenderer a sprite
                     childSprite.sprite = ModAPI.LoadSprite("white_tail.png");
					 //make it show up on top
                     childSprite.sortingLayerName = "Top";
					 //below is basically the same thing for but for the ears n stuff
					 	var childObjectF = new GameObject("what");
                     childObjectF.transform.SetParent(Instance.transform.Find("Head"));
                     childObjectF.transform.position = Instance.transform.position;
                     childObjectF.transform.localPosition = new Vector3(0.0282f, 0.043f);
                     childObjectF.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
                     childSpriteF.sprite = ModAPI.LoadSprite("labmask.png");
                     childSpriteF.sortingLayerName = "Top";
							  }
						  }
					   );
					    ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Italian Furry????", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "This guy actually might be a spy. Anyways, I'm an italian and this is accurate. Please don't kill this man ok? He might be a spy.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			var skin = ModAPI.LoadTexture("italian.png");
			var person = Instance.GetComponent<PersonBehaviour>();
			//ModAPI.Notify(person.AverageHealth.ToString());
            person.SetBodyTextures(skin, null, null, 1);
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			//Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			var childObject = new GameObject("what");
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                     childObject.transform.position = Instance.transform.position;
                     childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObject.transform.localScale = new Vector3(1f, 1f);
                     var childSprite = childObject.AddComponent < SpriteRenderer > ();
                     childSprite.sprite = ModAPI.LoadSprite("fuckthem.png");
                     childSprite.sortingLayerName = "Top";
					 
					 	var childObjectF = new GameObject("what");
                     childObjectF.transform.SetParent(Instance.transform.Find("Head"));
                     childObjectF.transform.position = Instance.transform.position;
                     childObjectF.transform.localPosition = new Vector3(0.085f, 0.04f);
                     childObjectF.transform.localScale = new Vector3(1f, 1f);
                     var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
                     childSpriteF.sprite = ModAPI.LoadSprite("italian_stuff.png");
                     childSpriteF.sortingLayerName = "Top";
							  }
						  }
					   );
					   
					   
					   
	ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Wolf Fursuiter (Black)", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "Furry who really is attatched to his character.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view_black.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			var skin = ModAPI.LoadTexture("black_fur.png");
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			var person = Instance.GetComponent<PersonBehaviour>();
			//ModAPI.Notify(person.AverageHealth.ToString());
            person.SetBodyTextures(skin, null, null, 1);
			//Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			var childObject = new GameObject("what");
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
            childObject.transform.position = Instance.transform.position;
            childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            
			var childSprite = childObject.AddComponent < SpriteRenderer > ();
            childSprite.sprite = ModAPI.LoadSprite("black_tail.png");
            childSprite.sortingLayerName = "Top";
					 
			var childObjectF = new GameObject("what_3");
            childObjectF.transform.SetParent(Instance.transform.Find("Head"));
            childObjectF.transform.position = Instance.transform.position;
            childObjectF.transform.localPosition = new Vector3(0.085f, 0.04f);
            childObjectF.transform.localScale = new Vector3(1f, 1f);
                     
			var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
            childSpriteF.sprite = ModAPI.LoadSprite("black_hats.png");
            childSpriteF.sortingLayerName = "Top";
        }
      }
	 );
	 
	 ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Arctic Fox", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "Would be useful in russia. At least.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view_black.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			var skin = ModAPI.LoadTexture("arctic_fox.png");
			var person = Instance.GetComponent<PersonBehaviour>();
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			//Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			//ModAPI.Notify(person.AverageHealth.ToString());
            person.SetBodyTextures(skin, null, null, 1);
			var childObject = new GameObject("what");
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
            childObject.transform.position = Instance.transform.position;
            childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            
			var childSprite = childObject.AddComponent < SpriteRenderer > ();
            childSprite.sprite = ModAPI.LoadSprite("white_tail.png");
            childSprite.sortingLayerName = "Top";
					 
			var childObjectF = new GameObject("what_3");
            childObjectF.transform.SetParent(Instance.transform.Find("Head"));
            childObjectF.transform.position = Instance.transform.position;
            childObjectF.transform.localPosition = new Vector3(0.085f, 0.04f);
            childObjectF.transform.localScale = new Vector3(1f, 1f);
                     
			var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
            childSpriteF.sprite = ModAPI.LoadSprite("white_fur.png");
            childSpriteF.sortingLayerName = "Top";
        }
      }
	 );
	 
	 ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Wolf Fursuiter (White + Lime)", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "Furry who really is attatched to his character.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			var skin = ModAPI.LoadTexture("White_Furry.png");
			var person = Instance.GetComponent<PersonBehaviour>();
			//Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			//ModAPI.Notify(person.AverageHealth.ToString());
            person.SetBodyTextures(skin, null, null, 1);
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			var childObject = new GameObject("what");
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
            childObject.transform.position = Instance.transform.position;
            childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            
			var childSprite = childObject.AddComponent < SpriteRenderer > ();
            childSprite.sprite = ModAPI.LoadSprite("white_tail.png");
            childSprite.sortingLayerName = "Top";
					 
			var childObjectF = new GameObject("what_3");
            childObjectF.transform.SetParent(Instance.transform.Find("Head"));
            childObjectF.transform.position = Instance.transform.position;
            childObjectF.transform.localPosition = new Vector3(0.085f, 0.04f);
            childObjectF.transform.localScale = new Vector3(1f, 1f);
                     
			var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
            childSpriteF.sprite = ModAPI.LoadSprite("white_fur.png");
            childSpriteF.sortingLayerName = "Top";
        }
      }
	 );
	  	ModAPI.Register(
      new Modification() {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "Puro (Chinese Furry)", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "Try putting it near Japanese troops during 1937! Or put it near a japenese furry!! I have a feeling this is going to offend a ton of people.", //new item description
        CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("view_black.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) =>{
			var skin = ModAPI.LoadTexture("chinese_fur.png");
			var person = Instance.GetComponent<PersonBehaviour>();
			//Instance.transform.Find("Head").gameObject.AddComponent(typeof (BombCollar));
			//ModAPI.Notify(person.AverageHealth.ToString());
            person.SetBodyTextures(skin, null, null, 1);
			Instance.transform.Find("Head").gameObject.AddComponent(typeof (EffectRemoval));
			var childObject = new GameObject("what");
            childObject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
            childObject.transform.position = Instance.transform.position;
            childObject.transform.localPosition = new Vector3(0.085f, 0.04f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            
			var childSprite = childObject.AddComponent < SpriteRenderer > ();
            childSprite.sprite = ModAPI.LoadSprite("black_tail.png");
            childSprite.sortingLayerName = "Top";
					 
			var childObjectF = new GameObject("what_3");
            childObjectF.transform.SetParent(Instance.transform.Find("Head"));
            childObjectF.transform.position = Instance.transform.position;
            childObjectF.transform.localPosition = new Vector3(0.085f, 0.04f);
            childObjectF.transform.localScale = new Vector3(1f, 1f);
                     
			var childSpriteF = childObjectF.AddComponent < SpriteRenderer > ();
            childSpriteF.sprite = ModAPI.LoadSprite("chinese_ears.png");
            childSpriteF.sortingLayerName = "Top";
        }
      }
	 );
		}
  }
}