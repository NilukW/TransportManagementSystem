using System;
using System.Collections.Generic;
using System.Text;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public class UserProducer
    {
        public IUserService getUser(Roles role)
        {
            IUserService userService = null;
            switch (role)
            {
                case Roles.driver:
                    userService = new DriverService();
                    break;
                case Roles.passenger:
                    userService = new PassengerService();
                    break;
                case Roles.inspector:
                    userService = new InspectorService();
                    break;
            }

            return userService;
        }
    }
}
