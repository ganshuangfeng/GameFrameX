
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Text.Json;
using Server.Config.Core;


namespace cfg
{
public partial struct vec3
{
    public vec3(JsonElement _buf) 
    {
        X = _buf.GetProperty("x").GetSingle();
        Y = _buf.GetProperty("y").GetSingle();
        Z = _buf.GetProperty("z").GetSingle();
    }

    public static vec3 Deserializevec3(JsonElement _buf)
    {
        return new vec3(_buf);
    }

    public readonly float X;
    public readonly float Y;
    public readonly float Z;
   

    public  void ResolveRef(Tables tables)
    {
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "x:" + X + ","
        + "y:" + Y + ","
        + "z:" + Z + ","
        + "}";
    }
}

}