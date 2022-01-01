using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaCore.ProtocolBuilder.Profiles
{
    public static class TypeFixer
    {

        public static string FixType(string type)
        {

            string _type = type;

            _type = _type.Replace("ReadVarint", "ReadVarInt");
            _type = _type.Replace("ReadVaruhint", "ReadVarUInt");
            _type = _type.Replace("ReadVarshort", "ReadVarShort");
            _type = _type.Replace("ReadVaruhshort", "ReadVarUShort");
            _type = _type.Replace("ReadVarlong", "ReadVarLong");
            _type = _type.Replace("ReadVaruhlong", "ReadVarULong");

            _type = _type.Replace("WriteVarint", "WriteVarInt");
            _type = _type.Replace("WriteVaruhint", "WriteVarInt");
            _type = _type.Replace("WriteVarshort", "WriteVarShort");
            _type = _type.Replace("WriteVaruhshort", "WriteVarShort");
            _type = _type.Replace("WriteVarlong", "WriteVarLong");
            _type = _type.Replace("WriteVaruhlong", "WriteVarLong");

            //for some reason floats are turne to doubles in helpet.tt (l286)
            _type = _type.Replace("WriteFloat", "WriteDouble");
            _type = _type.Replace("ReadFloat", "ReadDouble");

            _type = _type.Replace("WriteVarInt(", "WriteVarInt((int)");
            _type = _type.Replace("WriteVarShort(", "WriteVarShort((short)");

            _type = _type.Replace("varint", "int");
            _type = _type.Replace("varuhint", "uint");
            _type = _type.Replace("varshort", "int");
            _type = _type.Replace("varuhshort", "uint");
            _type = _type.Replace("varlong", "double");
            _type = _type.Replace("varuhlong", "double");

            return _type;
        }
    }
}
