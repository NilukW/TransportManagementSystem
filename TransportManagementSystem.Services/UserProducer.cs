using System;
using System.Collections.Generic;
using System.Text;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public class UserProducer
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;

        public UserProducer(IDriverRepository driverRepository, IUserRepository userRepository) {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
        }

        public IUserService GetUser(UserTypes type)
        {
            IUserService userService = null;
            switch (type)
            {
                case UserTypes.Driver:
                    userService = new DriverService(_userRepository,_driverRepository);
                    break;
                case UserTypes.Passenger:
                    userService = new PassengerService();
                    break;
                case UserTypes.Inspector:
                    userService = new InspectorService();
                    break;
                case UserTypes.TransportManager:
                    //userService = new TransportManager();
                    break;
            }

            return userService;
        }
    }
}
