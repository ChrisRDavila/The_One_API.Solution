using Tweetinvi;
using System;

namespace The_One_API.Models
{
  public class Tweet
  {
    public long Id { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}