using UnityEngine;
using System.Collections;

public static class DropListLibrary {
	static public DropList[] dropItems=new DropList[]
	{
		new DropList(new Drop[]{new Drop(ItemsLibrary.items[0],23,86),new Drop(ItemsLibrary.items[1],1,35)})
	};

}
