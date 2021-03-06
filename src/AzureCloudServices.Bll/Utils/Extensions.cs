﻿using System;
using System.Text;

namespace AzureCloudServices.Bll.Utils
{
    public static class Extensions
    { 
        public static string GetJson<T>(this T entry)
            => Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize(entry));
        public static T GetDeserializedObject<T>(this string entry)
            => Utf8Json.JsonSerializer.Deserialize<T>(entry);

        public static long ToUnixTimeMilliseconds(this DateTime dateTime)
            => new DateTimeOffset(dateTime, TimeSpan.FromSeconds(0)).ToUnixTimeMilliseconds();
    }
}