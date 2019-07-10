using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassRoomSpace.Domain.Commands.Inputs.College;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.College;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Infra.Context;
using Dapper;

namespace ClassRoomSpace.Infra.Repositories
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly IDB _db;

        public CollegeRepository(IDB db)
        {
            _db = db;
        }

        public void Create(College college)
        {
            _db.Connection().Execute(
                "spCreateCollege",
                new
                {
                    id = college.Id,
                    firstName = college.Name.FirstName,
                    lastName = college.Name.LastName,
                    document = college.Document.Number,
                    email = college.Email.Address,
                    phone = college.Phone,
                    image = college.Image
                },
                commandType: CommandType.StoredProcedure
            );

            foreach (var address in college.Addresses)
            {
                _db.Connection().Execute(
                    "spCreateAddress",
                    new 
                    {
                        id = address.Id,
                        street = address.Street,
                        number = address.Number,
                        district = address.District,
                        city = address.City,
                        state = address.State,
                        zipCode = address.ZipCode,
                        country = address.Country,
                        idOwner = college.Id
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Delete(DeleteCollegeCommand command)
        {
            _db.Connection().Execute(
                "spDeleteCollege",
                new
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditCollegeCommand command)
        {
            _db.Connection().Execute(
                "spEditCollege",
                new
                {
                    id = command.Id,
                    firstName = command.FirstName,
                    lastName = command.LastName,
                    document = command.Document,
                    email = command.Email,
                    phone = command.Phone,
                    image = command.Image
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetCollegesQuery> Get()
        {
            return _db.Connection().Query<GetCollegesQuery>(
                "spGetColleges",
                null,
                commandType: CommandType.StoredProcedure
            );
        }

        public GetCollegeByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetCollegeByIdQuery>(
                "spGetCollegeById",
                new 
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}