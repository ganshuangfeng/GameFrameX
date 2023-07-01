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

namespace cfg.test
{
    public sealed partial class TbTestSep
    {
        private readonly Dictionary<int, test.TestSep> _dataMap;
        private readonly List<test.TestSep> _dataList;
        
        public TbTestSep(JSONNode _json)
        {
            var count = _json.Children.Count();
            _dataMap = new Dictionary<int, test.TestSep>(count);
            _dataList = new List<test.TestSep>(count);
            
            foreach(var _row in _json.Children)
            {
                var _v = test.TestSep.DeserializeTestSep(_row);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }
            PostInit();
        }
    
        public Dictionary<int, test.TestSep> DataMap => _dataMap;
        public List<test.TestSep> DataList => _dataList;
    
        public test.TestSep GetOrDefault(int key)
        {
            return _dataMap.TryGetValue(key, out var v) ? v : null;
        }
        
        public test.TestSep Get(int key)
        {
            return _dataMap[key];
        }
        
        public test.TestSep this[int key]
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