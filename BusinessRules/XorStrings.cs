using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Aweton.Labs.XorString.BusinessRules;

internal class XorStrings : IXorStrings
{
  private readonly string m_Alphabet;
  private readonly string m_Input;
  private readonly IXorSerializer m_Serializer;
  private readonly IProcessArrays m_Processor;
  private readonly string m_Role;

  public XorStrings(
    IOptions<XorStringAlphabet> settings,
    IOptions<XorStringInput> input,
    IXorSerializer serializer,
    IProcessArrays processor)
  {
    m_Alphabet = settings.Value.Alphabet;
    m_Role = settings.Value.Role;
    m_Input = input.Value.LicenseKey;
    m_Serializer = serializer;
    m_Processor = processor;
  }
  public IMiceRunInfo Run()
  {
    string r1 = m_Serializer.Stringify(m_Processor.Process(m_Serializer.GetBits(m_Alphabet), m_Serializer.GetBits(m_Input)));
    return new MiceRunInfo(
      $"{m_Role}_{GetInt(r1):0000}",
      r1
    );
  }

  private object GetInt(string r1)
  {
    string firstFour = r1.Substring(0,4);
    byte[] three = Convert.FromBase64String(firstFour);
    byte[] four = new byte[]{
      0,
      three[0],
      three[1],
      three[2],
    };
    return BitConverter.ToUInt32(four, 0);
  }
}
