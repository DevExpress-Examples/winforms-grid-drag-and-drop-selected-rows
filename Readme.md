<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128624426/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E752)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Data Grid - Drag-and-drop multiple grid rows

This example shows how to use the [Drag And Drop Behavior](https://documentation.devexpress.com/WindowsForms/118656/Common-Features/Behaviors/Drag-And-Drop-Behavior) (available in v17.2+) to allow a user to move selected rows from the `GridControl` to the `ListBoxControl` using drag-and-drop. You should also handle the following drag-drop-related events:

```cs
DragDropBehavior listBoxBehavior = behaviorManager.GetBehavior<DragDropBehavior>(this.listBoxControl);
listBoxBehavior.DragOver += ListBoxBehavior_DragOver;
listBoxBehavior.DragDrop += ListBoxBehavior_DragDrop; 
```

> **Note**
>
> In older versions, use the standard Drag events. Read the following topic for more information: [Drag-and-drop of multiple selected grid rows](https://supportcenter.devexpress.com/ticket/details/a1445/drag-and-drop-of-multiple-selected-grid-rows).


## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Drag-and-Drop Behavior](https://docs.devexpress.com/WindowsForms/118656/common-features/behaviors/drag-and-drop-behavior)
* [Multiple Row and Cell Selection](https://docs.devexpress.com/WindowsForms/711/controls-and-libraries/data-grid/focus-and-selection-handling/multiple-row-and-cell-selection)
