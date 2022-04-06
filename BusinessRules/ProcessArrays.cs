using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace Aweton.Labs.XorString.BusinessRules;

internal class ProcessArrays : IProcessArrays
{
  private readonly int m_OutputLength;
  private readonly SHA256 m_Sha256;

  public ProcessArrays(IOptions<XorStringAlphabet> alphabet)
  {
    m_OutputLength = alphabet.Value.OutputLength;
    m_Sha256 = SHA256.Create();
  }
  public byte[] Process(byte[] alpabet, byte[] input)
  {
    byte[] hash = CreateSha(input);
    List<byte> Reducer (List<byte> a, int index){
      a.Add((byte)
        (
          ModuloGet(index, alpabet)
          ^ModuloGet(index,input)
          ^ModuloGet(index, hash)));
      return a;
    }
    return Enumerable.Range(0, m_OutputLength).Aggregate(new List<byte>(),Reducer).ToArray();
  }

  private byte[] CreateSha(byte[] input)
  {
    return m_Sha256.ComputeHash(input);
  }

  private byte ModuloGet(int index, byte[] buffer){
    return buffer[index%buffer.Length];
  }
}
