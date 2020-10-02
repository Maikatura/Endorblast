using System;
using System.Collections.Generic;
using System.Text;

namespace MasterServer
{
    class GameLogic
    {

        public static void Update()
        {
            for (int i = 1; i <= GameManager.playerList.Count; i++)
            {
                if (GameManager.playerList.ContainsKey(i))
                {
                    if (GameManager.playerList[i] != null)
                    {
                        if (GameManager.playerList[i].GetComponent<Player>().inGame)
                        {
                            //Console.WriteLine("Update Done");
                            GameManager.playerList[i].GetComponent<Player>().Update2();
                        }
                    }
                }
            }

        }

    }
}
