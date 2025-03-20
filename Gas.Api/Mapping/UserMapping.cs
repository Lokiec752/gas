using Gas.Api.Dto.User;
using Gas.Api.Entity;

namespace Gas.Api.Mapping;

public static class UserMapping
{
  public static User ToEntity(this CreateUserDto user)
  {
    return new User()
    {
      Name = user.Name
    };
  }

  public static User ToEntity(this UpdateUserDto user, int id)
  {
    return new User()
    {
      Id = id,
      Name = user.Name,
    };
  }

  public static UserDto ToDto(this User user)
  {
    return new UserDto(user.Name);
  }

}
