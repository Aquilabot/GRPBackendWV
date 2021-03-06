﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPBackendWV
{
    public class RMCPacketResponsePlayerProfileService_MethodF : RMCPacketReply
    {
        public List<GR5_FaceSkinTone> list = new List<GR5_FaceSkinTone>();

        public RMCPacketResponsePlayerProfileService_MethodF()
        {
            list.Add(new GR5_FaceSkinTone());
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)list.Count);
            foreach (GR5_FaceSkinTone fst in list)
                fst.toBuffer(m);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[RMCPacketResponsePlayerProfileService_MethodF]";
        }

        public override string PayloadToString()
        {
            return "";
        }
    }

}
