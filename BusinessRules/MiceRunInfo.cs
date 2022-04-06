namespace Aweton.Labs.XorString.BusinessRules;

internal class MiceRunInfo : IMiceRunInfo
{
  public MiceRunInfo(string userId, string token)
  {
    UserId = userId;
    Token = token;
  }
  public string UserId {get;}
  public string Token {get;}
}
