using System;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

namespace JWT.jws
{
    public class HmacSha384
    {
        private readonly HMac _hmac;

        public HmacSha384(byte[] key)
        {
            var sharedKey = Ensure.Type<byte[]>(key, "HmacSha384 alg expectes key to be byte[] array.");

            _hmac = new HMac(new Sha384Digest());
            _hmac.Init(new KeyParameter(sharedKey));
        }

        public byte[] ComputeHash(byte[] value)
        {
            if (value == null) throw new ArgumentNullException("value");

            byte[] resBuf = new byte[_hmac.GetMacSize()];
            _hmac.BlockUpdate(value, 0, value.Length);
            _hmac.DoFinal(resBuf, 0);

            return resBuf;
        }
    }
}
