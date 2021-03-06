﻿using UnityEngine;
using System.Collections;

public class DungeonView : MonoBehaviour {
	
	private GameObject m_rootView;
	public BetterList<GameObject> m_floorList;
	public BetterList<Cell> m_floorCellList;
	
	// Initialize
	void Awake() 
	{
		m_rootView = GameObject.Find("Main/Dungeon");
		m_floorList = new BetterList<GameObject>();
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Initialize(DungeonModel dungeon)
	{
		DungeonModel.FLOOR_TYPE[,] mapData = dungeon.GetMap();
		for(int ii=0;ii<DungeonModel.MAP_H;ii++)
		{
			for(int jj=0;jj<DungeonModel.MAP_W;jj++)
			{
				/*******************************************************
				 * 壁.
				 *******************************************************/ 
				if(mapData[ii,jj] == DungeonModel.FLOOR_TYPE.WALL)
				{
					GameObject cell = CustomObject.createObject("cell"+ii+"_"+jj, "map_wall", m_rootView);
					CustomTransform.setPosition(cell, jj, -ii, 0);
					this.m_floorList.Add(cell);
					this.m_floorCellList.Add (CustomObject.getChild(cell,"sprite").GetComponent<Cell>());
				}
				/******************************************************
				 * 床.
				 *******************************************************/ 
				else if(mapData[ii, jj] != DungeonModel.FLOOR_TYPE.WALL && 
					    mapData[ii, jj] != DungeonModel.FLOOR_TYPE.NONE)
				{
					GameObject cell = CustomObject.createObject("cell"+ii+"_"+jj, "map_floor", m_rootView);
					CustomTransform.setPosition(cell, jj, -ii, 0);
					this.m_floorList.Add(cell);
					this.m_floorCellList.Add (CustomObject.getChild(cell,"sprite").GetComponent<Cell>());
				}
				else if(mapData[ii, jj] == DungeonModel.FLOOR_TYPE.NONE)
				{
					GameObject cell = CustomObject.createObject("cell"+ii+"_"+jj, "map_none", m_rootView);
					CustomTransform.setPosition(cell, jj, -ii, 0);
				}
			}
		}
		
	}
}
