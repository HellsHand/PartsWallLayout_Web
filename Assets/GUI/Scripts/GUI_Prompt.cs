using UnityEngine;
using System.Collections;

public class GUI_Prompt : MonoBehaviour
{

    bool show = false;
    int menuHeight = 195;
    float lastWidth, lastHeight, newPosY = 44.0f, newPosX, leftX = -151.9f;
    string box_l = "Enter Label", box_w = "0", box_h = "0", box_q = "0";
    public Transform item;

    void Start()
    {
  
    }

    void CreateBox(float width, float height, string label)
    {
        newPosX = leftX + (width / 2) + 1;
        newPosY = newPosY - (lastHeight / 2 + height / 2) - 1;
        if (newPosY - height < -50)
        {
            newPosY = 44.0f - (height / 2) - 1;
            newPosX = newPosX + lastWidth + 1;
            leftX = leftX + lastWidth + 1;
            lastWidth = width;
        }
        Transform box = (Transform)Instantiate(item, new Vector3(newPosX, newPosY, 99.0f), Quaternion.Euler(new Vector3(0, 180, 0)));
        TextMesh mesh = box.FindChild("New Text").GetComponent(typeof(TextMesh)) as TextMesh;
        Vector2 colDim = GetColliderSize(width, height);
        box.GetComponent<BoxCollider>().size = new Vector3(colDim.x, colDim.y, 1);
        mesh.text = label;

        box.transform.localScale = new Vector3(width, height, 2.0f);
        lastHeight = height;
        if (width > lastWidth)
        {
            lastWidth = width;
        }
    }

    void OnGUI()
    {
  
        int btnHeight = 25, btnWidth = 100, menuWidth = 200;
        float scrnHeight = Screen.height, scrnWidth = Screen.width;

        if (GUI.Button(new Rect(0, 0, btnWidth, btnHeight), "Prompt Box"))
        {
            show = !show;
        }
        if (show)
        { 
            GUI.BeginGroup(new Rect((scrnWidth - menuWidth) / 2, (scrnHeight - menuHeight) / 2, menuWidth, menuHeight));
            GUI.Box(new Rect(0, 0, menuWidth, menuHeight), "Enter Values");
            GUI.Label(new Rect(15, 25, 50, 25), "Label: ");
            box_l = GUI.TextField(new Rect(70, 25, 100, 20), box_l);
            GUI.Label(new Rect(15, 60, 50, 25), "Width: ");
            box_w = GUI.TextField(new Rect(70, 60, 100, 20), box_w);
            GUI.Label(new Rect(15, 95, 50, 25), "Height: ");
            box_h = GUI.TextField(new Rect(70, 95, 100, 20), box_h);
            GUI.Label(new Rect(15, 130, 50, 25), "Quantity: ");
            box_q = GUI.TextField(new Rect(70, 130, 100, 20), box_q);
            if (GUI.Button(new Rect(70, 165, 100, 20), "Create Box"))
            {
                for (int i = 0; i < int.Parse(box_q); i++)
                {
                    CreateBox(float.Parse(box_w), float.Parse(box_h), box_l);
                }
            }
            GUI.EndGroup();
        }
    }

    Vector2 GetColliderSize(float width, float height)
    {
        Vector2 boxDim = new Vector2(width, height);
        Vector2 dim = new Vector2(1, 1);
        boxDim.x = width + 1;
        dim.x = (boxDim.x - width) / width + 1;

        if (height <= 5)
        {
            boxDim.y = 2.0f;
        }
        else if (height > 5 && height <= 8)
        {
            boxDim.y = 3.0f;
        }
        else if (height > 8 && height <= 11)
        {
            boxDim.y = 4.0f;
        }
        else if (height > 11 && height <= 14)
        {
            boxDim.y = 5.0f;
        }
        else if (height > 14 && height <= 17)
        {
            boxDim.y = 6.0f;
        }
        else if (height > 17 && height <= 20)
        {
            boxDim.y = 7.0f;
        }
        else if (height > 20 && height <= 23)
        {
            boxDim.y = 8.0f;
        }
        else if (height > 23 && height <= 26)
        {
            boxDim.y = 9.0f;
        }
        boxDim.y = boxDim.y * 3;
        dim.y = (boxDim.y - height) / height + 1;

        return dim;
    }
}
