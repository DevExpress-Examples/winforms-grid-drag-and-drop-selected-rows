<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# Drag-and-drop of multiple selected grid rows


<p>Starting with version 17.2, you can attach <a href="https://documentation.devexpress.com/WindowsForms/118656/Common-Features/Behaviors/Drag-And-Drop-Behavior">Drag And Drop Behavior</a> to GridControl and <strong>ListBoxControl</strong> to implement the drag-and-drop functionality. Note that it is still necessary to handle events of the corresponding behavior to implement adding items to <strong>ListBoxControl</strong>:</p>


```cs
DragDropBehavior listBoxBehavior = behaviorManager.GetBehavior<DragDropBehavior>(this.listBoxControl);
listBoxBehavior.DragOver += ListBoxBehavior_DragOver;
listBoxBehavior.DragDrop += ListBoxBehavior_DragDrop; 
```




```vb
Dim listBoxBehavior As DragDropBehavior = behaviorManager1.GetBehavior(Of DragDropBehavior)(Me.listBoxControl1)
AddHandler listBoxBehavior.DragOver, AddressOf ListBoxBehavior_DragOver
AddHandler listBoxBehavior.DragDrop, AddressOf ListBoxBehavior_DragDrop
```


<p>In older versions, drag-and-drop should be implemented using the standard Drag events. Please refer to the <a href="https://www.devexpress.com/Support/Center/p/A1445">Drag-and-drop of multiple selected grid rows</a> Knowledge Base article for an explanation.<strong> </strong></p>

<br/>


