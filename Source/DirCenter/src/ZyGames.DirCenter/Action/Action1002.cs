﻿/****************************************************************************
Copyright (c) 2013-2015 scutgame.com

http://www.scutgame.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/
using ZyGames.DirCenter.CacheData;
using ZyGames.DirCenter.Model;
using ZyGames.Framework.Game.Service;

namespace ZyGames.DirCenter.Action
{
    public class Action1002 : BaseStruct
    {
        private int _gameId = 0;
        private int _serverid = 0;
        private int _status = 0;
        private ServerInfo[] serverList;

        public Action1002(HttpGet httpGet)
            : base(ActionIDDefine.Cst_Action1002, httpGet)
        {
        }

        public override bool TakeAction()
        {
            CacheServer cacheServer = new CacheServer();
            cacheServer.ServerStatus(_gameId, _serverid, _status);
            return true;

        }

        public override void BuildPacket()
        {
        }

        public override bool GetUrlElement()
        {
            if (httpGet.GetInt("GameID", ref _gameId) &&
                httpGet.GetInt("ServerID", ref _serverid) && 
                httpGet.GetInt("Status", ref _status))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}