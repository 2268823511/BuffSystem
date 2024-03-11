using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class Player_Buff  {

		public int buff_id { get; set; }
		public int buff_type { get; set; }
		public int buff_time { get; set; }
		public string buff_name { get; set; }
		public float buff_harm { get; set; }
		public string buff_info { get; set; }
		public string buff_icon { get; set; }
		public int buff_decrease { get; set; }
		public int buff_increase { get; set; }
		 
		public static string configName = "Player_Buff";
		public static Player_Buff config { get; set; }
		public string version { get; set; }
		public List<Player_Buff> datas { get; set; }

		public static void Init()
		{
			string folderPath = "D:/Unity code And project/Buff/BuffSystem/Assets/Json/";
			string[] filePaths = Directory.GetFiles(folderPath, configName + ".json");
			if (filePaths != null)
			{
				string jsonContent = File.ReadAllText(filePaths[0]);
				config = JsonConvert.DeserializeObject<Player_Buff>(jsonContent);
			 }

		}

		public static Player_Buff Get(int buff_id)
		{
			Init();
			foreach (var item in config.datas)
			{
				if (item.buff_id == buff_id)
				{ 
					return item;
				}
			}
			return null;
		}

}