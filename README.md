# Simple Resource & Popup System
## Simple and clean system for managing resources with UI feedback.

### How to use:
1. Create ScriptableObject assets ```ResourceEvents.asset``` and ```PopupSettings.asset```.
2. Create **Popup Prefab**, drag and set ```ResourcePopup.cs``` *(ensure it has a TextMeshProUGUI component)* on **Popup Prefab** and put it in ```PopupSettings.asset```.
3. Set created ```PopupSettings.asset``` as you like. Just ensure you added **ResourceColorData**.
4. Put ```ResourceManager.cs``` on GameObject, drag there your ```ResourceEvents.asset``` asset and set **Starting Resources**.
5. Put ```UIController.cs``` on Canvas, drag there your assets and set **UI Elements**.
6. Put ```ResourceButton.cs``` or ```SimpleResourceRegenerator.cs``` *(for resource auto-regen)* on Button. 

#### Important: 
1. You need **TextMeshPro** to make everything work.
2. If you imported this asset and **EventSystem** is not working, delete asset's and create a new one that works with your version.

---

### About architecture & Why this architecture?
1. Event-Based: UI and Logic are separated via ScriptableObjects.
2. Safe Data: All changes are only through **ChangeResource** method inside ```ResourceManager.cs```.
3. Data-Driven Popups: All visuals are tweaked in the Inspector, not in code.
4. Scalable: Easy to add new resource type, just by adding a new one in Enum.
5. I really love clean code.
