using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Model
{
    public class TripDAO : ITripDAO
    {
        public static List<Trip> FindTripsByUser(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }

        List<Trip> ITripDAO.FindTripsByUser(User user)
        {
            return FindTripsByUser(user);
        }
    }
}
