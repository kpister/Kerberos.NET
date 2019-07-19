﻿using Kerberos.NET.Asn1;
using System;
using System.Security.Cryptography.Asn1;

namespace Kerberos.NET.Entities
{
    public partial class KrbApRep
    {
        public KrbApRep()
        {
            ProtocolVersionNumber = 5;
            MessageType = MessageType.KRB_AP_REP;
        }

        private static readonly Asn1Tag ApplicationTag = new Asn1Tag(TagClass.Application, 15);

        public ReadOnlyMemory<byte> EncodeAsApplication()
        {
            using (var writer = new AsnWriter(AsnEncodingRules.DER))
            {
                writer.PushSequence(ApplicationTag);

                this.Encode(writer);

                writer.PopSequence(ApplicationTag);

                var span = writer.EncodeAsSpan();

                return span.AsMemory();
            }
        }
    }
}