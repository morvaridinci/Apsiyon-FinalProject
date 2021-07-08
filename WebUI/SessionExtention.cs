using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebUI
{
        /// <summary>
        /// Session a istenen tipte veri yazılıp okunması için extension sınıfı
        /// </summary>
        public static class SessionExtension
        {
            /// <summary>
            /// Session a istenen tipte veri eklenmesini sağlar
            /// </summary>
            /// <typeparam name="T">Eklenmek istenen tip</typeparam>
            /// <param name="session">Extension yapılacak nesne</param>
            /// <param name="key">session key değeri</param>
            /// <param name="value">sessiona eklenecek değer</param>
            public static void Set<T>(this ISession session, string key, T value)
            {
                session.SetString(key, JsonSerializer.Serialize(value));
            }

            /// <summary>
            /// Session dan veri okumak için kullanılır
            /// </summary>
            /// <typeparam name="T">Okunmak istenen veri tipi</typeparam>
            /// <param name="session">Extension yapılacak nesne</param>
            /// <param name="key">Okunmak istenen session key</param>
            /// <returns></returns>
            public static T Get<T>(this ISession session, string key)
            {
                var value = session.GetString(key);
                return value == null ? default : JsonSerializer.Deserialize<T>(value);
            }
        }
    }

