using System.Collections.Generic;

namespace TripServiceKata.Model
{
    public interface ITripDAO
    {
        List<Trip> FindTripsByUser(Model.User user);
    }
}