namespace GPS.Api.Dtos;

public record class UserDtos
{

    public string Username;
    public string Password;
    public List<int> VehicleList=[];
    public UserDtos(string arg1,string arg2){
        Username=arg1;
        Username=arg2;
    }
}
