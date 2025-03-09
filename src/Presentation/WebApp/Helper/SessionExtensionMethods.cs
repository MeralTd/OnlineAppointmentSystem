using Newtonsoft.Json;

namespace WebApp.Helper;

public static class SessionExtensionMethods
{
    public static void SetObject(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T GetObject<T>(this ISession session, string key) where T : class
    {
        string objectString = session.GetString(key);
        if (string.IsNullOrEmpty(objectString))
            return null;
        return JsonConvert.DeserializeObject<T>(objectString);
    }
}

