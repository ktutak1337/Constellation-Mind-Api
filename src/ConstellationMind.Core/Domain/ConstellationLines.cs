using System.Collections.Generic;
using System.Linq;
using ConstellationMind.Shared.Exceptions;

namespace ConstellationMind.Core.Domain
{
    public class ConstellationLines
    {
        private ISet<EquatorialCoordinates> _coordinates = new HashSet<EquatorialCoordinates>();

        public IEnumerable<EquatorialCoordinates> Coordinates 
        {
            get { return _coordinates; }
            set { _coordinates = new HashSet<EquatorialCoordinates>(value); } 
        }

        public void AddCoordinates(EquatorialCoordinates coordinates)
        {
            var item = _coordinates.SingleOrDefault(x => x.Ra == coordinates.Ra && x.Dec == coordinates.Dec);

            if(item != null) 
                throw new ConstellationMindException(ErrorCodes.CoordinatesAlreadyExist,
                    $"Coordinates: ({coordinates.Ra},{coordinates.Dec}) already exists.");

            _coordinates.Add(coordinates);
        }

        public void AddCoordinates(IEnumerable<EquatorialCoordinates> collection)
        {
            if(collection == null || !collection.Any()) 
                throw new ConstellationMindException(ErrorCodes.NullOrEmptyCollection,
                    $"Cannot add a null or empty list of coordinates to lines collection.");

            foreach(var item in collection)
            {
                var coordinates = _coordinates.SingleOrDefault(x => x.Ra == item.Ra && x.Dec == item.Dec);

                if(coordinates != null) 
                    throw new ConstellationMindException(ErrorCodes.CoordinatesAlreadyExist,
                        $"Coordinates: ({item.Ra},{item.Dec}) already exists.");

                _coordinates.Add(item);        
            }
        }
    }
}
