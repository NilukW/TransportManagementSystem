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
        private readonly IInspectorRepository _inspectorRepository;
        private readonly IUserRepository _userRepository;

        public UserProducer(IDriverRepository driverRepository, ITransportManagerRepository transportManagerRepository, IPassengerRepository passengerRepository,
            IInspectorRepository inspectorRepository,IUserRepository userRepository) {
            _driverRepository = driverRepository;
            _passengerRepository = passengerRepository;
            _transportManagerRepository = transportManagerRepository;
            _inspectorRepository = inspectorRepository;
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
                    userService = new InspectorService(_userRepository, _inspectorRepository);
                    break;
                case UserTypes.TransportManager:
                    userService = new TransportManagerService(_userRepository, _transportManagerRepository);
                    break;
            }

            return userService;
        }
    }
}
