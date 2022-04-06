using System.Text;
using Microsoft.Extensions.Options;

namespace Aweton.Labs.XorString.BusinessRules;
internal class XorSerializer : IXorSerializer
{
  private readonly Encoding m_Encoding;

  public XorSerializer(IOptions<SerializerSettings> settings)
  {
    m_Encoding = Encoding.GetEncoding(settings.Value.Encoding);
  }
  public byte[] GetBits(string buffer)
  {
    return m_Encoding.GetBytes(buffer);
  }

  public string Stringify(byte[] buffer)
  {
    return Convert.ToBase64String(buffer);
  }
}
