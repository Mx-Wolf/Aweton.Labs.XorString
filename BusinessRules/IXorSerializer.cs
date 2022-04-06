using System.Collections;

namespace Aweton.Labs.XorString.BusinessRules;

internal interface IXorSerializer
{
  string Stringify(byte[] buffer);
  byte[] GetBits(string buffer);
}
