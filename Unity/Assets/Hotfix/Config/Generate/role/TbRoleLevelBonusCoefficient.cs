//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using System.Linq;
using SimpleJSON;

namespace cfg.role
{
    public sealed partial class TbRoleLevelBonusCoefficient
    {
        private readonly Dictionary<int, role.LevelBonus> _dataMap;
        private readonly List<role.LevelBonus> _dataList;
        
        public TbRoleLevelBonusCoefficient(JSONNode _json)
        {
            var count = _json.Children.Count();
            _dataMap = new Dictionary<int, role.LevelBonus>(count);
            _dataList = new List<role.LevelBonus>(count);
            
            foreach(var _row in _json.Children)
            {
                var _v = role.LevelBonus.DeserializeLevelBonus(_row);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }
            PostInit();
        }
    
        public Dictionary<int, role.LevelBonus> DataMap => _dataMap;
        public List<role.LevelBonus> DataList => _dataList;
    
        public role.LevelBonus GetOrDefault(int key)
        {
            return _dataMap.TryGetValue(key, out var v) ? v : null;
        }
        
        public role.LevelBonus Get(int key)
        {
            return _dataMap[key];
        }
        
        public role.LevelBonus this[int key]
        {
            get { return _dataMap[key]; }
        }
    
        public void Resolve(Dictionary<string, object> _tables)
        {
            foreach(var v in _dataList)
            {
                v.Resolve(_tables);
            }
            PostResolve();
        }
    
        public void TranslateText(System.Func<string, string, string> translator)
        {
            foreach(var v in _dataList)
            {
                v.TranslateText(translator);
            }
        }
        
        
        partial void PostInit();
        partial void PostResolve();
    }
}