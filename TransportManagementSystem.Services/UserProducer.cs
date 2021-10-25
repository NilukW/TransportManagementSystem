using System;
using System.Collections.Generic;
using System.Text;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public IUserService getUser(UserTypes type)
    {
        IUserService userService = null;
        switch (type)
        {
            case UserTypes.Driver:
                userService = new DriverService();
                break;
            case UserTypes.Passenger:
                userService = new PassengerService();
                break;
            case UserTypes.inspector:
                userService = new InspectorService();
                break;
        }

        return userService;
    }
}
