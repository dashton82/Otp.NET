﻿using System.Security.Cryptography;

namespace Simonbu11.Otp.Totp
{
    public class HmacSha1TotpGenerator : TotpGenerator
    {
        public HmacSha1TotpGenerator(TotpGeneratorSettings settings) : base(settings)
        {
        }

        protected override byte[] ConvertSecretToHashKey(OtpSharedSecret sharedSecret)
        {
            return sharedSecret.GetKeyOfLength(20);
        }

        protected override byte[] ComputeHash(byte[] k, byte[] msg)
        {
            return new HMACSHA1(k).ComputeHash(msg);
        }
    }
}