﻿using MessagePack.Resolvers;
using PolymorphicMessagePack;
using Protocol;
using UnityEngine;

namespace MessagePack
{
    public class PolymorphicRegister
    {
        static bool serializerRegistered = false;

        private static void Init()
        {
            if (!serializerRegistered)
            {
                // StaticCompositeResolver.Instance.Register(MessagePack.Resolvers.GeneratedResolver.Instance
                // );

                var option = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);

                // PolymorphicResolver.AddInnerResolver(GeneratedResolver.Instance);
                PolymorphicTypeMapper.Register<Message>();
                PolymorphicResolver.Instance.Init();
                MessagePackSerializer.DefaultOptions = option;
                serializerRegistered = true;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Load()
        {
            Init();
        }
    }
}