using System;
using System.Collections.Generic;
using System.Text;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;
using static TransportManagementSystem.Model.Types.Enums;

namespace TransportManagementSystem.Services
{
    public class UserProducer
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ITransportManagerRepository _transportManagerRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IUserRepository _userRepository;


        public UserProducer(IDriverRepository driverRepository, IUserRepository userRepository) {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
        }

        public UserProducer(ITransportManagerRepository transportManagerRepository, IUserRepository userRepository)
        {
            _transportManagerRepository = transportManagerRepository;
            _userRepository = userRepository;
        }

        public UserProducer(IPassengerRepository passengerRepository, IUserRepository userRepository)
        {
            _passengerRepository = passengerRepository;
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
                    userService = new PassengerService(_userRepository, _passengerRepository);
                    break;
                case UserTypes.Inspector:
                    //userService = new InspectorService(_userRepository, _driverRepository);
                    break;
                case UserTypes.TransportManager:
                    userService = new TransportManagerService(_userRepository, _transportManagerRepository);
                    break;
            }

            return userService;
        }
    }
}
