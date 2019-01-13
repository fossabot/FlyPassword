﻿//FlyPassword
//Copyright(C) yinyue200.com 

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, version 3 of the License.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.If not, see https://github.com/yinyue200/FlyPassword/blob/master/LICENSE.
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CorePasswordKeeper
{
    public class PasswordKeeper
    {
        public IList<Record> Records { get; private set; }
        public void LoadString(string json)
        {
            Records = JsonConvert.DeserializeObject<List<Record>>(json)??new List<Record>();
        }
        public string SaveToJson()
        {
            var json = JsonConvert.SerializeObject(Records);
#if DEBUG
            _ = JsonConvert.DeserializeObject<List<Record>>(json);
#endif
            System.Diagnostics.Debug.WriteLine(json);
            return json;
        }
    }
}
