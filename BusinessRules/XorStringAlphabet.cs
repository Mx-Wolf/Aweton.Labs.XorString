namespace Aweton.Labs.XorString.BusinessRules;

internal class XorStringAlphabet
{
  public string Alphabet { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*(),.;:\\/";
  public int OutputLength { get; set; } = 27;
  public string Role { get; set; } = null!;
}
