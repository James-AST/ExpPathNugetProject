using System;
using System.Collections.Specialized;
using System.IO;
using DotNetCasClient.Utils;
using Thrift.Protocol;
using Opc.Ua;
using ServiceStack.Formats;
using ServiceStack.Host;
using WindowsHello;

namespace ExploitablePath
{
    public class Program
    {
        static TProtocol prot;

        static void TestSkip()
        {
            TProtocolUtil.Skip(prot, TType.Stop);
        }

        public Program()
        {
            var decoder = new BinaryDecoder(Stream.Null, ServiceMessageContext.GlobalContext);
            decoder.ReadExtensionObject("field");
            UrlUtil.ConstructValidateUrl("https://mockurl.com", true, false, new NameValueCollection());
            UrlUtilTest();
            HtmTest();
        }

        static void TestReadExtensionObjectFunc()
        {
            var decoder = new BinaryDecoder(Stream.Null, ServiceMessageContext.GlobalContext);
            decoder.ReadExtensionObject("field");
        }

        async void HtmTest()
        {
            var stack = new HtmlFormat();
            await stack.SerializeToStreamAsync(null, null, null);
            await stack.SerializeToStreamAsync(new BasicRequest(), new { }, Stream.Null);
        }


        void UrlUtilTest()
        {
            UrlUtil.ConstructServiceUrl(true);
            UrlUtil.ConstructValidateUrl("https://mockurl.com", true, false, new NameValueCollection());
        }

        public static void Main()
        {
            TestReadExtensionObjectFunc();
        }

        public void WindowsHelloTest()
        {
            var handle = new IntPtr();
            var data = new byte[] {0x32, 0x32};
            var provider = new WinHelloProvider("Hello", handle);
            var encryptedData = provider.Encrypt(data);
            var decryptedData = provider.PromptToDecrypt(encryptedData);
        }
    }
}