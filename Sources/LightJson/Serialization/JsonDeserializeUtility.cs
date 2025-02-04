using System.Collections.Generic;
using System.Numerics;

namespace LightJson;

public static class JsonDeserializeUtility 
{
#region Convert-Deserialize
    public static T Convert<T>(this JsonValue value) 
    where T : IJsonDeserializable, new()
    {
        if (value.IsNull) 
            return default;
        var obj = new T();
        obj.Deserialize(value);
        return obj;
    }
#endregion

#region ToDictionary
    public static Dictionary<string, JsonValue> ToDictionary(this JsonValue value)
    {
        if (value.IsNull) 
            return null;
        var dict = new Dictionary<string, JsonValue>();
        var jsonObject = value.AsJsonObject;
        foreach (var jsObj in jsonObject) 
        {
            dict.Add(jsObj.Key, jsObj.Value);
        }
        return dict;
    }

    public static Dictionary<string, T> ToDictionary<T>(this JsonValue value)
    where T : IJsonDeserializable, new()
    {
        if (value.IsNull) 
            return null;
        var dict = new Dictionary<string, T>();
        var jsonObject = value.AsJsonObject;
        foreach (var jsObj in jsonObject) 
        {
            dict.Add(jsObj.Key, JsonConvert.Deserialize<T>(jsObj.Value));
        }
        return dict;
    }
#endregion

#region ConvertToArray
    public static int[] ConvertToArrayInt(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var intArray = new int[arrayCount];
        for (int i = 0; i < arrayCount; i++) 
        {
            intArray[i] = array[i];
        }
        return intArray;
    }

    public static string[] ConvertToArrayString(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var stringArray = new string[arrayCount];
        for (int i = 0; i < arrayCount; i++) 
        {
            stringArray[i] = array[i];
        }
        return stringArray;
    }

    public static char[] ConvertToArrayChar(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var charArray = new char[arrayCount];
        for (int i = 0; i < arrayCount; i++) 
        {
            charArray[i] = (char)array[i].AsObject;
        }
        return charArray;
    }

    public static bool[] ConvertToArrayBoolean(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var booleanArray = new bool[arrayCount];
        for (int i = 0; i < arrayCount; i++) 
        {
            booleanArray[i] = array[i];
        }
        return booleanArray;
    }

    public static float[] ConvertToArrayFloat(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var floatArray = new float[arrayCount];
        for (int i = 0; i < arrayCount; i++) 
        {
            floatArray[i] = array[i];
        }
        return floatArray;
    }

    public static T[] ConvertToArray<T>(this JsonValue value) 
    where T : IJsonDeserializable, new()
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count; 
        var objectArray = new T[arrayCount];
        for (int i = 0; i < arrayCount; i++) 
        {
            objectArray[i] = JsonConvert.Deserialize<T>(array[i]);
        }
        return objectArray;
    }
#endregion

#region ConvertToArray2D
    public static T[,] ConvertToArray2D<T>(this JsonValue value) 
    where T : IJsonDeserializable, new()
    {
        if (value.IsNull)
            return null;
        var arrayX = value.AsJsonArray;
        var arrayY = arrayX[0].AsJsonArray;
        var objArray2D = new T[arrayX.Count, arrayY.Count];
        for (int i = 0; i < arrayX.Count; i++) 
        {
            for (int j = 0; j < arrayY.Count; j++) 
            {
                objArray2D[i, j] = JsonConvert.Deserialize<T>(arrayX[i].AsJsonArray[j]);
            }
        }
        return objArray2D;
    }

    public static int[,] ConvertToArrayInt2D(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var arrayX = value.AsJsonArray;
        var arrayY = arrayX[0].AsJsonArray;
        var intArray2D = new int[arrayX.Count, arrayY.Count];
        for (int i = 0; i < arrayX.Count; i++) 
        {
            for (int j = 0; j < arrayY.Count; j++) 
            {
                intArray2D[i, j] = arrayX[i].AsJsonArray[j];
            }
        }
        return intArray2D;
    }

    public static string[,] ConvertToArrayString2D(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var arrayX = value.AsJsonArray;
        var arrayY = arrayX[0].AsJsonArray;
        var stringArray2D = new string[arrayX.Count, arrayY.Count];
        for (int i = 0; i < arrayX.Count; i++) 
        {
            for (int j = 0; j < arrayY.Count; j++) 
            {
                stringArray2D[i, j] = arrayX[i].AsJsonArray[j];
            }
        }
        return stringArray2D;
    }

    public static char[,] ConvertToArrayChar2D(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var arrayX = value.AsJsonArray;
        var arrayY = arrayX[0].AsJsonArray;
        var charArray2D = new char[arrayX.Count, arrayY.Count];
        for (int i = 0; i < arrayX.Count; i++) 
        {
            for (int j = 0; j < arrayY.Count; j++) 
            {
                charArray2D[i, j] = (char)arrayX[i].AsJsonArray[j].AsObject;
            }
        }
        return charArray2D;
    }

    public static bool[,] ConvertToArrayBoolean2D(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var arrayX = value.AsJsonArray;
        var arrayY = arrayX[0].AsJsonArray;
        var boolArray2D = new bool[arrayX.Count, arrayY.Count];
        for (int i = 0; i < arrayX.Count; i++) 
        {
            for (int j = 0; j < arrayY.Count; j++) 
            {
                boolArray2D[i, j] = arrayX[i].AsJsonArray[j];
            }
        }
        return boolArray2D;
    }

    public static float[,] ConvertToArrayFloat2D(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var arrayX = value.AsJsonArray;
        var arrayY = arrayX[0].AsJsonArray;
        var floatArray2D = new float[arrayX.Count, arrayY.Count];
        for (int i = 0; i < arrayX.Count; i++) 
        {
            for (int j = 0; j < arrayY.Count; j++) 
            {
                floatArray2D[i, j] = arrayX[i].AsJsonArray[j];
            }
        }
        return floatArray2D;
    }
#endregion

#region List
    public static List<int> ConvertToListInt(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var intList = new List<int>(arrayCount);
        for (int i = 0; i < arrayCount; i++) 
        {
            intList.Add(array[i]);
        }
        return intList;
    }

    public static List<string> ConvertToListString(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var stringList = new List<string>(arrayCount);
        for (int i = 0; i < arrayCount; i++) 
        {
            stringList.Add(array[i]);
        }
        return stringList;
    }

    public static List<bool> ConvertToBooleanList(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var booleanList = new List<bool>(arrayCount);
        for (int i = 0; i < arrayCount; i++) 
        {
            booleanList.Add(array[i]);
        }
        return booleanList;
    }

    public static List<float> ConvertToFloatList(this JsonValue value) 
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count;
        var floatList = new List<float>(arrayCount);
        for (int i = 0; i < arrayCount; i++) 
        {
            floatList.Add(array[i]);
        }
        return floatList;
    }

    public static List<T> ConvertToList<T>(this JsonValue value) 
    where T : IJsonDeserializable, new()
    {
        if (value.IsNull)
            return null;
        var array = value.AsJsonArray;
        var arrayCount = array.Count; 
        var objectArray = new List<T>(arrayCount);
        for (int i = 0; i < arrayCount; i++) 
        {
            objectArray.Add(JsonConvert.Deserialize<T>(array[i]));
        }
        return objectArray;
    }
#endregion
}
