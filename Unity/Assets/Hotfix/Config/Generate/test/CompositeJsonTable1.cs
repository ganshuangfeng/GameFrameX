//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;

namespace cfg.test
{
    public sealed partial class CompositeJsonTable1 :  Bright.Config.BeanBase 
    {
        public CompositeJsonTable1(JSONNode _json) 
        {
            { if(!_json["id"].IsNumber) { throw new SerializationException(); }  Id = _json["id"]; }
            { if(!_json["x"].IsString) { throw new SerializationException(); }  X = _json["x"]; }
            PostInit();
        }
    
        public CompositeJsonTable1(int id, string x ) 
        {
            this.Id = id;
            this.X = x;
            PostInit();
        }
    
        public static CompositeJsonTable1 DeserializeCompositeJsonTable1(JSONNode _json)
        {
            return new test.CompositeJsonTable1(_json);
        }
    
        public int Id { get; private set; }
        public string X { get; private set; }
    
        public const int __ID__ = 1566207894;
        public override int GetTypeId() => __ID__;
    
        public  void Resolve(Dictionary<string, object> _tables)
        {
            PostResolve();
        }
    
        public  void TranslateText(System.Func<string, string, string> translator)
        {
        }
    
        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "X:" + X + ","
            + "}";
        }
        
        partial void PostInit();
        partial void PostResolve();
    }
}