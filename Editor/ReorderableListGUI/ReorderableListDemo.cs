// Copyright (c) 2012-2013 Rotorz Limited. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using UnityEngine;
using UnityEditor;

using System.Collections.Generic;

public class ReorderableListDemo : EditorWindow {

	[MenuItem("Window/List Demo")]
	static void ShowWindow() {
		GetWindow<ReorderableListDemo>("List Demo");
	}

	private List<string> shoppingList;
	private List<string> pruchaseList;
	
	#region Message
	
	private void OnEnable() {
		shoppingList = new List<string>();
		shoppingList.Add("Bread");
		shoppingList.Add("Carrots");
		shoppingList.Add("Beans");
		shoppingList.Add("Steak");
		shoppingList.Add("Coffee");
		shoppingList.Add("Fries");

		pruchaseList = new List<string>();
		pruchaseList.Add("Cheese");
		pruchaseList.Add("Crackers");
	}

	private Vector2 _scrollPosition;

	private void OnGUI() {
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
		{
			ReorderableListGUI.Title("Shopping List");
			ReorderableListGUI.ListField(shoppingList, PendingItemDrawer, DrawEmpty);

			ReorderableListGUI.Title("Purchased Items");
			ReorderableListGUI.ListField(pruchaseList, PurchasedItemDrawer, DrawEmpty, ReorderableListFlags.HideAddButton | ReorderableListFlags.DisableReordering);
		}
		GUILayout.EndScrollView();
	}
	
	private string PendingItemDrawer(Rect position, string itemValue) {
		// Text fields do not like null values!
		if (itemValue == null)
			itemValue = "";
		
		position.width -= 50;
		itemValue = EditorGUI.TextField(position, itemValue);
		
		position.x = position.xMax + 5;
		position.width = 45;
		if (GUI.Button(position, "Info")) {
		}
		
		return itemValue;
	}

	private string PurchasedItemDrawer(Rect position, string itemValue) {
		position.width -= 50;
		GUI.Label(position, itemValue);

		position.x = position.xMax + 5;
		position.width = 45;
		if (GUI.Button(position, "Info")) {
		}

		return itemValue;
	}

	private void DrawEmpty() {
		GUILayout.Label("No items in list.", EditorStyles.miniLabel);
	}
	
	#endregion
	
}