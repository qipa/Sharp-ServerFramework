using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using Ssc.Ssc;
using Ssc.SscTemplate;
using Sss.SssScripts.Lua;

namespace Sss.SssComponent {
    public class LuaPeerComponent : PoolAllocator<LuaPeerComponent>, ILuaComponent,IMemoryable{
        public Table Instance { get; }
        private readonly LuaHelper _luaHelper;

        public LuaPeerComponent(Table instance, LuaHelper luaHelper) {
            Instance = instance ?? throw new ArgumentNullException(nameof(instance));
            _luaHelper = luaHelper ?? throw new ArgumentNullException(nameof(luaHelper));
        }

        public T GetField<T>(string name) {
            return Instance.Get(name).ToObject<T>();
        }

        public T Call<T>(string methodName, params object[] args) {
            var list = new List<object> {Instance};
            list.AddRange(args);
            return _luaHelper.Call(Instance, methodName, list.ToArray()).ToObject<T>();
        }

        public void Assign() {
        }

        public void Recycle() {
        }
    }
}