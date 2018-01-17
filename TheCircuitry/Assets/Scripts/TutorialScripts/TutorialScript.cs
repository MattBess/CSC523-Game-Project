﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class TutorialScript : MonoBehaviour {
    private string[] tutorialSections = {
        "Welcome to the Circuit Builder tutorial. Click the back arrow above at any time to exit to the menu. Click next to continue.",        //0
        "This is where you will make your own simple circuits! This game section comes up when you click a broken tower to fix it.",           //1
        "Upon successfully submitting a fixed circuit, the broken tower will be fixed and will start attacking nearby enemies again.",         //2
        "This is the function you have to build a circuit for. Whenever you click a broken tower, a new random function will be here.",        //3
        "This is the Submit button. When you think your circuit is good to go, click this button to see if your circuit correctly works.",     //4
        "These are the Logic and Gates Reference buttons. If there is something you're not sure of, click these buttons to get help.",         //5
        "Gates Reference will tell you how each gate works. Logic Reference will tell you how the operations work and offers advanced info.",  //6
        "These are the variable inputs. You can connect wires from these by left clicking the black square next to them to make a point.",     //7
        "You can connect this point to another (valid) black square by left clicking on it. This will make a wire between the two points. ",   //8
        "Note that only the inputs are allowed to have multiple wires coming from them. Every other connection point is limited to one wire.", //9
        "This is the final output. A single wire will connect here. When you submit, your output will be compared to the expected one.",       //10
        "At the bottom of the screen are the gates you can use. Left clicking a gate will make a useable copy of it, which you can place.",    //11
        "Now, the function above is (A + B). The OR gate represents the '+' operation. Click on the OR gate and place it in the red area.",    //12
        "If you want to move the gate, click on the body to pick it up to place it somewhere else. You can also right click to delete it.",    //13
        "Click the variable inputs and connect them to the OR gate inputs. Then, click the OR gate output and connect it to the final output.",//14
        "You can delete wires you don't want. To delete, left click on the black square to select a connection point and then right click it.",//15
        "Once everything is connected properly, click the Submit button. If you did it correctly, the popup message will let you know.",       //16
        "This tutorial is now over. Whenever you're ready, simply press the back button to return to the main menu. Thanks for playing!"       //17
    };
    private int sectionIndex = 0;

    private GameObject tutorialPanel;
    private UnityEngine.UI.Text tutorialText;
    private UnityEngine.UI.Button tutorialButton;
    private Quaternion upsideDownQuaternion = new Quaternion(0, 0, 180, 0);
    private Vector3 initialPos;
	// Use this for initialization
	void Start () {
        tutorialPanel = GameObject.FindGameObjectWithTag("TutorialPanel");
        initialPos = tutorialPanel.transform.position;
        tutorialText = tutorialPanel.GetComponentInChildren<UnityEngine.UI.Text>();
        tutorialButton = tutorialPanel.GetComponentInChildren<UnityEngine.UI.Button>();
        tutorialText.text = tutorialSections[sectionIndex];
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void GoToNextSection()
    {
        tutorialText.text = tutorialSections[++sectionIndex];
        if (sectionIndex == 3)      // Index for FunctionText
        {
            GoUpsideDown();
            MoveNearNewSection();
        }
        else if(sectionIndex == 4)  // Index for Submit Button
        {
            MoveNearNewSection();
        }
        else if(sectionIndex == 5)  // Index for Logic Reference and Gate Reference
        {
            MoveNearNewSection();
        }
        else if(sectionIndex == 7)  // Index for Inputs
        {
            MoveNearNewSection();
            GoRightSideUp();
            tutorialPanel.transform.position = initialPos;
        }

    }

    private void GoUpsideDown()
    {
        tutorialText.transform.rotation = upsideDownQuaternion;
        tutorialButton.transform.rotation = upsideDownQuaternion;
        tutorialPanel.transform.rotation = upsideDownQuaternion;
    }

    private void GoRightSideUp()
    {
        tutorialText.transform.rotation = new Quaternion();
        tutorialButton.transform.rotation = new Quaternion();
        tutorialPanel.transform.rotation = new Quaternion();
    }

    private void MoveNearNewSection()
    {
        if(sectionIndex == 3)       // Index for FunctionText
        {
            GameObject func = GameObject.FindGameObjectWithTag("Function");
            tutorialPanel.transform.position = new Vector3(func.transform.position.x, func.transform.position.y - 160);
        }
        else if(sectionIndex == 4)  // Index for Submit Button
        {
            GameObject submit = GameObject.Find("Canvas/SubmitButton");
            tutorialPanel.transform.position = new Vector3(submit.transform.position.x, submit.transform.position.y - 175);
        }
        else if(sectionIndex == 5)  // Index for Logic Reference and Gate Reference
        {
            GameObject logic = GameObject.Find("Canvas/LogicRefButton");
            GameObject gates = GameObject.Find("Canvas/GatesRefButton");
            float midpoint = (logic.transform.position.x + gates.transform.position.x) / 2;
            tutorialPanel.transform.position = new Vector3(midpoint + 23, logic.transform.position.y - 175);
        }
        else if (sectionIndex == 7)  // Index for Inputs
        {
            
        }
    }
}