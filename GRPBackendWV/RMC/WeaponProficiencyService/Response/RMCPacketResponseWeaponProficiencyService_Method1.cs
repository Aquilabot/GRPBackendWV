﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPBackendWV
{
    public class RMCPacketResponseWeaponProficiencyService_Method1 : RMCPacketReply
    {
        public class unknown
        {
            public uint unk1;
            public List<uint> unk2 = new List<uint>();
            public void toBuffer(Stream s)
            {
                Helper.WriteU32(s, unk1);
                Helper.WriteU32(s, (uint)unk2.Count);
                foreach (uint u in unk2)
                    Helper.WriteU32(s, u);
            }
        }

        public List<unknown> unk1 = new List<unknown>();

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)unk1.Count);
            foreach (unknown u in unk1)
                u.toBuffer(m);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[RMCPacketResponseWeaponProficiencyService_Method1]";
        }

        public override string PayloadToString()
        {
            return "";
        }
    }
}
